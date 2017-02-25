using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static void partition(int[] array)
    {
        int pivot = array[0];
        List<int> left = array.Where(x => x < pivot).ToList();
        List<int> right = array.Where(x => x > pivot).ToList();

        left.Add(pivot);
        left.AddRange(right);

        Console.WriteLine(String.Concat(left.Select(x => x.ToString() + " ")));
    }

    static void Main(String[] args)
    {
        //a more efficient way?
        //Console.ReadLine();
        //Partition(Console.ReadLine().Trim().Split(' ').Select(x => Int32.Parse(x)).ToArray());

        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int[] _ar = new int[_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
        {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }

        partition(_ar);
    }
}