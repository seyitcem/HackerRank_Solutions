/*
Question Link: https://www.hackerrank.com/challenges/queens-attack-2/problem
*/
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Queens_Attack_II
{
    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        int[] arr = new int[8];
        for (int i = 0; i < 8; i++)
        {
            arr[i] = int.MaxValue;
        }
        foreach (var obstacle in obstacles)
        {
            int distance_row = Math.Abs(obstacle[0] - r_q);
            int distance_col = Math.Abs(obstacle[1] - c_q);
            if (distance_row == distance_col && distance_row != 0)
            {
                if (obstacle[0] > r_q && obstacle[1] > c_q && arr[0] > distance_row)
                {
                    arr[0] = distance_row;
                }
                else if (obstacle[0] < r_q && obstacle[1] < c_q && arr[1] > distance_row)
                {
                    arr[1] = distance_row;
                }
                else if (obstacle[0] < r_q && obstacle[1] > c_q && arr[2] > distance_row)
                {
                    arr[2] = distance_row;
                }
                else if (obstacle[0] > r_q && obstacle[1] < c_q && arr[3] > distance_row)
                {
                    arr[3] = distance_row;
                }
            }
            else if (distance_row == 0 && distance_col != 0)
            {
                if (obstacle[1] > c_q && arr[4] > distance_col)
                {
                    arr[4] = distance_col;
                }
                else if (obstacle[1] < c_q && arr[5] > distance_col)
                {
                    arr[5] = distance_col;
                }
            }
            else if (distance_row != 0 && distance_col == 0)
            {
                if (obstacle[0] < r_q && arr[6] > distance_row)
                {
                    arr[6] = distance_row;
                }
                else if (obstacle[0] > r_q && arr[7] > distance_row)
                {
                    arr[7] = distance_row;
                }
            }
        }
        int count = 0;
        if (arr[0] == int.MaxValue)
        {
            if (Math.Abs(r_q - n) < Math.Abs(c_q - n))
            {
                count += Math.Abs(r_q - n);
            }
            else
            {
                count += Math.Abs(c_q - n);
            }
        }
        else
        {
            count += arr[0] - 1;
        }
        if (arr[1] == int.MaxValue)
        {
            if (Math.Abs(r_q - 1) < Math.Abs(c_q - 1))
            {
                count += Math.Abs(r_q - 1);
            }
            else if (c_q != 1 && r_q != 1)
            {
                count += Math.Abs(c_q - 1);
            }
        }
        else
        {
            count += arr[1] - 1;
        }

        if (arr[2] == int.MaxValue)
        {
            if (Math.Abs(r_q - 1) < Math.Abs(c_q - n))
            {
                count += Math.Abs(r_q - 1);
            }
            else if (c_q != n && r_q != 1)
            {
                count += Math.Abs(c_q - n);
            }
        }
        else
        {
            count += arr[2] - 1;
        }

        if (arr[3] == int.MaxValue)
        {
            if (Math.Abs(r_q - n) < Math.Abs(c_q - 1))
            {
                count += Math.Abs(r_q - n);
            }
            else if (c_q != 1 && r_q != n)
            {
                count += Math.Abs(c_q - 1);
            }
        }
        else
        {
            count += arr[3] - 1;
        }

        if (arr[4] == int.MaxValue)
        {
            if (c_q != n)
            {
                count += n - c_q;
            }
        }
        else
        {
            count += arr[4] - 1;
        }

        if (arr[5] == int.MaxValue)
        {
            if (c_q != 1)
            {
                count += c_q - 1;
            }
        }
        else
        {
            count += arr[5] - 1;
        }

        if (arr[6] == int.MaxValue)
        {
            if (r_q != 1)
            {
                count += r_q - 1;
            }
        }
        else
        {
            count += arr[6] - 1;
        }

        if (arr[7] == int.MaxValue)
        {
            if (r_q != n)
            {
                count += n - r_q;
            }
        }
        else
        {
            count += arr[7] - 1;
        }
        return count;
    }
    public static void Main(string[] args)
    {
        string[] n_k_tokens = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(n_k_tokens[0]);
        int k = Convert.ToInt32(n_k_tokens[1]);

        string[] queen_tokens = Console.ReadLine().Split(' ');
        int r_q = Convert.ToInt32(queen_tokens[0]);
        int c_q = Convert.ToInt32(queen_tokens[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            string[] obstacle_tokens = Console.ReadLine().Split(' ');
            obstacles.Add(new List<int> { Convert.ToInt32(obstacle_tokens[0]), Convert.ToInt32(obstacle_tokens[1]) });
        }
        Console.WriteLine(queensAttack(n, k, r_q, c_q, obstacles));
        Console.ReadLine();
    }
}
