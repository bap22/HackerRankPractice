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
            int count = 0;
            string number = Console.ReadLine();
            double xmod = Math.Pow(10, 9) + 7;
            List<int> div8 = GetPermutationsDiv8<int>(number, number.Length);
            Console.WriteLine(div8.Count % xmod);
            Console.ReadLine();
        }
        // Print out the permutations of the input 


        static List<int> GetPermutationsDiv8<T>(IEnumerable<char> input, int count)
        {
            List<int> returnList = new List<int>();
            List<int> theList = new List<int>();
            for(int z=1; z <= count; z++)
            {
                theList = GenerateWordCombinations(input);
            }
            foreach (int permutation in theList)
            {
                if (permutation%8 == 0)
                {
                    returnList.Add(permutation);
                }
            }
            return returnList;
        }
        //TODO: this isn't handling skipping numbers appropriately

        static public List<int> GenerateWordCombinations(IEnumerable<char> inputWords)
        {
            List<int> returnList = new List<int>();
            GenerateWordCombinations(inputWords, returnList);
            return returnList;
        }

        static private void GenerateWordCombinations(IEnumerable<char> words, IList<int> combinations)
        {
            if (words.Count() == 0)
            {
                return;
            }

            foreach (var word in words)
            {
                GenerateWordCombinations(words.Where(x => x != word), combinations);
                combinations.Add(word);
            }
        }
    }
}
