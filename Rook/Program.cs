using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rook
{
    class Program
    {
        static int n;
        static int queens = 0;
        static bool[] horiz;
        static bool[] diag1;
        static bool[] diag2;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            horiz = new bool[n];
            diag1 = new bool[n << 1];
            diag2 = new bool[n << 1];
            
            Next(0);

            long start = Time();
            // int rook = 0;
            // ладьи
            //for (int a = 1; a <= 4; a++)
            //    for (int b = 1; b <= 4; b++)
            //        if (a != b)
            //            for (int c = 1; c <= 4; c++)
            //                if (c != a && c != b)
            //                    for (int d = 1; d <= 4; d++)
            //                        if (d != a && d != b && d != c)
            //                            rook++;
            // ферзи
            //int queens = 0;
            //for (int a = 1; a <= 4; a++)
            //    for (int b = 1; b <= 4; b++)
            //        if (a != b && b != a+1 && b != a - 1)
            //            for (int c = 1; c <= 4; c++)
            //                if (c != b && c != b+1 && c!=b-1 && c!=a && c!= a+2 && c != a - 2)
            //                    for (int d = 1; d <= 4; d++)
            //                        if (d != c && d != c-1 && d != c+1 &&
            //                            d != b && d != b - 2 && d != b + 2 &&
            //                            d != a && d != a - 3 && d != a + 3)
            //                            queens++;

            

            Console.WriteLine(queens);
            Console.WriteLine("Time: " + (Time() - start).ToString());
            Console.ReadKey();
        }
        static void Next(int vert)
        {
            if(vert == n)
            {
                queens++;
                return;
            }
            for (int a = 0; a < n; a++)
            {
                if (horiz[a]) continue;
                if (diag1[a + vert]) continue;
                if (diag2[a - vert + n]) continue;

                horiz[a] = true;
                diag1[a + vert] = true;
                diag2[a - vert + n] = true;

                Next(vert + 1);

                horiz[a] = false;
                diag1[a + vert] = false;
                diag2[a - vert + n] = false;
            }
        }

        private static long Time()
        {
            return DateTime.Now.Ticks / 10000;
        }
    }
}
