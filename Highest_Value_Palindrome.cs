/*
Question Link: https://www.hackerrank.com/challenges/richie-rich/problem
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Highest_Value_Palindrome
{
    class Program
    {
        static string HighestValuePalindrome(int n, int k, string num_s)
        {
            char[] char_array = new char[num_s.Length];
            int different_counter = 0;
            for (int i = 0; i < ((num_s.Length % 2 == 0) ? num_s.Length / 2 : num_s.Length / 2 + 1); i++)
            {
                if (num_s[i] != num_s[num_s.Length - 1 - i])
                {
                    different_counter++;
                    if (different_counter > k)
                    {
                        return "-1";
                    }
                }
            }

            int max_optional_change = k - different_counter;

            for (int i = 0; i < ((num_s.Length % 2 == 0) ? num_s.Length / 2 : num_s.Length / 2 + 1); i++)
            {
                if(num_s[i] != num_s[num_s.Length - 1 - i])
                {
                    if(max_optional_change > 0 && num_s[i] != '9' && num_s[num_s.Length - 1 - i] != '9')
                    {
                        char_array[i] = '9';
                        char_array[num_s.Length - 1 - i] = '9';
                        max_optional_change--;
                    }
                    else
                    {
                        if(num_s[i] > num_s[num_s.Length - 1 - i])
                        {
                            char_array[i] = num_s[i];
                            char_array[num_s.Length - 1 - i] = num_s[i];
                        }
                        else
                        {
                            char_array[i] = num_s[num_s.Length - 1 - i];
                            char_array[num_s.Length - 1 - i] = num_s[num_s.Length - 1 - i];
                        }
                    }
                }
                else
                {
                    if (max_optional_change > 1 && num_s[i] != '9')
                    {
                        char_array[i] = '9';
                        char_array[num_s.Length - 1 - i] = '9';
                        max_optional_change -= 2;
                    }
                    else
                    {
                        char_array[i] = num_s[i];
                        char_array[num_s.Length - 1 - i] = num_s[i];
                    }
                }
            }
            if(max_optional_change > 0 && num_s.Length % 2 != 0)
            {
                char_array[num_s.Length / 2] = '9';
            }
            return new string(char_array);
        }
        static void Main(string[] args)
        {
            int bufSize = 100000;
            Stream inStream = Console.OpenStandardInput(bufSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));
            string[] tokens = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens[0]);
            int k = Convert.ToInt32(tokens[1]);
            string num_s = Console.ReadLine();
            Console.WriteLine(HighestValuePalindrome(n, k, num_s));
            Console.ReadLine();
        }
    }
}
