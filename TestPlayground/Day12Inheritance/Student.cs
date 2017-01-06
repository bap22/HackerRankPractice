using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12Inheritance
{
    class Student : Person
    {
        private int[] testScores;

        public Student(string fName , string lName , int id , int[] scores )
        {
            firstName = fName;
            lastName = lName;
            this.id = id;
            testScores = scores;
        }

        public char calculate()
        {
            int length = testScores.Length;
            int sum = testScores.Sum();
            double average = sum/length;
            if (average >= 90)
            {
                return 'O';
            }
            else if (average >= 80)
            {
                return 'E';
            }
            else if (average >= 70)
            {
                return 'A';
            }
            else if (average >= 55)
            {
                return 'P';
            }
            else if (average >= 40)
            {
                return 'D';
            }
            else
            {
                return 'T';
            }
        }

    }
}
