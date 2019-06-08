using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hatch
{
    class Program
    {
        static int maxx = 79;
        static int maxy = 25;

        static Random rnd = new Random(12345);

        static int[,] map = new int[maxx, maxy];

        static string[] symbols = new string[] {" ", "#", "*", ">", "v", "<", "^" };
        static ConsoleColor[] fore = new ConsoleColor[]
        {
            ConsoleColor.Black,
            ConsoleColor.DarkGray,
            ConsoleColor.White,
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Yellow
        };
        static ConsoleColor[] back = new ConsoleColor[]
        {
            ConsoleColor.Black,
            ConsoleColor.DarkGray,
            ConsoleColor.Black,
            ConsoleColor.Black,
            ConsoleColor.Black,
            ConsoleColor.Black,
            ConsoleColor.Black
        };
        static void Main(string[] args)
        {
            Init();

            Show(maxx >>1, maxy >> 1, 2);
            Console.ReadKey();
            Show(maxx >> 1, maxy >> 1, 0);
            Fill(maxx >> 1, maxy >> 1);
            Console.Read();
        }

        private static void Fill(int x, int y)
        {
            Thread.Sleep(10);
            if (map[x, y] > 0) return;
            Show(x, y, 3);
            Fill(x, y+1);
            Show(x, y, 4);
            Fill(x+1, y);
            Show(x, y, 5);
            Fill(x-1, y);
            Show(x, y, 6);
            Fill(x, y-1);
            Show(x, y, 2);
        }

        /// <summary>
        /// заполнение матрицы map значениями
        /// </summary>
        private static void Init()
        {
            for (int x = 0; x < maxx; x++)
                for (int y = 0; y < maxy; y++)
                {
                    Show(x, y, 0);
                }
            for (int x = 0; x < maxx; x++)
            {
                Show(x, 0, 1);
                Show(x, maxy - 1, 1);
            }
            for (int y = 1; y < maxy-1; y++)
            {
                Show(0, y, 1);
                Show(maxx - 1, y, 1);
            }
            for (int j = 0; j < 400; j++)
            {
                Show(rnd.Next(0, maxx), rnd.Next(0, maxy), 1);
            }
        }

        private static void Show(int x, int y, int color)
        {
            map[x, y] = color;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = fore[color];
            Console.BackgroundColor = back[color];
            Console.Write(symbols[color]);
        }
    }
}
