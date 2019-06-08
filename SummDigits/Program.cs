using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummDigits
{
    class Program
    {
        static int count;//сколько букв
        static string[] letter;
        static int[] digits;
        static bool[] used;// свободна цифра или нет
        static string one, two, sum;
        static bool found = false;

        static void Main(string[] args)
        {
            one = "БУЛОК";
            two = "БЫЛО";
            sum = "МНОГО";

            letter = new string[10];
            digits = new int[10];
            used = new bool[10];
            count = 0;
            for (int j = 0; j < sum.Length; j++)
                AddLetter(sum.Substring(j, 1));
            for (int j = 0; j < one.Length; j++)
                AddLetter(one.Substring(j, 1));
            for (int j = 0; j < two.Length; j++)
                AddLetter(two.Substring(j, 1));




            //// ШРАМ * Ы = МАРШ
            //int ШРАМ, МАРШ;
            //for(int Ш=0; Ш <= 9; Ш++)
            //    for (int Р = 0; Р <= 9; Р++)
            //        if(Р!=Ш)
            //        for (int А = 0; А <= 9; А++)
            //                if (Р != А && Ш != А)
            //                    for (int М = 0; М <= 9; М++)
            //                        if (М != А && М != Р && М != Ш)
            //                            for (int Ы = 0; Ы <= 9; Ы++)
            //                                if (Ы != Ш && Ы != Р && Ы != А && Ы != М)
            //                                {
            //                                    ШРАМ = Ш * 1000 + Р * 100 + А * 10 + М;
            //                                    МАРШ = М * 1000 + А * 100 + Р * 10 + Ш;
            //                                    if (ШРАМ*Ы==МАРШ)
            //                                        Console.WriteLine(М.ToString() + А.ToString() + Р.ToString() + Ш.ToString());
            //                                }
            //Console.Read();
            Next(0);
            Console.Read();
        }
        static void Next(int nr)
        {
            if(nr == count)
            {
                int a = StringToNumber(one);
                int b = StringToNumber(two);
                int s = StringToNumber(sum);
                if(a+b == s)
                {
                    Console.WriteLine("{0} + {1} = {2}", a, b, s);
                    found = true;
                    return;
                }
            }
                for (int d = 9; d >= 0; d--)
                {
                    if (used[d])
                        continue;
                    used[d] = true;
                    digits[nr] = d;
                    Next(nr + 1);
                    used[d] = false;
                    if (found) break;
                }
        }

        private static int StringToNumber(string word)
        {
            for (int j = 0; j < count; j++)
            {
                word = word.Replace(letter[j],digits[j].ToString());

            }
            return int.Parse(word);
        }

        static void AddLetter(string a)
        {
            if(Array.IndexOf(letter,a) == -1)
            {
                letter[count] = a;
                count++;
            }
        }
    }
}
