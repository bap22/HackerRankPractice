using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = Console.ReadLine();
            try
            {
                int n = Convert.ToInt32(S);
                Console.WriteLine(n);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bad String");
            }
        }
    }
}
