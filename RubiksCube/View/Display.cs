using Structures;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace View
{
    public static class Display
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);
        
        
        
        public static void PlayWithColors()
        {
            var handle = GetStdHandle(-11);
            int mode;
            GetConsoleMode(handle, out mode);
            SetConsoleMode(handle, mode | 0x4);
        
            for (int i = 0; i < 255; i++)
            {
                Console.WriteLine("\x1b[48;5;" + i + $"m*{i}    ");
            }
        
            Console.ReadLine();
        }

        public static void DisplayFile(string filePath, int? milliseconds = null)
        {
            var txt = File.ReadAllText(filePath)
                .ToCharArray().ToList();

            txt.ForEach(x =>
            {
                Console.Write(x);
            });

            if (milliseconds != null)
            {
                Thread.Sleep((int)milliseconds);

                Console.Clear();
            }
        }

        public static void DisplayColorizedFile(string filePath)
        {
            var colors = new CharToColor();

            var txt = File.ReadAllText(filePath)
                .ToCharArray();

            foreach(var x in txt)
            {
                if (colors.ContainsKey(x))
                {
                    Console.Write(colors[x]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(x);

                }

                Console.ResetColor();
            }
        }

        public static void ColorizeRubiksTxt(string input)
        {
            var colors = new CharToColor();

            var txt = input.ToCharArray();

            foreach (var x in txt)
            {
                if (colors.ContainsKey(x))
                {
                    Console.Write(colors[x]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(x);
                }

                Console.ResetColor();
            }
        }
    }
}
