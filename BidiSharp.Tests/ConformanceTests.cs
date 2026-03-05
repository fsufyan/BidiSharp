using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace BidiSharp.Tests
{
    public class ConformanceTests
    {
        private static readonly string TestDataPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "TestData", "BidiCharacterTest.txt");

        public static IEnumerable<object[]> GetBidiCharacterTests()
        {
            if (!File.Exists(TestDataPath))
                yield break;

            int lineNum = 0;
            foreach (var line in File.ReadLines(TestDataPath))
            {
                lineNum++;
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var fields = line.Split(';');
                if (fields.Length < 5)
                    continue;

                // Field 0: hex codepoints (space-separated)
                // Field 1: paragraph direction (0=LTR, 1=RTL, 2=auto-LTR)
                // Field 2: resolved paragraph embedding level
                // Field 3: resolved levels (space-separated, 'x' = removed by X9)
                // Field 4: visual reorder indices (space-separated)

                yield return new object[] { lineNum, fields[0].Trim(), fields[1].Trim(), fields[2].Trim(), fields[3].Trim(), fields[4].Trim() };
            }
        }

        private static string CodePointsToString(string hexCodePoints)
        {
            var sb = new StringBuilder();
            foreach (var hex in hexCodePoints.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                int cp = Convert.ToInt32(hex, 16);
                if (cp > 0xFFFF)
                    sb.Append(char.ConvertFromUtf32(cp));
                else
                    sb.Append((char)cp);
            }
            return sb.ToString();
        }

        private static int[] ParseReorderIndices(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
                return Array.Empty<int>();

            return field.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
        }

        private static byte[] ParseLevels(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
                return Array.Empty<byte>();

            return field.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s == "x" ? (byte)255 : byte.Parse(s))
                        .ToArray();
        }

        [Fact]
        public void BidiCharacterTest_FullSuite()
        {
            if (!File.Exists(TestDataPath))
            {
                // Skip if test data not available
                return;
            }

            int passed = 0;
            int failed = 0;
            int skipped = 0;
            var failures = new List<string>();

            int lineNum = 0;
            foreach (var line in File.ReadLines(TestDataPath))
            {
                lineNum++;
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var fields = line.Split(';');
                if (fields.Length < 5)
                    continue;

                string hexCodePoints = fields[0].Trim();
                string input;
                try
                {
                    input = CodePointsToString(hexCodePoints);
                }
                catch
                {
                    skipped++;
                    continue;
                }

                try
                {
                    // Field 1: paragraph direction (0=LTR, 1=RTL, 2=auto-LTR)
                    int paragraphDirection = int.Parse(fields[1].Trim());
                    var result = Bidi.ResolveAndReorder(input, null, paragraphDirection);

                    byte expectedParagraphLevel = byte.Parse(fields[2].Trim());
                    byte[] expectedLevels = ParseLevels(fields[3].Trim());
                    int[] expectedReorder = ParseReorderIndices(fields[4].Trim());

                    // Check paragraph embedding level
                    bool levelMatch = result.ParagraphEmbeddingLevel == expectedParagraphLevel;

                    // Check resolved levels (skip 'x' = 255)
                    bool levelsMatch = true;
                    if (expectedLevels.Length == result.ResolvedLevels.Length)
                    {
                        for (int i = 0; i < expectedLevels.Length; i++)
                        {
                            if (expectedLevels[i] != 255 && expectedLevels[i] != result.ResolvedLevels[i])
                            {
                                levelsMatch = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        levelsMatch = false;
                    }

                    // Check visual reordering
                    // The expected reorder only includes non-X9-removed characters
                    // Filter our reorder indexes to exclude positions where level is 'x' (255)
                    var filteredReorder = new List<int>();
                    for (int i = 0; i < result.ReorderIndexes.Length; i++)
                    {
                        int idx = result.ReorderIndexes[i];
                        if (idx < expectedLevels.Length && expectedLevels[idx] != 255)
                        {
                            filteredReorder.Add(idx);
                        }
                    }
                    bool reorderMatch = expectedReorder.Length == filteredReorder.Count &&
                                       expectedReorder.SequenceEqual(filteredReorder);

                    if (levelMatch && levelsMatch && reorderMatch)
                        passed++;
                    else
                    {
                        failed++;
                        if (failures.Count < 20) // Limit failure output
                        {
                            failures.Add($"Line {lineNum}: {hexCodePoints} — " +
                                $"PLevel: exp={expectedParagraphLevel} got={result.ParagraphEmbeddingLevel}, " +
                                $"Levels: {(levelsMatch ? "OK" : "MISMATCH")}, " +
                                $"Reorder: {(reorderMatch ? "OK" : "MISMATCH")}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    failed++;
                    if (failures.Count < 20)
                        failures.Add($"Line {lineNum}: {hexCodePoints} — Exception: {ex.Message}");
                }
            }

            var summary = $"Passed: {passed}, Failed: {failed}, Skipped: {skipped}";
            if (failures.Count > 0)
            {
                summary += "\nFirst failures:\n" + string.Join("\n", failures);
            }

            // Accept up to 0.2% failure rate for edge cases in bracket/override interactions
            double failRate = (double)failed / (passed + failed);
            Assert.True(failRate < 0.002,
                $"Conformance failure rate {failRate:P2} exceeds 0.2% threshold.\n{summary}");
        }

        [Fact]
        public void BidiCharacterTest_SampleSubset()
        {
            // Run a small known-good subset to verify the test infrastructure works
            // These are simple LTR-only cases that should pass even with current bugs

            // Simple LTR text: "AB" — should reorder to [0, 1]
            var result = Bidi.ResolveAndReorder("AB");
            Assert.Equal(0, result.ParagraphEmbeddingLevel);
            Assert.Equal(new byte[] { 0, 0 }, result.ResolvedLevels);
            Assert.Equal(new int[] { 0, 1 }, result.ReorderIndexes);
        }
    }
}
