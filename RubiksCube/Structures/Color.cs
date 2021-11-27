using System;
using System.Collections.Generic;

namespace Structures
{
    public enum Color
    {
        Red = 0,
        Yellow = 1,
        Orange = 2,
        Green = 3,
        Blue = 4,
        White = 5
    }

    public class CharToColor
    {    
        public string this [char key]
        {
            get { return ColorPalette[key]; }
            protected set { }
        }


        private static readonly Dictionary<char, string> ColorPalette
            = new Dictionary<char, string>
        {
            {'R', "\x1b[48;5;" + 160 + $"m " },
            {'Y', "\x1b[48;5;" + 11  + $"m " },
            {'O', "\x1b[48;5;" + 202 + $"m " },
            {'G', "\x1b[48;5;" + 40  + $"m " },
            {'B', "\x1b[48;5;" + 12  + $"m " },
            {'W', "\x1b[48;5;" + 254 + $"m " }

        };

        public bool ContainsKey(char character)
        {
            return ColorPalette.ContainsKey(character);
        }
    }
}