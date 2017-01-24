using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day26NestedLogic
{
    /// <summary>
    /// Task 
    /// Your local library needs your help! Given the expected and actual return dates for a library book, create a program that calculates the fine(if any). The fee structure is as follows:
    /// If the book is returned on or before the expected return date, no fine will be charged(i.e.: fine = 0.
    /// If the book is returned after the expected return day but still within the same calendar month and year as the expected return date, fine = 15 Hackos * # days late.
    /// If the book is returned after the expected return month but still within the same calendar year as the expected return date, the fine=500 Hackos * num months late.
    /// If the book is returned after the calendar year in which it was expected, there is a fixed fine of 10,000 Hackos.
    /// 
    /// Input format: 1st line is 3 space separated integers, D M Y actual returned. 2nd line expected D M Y.
    /// Output is integer fine
    /// </summary>
    class Solution
    {
        static void Main(String[] args)
        {
            int fine = 0;
            var actualReturn = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            var expectedReturn = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            
            //check year first
            if (actualReturn[2] != expectedReturn[2] && actualReturn[2] > expectedReturn[2])
            {
                fine = 10000;
            }

            //check same calendar month
            else if (actualReturn[2] == expectedReturn[2] && actualReturn[1] != expectedReturn[1] && actualReturn[1] > expectedReturn[1])
            {
                var diffMonths = actualReturn[1] - expectedReturn[1];
                fine = diffMonths * 500;
            }

            //check days
            else if (actualReturn[2] == expectedReturn[2] && actualReturn[1] == expectedReturn[1] && actualReturn[0] != expectedReturn[0] && actualReturn[0] > expectedReturn[0])
            {
                var diffDays = actualReturn[0] - expectedReturn[0];
                fine = diffDays * 15;
            }

            Console.WriteLine(fine);
            //Console.ReadLine();
        }
    }
}
