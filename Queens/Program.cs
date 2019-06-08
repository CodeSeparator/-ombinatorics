using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            Activate(5, 4, 4);
        }

        private static void Activate(int n, int x, int y)
        {
            FindStartPoint(x, y);
            for (int i = 0; i <= n; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            for (int i = 0; i <= x - 3; i++)
            {
                Console.Write(" ");
            }
            Console.Write(0);
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= x - 3; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(i + " ");
                Inserts(n, 4);
            }
            Console.Read();
        }

        /// <summary>
        /// Вставка элементов
        /// </summary>
        /// <param name="n"></param>
        private static void Inserts(int n, int k)
        {
            //Console.WriteLine();
            for (int i = 1; i <= n; i++)
            {
                if (k != i)
                    Console.Write(" ");
                else
                    Console.Write("Z");
            }
        }

        private static void FindStartPoint(int x, int y)
        {
            for (int i = 0; i < y - 1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < x - 1; j++)
                {
                    Console.Write(" ");
                }
            }

        }
    }
}
