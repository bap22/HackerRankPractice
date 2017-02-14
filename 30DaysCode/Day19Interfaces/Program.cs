using System;
using System.Collections.Generic;

namespace Day19Interfaces
{
    public interface AdvancedArithmetic
    {
        int divisorSum(int n);
    }

    class Calculator:AdvancedArithmetic
    {
        public int divisorSum(int number)
        {
            int sum = 0;
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    { // Don't add the square root twice
                        factors.Add(number / factor);
                    }
                }
            }
            foreach (int i in factors)
            {
                sum += i;
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            AdvancedArithmetic myCalculator = new Calculator();
            int sum = myCalculator.divisorSum(n);
            Console.WriteLine("I implemented: AdvancedArithmetic\n" + sum);
        }
    }
}
