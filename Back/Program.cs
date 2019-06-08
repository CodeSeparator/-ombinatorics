using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Back
{
    class Program
    {
        static void Main(string[] args)
        {
            Back();
            Console.ReadKey();
        }

        static void Back()
        {
            int x = int.Parse(Console.ReadLine());
            if (x == 0)
            {
                Console.WriteLine(x);
                return;
            }
            Back();
            Console.WriteLine(x);
        }
    }
}
