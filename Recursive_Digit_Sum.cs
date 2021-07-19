/*
Question Link: https://www.hackerrank.com/challenges/recursive-digit-sum/problem
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Digit_Sum
{
    class Program
    {
        static int Super_Digit(string num_s)
        {
            int result = 0;
            if(num_s.Length == 1)
            {
                return Convert.ToInt32(num_s);
            }
            else
            {
                for (int i = 0; i < num_s.Length; i++)
                {
                    result += int.Parse(num_s[i].ToString());
                }
            }

            return Super_Digit(result.ToString());
        }
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            string n = tokens[0];
            string k = tokens[1];
            string num_s = n;
            num_s = Super_Digit(num_s).ToString();

            Console.WriteLine(Super_Digit((Convert.ToInt32(num_s) * Convert.ToInt32(k)).ToString()));

            Console.ReadLine();
        }
    }
}
