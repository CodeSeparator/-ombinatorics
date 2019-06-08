using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NOD
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = long.Parse(Console.ReadLine());
            long b = long.Parse(Console.ReadLine());
            Console.WriteLine(NOD(a, b));
            Console.Read();
        }

        static long NOD(long a, long b)
        {
            if (a == b)
                return a;
            if(a > b)
            {
                return NOD(a - b, b);
            }
            else
            {
                return NOD(b - a, a);
            }
        }
    }
}
