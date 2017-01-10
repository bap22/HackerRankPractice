using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Contest2XOR
{
    /// <summary>
    /// https://www.hackerrank.com/contests/w28/challenges/the-great-xor
    /// Given a long integer, X, count the number of values of A satisfying the following conditions:
    /// A XOR X > X and A gt 0 and A lt X
    /// where A and X are long integers
    /// You are given queries, and each query is in the form of a long integer denoting. For each query, 
    /// print the total number of values of satisfying the conditions above on a new line.
    /// The first line contains an integer, , denoting the number of queries. 
    /// Each of the subsequent lines contains a long integer describing the value of  for a query.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<long> results = new List<long>();
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                long x = Convert.ToInt64(Console.ReadLine());
                long result = XOR(x);
                results.Add(result);
            }
            foreach (long re in results)
            {
                Console.WriteLine(re);
            }
            //Console.ReadLine();
        }

        public static long XOR(long x)
        {
            long count = 0;
            for (int i = 1; i <= x; i++)
            {
                if ((i ^ x) > x && i < x)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
