using System;
using System.Collections.Generic;
using System.IO;

namespace Day25RunningTime
{
    class Solution
    {
        static void Main(string[] args)
        {
            int numberOfTests = Convert.ToInt32(Console.ReadLine());
            List<int> tests = new List<int>();
            for (int i = 0; i < numberOfTests; i++)
            {
                tests.Add(Convert.ToInt32(Console.ReadLine()));
            }
            foreach (int test in tests)
            {
                if (isPrime(test))
                {
                    Console.WriteLine("Prime");
                }
                else
                {
                    Console.WriteLine("Not prime");
                }
            }
            Console.ReadLine();
        }

        private static bool isPrime(int test)
        {
            if (test == 2)
            {
                return true;
            }
            if (test%2 == 0 || test==1)
            {
                return false;
            }
            int sqrt = (int) Math.Ceiling(Math.Sqrt(test));
            for (int i = 2; i <= sqrt; i++)
            {
                if (test%i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
