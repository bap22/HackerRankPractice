using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pangrams
{
    class Program
    {
        static string isPangram(string[] strings)
        {
            string binaryReturn = "";
            //Dictionary<char, char> alphabet = new Dictionary<char, char>();

            foreach (var str in strings)
            {
                bool[] hashTable = new bool[27];
                hashTable[0] = true;
                foreach (char c in str)
                {
                    if (c == ' ') continue; //string will be an alpha char or space
                    int alphabetPosition = (int)char.ToUpper(c) - 64; //looked up char to alphabet interger conversion.
                    hashTable[alphabetPosition] = true;
                }
                if (hashTable.Contains(false))
                {
                    binaryReturn += "0";
                }
                else
                {
                    binaryReturn += "1";
                }
            }
            return binaryReturn;
        }

        static void Main(String[] args)
        {
            //string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
            //TextWriter tw = new StreamWriter(@fileName, true);
            string res;

            int _strings_size = 0;
            _strings_size = Convert.ToInt32(Console.ReadLine());
            string[] _strings = new string[_strings_size];
            string _strings_item;
            for (int _strings_i = 0; _strings_i < _strings_size; _strings_i++)
            {
                _strings_item = Console.ReadLine();
                _strings[_strings_i] = _strings_item;
            }

            res = isPangram(_strings);
            Console.WriteLine(res);

           // tw.Flush();
           // tw.Close();
        }
    }
}
