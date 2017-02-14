using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestBoatTrips
{
    /// <summary>
    /// ///https://www.hackerrank.com/contests/w28/challenges/boat-trip
    /// Alice owns a company that transports tour groups between two islands. She has n trips booked, and each trip i has p passengers. Alice has m boats for transporting people, and each boat's maximum capacity is c passengers.

    ///Given the number of passengers going on each trip, determine whether or not Alice can perform all n trips using no more than m boats per individual trip.If this is possible, print Yes; otherwise, print No.
    /// </summary>
    class Program
    {
        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);//trips booked
            int c = Convert.ToInt32(tokens_n[1]);//capacity of each boat
            int m = Convert.ToInt32(tokens_n[2]);//number of boats
            string[] p_temp = Console.ReadLine().Split(' ');
            int[] p = Array.ConvertAll(p_temp, Int32.Parse);//each trips number of passengers
            if (bookable(c*m, p))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadLine();//not submitted for contest
        }

        public static bool bookable(int total, int[] p, int tripNum = 0)
        {
            if (p[tripNum] > total)
            {
                return false;
            }
            if (tripNum == p.Length - 1)
            {
                return true;
            }
            return bookable(total, p, ++tripNum);
        }
    }
}
