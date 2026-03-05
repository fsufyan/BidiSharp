using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Generates BidiSharp source files from Unicode Character Database files.
///
/// Usage: dotnet run -- [DerivedBidiClass.txt] [BidiBrackets.txt] [OutputDir]
///
/// Input files (from Unicode 16.0.0 UCD):
///   - DerivedBidiClass.txt: Bidi class assignments for all codepoints
///   - BidiBrackets.txt: Paired bracket data
///
/// Output files:
///   - Bidi_types.cs: BMP flat array + supplementary plane ranges
///   - BidiBrackets.cs: Bracket pair lookup dictionary
/// </summary>
class Program
{
    // Map bidi class names to BidiClass enum values
    static readonly Dictionary<string, int> BidiClassMap = new Dictionary<string, int>
    {
        {"L",   0}, {"LRE", 1}, {"LRO", 2}, {"R",   3}, {"AL",  4},
        {"RLE", 5}, {"RLO", 6}, {"PDF", 7}, {"EN",  8}, {"ES",  9},
        {"ET", 10}, {"AN", 11}, {"CS", 12}, {"NSM", 13}, {"BN", 14},
        {"B",  15}, {"S",  16}, {"WS", 17}, {"ON", 18},
        {"LRI",19}, {"RLI",20}, {"FSI",21}, {"PDI",22},
    };

    static void Main(string[] args)
    {
        string derivedBidiClassFile = args.Length > 0 ? args[0] : "DerivedBidiClass.txt";
        string bidiBracketsFile    = args.Length > 1 ? args[1] : "BidiBrackets.txt";
        string outputDir           = args.Length > 2 ? args[2] : ".";

        Console.WriteLine($"Reading {derivedBidiClassFile}...");
        var bidiClasses = ParseDerivedBidiClass(derivedBidiClassFile);

        Console.WriteLine($"Generating Bidi_types.cs...");
        GenerateBidiTypes(bidiClasses, Path.Combine(outputDir, "Bidi_types.cs"));

        if (File.Exists(bidiBracketsFile))
        {
            Console.WriteLine($"Reading {bidiBracketsFile}...");
            Console.WriteLine($"Generating BidiBrackets.cs...");
            GenerateBidiBrackets(bidiBracketsFile, Path.Combine(outputDir, "BidiBrackets.cs"));
        }

        Console.WriteLine("Done.");
    }

    static Dictionary<int, byte> ParseDerivedBidiClass(string path)
    {
        var result = new Dictionary<int, byte>();

        foreach (var line in File.ReadLines(path))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue;

            // Format: "0000..001F    ; BN # Cc  [32] ..." or "0020          ; WS # Zs       SPACE"
            int commentIdx = line.IndexOf('#');
            string data = commentIdx >= 0 ? line.Substring(0, commentIdx) : line;
            data = data.Trim();
            if (string.IsNullOrEmpty(data)) continue;

            var parts = data.Split(';');
            if (parts.Length < 2) continue;

            string range = parts[0].Trim();
            string className = parts[1].Trim();

            if (!BidiClassMap.TryGetValue(className, out int classValue))
            {
                Console.Error.WriteLine($"Unknown bidi class: {className}");
                continue;
            }

            if (range.Contains(".."))
            {
                var rangeParts = range.Split(new[] { ".." }, StringSplitOptions.None);
                int start = Convert.ToInt32(rangeParts[0], 16);
                int end = Convert.ToInt32(rangeParts[1], 16);
                for (int cp = start; cp <= end; cp++)
                {
                    result[cp] = (byte)classValue;
                }
            }
            else
            {
                int cp = Convert.ToInt32(range, 16);
                result[cp] = (byte)classValue;
            }
        }

        return result;
    }

    static void GenerateBidiTypes(Dictionary<int, byte> bidiClasses, string outputPath)
    {
        var sb = new StringBuilder();

        sb.AppendLine(@"/*
    BidiSharp: Bidirectional algorithm C# implementation
    Auto-generated from Unicode 16.0.0 DerivedBidiClass.txt
    DO NOT EDIT MANUALLY — regenerate using tools/GenerateBidiTypes
*/

namespace BidiSharp
{
	internal static class Bidi_Types
	{
		internal static byte[] BidiCharTypes = new byte[0x10000]
		{");

        // Generate BMP array (0x0000 - 0xFFFF)
        for (int cp = 0; cp < 0x10000; cp++)
        {
            if (cp % 25 == 0)
            {
                if (cp > 0) sb.AppendLine();
                sb.Append("\t\t\t");
            }

            byte bidiClass = bidiClasses.ContainsKey(cp) ? bidiClasses[cp] : (byte)0; // Default: L
            sb.Append(bidiClass);
            if (cp < 0xFFFF) sb.Append(", ");
        }

        sb.AppendLine();
        sb.AppendLine("\t\t};");
        sb.AppendLine();

        // Generate supplementary plane ranges
        var suppRanges = new List<(int start, int end, byte bidiClass)>();
        int? rangeStart = null;
        byte? rangeClass = null;

        for (int cp = 0x10000; cp <= 0x10FFFF; cp++)
        {
            byte cls = bidiClasses.ContainsKey(cp) ? bidiClasses[cp] : (byte)0;

            if (rangeStart == null)
            {
                if (cls != 0) // Skip default L ranges
                {
                    rangeStart = cp;
                    rangeClass = cls;
                }
            }
            else if (cls != rangeClass)
            {
                suppRanges.Add((rangeStart.Value, cp - 1, rangeClass.Value));
                if (cls != 0)
                {
                    rangeStart = cp;
                    rangeClass = cls;
                }
                else
                {
                    rangeStart = null;
                    rangeClass = null;
                }
            }
        }
        if (rangeStart != null)
        {
            suppRanges.Add((rangeStart.Value, 0x10FFFF, rangeClass.Value));
        }

        // Map bidi class values back to names for comments
        var classNames = BidiClassMap.ToDictionary(kv => kv.Value, kv => kv.Key);

        sb.AppendLine("\t\t// Supplementary plane ranges for codepoints > 0xFFFF");
        sb.AppendLine("\t\t// Auto-generated from Unicode 16.0.0 DerivedBidiClass.txt");
        sb.AppendLine("\t\tinternal static readonly (int start, int end, byte bidiClass)[] SupplementaryRanges = new[]");
        sb.AppendLine("\t\t{");
        foreach (var range in suppRanges)
        {
            string className = classNames.ContainsKey(range.bidiClass) ? classNames[range.bidiClass] : "?";
            sb.AppendLine($"\t\t\t(0x{range.start:X5}, 0x{range.end:X5}, (byte){range.bidiClass}), // {className}");
        }
        sb.AppendLine("\t\t};");
        sb.AppendLine();

        sb.AppendLine(@"		// Get bidi class for any codepoint (BMP or supplementary)
		internal static byte GetBidiClass(int codepoint)
		{
			if (codepoint < 0x10000)
			{
				return BidiCharTypes[codepoint];
			}

			// Search supplementary ranges
			foreach (var range in SupplementaryRanges)
			{
				if (codepoint >= range.start && codepoint <= range.end)
				{
					return range.bidiClass;
				}
			}

			// Default: L (Left-to-Right) for unassigned supplementary codepoints
			return (byte)BidiClass.L;
		}
	}
}");

        File.WriteAllText(outputPath, sb.ToString());
        Console.WriteLine($"  Wrote {outputPath}");
        Console.WriteLine($"  BMP entries: 65536");
        Console.WriteLine($"  Supplementary ranges: {suppRanges.Count}");
    }

    static void GenerateBidiBrackets(string inputPath, string outputPath)
    {
        var sb = new StringBuilder();
        sb.AppendLine(@"/*
    BidiBrackets data — auto-generated from Unicode 16.0.0 BidiBrackets.txt
    DO NOT EDIT MANUALLY — regenerate using tools/GenerateBidiTypes
*/

using System.Collections.Generic;

namespace BidiSharp
{
    internal static class BidiBrackets
    {
        internal struct BracketInfo
        {
            internal int  pairedChar;
            internal bool isOpen;   // true = opening bracket, false = closing bracket
        }

        // Lookup: codepoint -> paired bracket info
        internal static readonly Dictionary<int, BracketInfo> Data = new Dictionary<int, BracketInfo>
        {");

        foreach (var line in File.ReadLines(inputPath))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue;

            int commentIdx = line.IndexOf('#');
            string comment = commentIdx >= 0 ? line.Substring(commentIdx + 1).Trim() : "";
            string data = commentIdx >= 0 ? line.Substring(0, commentIdx) : line;

            var parts = data.Split(';');
            if (parts.Length < 3) continue;

            string cp = parts[0].Trim();
            string paired = parts[1].Trim();
            string type = parts[2].Trim();
            bool isOpen = type == "o";

            sb.AppendLine($"            {{ 0x{cp}, new BracketInfo {{ pairedChar = 0x{paired}, isOpen = {(isOpen ? "true " : "false")} }} }}, // {comment}");
        }

        sb.AppendLine(@"        };

        // Canonical equivalents: U+2329 <=> U+3008, U+232A <=> U+3009
        internal static int GetCanonicalEquivalent(int codepoint)
        {
            switch (codepoint)
            {
                case 0x2329: return 0x3008;
                case 0x232A: return 0x3009;
                case 0x3008: return 0x2329;
                case 0x3009: return 0x232A;
                default: return -1;
            }
        }
    }
}");

        File.WriteAllText(outputPath, sb.ToString());
        Console.WriteLine($"  Wrote {outputPath}");
    }
}
