using System;

namespace fctr
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            Console.WriteLine(Factor(num));
            Console.Read();
            
        }
        public static long Factor(long x)
        {
            try
            {
                if (x <= 0) return 1;
                return x = x * Factor(x - 1);
            }
            catch
            {
                Console.WriteLine("Exception");
                return 0;
            }
            
        }
    }
}
