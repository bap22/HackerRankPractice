using System;
using System.Collections.Generic;
using System.IO;

namespace LonelyInteger
{
    /// <summary>
    /// Print the unique number that occurs only once in N on a new line.
    /// Constraint: N is odd length, numbers are between 0 and 100
    /// Sample Input:
    /// 5
    /// 0 0 1 2 1
    /// Output:
    /// 2
    /// </summary>
    class Program
    {
        static int lonelyinteger(int[] a)
        {
            //temp array
            var temp = new int[100];
            foreach (int test in a)
            {
                temp[test] = temp[test] + 1;
            }
            var index = Array.FindIndex(temp, x=> x==1);// Define the Predicate<T> delegate.
            return index;
        }
        static void Main(String[] args)
        {
            int res;

            int _a_size = Convert.ToInt32(Console.ReadLine());
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }
            res = lonelyinteger(_a);
            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}
