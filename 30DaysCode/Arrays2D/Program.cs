using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11Arrays2D
{
    /// <summary>
    /// Task 
    ///Calculate the hourglass sum for every hourglass in A, then print the maximum hourglass sum.
    ///
    ///Input Format
    ///
    ///There are 6 lines of input, where each line contains 6 space-separated integers describing 2D Array A; every value in  will be in the inclusive range of -9 to 9.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[6][];
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            int maxHourglassSum = 0;
            int thisHourglassSum = 0;
            int hourglassCount = 1;

            //get the max for all hourglasses. 
            //since we are 6x6, we know we can only go to arr[3][3] and still have an hourglass
            // a b c
            //   d
            // e f g
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    thisHourglassSum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2];
                    thisHourglassSum += arr[i + 1][j + 1];
                    thisHourglassSum += arr[i+2][j] + arr[i + 2][j+1] + arr[i + 2][j+2];
                    
                    if (thisHourglassSum > maxHourglassSum)
                    {
                        maxHourglassSum = thisHourglassSum;
                    }
                    else if (hourglassCount == 1)
                    {
                        maxHourglassSum = thisHourglassSum;
                    }
                    hourglassCount++;
                }
            }

            Console.WriteLine(maxHourglassSum);
            //Console.ReadLine();
        }
    }
}
