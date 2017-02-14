using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day29BitwiseAnd
{
    /// <summary>
    /// Task : Given set S = {1,2,3,....N}. Find two integers, A and B (where A less than B), 
    /// from set S such that the value of A&B is the maximum possible and also 
    /// less than a given integer, K. In this case, & represents the bitwise AND operator.
    /// </summary>
    class Solution
    {
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
            }
        }
    }
}
