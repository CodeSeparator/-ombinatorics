using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTickets
{
    class Program
    {
        public static int sumnums = 0;
        static void Main(string[] args)
        {
            //int luck = 0;
            Console.WriteLine(Numbers(4));
            Console.ReadKey();
        }
        static int Numbers(int n)
        {
            int[] mass = new int[28];
            int x = (int)Math.Pow(10, n >> 1);
            for (int i = 0; i < x; i++)
            {
                sumnums = 0;
                mass[SumNum(i)]++;
            }
            int s = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                s += mass[i] * mass[i];
            }
            return s;
        }
        static int SumNum(int n)
        {
            if (n == 0)
            {
                return sumnums;
            }
            else
            {
                sumnums += n%10;
                SumNum(n / 10);
            }
            return sumnums;
        }
    }
}
