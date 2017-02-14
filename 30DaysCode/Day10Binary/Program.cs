using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10Binary
{
    class Solution
    {

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string binary = IntToBinaryString(n);
            int consecutiveOnes = CountConsecutiveOnes(binary);
            Console.WriteLine(consecutiveOnes);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// to convert to binary, repeatedly divide by 2 until 0 or 1 with remainder 0 or 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static string IntToBinaryString(int n)
        {
            string binary = "";
            Stack<int> stack = new Stack<int>();
            while (n > 0)
            {
                int remainder = n % 2;
                n = n / 2;
                stack.Push(remainder);
            }
            foreach (int i in stack)
            {
                binary += i.ToString();
            }
            return binary;
        }

        /// <summary>
        /// 1011 binary can be converted to decimal by (1 * 2^3) + (0 * 2^2) + (1 * 2^1) + (1 * 2^0)
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        private static long BinaryStringToDecimal(string binaryString)
        {
            long d = 0;
            int stringPosition = 0;
            //string binaryString = Convert.ToString(binary);
            int length = binaryString.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                d += binaryString[stringPosition] * (long)Math.Pow(2, i);
            }
            return d;
        }

        private static int CountConsecutiveOnes(string binaryString)
        {
            int max = 0;
            int current = 0;
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '1')
                {
                    current++;
                    if (current > max)
                    {
                        max = current;
                    }
                }
                else
                {
                    current = 0;
                }
            }
            return max;
        }
    }
}
