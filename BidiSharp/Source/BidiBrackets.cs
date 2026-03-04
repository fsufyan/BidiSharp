/*
    BidiBrackets data from Unicode 16.0.0
    Generated from BidiBrackets-16.0.0.txt
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
        {
            { 0x0028, new BracketInfo { pairedChar = 0x0029, isOpen = true  } }, // LEFT PARENTHESIS
            { 0x0029, new BracketInfo { pairedChar = 0x0028, isOpen = false } }, // RIGHT PARENTHESIS
            { 0x005B, new BracketInfo { pairedChar = 0x005D, isOpen = true  } }, // LEFT SQUARE BRACKET
            { 0x005D, new BracketInfo { pairedChar = 0x005B, isOpen = false } }, // RIGHT SQUARE BRACKET
            { 0x007B, new BracketInfo { pairedChar = 0x007D, isOpen = true  } }, // LEFT CURLY BRACKET
            { 0x007D, new BracketInfo { pairedChar = 0x007B, isOpen = false } }, // RIGHT CURLY BRACKET
            { 0x0F3A, new BracketInfo { pairedChar = 0x0F3B, isOpen = true  } }, // TIBETAN MARK GUG RTAGS GYON
            { 0x0F3B, new BracketInfo { pairedChar = 0x0F3A, isOpen = false } }, // TIBETAN MARK GUG RTAGS GYAS
            { 0x0F3C, new BracketInfo { pairedChar = 0x0F3D, isOpen = true  } }, // TIBETAN MARK ANG KHANG GYON
            { 0x0F3D, new BracketInfo { pairedChar = 0x0F3C, isOpen = false } }, // TIBETAN MARK ANG KHANG GYAS
            { 0x169B, new BracketInfo { pairedChar = 0x169C, isOpen = true  } }, // OGHAM FEATHER MARK
            { 0x169C, new BracketInfo { pairedChar = 0x169B, isOpen = false } }, // OGHAM REVERSED FEATHER MARK
            { 0x2045, new BracketInfo { pairedChar = 0x2046, isOpen = true  } }, // LEFT SQUARE BRACKET WITH QUILL
            { 0x2046, new BracketInfo { pairedChar = 0x2045, isOpen = false } }, // RIGHT SQUARE BRACKET WITH QUILL
            { 0x207D, new BracketInfo { pairedChar = 0x207E, isOpen = true  } }, // SUPERSCRIPT LEFT PARENTHESIS
            { 0x207E, new BracketInfo { pairedChar = 0x207D, isOpen = false } }, // SUPERSCRIPT RIGHT PARENTHESIS
            { 0x208D, new BracketInfo { pairedChar = 0x208E, isOpen = true  } }, // SUBSCRIPT LEFT PARENTHESIS
            { 0x208E, new BracketInfo { pairedChar = 0x208D, isOpen = false } }, // SUBSCRIPT RIGHT PARENTHESIS
            { 0x2308, new BracketInfo { pairedChar = 0x2309, isOpen = true  } }, // LEFT CEILING
            { 0x2309, new BracketInfo { pairedChar = 0x2308, isOpen = false } }, // RIGHT CEILING
            { 0x230A, new BracketInfo { pairedChar = 0x230B, isOpen = true  } }, // LEFT FLOOR
            { 0x230B, new BracketInfo { pairedChar = 0x230A, isOpen = false } }, // RIGHT FLOOR
            { 0x2329, new BracketInfo { pairedChar = 0x232A, isOpen = true  } }, // LEFT-POINTING ANGLE BRACKET
            { 0x232A, new BracketInfo { pairedChar = 0x2329, isOpen = false } }, // RIGHT-POINTING ANGLE BRACKET
            { 0x2768, new BracketInfo { pairedChar = 0x2769, isOpen = true  } }, // MEDIUM LEFT PARENTHESIS ORNAMENT
            { 0x2769, new BracketInfo { pairedChar = 0x2768, isOpen = false } }, // MEDIUM RIGHT PARENTHESIS ORNAMENT
            { 0x276A, new BracketInfo { pairedChar = 0x276B, isOpen = true  } }, // MEDIUM FLATTENED LEFT PARENTHESIS ORNAMENT
            { 0x276B, new BracketInfo { pairedChar = 0x276A, isOpen = false } }, // MEDIUM FLATTENED RIGHT PARENTHESIS ORNAMENT
            { 0x276C, new BracketInfo { pairedChar = 0x276D, isOpen = true  } }, // MEDIUM LEFT-POINTING ANGLE BRACKET ORNAMENT
            { 0x276D, new BracketInfo { pairedChar = 0x276C, isOpen = false } }, // MEDIUM RIGHT-POINTING ANGLE BRACKET ORNAMENT
            { 0x276E, new BracketInfo { pairedChar = 0x276F, isOpen = true  } }, // HEAVY LEFT-POINTING ANGLE QUOTATION MARK ORNAMENT
            { 0x276F, new BracketInfo { pairedChar = 0x276E, isOpen = false } }, // HEAVY RIGHT-POINTING ANGLE QUOTATION MARK ORNAMENT
            { 0x2770, new BracketInfo { pairedChar = 0x2771, isOpen = true  } }, // HEAVY LEFT-POINTING ANGLE BRACKET ORNAMENT
            { 0x2771, new BracketInfo { pairedChar = 0x2770, isOpen = false } }, // HEAVY RIGHT-POINTING ANGLE BRACKET ORNAMENT
            { 0x2772, new BracketInfo { pairedChar = 0x2773, isOpen = true  } }, // LIGHT LEFT TORTOISE SHELL BRACKET ORNAMENT
            { 0x2773, new BracketInfo { pairedChar = 0x2772, isOpen = false } }, // LIGHT RIGHT TORTOISE SHELL BRACKET ORNAMENT
            { 0x2774, new BracketInfo { pairedChar = 0x2775, isOpen = true  } }, // MEDIUM LEFT CURLY BRACKET ORNAMENT
            { 0x2775, new BracketInfo { pairedChar = 0x2774, isOpen = false } }, // MEDIUM RIGHT CURLY BRACKET ORNAMENT
            { 0x27C5, new BracketInfo { pairedChar = 0x27C6, isOpen = true  } }, // LEFT S-SHAPED BAG DELIMITER
            { 0x27C6, new BracketInfo { pairedChar = 0x27C5, isOpen = false } }, // RIGHT S-SHAPED BAG DELIMITER
            { 0x27E6, new BracketInfo { pairedChar = 0x27E7, isOpen = true  } }, // MATHEMATICAL LEFT WHITE SQUARE BRACKET
            { 0x27E7, new BracketInfo { pairedChar = 0x27E6, isOpen = false } }, // MATHEMATICAL RIGHT WHITE SQUARE BRACKET
            { 0x27E8, new BracketInfo { pairedChar = 0x27E9, isOpen = true  } }, // MATHEMATICAL LEFT ANGLE BRACKET
            { 0x27E9, new BracketInfo { pairedChar = 0x27E8, isOpen = false } }, // MATHEMATICAL RIGHT ANGLE BRACKET
            { 0x27EA, new BracketInfo { pairedChar = 0x27EB, isOpen = true  } }, // MATHEMATICAL LEFT DOUBLE ANGLE BRACKET
            { 0x27EB, new BracketInfo { pairedChar = 0x27EA, isOpen = false } }, // MATHEMATICAL RIGHT DOUBLE ANGLE BRACKET
            { 0x27EC, new BracketInfo { pairedChar = 0x27ED, isOpen = true  } }, // MATHEMATICAL LEFT WHITE TORTOISE SHELL BRACKET
            { 0x27ED, new BracketInfo { pairedChar = 0x27EC, isOpen = false } }, // MATHEMATICAL RIGHT WHITE TORTOISE SHELL BRACKET
            { 0x27EE, new BracketInfo { pairedChar = 0x27EF, isOpen = true  } }, // MATHEMATICAL LEFT FLATTENED PARENTHESIS
            { 0x27EF, new BracketInfo { pairedChar = 0x27EE, isOpen = false } }, // MATHEMATICAL RIGHT FLATTENED PARENTHESIS
            { 0x2983, new BracketInfo { pairedChar = 0x2984, isOpen = true  } }, // LEFT WHITE CURLY BRACKET
            { 0x2984, new BracketInfo { pairedChar = 0x2983, isOpen = false } }, // RIGHT WHITE CURLY BRACKET
            { 0x2985, new BracketInfo { pairedChar = 0x2986, isOpen = true  } }, // LEFT WHITE PARENTHESIS
            { 0x2986, new BracketInfo { pairedChar = 0x2985, isOpen = false } }, // RIGHT WHITE PARENTHESIS
            { 0x2987, new BracketInfo { pairedChar = 0x2988, isOpen = true  } }, // Z NOTATION LEFT IMAGE BRACKET
            { 0x2988, new BracketInfo { pairedChar = 0x2987, isOpen = false } }, // Z NOTATION RIGHT IMAGE BRACKET
            { 0x2989, new BracketInfo { pairedChar = 0x298A, isOpen = true  } }, // Z NOTATION LEFT BINDING BRACKET
            { 0x298A, new BracketInfo { pairedChar = 0x2989, isOpen = false } }, // Z NOTATION RIGHT BINDING BRACKET
            { 0x298B, new BracketInfo { pairedChar = 0x298C, isOpen = true  } }, // LEFT SQUARE BRACKET WITH UNDERBAR
            { 0x298C, new BracketInfo { pairedChar = 0x298B, isOpen = false } }, // RIGHT SQUARE BRACKET WITH UNDERBAR
            { 0x298D, new BracketInfo { pairedChar = 0x2990, isOpen = true  } }, // LEFT SQUARE BRACKET WITH TICK IN TOP CORNER
            { 0x298E, new BracketInfo { pairedChar = 0x298F, isOpen = false } }, // RIGHT SQUARE BRACKET WITH TICK IN BOTTOM CORNER
            { 0x298F, new BracketInfo { pairedChar = 0x298E, isOpen = true  } }, // LEFT SQUARE BRACKET WITH TICK IN BOTTOM CORNER
            { 0x2990, new BracketInfo { pairedChar = 0x298D, isOpen = false } }, // RIGHT SQUARE BRACKET WITH TICK IN TOP CORNER
            { 0x2991, new BracketInfo { pairedChar = 0x2992, isOpen = true  } }, // LEFT ANGLE BRACKET WITH DOT
            { 0x2992, new BracketInfo { pairedChar = 0x2991, isOpen = false } }, // RIGHT ANGLE BRACKET WITH DOT
            { 0x2993, new BracketInfo { pairedChar = 0x2994, isOpen = true  } }, // LEFT ARC LESS-THAN BRACKET
            { 0x2994, new BracketInfo { pairedChar = 0x2993, isOpen = false } }, // RIGHT ARC GREATER-THAN BRACKET
            { 0x2995, new BracketInfo { pairedChar = 0x2996, isOpen = true  } }, // DOUBLE LEFT ARC GREATER-THAN BRACKET
            { 0x2996, new BracketInfo { pairedChar = 0x2995, isOpen = false } }, // DOUBLE RIGHT ARC LESS-THAN BRACKET
            { 0x2997, new BracketInfo { pairedChar = 0x2998, isOpen = true  } }, // LEFT BLACK TORTOISE SHELL BRACKET
            { 0x2998, new BracketInfo { pairedChar = 0x2997, isOpen = false } }, // RIGHT BLACK TORTOISE SHELL BRACKET
            { 0x29D8, new BracketInfo { pairedChar = 0x29D9, isOpen = true  } }, // LEFT WIGGLY FENCE
            { 0x29D9, new BracketInfo { pairedChar = 0x29D8, isOpen = false } }, // RIGHT WIGGLY FENCE
            { 0x29DA, new BracketInfo { pairedChar = 0x29DB, isOpen = true  } }, // LEFT DOUBLE WIGGLY FENCE
            { 0x29DB, new BracketInfo { pairedChar = 0x29DA, isOpen = false } }, // RIGHT DOUBLE WIGGLY FENCE
            { 0x29FC, new BracketInfo { pairedChar = 0x29FD, isOpen = true  } }, // LEFT-POINTING CURVED ANGLE BRACKET
            { 0x29FD, new BracketInfo { pairedChar = 0x29FC, isOpen = false } }, // RIGHT-POINTING CURVED ANGLE BRACKET
            { 0x2E22, new BracketInfo { pairedChar = 0x2E23, isOpen = true  } }, // TOP LEFT HALF BRACKET
            { 0x2E23, new BracketInfo { pairedChar = 0x2E22, isOpen = false } }, // TOP RIGHT HALF BRACKET
            { 0x2E24, new BracketInfo { pairedChar = 0x2E25, isOpen = true  } }, // BOTTOM LEFT HALF BRACKET
            { 0x2E25, new BracketInfo { pairedChar = 0x2E24, isOpen = false } }, // BOTTOM RIGHT HALF BRACKET
            { 0x2E26, new BracketInfo { pairedChar = 0x2E27, isOpen = true  } }, // LEFT SIDEWAYS U BRACKET
            { 0x2E27, new BracketInfo { pairedChar = 0x2E26, isOpen = false } }, // RIGHT SIDEWAYS U BRACKET
            { 0x2E28, new BracketInfo { pairedChar = 0x2E29, isOpen = true  } }, // LEFT DOUBLE PARENTHESIS
            { 0x2E29, new BracketInfo { pairedChar = 0x2E28, isOpen = false } }, // RIGHT DOUBLE PARENTHESIS
            { 0x2E55, new BracketInfo { pairedChar = 0x2E56, isOpen = true  } }, // LEFT SQUARE BRACKET WITH STROKE
            { 0x2E56, new BracketInfo { pairedChar = 0x2E55, isOpen = false } }, // RIGHT SQUARE BRACKET WITH STROKE
            { 0x2E57, new BracketInfo { pairedChar = 0x2E58, isOpen = true  } }, // LEFT SQUARE BRACKET WITH DOUBLE STROKE
            { 0x2E58, new BracketInfo { pairedChar = 0x2E57, isOpen = false } }, // RIGHT SQUARE BRACKET WITH DOUBLE STROKE
            { 0x2E59, new BracketInfo { pairedChar = 0x2E5A, isOpen = true  } }, // TOP HALF LEFT PARENTHESIS
            { 0x2E5A, new BracketInfo { pairedChar = 0x2E59, isOpen = false } }, // TOP HALF RIGHT PARENTHESIS
            { 0x2E5B, new BracketInfo { pairedChar = 0x2E5C, isOpen = true  } }, // BOTTOM HALF LEFT PARENTHESIS
            { 0x2E5C, new BracketInfo { pairedChar = 0x2E5B, isOpen = false } }, // BOTTOM HALF RIGHT PARENTHESIS
            { 0x3008, new BracketInfo { pairedChar = 0x3009, isOpen = true  } }, // LEFT ANGLE BRACKET
            { 0x3009, new BracketInfo { pairedChar = 0x3008, isOpen = false } }, // RIGHT ANGLE BRACKET
            { 0x300A, new BracketInfo { pairedChar = 0x300B, isOpen = true  } }, // LEFT DOUBLE ANGLE BRACKET
            { 0x300B, new BracketInfo { pairedChar = 0x300A, isOpen = false } }, // RIGHT DOUBLE ANGLE BRACKET
            { 0x300C, new BracketInfo { pairedChar = 0x300D, isOpen = true  } }, // LEFT CORNER BRACKET
            { 0x300D, new BracketInfo { pairedChar = 0x300C, isOpen = false } }, // RIGHT CORNER BRACKET
            { 0x300E, new BracketInfo { pairedChar = 0x300F, isOpen = true  } }, // LEFT WHITE CORNER BRACKET
            { 0x300F, new BracketInfo { pairedChar = 0x300E, isOpen = false } }, // RIGHT WHITE CORNER BRACKET
            { 0x3010, new BracketInfo { pairedChar = 0x3011, isOpen = true  } }, // LEFT BLACK LENTICULAR BRACKET
            { 0x3011, new BracketInfo { pairedChar = 0x3010, isOpen = false } }, // RIGHT BLACK LENTICULAR BRACKET
            { 0x3014, new BracketInfo { pairedChar = 0x3015, isOpen = true  } }, // LEFT TORTOISE SHELL BRACKET
            { 0x3015, new BracketInfo { pairedChar = 0x3014, isOpen = false } }, // RIGHT TORTOISE SHELL BRACKET
            { 0x3016, new BracketInfo { pairedChar = 0x3017, isOpen = true  } }, // LEFT WHITE LENTICULAR BRACKET
            { 0x3017, new BracketInfo { pairedChar = 0x3016, isOpen = false } }, // RIGHT WHITE LENTICULAR BRACKET
            { 0x3018, new BracketInfo { pairedChar = 0x3019, isOpen = true  } }, // LEFT WHITE TORTOISE SHELL BRACKET
            { 0x3019, new BracketInfo { pairedChar = 0x3018, isOpen = false } }, // RIGHT WHITE TORTOISE SHELL BRACKET
            { 0x301A, new BracketInfo { pairedChar = 0x301B, isOpen = true  } }, // LEFT WHITE SQUARE BRACKET
            { 0x301B, new BracketInfo { pairedChar = 0x301A, isOpen = false } }, // RIGHT WHITE SQUARE BRACKET
            { 0xFE59, new BracketInfo { pairedChar = 0xFE5A, isOpen = true  } }, // SMALL LEFT PARENTHESIS
            { 0xFE5A, new BracketInfo { pairedChar = 0xFE59, isOpen = false } }, // SMALL RIGHT PARENTHESIS
            { 0xFE5B, new BracketInfo { pairedChar = 0xFE5C, isOpen = true  } }, // SMALL LEFT CURLY BRACKET
            { 0xFE5C, new BracketInfo { pairedChar = 0xFE5B, isOpen = false } }, // SMALL RIGHT CURLY BRACKET
            { 0xFE5D, new BracketInfo { pairedChar = 0xFE5E, isOpen = true  } }, // SMALL LEFT TORTOISE SHELL BRACKET
            { 0xFE5E, new BracketInfo { pairedChar = 0xFE5D, isOpen = false } }, // SMALL RIGHT TORTOISE SHELL BRACKET
            { 0xFF08, new BracketInfo { pairedChar = 0xFF09, isOpen = true  } }, // FULLWIDTH LEFT PARENTHESIS
            { 0xFF09, new BracketInfo { pairedChar = 0xFF08, isOpen = false } }, // FULLWIDTH RIGHT PARENTHESIS
            { 0xFF3B, new BracketInfo { pairedChar = 0xFF3D, isOpen = true  } }, // FULLWIDTH LEFT SQUARE BRACKET
            { 0xFF3D, new BracketInfo { pairedChar = 0xFF3B, isOpen = false } }, // FULLWIDTH RIGHT SQUARE BRACKET
            { 0xFF5B, new BracketInfo { pairedChar = 0xFF5D, isOpen = true  } }, // FULLWIDTH LEFT CURLY BRACKET
            { 0xFF5D, new BracketInfo { pairedChar = 0xFF5B, isOpen = false } }, // FULLWIDTH RIGHT CURLY BRACKET
            { 0xFF5F, new BracketInfo { pairedChar = 0xFF60, isOpen = true  } }, // FULLWIDTH LEFT WHITE PARENTHESIS
            { 0xFF60, new BracketInfo { pairedChar = 0xFF5F, isOpen = false } }, // FULLWIDTH RIGHT WHITE PARENTHESIS
            { 0xFF62, new BracketInfo { pairedChar = 0xFF63, isOpen = true  } }, // HALFWIDTH LEFT CORNER BRACKET
            { 0xFF63, new BracketInfo { pairedChar = 0xFF62, isOpen = false } }, // HALFWIDTH RIGHT CORNER BRACKET
        };

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
}
