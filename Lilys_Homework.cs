/*
Question Link: https://www.hackerrank.com/challenges/lilys-homework/problem
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lilys_Homework
{
    class Program
    {
        static int LilysHomework(List<int> arr)
        {
            int[] results = new int[] { 0, 0 };
            for (int k = 0; k < 2; k++)
            {
                if (k == 1)
                {
                    arr.Reverse();
                }
                List<KeyValuePair<int, int>> pairs = new List<KeyValuePair<int, int>>();
                for (int i = 0; i < arr.Count; i++)
                {
                    pairs.Add(new KeyValuePair<int, int>(arr[i], i));
                }
                pairs.Sort((x, y) => (x.Key.CompareTo(y.Key)));
                Dictionary<int, bool> sortedIndexIsVisited = new Dictionary<int, bool>();
                for (int i = 0; i < arr.Count; i++)
                {
                    sortedIndexIsVisited[i] = false;
                }
                for (int i = 0; i < arr.Count; i++)
                {
                    if (!sortedIndexIsVisited[i] && pairs[i].Value != i)
                    {
                        int cycle_size = 0;
                        int j = i;
                        while (!sortedIndexIsVisited[j])
                        {
                            sortedIndexIsVisited[j] = true;
                            j = pairs[j].Value;
                            cycle_size++;
                        }
                        if (cycle_size > 0)
                        {
                            results[k] += cycle_size - 1;
                        }
                    }

                }
            }
            return results[0] < results[1] ? results[0] : results[1];
        }
        static void Main(string[] args)
        {
            int bufSize = 2000000;
            Stream inStream = Console.OpenStandardInput(bufSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));
            int n = int.Parse(Console.ReadLine());
            List<int> arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32).ToList();

            Console.WriteLine(LilysHomework(arr));

            Console.ReadLine();
        }
    }
}
