using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibo
{
    class Program
    {
        static void Main(string[] args)
        {
            long x = long.Parse(Console.ReadLine());
            Console.WriteLine(Fibo(x));
            Console.ReadKey();
        }

        static long Fibo(long n)
        {
            if (n < 2)
                return 1;
            return Fibo(n-1) + Fibo(n - 2);
        }
    }
}
