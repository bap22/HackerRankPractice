using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlayground
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            bool stillGoing = true;
            var dictionary = new Dictionary<string, string>();
            var numEntries = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numEntries; i++)
            {
                var entry = Console.ReadLine().Split(' ');
                var name = entry[0];
                var phone = entry[1];
                dictionary.Add(name,phone);
            }

            //now print number as many times as a new entry is put in
            while (stillGoing)
            {
                string phoneFound = "";
                var nameToFind = Console.ReadLine();
                if (dictionary.TryGetValue(nameToFind, out phoneFound) != null)
                {
                    Console.WriteLine($"{nameToFind}={phoneFound}");
                }
                else
                {
                    Console.WriteLine("Not found");
                }

            }
        }
    }
}
