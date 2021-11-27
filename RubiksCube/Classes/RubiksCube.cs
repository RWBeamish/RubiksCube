using Structures;
using System.Collections.Generic;
using System.Linq;

namespace RubiksCube.Classes
{
    public class RubiksCube
    {
        ICollection<AxisOfRotation> AxisOfRotation;
    }

    public class AxisOfRotation
    {
        Color Color;

        ICollection<Position> Positions;

        public void RotateClockwise()
        {
            var positions = Positions.ToList();

            var pieces = positions
                .Select(x => x.CurrentPiece)
                .ToList();

            var buffer = new[] { pieces[0], pieces[1] };
            pieces.RemoveRange(0, 2);
            pieces.AddRange(buffer);

            for (var i = 0; i < pieces.Count; i++)
                positions[i].CurrentPiece = pieces[i];
        }

        public void RotateCounterClockwise()
        {

        }
    }

    public class Position
    {
        Piece IntendedPiece;

        public Piece CurrentPiece;

        Coordinates Coordinates;
    }

    public class Piece
    {
        string Name; // (ex. RGB, RB, etc.)

        PieceType PieceType;

        List<Color> Faces;

        Position IntendedPosition;

        Position CurrentPosition;

        Orientation Orientation;
    }

    public struct Coordinates
    {
        int X;
        int Y;
        int Z;

        public Coordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public struct Orientation   //  [ Up, Down, Left, Right, Front, Back ];
    {
        Color?[] ToArray;       //  (ex. [ null, Red, Green, Blue, null, null ]; )

        Direction Direction;
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Clockwise,
        CounterClockwise
    }

    public enum PieceType
    {
        Center,
        Edge,
        Corner
    }
}