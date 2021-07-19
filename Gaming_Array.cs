/*
Question Link: https://www.hackerrank.com/challenges/an-interesting-game-1/problem
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Array
{
    class Program
    {
        static string GamingArray(string[] tokens)
        {
            int num_of_moves = 1;
            int max = Convert.ToInt32(tokens[0]);
            for(int i=1;i<tokens.Length;i++)
            {
                if (max < Convert.ToInt32(tokens[i]))
                {
                    num_of_moves++;
                    max = Convert.ToInt32(tokens[i]);
                }
            }
            if (num_of_moves % 2 == 0) return "ANDY";
            else return "BOB";

        }
        static void Main(string[] args)
        {
            int g = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < g; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] tokens = Console.ReadLine().Split(' ');
                Console.WriteLine(GamingArray(tokens));
            }
            Console.ReadLine();
        }
    }
}
