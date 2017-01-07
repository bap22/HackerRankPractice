using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13AbstractClasses
{
    /// <summary>
    /// sample input
    /// The Alchemist
    /// Paulo Coelho
    /// 248
    /// 
    /// sample output
    /// Title: The Alchemist
    /// Author: Paulo Coelho
    /// Price: 248
    /// </summary>
    class Program
    {
        static void Main(String[] args)
        {
            String title = Console.ReadLine();
            String author = Console.ReadLine();
            int price = Int32.Parse(Console.ReadLine());
            Book new_novel = new MyBook(title, author, price);
            new_novel.display();
        }
    }
}
