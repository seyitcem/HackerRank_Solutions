using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock_And_The_Valid_String
{
    class Program
    {
        public struct Characters
        {
            public char ch;
            public int count;
            public Characters(char ch, int count)
            {
                this.ch = ch;
                this.count = count;
            }
        }
        static string ValidString(string str)
        {
            List<Characters> list = new List<Characters>();
            Characters characters = new Characters(str[0], 1);
            list.Add(characters);

            for (int i = 1; i < str.Length; i++)
            {
                bool isHave = false;
                for (int j = 0; j < list.Count; j++)
                {
                    if (str[i] == list[j].ch)
                    {
                        Characters temp = list[j];
                        temp.count++;
                        list[j] = temp;
                        isHave = true;
                        break;
                    }
                }
                if (!isHave)
                {
                    Characters new_character = new Characters(str[i], 1);
                    list.Add(new_character);
                }
            }
            int different_count = 0;
            int different_number = 0;
            int counter = list[0].count;

            for (int i = 1; i < list.Count; i++)
            {
                if (counter != list[i].count)
                {
                    different_number = list[i].count;
                    different_count++;
                    if (different_count > 1)
                    {
                        return "NO";
                    }
                }
            }

            if (different_count == 0)
            {
                return "YES";
            }
            else if (different_number - 1 == counter)
            {
                return "YES";
            }
            else if (different_number == 1 && different_number == 1)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }
        static void Main(string[] args)
        {
            int bufSize = 1024;
            Stream inStream = Console.OpenStandardInput(bufSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));
            string str = Console.ReadLine();

            Console.WriteLine(ValidString(str));

            Console.ReadLine();
        }
    }
}
