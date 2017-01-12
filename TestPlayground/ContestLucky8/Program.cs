using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ContestLucky8
{
    class Program
    {
        /// <summary>
        /// Given an n-digit positive integer, count and print the number of multiples of 8 that can be formed by concatenating subsequences of the given number's digits, modulo 10^9 + 7.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string number = Console.ReadLine();
            double xmod = Math.Pow(10, 9) + 7;
            List<int> div8 = GetPermutationsDiv8<int>(number, n);
            Console.WriteLine(div8.Count % xmod);
        }


        static List<int> GetPermutationsDiv8<T>(string input, int count)
        {
            List<int> returnList = new List<int>();
            List<int> subsets = new List<int>();

            // Loop over individual elements
            for (int i = 1; i < count; i++)
            {
                subsets.Add(input[i - 1]);

                List<int> newSubsets = new List<int>();

                // Loop over existing subsets
                for (int j = 0; j < subsets.Count; j++)
                {
                    int newSubset = int.Parse(subsets[j].ToString() + input[i].ToString());
                    newSubsets.Add(newSubset);
                }

                subsets.AddRange(newSubsets);
            }

            // Add in the last element
            subsets.Add(input[count - 1]);

            foreach (int permutation in subsets)
            {
                //int permutation = Convert.ToInt32(p);
                if (permutation%8 == 0)
                {
                    returnList.Add(permutation);
                }
            }
            return returnList;
        }
    }
}
