using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapptTickets2
{
    class Program
    {
        static int lucky = 0;
        static int[] digits;
        static int n, max;
        static int sum1, sum2;
        static void Main(string[] args)
        {
            // неоптимальный
            #region 1 вар
            //long start = Time();
            //for (int a = 0; a <= 9; a++)
            //    for (int b = 0; a <= 9; b++)
            //        for (int c = 0; a <= 9; c++)
            //            for (int d = 0; a <= 9; d++)
            //                for (int e = 0; a <= 9; e++)
            //                    for (int f = 0; a <= 9; f++)
            //                    {
            //                        if (a + b + c == d + e + f)
            //                        {
            //                            Console.WriteLine("{0}{1}{2}{3}{4}{5}", a, b, c, d, e, f);
            //                            lucky++;
            //                        }
            //                    }

            #endregion
            // с неизв числом цифр
            n = int.Parse(Console.ReadLine());
            long start = Time();
            max = n << 1;
            digits = new int[max];
            Next(0);

            Console.WriteLine(lucky);
            Console.WriteLine("Time: " + (Time() - start).ToString());
            Console.ReadKey();
        }
        static void Next(int num)
        {
            if (num == max)
            {

                if (sum1 >= sum2 && sum1 <= sum2 + 9)
                    lucky++;
                return;

            }
            for (int j = 0; j <= 9; j++)
            {
                digits[num] = j;
                if (num < n)
                    sum1 += j;
                else
                    sum2 += j;
                Next(num + 1);
                if (num < n)
                    sum1 -= j;
                else
                    sum2 -= j;
            }
        }
        static long Time()
        {
            return DateTime.Now.Ticks / 10 / 1000;
        }
    }
}
