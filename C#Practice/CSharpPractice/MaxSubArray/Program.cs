using System;
using System.Collections.Generic;
using System.Linq;
namespace MaxSubArray
{
    class Solution
    {
        static void Main(String[] args)
        {
            //if all elements are positive, just add them
            //if there are negatives, figure out max from connecting ints
            //for non-contiguous, just sum all positives

            int numTestCases = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numTestCases; i++)
            {
                Console.ReadLine(); //skip the number of elements in array, we dont care.
                var fullArray = Console.ReadLine().Trim().Split(' ').Select(x => Int32.Parse(x)).ToArray();
                //var fullArray = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);

                var currentContiguous = 0;
                var maxNonContiguous = 0;
                var maxContiguous = 0;

                //contiguous
                foreach (int num in fullArray)
                {
                    currentContiguous += num;
                    maxContiguous = Math.Max(maxContiguous, currentContiguous);
                    currentContiguous = Math.Max(0, currentContiguous);
                }

                //non-contiguous
                var containsPositives = fullArray.Where(x => x > 0).Any();
                if (containsPositives)
                {
                    maxNonContiguous = fullArray.Where(x => x > 0).Sum();//per instructions this is sum of all positives
                }
                else //all negatives, get the largest single as a subarray
                {
                    Array.Sort(fullArray);
                    maxNonContiguous = fullArray[fullArray.Length - 1];
                }

                if (maxContiguous == 0)
                {
                    maxContiguous = fullArray.Max();
                }

                Console.WriteLine(maxContiguous + " " + maxNonContiguous);
            }

            Console.ReadLine();

        }
    }
}

