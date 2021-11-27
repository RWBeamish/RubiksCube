using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksCube.View
{
    public class CubeBuilder
    {
        public readonly string Rubikstxt;

        private StringBuilder _builder = new StringBuilder();
        private Dictionary<string, char> _colors;

        private const string _spaces30 = "                          ";
        private const string _spaces5 = "     ";

        private static string[] line1 = new[] { "W1", "W2", "W3" };
        private static string[] line2 = new[] { "W8", "W0", "W4" };
        private static string[] line3 = new[] { "W7", "W6", "W5" };
        private static string[] line4 = new[] { "G1", "G2", "G3", "R1", "R2", "R3", "B1", "B2", "B3", "O1", "O2", "O3" };
        private static string[] line5 = new[] { "G8", "G0", "G4", "R8", "R0", "R4", "B8", "B0", "B4", "O8", "O0", "O4" };
        private static string[] line6 = new[] { "G7", "G6", "G5", "R7", "R6", "R5", "B7", "B6", "B5", "O7", "O6", "O5" };
        private static string[] line7 = new[] { "Y1", "Y2", "Y3" };
        private static string[] line8 = new[] { "Y8", "Y0", "Y4" };
        private static string[] line9 = new[] { "Y7", "Y6", "Y5" };

        private static string[][] _allLines = new[] { line1, line2, line3, line4, line5, line6, line7, line8, line9 };


        public CubeBuilder(Dictionary<string, char> input)
        {
            _colors = input;

            _builder.AppendLine("\n\n\n\n\n");
            WriteAllLines();
            _builder.AppendLine("\n\n\n");

            Rubikstxt = _builder.ToString();
        }

        private void WriteAllLines()
        {
            _allLines.ToList().ForEach(x =>
            {
                var isMiddle = x.Length > 3;

                WriteFullLine(isMiddle, x);
                _builder.AppendLine();
            });
        }

        private void WriteFullLine(bool isMiddle, params string[] ids)
        {
            for(var i = 0; i < 3; i++)
            {
                if (isMiddle)
                    _builder.Append($"{_spaces5}");
                else
                    _builder.Append(_spaces30);

                foreach (var id in ids)
                {
                    for(var j = 0; j < 5; j++)
                    {
                        _builder.Append($"{_colors[id]}");
                    }

                    _builder.Append("  ");
                }

                _builder.AppendLine();
            }
        }
    }
}
