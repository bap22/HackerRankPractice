using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staircase
{
    class Program
    {
        static void Main(String[] args)
        {
            int _n;
            _n = Convert.ToInt32(Console.ReadLine());

            StairCase(_n);
            Console.ReadLine();
        }

        static void StairCase(int n)
        {
            string pound = "";
            for (int i = 0; i < n; i++)
            {
                pound += "#";
                Console.WriteLine(pound.PadLeft(n));
            }

        }
    }
}
