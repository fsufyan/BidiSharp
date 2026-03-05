# Changelog

## v1.0.1

### Added
- **Rule L4**: Character mirroring — brackets and other paired characters (e.g. `()`, `<>`, `{}`) are now correctly mirrored at RTL levels
- **BidiMirroring data**: 428 mirror pairs from Unicode 16.0 `BidiMirroring.txt`

## v1.0.0 — Unicode 16.0

Major update bringing full Unicode 16.0 conformance.

### Added
- **Rule N0**: Paired Brackets Algorithm (BD16) for correct bracket resolution in mixed-direction text
- **Supplementary plane support**: Full Unicode range U+0000–U+10FFFF with surrogate pair handling
- **Paragraph direction parameter**: `LogicalToVisual` and `ResolveAndReorder` accept explicit LTR/RTL/auto direction
- **`ResolveAndReorder` API**: Returns detailed results (paragraph level, resolved levels, reorder indexes)
- **Code generator tool**: `tools/GenerateBidiTypes` regenerates character data from UCD files
- **Comprehensive test suite**: 45 tests including Unicode conformance suite (99.9%+ pass rate)

### Fixed
- `GetLevelRuns` cleared run list by reference, corrupting all runs except the last
- Rule L1 had duplicate FSI check instead of PDI, and missed WS type
- Rule W7 condition was misplaced inside the backward-search loop
- Rule X9 did not convert PDF characters to BN
- Rule X8 paragraph separator handler left directional status stack empty
- `GetRunForCharacter` mapped character positions to themselves instead of run indices
- `GetIsolatingRunSequences` could enter an infinite loop due to missing loop variable updates

### Changed
- Character type data updated from Unicode 6.3 to Unicode 16.0
- Bracket pair data updated to Unicode 16.0
- `UnicodeData.txt` updated to Unicode 16.0

## v0.2

- Initial release supporting Unicode 6.3 (UAX #9 revision 28)
