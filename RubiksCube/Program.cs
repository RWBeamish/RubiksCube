using System;
using View;
using Structures;
using System.Linq;
using System.Collections.Generic;
using RubiksCube.View;

namespace RubiksCube
{
    class Program
    {
        const string _templatePath = @"C:\Projects\RubiksCube\RubiksCube\State\RubiksCube.txt";
        const string _startingPath = @"C:\Projects\RubiksCube\RubiksCube\State\StartingCube.txt";

        const ConsoleKey Right = ConsoleKey.RightArrow;
        const ConsoleKey Left = ConsoleKey.LeftArrow;
        const ConsoleKey R = ConsoleKey.R;
        const ConsoleKey Y = ConsoleKey.Y;
        const ConsoleKey O = ConsoleKey.O;
        const ConsoleKey G = ConsoleKey.G;
        const ConsoleKey B = ConsoleKey.B;
        const ConsoleKey W = ConsoleKey.W;

        static ConsoleKey[] Colors = new ConsoleKey[6] { R, Y, O, G, B, W };

        static void Main(string[] args)
        {
            var rubiksCube = new Structures.RubiksCube();
            UpdateConsole(rubiksCube.Faces);

            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable) { }

                var color = Console.ReadKey(true).Key;
                key = color;
                
                if (!Colors.Contains(color))
                    continue;
                
                var direction = Console.ReadKey(true).Key;
                key = direction;

                if (direction != Right && direction != Left)
                    continue;
                
                var isClockwise = direction == Right;

                PlayWithRubiksCube(rubiksCube, color, isClockwise);
                UpdateConsole(rubiksCube.Faces);

            }
            while (key != ConsoleKey.Escape);            
        }

        public static void PlayWithRubiksCube(Structures.RubiksCube rubiksCube, ConsoleKey color, bool isClockwise)
        {
            switch (color)
            {
                case R:
                    rubiksCube.RotateOnAxis(Color.Red, isClockwise);
                    break;
                case Y:
                    rubiksCube.RotateOnAxis(Color.Yellow, isClockwise);
                    break;
                case O:
                    rubiksCube.RotateOnAxis(Color.Orange, isClockwise);
                    break;
                case G:
                    rubiksCube.RotateOnAxis(Color.Green, isClockwise);
                    break;
                case B:
                    rubiksCube.RotateOnAxis(Color.Blue, isClockwise);
                    break;
                case W:
                    rubiksCube.RotateOnAxis(Color.White, isClockwise);
                    break;
                default:
                    break;
            }
        }

        public static void UpdateConsole(Dictionary<string, char> input)
        {
            var rubiksTxt = new CubeBuilder(input).Rubikstxt;

            Console.Clear();

            Display.ColorizeRubiksTxt(rubiksTxt);
        }
    }
}
