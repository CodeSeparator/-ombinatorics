using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queens2
{
    class Program
    {
        static int N;
        static bool[] hor;
        static bool[] vert;
        static bool[] diag1;
        static bool[] diag2;
        static int queens = 0;//найдено
        static int totals = 0;
        static void Main(string[] args)
        {



        }
        static void SearchQueens(int a)
        {
            if (a == N)
            {
                queens++;
                Showstats();
                Console.ReadLine();
                return;
            }
            for (int b = 0; b < N; b++)
            {
                totals++;
                // (a,b) - коорд размещ ферзя
                if (hor[b] ||
                    diag1[a + b] ||
                    diag2[b - a + N - 1])
                {
                    WarnStats(a, b);
                    continue;
                }
                vert[a] = true;
                hor[b] = true;
                diag1[a+b] = true;
                diag2[b - a + N - 1] = true;

                ShowQueen(a, b);
                Showstats();
                SearchQueens(a + 1);

                vert[a] = false;
                hor[b] = false;
                diag1[a + b] = false;
                diag2[b - a + N - 1] = false;
            }
            
        }

        private static void ShowQueen(int a, int b)
        {
            throw new NotImplementedException();
        }

        private static void WarnStats(int a, int b)
        {
            throw new NotImplementedException();
        }

        private static void Showstats()
        {
            throw new NotImplementedException();
        }
    }
}
