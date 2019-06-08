using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Digits
{
    class Program
    {

        static string digits;
        static int answer;
        static char[] operation = {' ', '*', '+', '-'};
        static char[] op;
        static int total;
        static void Main(string[] args)
        {
            digits = Console.ReadLine();
            answer = int.Parse(Console.ReadLine());
            total = digits.Length;
            op = new char[total];
            Find(0);
            Console.Read();
        }

        private static void Find(int poz)
        {
            if(poz == total - 1)
            {
                op[poz] = '=';
                string formula = "";
                for (int j = 0; j < total; j++)
                {
                    formula += digits[j].ToString() + op[j].ToString();
                }
                if (Calc(formula) == answer)//Calc(formula) == answer
                {
                    Console.WriteLine("{0}{1}", formula, answer);
                }
                return;
            }
            foreach(char o in operation)
            {
                op[poz] = o;
                Find(poz + 1);
            }
        }

        private static int Calc(string formula)
        {

            formula = formula.Replace(" ", "").Replace("=", "");
            var table = new DataTable();
            table.Columns.Add("sum", typeof(decimal)).Expression = formula;
            var row = table.NewRow();
            table.Rows.Add(row);
            return Convert.ToInt32(table.Rows[0]["sum"]);
        }
    }
}
