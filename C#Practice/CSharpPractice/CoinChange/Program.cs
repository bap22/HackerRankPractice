using System;
using System.Linq;

namespace CoinChange
{
    class Program
    {
        /// <summary>
        /// Write a program that, given: 1) The amount N to make change for and the number of types M of infinitely available coins and 2) A list of M coins - C- {C1, C2, ... CM}...
        /// Prints out how many different ways you can make change from the coins to STDOUT.
        /// HINT: If you can think of a way to store the checked solutions, then this store can be used to avoid checking the same solution again and again.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //read in the line that contains 
            int n = int.Parse(Console.ReadLine().Split(' ')[0]);
            int[] coinArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();           
            int m = coinArray.Length;//how many coins
            Console.WriteLine(CoinChange(coinArray, m, n));
            Console.ReadLine();
        }

        /// <summary>
        /// note: this solution was found from a different user, it isn't mine
        /// </summary>
        /// <param name="S">coin array</param>
        /// <param name="m">number of coins</param>
        /// <param name="n">amount to make change for</param>
        /// <returns></returns>
        public static int CoinChange(int[] S, int m, int n)
        {
            int[] table = new int[n + 1];
            table[0] = 1;//ways to make change for 0
            for (int i = 0; i < m; i++)
            {
                for (int j = S[i]; j <= n; j++)
                {
                    table[j] += table[j - S[i]];
                }
            }
            return table[n];
        }
    }
}

///TEST CASE that isn't passing...:
/// 250 26
/// 8 47 13 24 25 31 32 35 3 19 40 48 1 4 17 38 22 30 33 15 44 46 36 9 20 49
/// EXPECTED OUTPUT: 3542323427
