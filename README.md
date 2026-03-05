# BidiSharp

A free C# implementation of the Unicode Bidirectional Algorithm ([UAX #9](https://www.unicode.org/reports/tr9/)).

[![CI](https://github.com/fsufyan/BidiSharp/actions/workflows/ci.yml/badge.svg?branch=unicode-16)](https://github.com/fsufyan/BidiSharp/actions/workflows/ci.yml)

## Background

Responsible for supporting text bidirectionality — ordering and positioning of texts containing mixed right-to-left and left-to-right scripts, such as Latin + Arabic or Hebrew.

Similar to [ICU](http://icu-project.org) and [FriBidi](https://github.com/fribidi/fribidi).

## Conformance

- **Unicode 16.0** — UAX #9 revision 51
- Full BMP and supplementary plane support (U+0000–U+10FFFF)
- Rule N0 (Paired Brackets Algorithm / BD16)
- Rule L4 (Character Mirroring for brackets and paired characters at RTL levels)
- 99.9%+ pass rate on the official `BidiCharacterTest.txt` conformance suite

## Usage

```csharp
using BidiSharp;

// Convert logical order to visual order
string visual = Bidi.LogicalToVisual("Hello אבג world");

// With explicit paragraph direction (0=LTR, 1=RTL, 2=auto)
string rtl = Bidi.LogicalToVisual(text, paragraphDirection: 1);

// Get detailed results (levels, reorder indexes)
var result = Bidi.ResolveAndReorder(text);
byte paragraphLevel = result.ParagraphEmbeddingLevel;
byte[] levels = result.ResolvedLevels;
int[] reorderIndexes = result.ReorderIndexes;
```

## Target Framework

- Library: .NET Standard 2.0 (compatible with .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+)
- Tests: .NET 10.0

## Updating Unicode Data

Character data can be regenerated from the Unicode Character Database using the included tool:

```bash
cd tools/GenerateBidiTypes
dotnet run -- DerivedBidiClass.txt BidiBrackets.txt BidiMirroring.txt ../../BidiSharp/Source
```

Download the UCD files (`DerivedBidiClass.txt`, `BidiBrackets.txt`, `BidiMirroring.txt`) from https://www.unicode.org/Public/16.0.0/ucd/.
