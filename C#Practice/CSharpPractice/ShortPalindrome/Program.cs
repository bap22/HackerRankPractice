using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortPalindrome
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/short-palindrome
    /// Consider a string, s, of n lowercase English letters where each character, s (0 lte i lt n), denotes the letter at index i in s. 
    /// We define an (a,b,c,d) palindromic tuple of s to be a sequence of indices in s satisfying the following criteria:
    /// Sa = Sd, meaning the characters located at indices a and d are the same.
    /// Sb = Sc, meaning the characters located at indices b and c are the same.
    /// 0 lte a lt b lt c lt d lt |s|, meaning that a, b, c, and d are ascending in value and are valid indices within string s
    /// 
    /// Given s, find and print the number of (a,b,c,d) tuples satisfying the above conditions. As this value can be quite large, print it modulo 10^9 + 7.
    /// </summary>
    class Program
    {
        const long modulo = 1000000007; //requirements ask to print mod this number, i.e. %modulo

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            long total = 0;
            foreach (char c1 in input.Distinct())
                total = (total + SolveSingleChar(input.Count(c => c == c1))) % modulo;
            total = (total + SolveTwoChar(input)) % modulo;
            Console.WriteLine(total);
        }

        //i dont take credit for the following 2 methods, I found online.
        static long SolveTwoChar(string s)
        {
            int[] sequence = s.Select(c => c - 'a').ToArray();
            int nc = sequence.Max() + 1;
            long[] numAs = new long[nc];
            long[] totalAs = new long[nc];
            foreach (int c in sequence)
                totalAs[c]++;
            long[][] numABPairs = new long[nc][].Select(u => new long[nc]).ToArray();
            long total = 0;
            foreach (int b in sequence)
            {
                numAs[b]++;
                for (int a = 0; a < nc; a++)
                {
                    if (a == b)
                        continue;
                    total += numABPairs[a][b] * (totalAs[a] - numAs[a]);
                    total %= modulo;
                    numABPairs[a][b] += numAs[a];
                    numABPairs[a][b] %= modulo;

                }
            }
            return total;

        }

        static long SolveSingleChar(int n)
        {
            long[] top = new long[] { n, n - 1, n - 2, n - 3 };
            foreach (int div in new int[] { 2, 2, 2, 3 })
                for (int i = 0; i < top.Length; i++)
                    if (top[i] % div == 0)
                    {
                        top[i] /= div;
                        break;
                    }
            return top.Aggregate(1L, (a, b) => (a * b) % modulo);
        }


    }
}
