using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20Sorting
{
    class Program
    {
        /// <summary>
        /// with input: # of ints, then an int array space separated, for example:
        /// 3
        /// 3 2 1
        /// 
        /// output: Array is sorted in 3 swaps.
        /// First Element: 1
        /// Last Element: 3
        /// </summary>
        /// <param name="args"></param>

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int totalSwaps = 0;

            for (int i = 0; i < n; i++)
            {
                // Track number of elements swapped during a single array traversal
                int numberOfSwaps = 0;

                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        swap(ref a[j], ref a[j + 1]);
                        numberOfSwaps++;
                    }
                }

                // If no elements were swapped during a traversal, array is sorted
                if (numberOfSwaps == 0)
                {
                    break;
                }
                totalSwaps += numberOfSwaps;
            }
            var length = a.Length;
            Console.WriteLine($"Array is sorted in {totalSwaps} swaps.");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a[length - 1]}");

            //Console.ReadLine();


        }

        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
