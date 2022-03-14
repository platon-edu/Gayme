using System;
using System.Diagnostics;

namespace Gayme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int x = 10, y = 10;
            Console.SetCursorPosition(x, y);
            char symb = '*';
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.Clear();

                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.CursorVisible = false;
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        case ConsoleKey.LeftArrow:
                            x = Math.Max(0, x - 1);
                            break;
                        case ConsoleKey.RightArrow:
                            x = Math.Min(Console.WindowWidth, x + 1);
                            break;
                        case ConsoleKey.UpArrow:
                            y = Math.Max(0, y - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            y = Math.Min(Console.WindowHeight, y + 1);
                            break;
                        case ConsoleKey.D1:
                            Console.SetCursorPosition(x, y);
                            Console.Write(symb);
                            break;
                    }
                }
            }
        }
    }
}