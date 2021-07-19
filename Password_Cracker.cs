/*
Question Link: https://www.hackerrank.com/challenges/password-cracker/problem
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Cracker
{
    class Program
    {
        static Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
        static bool Results(ref List<string> tokens, string loginAttempt, string createdStr, ref List<string> elements)
        {
            if (loginAttempt == "")
            {
                if (dictionary.ContainsKey(createdStr))
                {
                    if (dictionary[createdStr])
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (!dictionary.ContainsKey(loginAttempt) || dictionary[loginAttempt])
            {
                for (int i = 0; i < tokens.Count; i++)
                {
                    if (loginAttempt.Length - tokens[i].Length >= 0)
                    {
                        if (loginAttempt.Substring(0, tokens[i].Length) == tokens[i])
                        {
                            elements.Add(tokens[i]);
                            if (!Results(ref tokens, loginAttempt.Substring(elements[elements.Count - 1].Length), createdStr + elements[elements.Count - 1], ref elements))
                            {
                                if (elements.Count != 0)
                                {
                                    if (!dictionary.ContainsKey(loginAttempt.Substring(elements[elements.Count - 1].Length)))
                                    {
                                        dictionary.Add(loginAttempt.Substring(elements[elements.Count - 1].Length), false);
                                    }
                                    elements.RemoveAt(elements.Count - 1);
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
        static void PasswordCracker(List<string> tokens, string loginAttempt)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Length > loginAttempt.Length)
                {
                    tokens.RemoveAt(i);
                    i--;
                }
                else if (tokens[i].Length == loginAttempt.Length)
                {
                    if (tokens[i] != loginAttempt)
                    {
                        tokens.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        Console.WriteLine(tokens[i]);
                        return;
                    }
                }
                else if (!loginAttempt.Contains(tokens[i]))
                {
                    tokens.RemoveAt(i);
                    i--;
                }
            }
            List<string> list = new List<string>();
            tokens = (from token in tokens.ToArray() orderby token.Length descending select token).ToList();
            dictionary.Add(loginAttempt, true);
            if (!Results(ref tokens, loginAttempt, "", ref list))
            {
                Console.WriteLine("WRONG PASSWORD");
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i]);
                    if (i + 1 < list.Count)
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            dictionary.Clear();
        }
        static void Main(string[] args)
        {
            int bufSize = 2048;
            Stream inStream = Console.OpenStandardInput(bufSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                List<string> tokens = Console.ReadLine().Split(' ').ToList();
                string loginAttempt = Console.ReadLine();
                PasswordCracker(tokens, loginAttempt);
            }
            Console.ReadLine();
        }
    }
}
