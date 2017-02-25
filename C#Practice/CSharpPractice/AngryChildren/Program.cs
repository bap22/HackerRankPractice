using System;

namespace AngryChildren
{
    /// <summary>
    /// Bill Gates is on one of his philanthropic journeys to a village in Utopia. He has N packets of candies and would like to distribute one packet to each of the K children in the village (each packet may contain different number of candies). To avoid a fight between the children, he would like to pick K out of N packets such that the unfairness is minimized.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            long nNumCandyPackets = long.Parse(Console.ReadLine());
            long kNumChildren = long.Parse(Console.ReadLine());
            
            //init array of candy packets
            long[] numCandies = new long[nNumCandyPackets];
            //put the input into the array
            for (long i = 0; i < nNumCandyPackets; i++)
            {
                numCandies[i] = long.Parse(Console.ReadLine());
            }                
            //now we have a sorted arry of the candy packets
            Array.Sort(numCandies);

            //unfairness definition is a summation: https://www.hackerrank.com/challenges/angry-children-2
            long total = 0;
            long unFairness = 0;
            long finalTallyUnfairness = 0;

            for (long i = 0; i < kNumChildren; i++)
            {
                unFairness += ((numCandies[i] * i) - total);
                total += numCandies[i];
            }

            finalTallyUnfairness = unFairness;


            for (long i = kNumChildren; i < nNumCandyPackets; i++)
            {
                total -= numCandies[i - kNumChildren];
                unFairness -= (total - (numCandies[i - kNumChildren] * (kNumChildren - 1)));

                unFairness += ((numCandies[i] * (kNumChildren - 1)) - total);
                total += numCandies[i];
                
                //we want to minimize unfairness, so if this unfairness is less than current FinalUnfairness...
                if (unFairness < finalTallyUnfairness)
                {
                    finalTallyUnfairness = unFairness;
                }
            }

            Console.WriteLine(finalTallyUnfairness);

        }
    }
}