using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SumThemAll
{
    class Program
    {
        static int summation(int[] numbers)
        {
            return numbers.Sum();
            //in a test, do they want to see it without Linq?
        }

        static void Main(String[] args)
        {
            string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
            TextWriter tw = new StreamWriter(@fileName, true);
            int res;

            int _numbers_size = 0;
            _numbers_size = Convert.ToInt32(Console.ReadLine());
            int[] _numbers = new int[_numbers_size];
            int _numbers_item;
            for (int _numbers_i = 0; _numbers_i < _numbers_size; _numbers_i++)
            {
                _numbers_item = Convert.ToInt32(Console.ReadLine());
                _numbers[_numbers_i] = _numbers_item;
            }

            res = summation(_numbers);
            tw.WriteLine(res);

            tw.Flush();
            tw.Close();
        }
    }
}
