using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchPairs
{

    /// <summary>
    /// given array of numbers, find how many pairs have the difference k
    /// </summary>
    class Program
    {
        /* Head ends here */
        static int pairs(int[] a, int k)
        {
            var len = a.Length;
            var ret = 0;

            //TOO SLOW!

            //foreach (IEnumerable<int> permutation in PermuteUtils.Permute<int>(a, 2))
            //{
            //    if(permutation.ElementAt(0) - permutation.ElementAt(1) == k)
            //    {
            //        ret++;
            //    }
            //}

            //fastest way is to sort the array (perhaps with a quicksort?) then continue and break when we can.
            Array.Sort(a);
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i+1; j < len; j++)
                {
                    if ((a[j] - a[i]) < k) continue;
                    if ((a[j] - a[i]) == k) { ret++; break; }
                    if ((a[j] - a[i]) > k) break;
                }

            }
            return ret;
        }

        /* Tail starts here */
        static void Main(String[] args)
        {
            int res;

            String line = Console.ReadLine();
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }

            res = pairs(_a, _k);
            Console.WriteLine(res);

            //ShowPermutations<int>(_a, 2);
            //Console.ReadLine();

        }

        // Print out the permutations of the input 
        static void ShowPermutations<T>(IEnumerable<T> input, int count)
        {
            foreach (IEnumerable<T> permutation in PermuteUtils.Permute<T>(input, count))
            {
                foreach (T i in permutation)
                {
                    Console.Write(" " + i);
                }
                Console.WriteLine();
            }
        }
    }

    public class PermuteUtils
    {
        // Returns an enumeration of enumerators, one for each permutation
        // of the input.
        public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list, int count)
        {
            if (count == 0)
            {
                yield return new T[0];
            }
            else
            {
                int startingElementIndex = 0;
                foreach (T startingElement in list)
                {
                    IEnumerable<T> remainingItems = AllExcept(list, startingElementIndex);

                    foreach (IEnumerable<T> permutationOfRemainder in Permute(remainingItems, count - 1))
                    {
                        yield return Concat<T>(
                            new T[] { startingElement },
                            permutationOfRemainder);
                    }
                    startingElementIndex += 1;
                }
            }
        }

        // Enumerates over contents of both lists.
        public static IEnumerable<T> Concat<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            foreach (T item in a) { yield return item; }
            foreach (T item in b) { yield return item; }
        }

        // Enumerates over all items in the input, skipping over the item
        // with the specified offset.
        public static IEnumerable<T> AllExcept<T>(IEnumerable<T> input, int indexToSkip)
        {
            int index = 0;
            foreach (T item in input)
            {
                if (index != indexToSkip) yield return item;
                index += 1;
            }
        }
    }
}



