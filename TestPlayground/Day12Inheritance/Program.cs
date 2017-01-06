using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12Inheritance
{
    /// <summary>
    /// SAMPLE INPUT:
    /// Heraldo Memelli 8135627
    /// 2
    /// 100 80
    /// 
    /// SAMPLE OUTPUT:
    /// Name: Memelli, Heraldo
    /// ID: 8135627
    /// Grade: O
    /// 
    /// GRADES:
    /// 90-100 = O
    /// 80-89 = E
    /// 70-79 = A
    /// 55-69 = P
    /// 40-54 = D
    /// 0-39 = T
    /// </summary>
    class Program
    {
        static void Main()
        {
            string[] inputs = Console.ReadLine().Split();
            string firstName = inputs[0];
            string lastName = inputs[1];
            int id = Convert.ToInt32(inputs[2]);
            int numScores = Convert.ToInt32(Console.ReadLine());
            inputs = Console.ReadLine().Split();
            int[] scores = new int[numScores];
            for (int i = 0; i < numScores; i++)
            {
                scores[i] = Convert.ToInt32(inputs[i]);
            }

            Student s = new Student(firstName, lastName, id, scores);
            s.printPerson();
            Console.WriteLine("Grade: " + s.calculate() + "\n");
        }
    }
}
