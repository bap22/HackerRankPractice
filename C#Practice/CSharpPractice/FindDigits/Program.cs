using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindDigits
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/find-digits?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
    /// Given an integer, N, traverse its digits (1,2,...,n) and determine how many digits evenly divide N (i.e.: count the number of times  divided by each digit i has a remainder of 0). Print the number of evenly divisible digits.
    /// For every test case, count and print (on a new line) the number of digits in N that are able to evenly divide N.
    /// </summary>
    class Program
    {
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            var outputs = new List<int>();
            for (int a0 = 0; a0 < t; a0++)
            {
                int evenlyDivisible = 0;
                int n = Convert.ToInt32(Console.ReadLine());
                var digits = NumbersIn(n).ToArray();
                foreach (int digit in digits)
                {
                    if (digit != 0)
                    {
                        if (n % digit == 0)
                        {
                            evenlyDivisible++;
                        }
                    }

                }
                outputs.Add(evenlyDivisible);
            }
            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
            Console.ReadLine();
        }


        ///
        /// We want to find the actual numeric digit value, not the unicode. Thus, we must % 10.    
        private static Stack<int> NumbersIn(int value)
        {
            if (value == 0) return new Stack<int>();

            var numbers = NumbersIn(value / 10);

            numbers.Push(value % 10);

            return numbers;
        }
    }
}
