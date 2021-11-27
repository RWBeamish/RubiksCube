using Structures;
using System.Collections.Generic;

namespace RubiksCube.Structures
{
    public class AxisOfRotation
    {
        public Color Color { get; protected set; }

        public string[] Front     = new string[9];

        public string[] Upper     = new string[3];
        public string[] Lower   = new string[3];
        public string[] Left   = new string[3];
        public string[] Right  = new string[3];

        public AxisOfRotation() { }

        public AxisOfRotation(Color color)
        {
            this.Color = color;
        }

        public List<AxisOfRotation> Create()
        {
            var axes = new List<AxisOfRotation>();

            axes.Add(Red());
            axes.Add(Yellow());
            axes.Add(Orange());
            axes.Add(Green());
            axes.Add(Blue());
            axes.Add(White());


            return axes;
        }

        #region templates

        private AxisOfRotation Red()
        {
            var axis = new AxisOfRotation(Color.Red);
            axis.Front = new string[]
            {
                "R0",
                "R1",
                "R2",
                "R3",
                "R4",
                "R5",
                "R6",
                "R7",
                "R8"
            };
            axis.Upper = new string[] { "W7", "W6", "W5" };
            axis.Lower = new string[] { "Y3", "Y2", "Y1" };
            axis.Right = new string[] { "B1", "B8", "B7" };
            axis.Left  = new string[] { "G5", "G4", "G3" };

            return axis;
        }

        private AxisOfRotation Yellow()
        {
            var axis = new AxisOfRotation(Color.Yellow);
            axis.Front = new string[]
            {
                "Y0",
                "Y1",
                "Y2",
                "Y3",
                "Y4",
                "Y5",
                "Y6",
                "Y7",
                "Y8"
            };
            axis.Upper = new string[] { "R7", "R6", "R5" };
            axis.Lower = new string[] { "O7", "O6", "O5" };
            axis.Right = new string[] { "B7", "B6", "B5" };
            axis.Left = new string[] { "G7", "G6", "G5" };

            return axis;
        }

        private AxisOfRotation Orange()
        {
            var axis = new AxisOfRotation(Color.Orange);
            axis.Front = new string[]
            {
                "O0",
                "O1",
                "O2",
                "O3",
                "O4",
                "O5",
                "O6",
                "O7",
                "O8"
            };
            axis.Upper = new string[] { "W5", "W4", "W3" };
            axis.Lower = new string[] { "Y5", "Y4", "Y3" };
            axis.Right = new string[] { "G1", "G8", "G7" };
            axis.Left  = new string[] { "B5", "B4", "B3" };

            return axis;
        }

        private AxisOfRotation Green()
        {
            var axis = new AxisOfRotation(Color.Green);
            axis.Front = new string[]
            {
                "G0",
                "G1",
                "G2",
                "G3",
                "G4",
                "G5",
                "G6",
                "G7",
                "G8"
            };
            axis.Upper = new string[] { "W1", "W8", "W7" };
            axis.Lower = new string[] { "Y1", "Y8", "Y7" };
            axis.Right = new string[] { "R1", "R8", "R7" };
            axis.Left  = new string[] { "O5", "O4", "O3" };

            return axis;
        }

        private AxisOfRotation Blue()
        {
            var axis = new AxisOfRotation(Color.Blue);
            axis.Front = new string[]
            {
                "B0",
                "B1",
                "B2",
                "B3",
                "B4",
                "B5",
                "B6",
                "B7",
                "B8"
            };
            axis.Upper = new string[] { "W5", "W4", "W3" };
            axis.Lower = new string[] { "Y5", "Y4", "Y3" };
            axis.Right = new string[] { "O1", "O8", "O7" };
            axis.Left  = new string[] { "R5", "R4", "R3" };

            return axis;
        }

        private AxisOfRotation White()
        {
            var axis = new AxisOfRotation(Color.White);
            axis.Front = new string[]
            {
                "W0",
                "W1",
                "W2",
                "W3",
                "W4",
                "W5",
                "W6",
                "W7",
                "W8"
            };
            axis.Upper = new string[] { "O3", "O2", "O1" };
            axis.Lower = new string[] { "R3", "R2", "R1" };
            axis.Right = new string[] { "B3", "B2", "B1" };
            axis.Left  = new string[] { "G3", "G2", "G1" };

            return axis;
        }

        #endregion
    }
}
