/*
Question Link: https://www.hackerrank.com/challenges/organizing-containers-of-balls/problem
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizing_Containers_Of_Balls
{
    class Program
    {
        static string OrganizingContainersOfBalls(List<string[]> containers)
        {
            int[] container_capacity = new int[containers.Count];
            int[] ball_amount = new int[containers[0].Length];
            for (int i = 0; i < containers.Count; i++)
            {
                for (int j = 0; j < containers[i].Length; j++)
                {
                    ball_amount[i] += int.Parse(containers[j][i]);
                    container_capacity[i] += int.Parse(containers[i][j]);
                }
            }
            for (int i = 0; i < containers.Count; i++)
            {
                bool control = false;
                for(int j = 0; j < containers.Count; j++)
                {
                    if(ball_amount[i] == container_capacity[j])
                    {
                        container_capacity[j] = -1;
                        control = true;
                        break;
                    }
                }
                if(control == false)
                {
                    return "Impossible";
                }
            }
            return "Possible";
        }
        static void Main(string[] args)
        {
            string q = Console.ReadLine();
            for (int i = 0; i < Convert.ToInt32(q); i++)
            {
                string n = Console.ReadLine();
                List<string[]> containers = new List<string[]>();
                for (int j = 0; j < Convert.ToInt32(n); j++)
                {
                    string[] values = Console.ReadLine().Split(' ');
                    containers.Add(values);
                }
                Console.WriteLine(OrganizingContainersOfBalls(containers));
            }
            Console.ReadLine();
        }
    }
}
