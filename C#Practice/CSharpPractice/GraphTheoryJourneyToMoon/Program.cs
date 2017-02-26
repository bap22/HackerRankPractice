using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryJourneyToMoon
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/journey-to-the-moon
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Trim().Split(' ');
            var numAstronauts = Int32.Parse(line1[0]);
            var numPairs = Int32.Parse(line1[1]);

            //is the number of subsets of given size of N 2^N? NOPE
            //Console.WriteLine(Math.Pow(2.0, (double)numPairs));

            //i take no credit for this, just learning and practicing. this was found on leaderboard.

            var sets = new List<HashSet<long>>();
            for (int i=0; i < numPairs; i++)
            {
                var astros = Console.ReadLine().Split(' ');
                long A = Int64.Parse(astros[0]);
                long B = Int64.Parse(astros[1]);

                bool exists = false;
                bool hasA = false;
                bool hasB = false;
                int aSetIndex = -1;
                int bSetIndex = -1;

                for (int j = 0; j < sets.Count; j++)
                {

                    if (sets[j].Contains(A))
                    {
                        exists = true;
                        hasA = true;
                        aSetIndex = j;
                    }

                    else if (sets[j].Contains(B))
                    {
                        exists = true;
                        bSetIndex = j;
                        hasB = true;
                    }
                }

                //check if we need to combine two sets
                if (hasA && hasB)
                {
                    sets[aSetIndex].UnionWith(sets[bSetIndex]);
                    sets[bSetIndex].Clear();
                }

                else if (hasA || hasB)
                {
                    if (hasA) sets[aSetIndex].Add(B);
                    if (hasB) sets[bSetIndex].Add(A);
                }

                if (!exists)
                {
                    var newCountry = new HashSet<long>();
                    newCountry.Add(A);
                    newCountry.Add(B);
                    sets.Add(newCountry);
                }
            }
            long combination = (numAstronauts * (numAstronauts - 1)) / 2;

            //we overcounted
            foreach (var set in sets)
            {
                if (set.Count == 0) continue;
                combination -= (set.Count * (set.Count - 1)) / 2;
            }

            Console.WriteLine(combination);
        }
    }
}