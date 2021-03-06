using System;
using System.Diagnostics;

namespace Gayme
{
    class Program
    {
        private static char[,] field;
        private static Random r = new();
        private static int size = 11;
        private static int myX = size / 2, myY = size / 2;
        private static int score = 0;

        static void Main(string[] args)
        {
            InitField();
            PrintField();
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q) break;
                if (key == ConsoleKey.UpArrow) MoveUp();
                else if (key == ConsoleKey.LeftArrow) MoveLeft();
                else if (key == ConsoleKey.DownArrow) MoveDown();
                else if (key == ConsoleKey.RightArrow) MoveRight();
                else if (key == ConsoleKey.B) MakeBigger();
                else if (key == ConsoleKey.S) MakeSmaller();
                else continue;
                PrintField();
            }
        }

        private static void MakeBigger()
        {
            size = Math.Min(size + 1, 27);
            InitField();
            PrintField();
        }

        private static void MakeSmaller()
        {
            size = Math.Max(5, size - 1);
            myX = Math.Min(myX, size - 1);
            myY = Math.Min(myY, size - 1);
            InitField();
            PrintField();
        }

        private static void MoveUp()
        {
            field[myX, myY] = ' ';
            myY = Math.Max(0, myY - 1);
            if (field[myX, myY] == '*')
            {
                score++;
                SpawnPoint();
            }

            field[myX, myY] = 'x';
        }

        private static void MoveDown()
        {
            field[myX, myY] = ' ';
            myY = Math.Min(size - 1, myY + 1);
            if (field[myX, myY] == '*')
            {
                score++;
                SpawnPoint();
            }

            field[myX, myY] = 'x';
        }

        private static void MoveRight()
        {
            field[myX, myY] = ' ';
            myX = Math.Min(size - 1, myX + 1);
            if (field[myX, myY] == '*')
            {
                score++;
                SpawnPoint();
            }

            field[myX, myY] = 'x';
        }

        private static void MoveLeft()
        {
            field[myX, myY] = ' ';
            myX = Math.Max(0, myX - 1);
            if (field[myX, myY] == '*')
            {
                score++;
                SpawnPoint();
            }

            field[myX, myY] = 'x';
        }

        private static void InitField()
        {
            field = new char[size, size];
            for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                field[i, j] = ' ';
            field[myX, myY] = 'x';
            SpawnPoint();
        }

        private static void SpawnPoint()
        {
            int a = r.Next(0, size * size - 1);
            while (field[a / size, a % size] != ' ') a = r.Next(0, size * size - 1);
            field[a / size, a % size] = '*';
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine('╔' + new string('═', size + 2) + '╗');
            for (int i = 0; i < size; i++)
            {
                Console.Write("║ ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[j, i]);
                }

                Console.Write(" ║\n");
            }

            Console.WriteLine('╚' + new string('═', size + 2) + '╝');
            Console.WriteLine($"Score: {score}");
        }
    }
}
