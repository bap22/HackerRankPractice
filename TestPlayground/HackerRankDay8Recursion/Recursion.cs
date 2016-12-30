using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int num = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"{factorial(num)}");

    }
    public static int factorial(int number)
    {
        if (number != 1)
        {
            return number*factorial(number - 1);
        }
        else
        {
            return number;
        }
    }
}