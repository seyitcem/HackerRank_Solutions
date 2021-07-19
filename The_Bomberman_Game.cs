/*
Question Link: https://www.hackerrank.com/challenges/bomber-man/problem
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Bomberman_Game
{
    class Program
    {
        public struct Coord
        {
            public int r;
            public int c;
            public Coord(int r, int c)
            {
                this.r = r;
                this.c = c;
            }
        }
        static string ReplaceAtIndex(string str, int index, char ch)
        {
            StringBuilder sb = new StringBuilder(str);
            sb[index] = ch;
            return sb.ToString();
        }
        static void BombermanGame(int row, int col, int sec, string[] grid)
        {
            if (sec % 2 == 0)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write('O');
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int k = 0; k < (sec > 2 ? (sec / 2) % 2 + 2 : 0); k++)
                {
                    List<Coord> bombs = new List<Coord>();
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            if (grid[i][j] == 'O')
                            {
                                bombs.Add(new Coord(i, j));
                            }
                        }
                    }
                    List<Coord> temp = new List<Coord>();
                    foreach (var coord in bombs)
                    {
                        temp.Add(coord);
                        if (coord.r + 1 < row)
                        {
                            temp.Add(new Coord(coord.r + 1, coord.c));
                        }
                        if (coord.r - 1 >= 0)
                        {
                            temp.Add(new Coord(coord.r - 1, coord.c));
                        }
                        if (coord.c + 1 < col)
                        {
                            temp.Add(new Coord(coord.r, coord.c + 1));
                        }
                        if (coord.c - 1 >= 0)
                        {
                            temp.Add(new Coord(coord.r, coord.c - 1));
                        }
                    }
                    for (int i = 0; i < row; i++)
                    {
                        grid[i] = "";
                        for (int j = 0; j < col; j++)
                        {
                            grid[i] += 'O';
                        }
                    }
                    foreach (var coord in temp)
                    {
                        grid[coord.r] = ReplaceAtIndex(grid[coord.r], coord.c, '.');
                    }
                }
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(grid[i][j]);
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int row = int.Parse(tokens[0]);
            int col = int.Parse(tokens[1]);
            int sec = int.Parse(tokens[2]);

            string[] grid = new string[row];

            for (int i = 0; i < row; i++)
            {
                grid[i] = Console.ReadLine();
            }
            BombermanGame(row, col, sec, grid);

            Console.ReadLine();
        }
    }
}
