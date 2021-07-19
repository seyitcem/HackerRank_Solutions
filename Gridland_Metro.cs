/*
Question Link: https://www.hackerrank.com/challenges/gridland-metro/problem
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridland_Metro
{
    class Program
    {
        static ulong GridlandMetro(ulong n, ulong m, List<string[]> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for(int j = i+1; j < list.Count; j++)
                {
                    if(Convert.ToInt32(list[i][0]) == Convert.ToInt32(list[j][0]))
                    {
                        if (Convert.ToInt32(list[i][2]) >= Convert.ToInt32(list[j][2]) && Convert.ToInt32(list[i][1]) <= Convert.ToInt32(list[j][1]))           // içinde ise
                        {
                            list.RemoveAt(j);
                            j--;
                        }else if (Convert.ToInt32(list[i][2]) >= Convert.ToInt32(list[j][1]) && Convert.ToInt32(list[i][1]) <= Convert.ToInt32(list[j][1]))     // sağ içine
                        {
                            list[i][2] = list[j][2];
                            list.RemoveAt(j);
                            j--;
                        }else if (Convert.ToInt32(list[i][1]) <= Convert.ToInt32(list[j][2]) && Convert.ToInt32(list[i][2]) >= Convert.ToInt32(list[j][2]))     // sol içine ise
                        {
                            list[i][1] = list[j][1];
                            list.RemoveAt(j);
                            j--;
                        }else if (Convert.ToInt32(list[i][2]) <= Convert.ToInt32(list[j][2]) && Convert.ToInt32(list[i][1]) >= Convert.ToInt32(list[j][1]))     // dışında ise
                        {
                            list[i][1] = list[j][1];
                            list[i][2] = list[j][2];
                            list.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }
            ulong full_space = 0;
            for(int i = 0; i < list.Count;i++)
            {
                full_space +=(ulong) (Convert.ToInt32(list[i][2]) - Convert.ToInt32(list[i][1]) + 1);
            }

            return n * m - full_space;
        }
        static void Main(string[] args)
        {
            string[] tokens_first_line = Console.ReadLine().Split(' ');
            ulong n = Convert.ToUInt64(tokens_first_line[0]);
            ulong m = Convert.ToUInt64(tokens_first_line[1]);
            int k = Convert.ToInt32(tokens_first_line[2]);
            List<string[]> list = new List<string[]>();
            for (int i = 0; i < k; i++)
            {
                list.Add(Console.ReadLine().Split(' '));
            }
            Console.WriteLine(GridlandMetro(n, m, list));
            Console.ReadLine();
        }
    }
}
