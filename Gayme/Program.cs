using System;
using System.Diagnostics;

namespace Gayme
{
    class Program
    {
        private static char[,] field;
        private static Random r = new();
        private static int size;
        private static int myX, myY;
        private static int score = 0;

        static void Main(string[] args)
        {
            InitField();
            PrintField();
            
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Q: break;
            }
        }

        private static void InitField()
        {
            size = 11;
            field = new char[size, size];
            for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                field[i, j] = ' ';

            myX = size / 2;
            myY = size / 2;
            field[myY, myX] = 'x';
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
            Console.WriteLine('╔' + new string('═', size + 2) + '╗');
            Console.WriteLine("║" + new string(' ', size + 2) + "║");
            for (int i = 0; i < size; i++)
            {
                Console.Write("║ ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.Write(" ║\n");
            }

            Console.WriteLine("║" + new string(' ', size + 2) + "║");
            Console.WriteLine('╚' + new string('═', size + 2) + '╝');
            // ╚   ╝
        }
    }
}