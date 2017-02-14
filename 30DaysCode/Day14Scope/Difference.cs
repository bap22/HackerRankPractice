using System;
using System.Linq;

namespace Day14Scope
{

    class Difference
    {
        private int[] elements;
        public int maximumDifference;
        private int minInt;
        private int maxInt;

        public Difference(int[] integerArray)
        {
            elements = integerArray;
            maximumDifference = 0;
            minInt = maxInt = elements[0];
        }

        public int computeDifference()
        {
            foreach (int current in elements)
            {
                if (current > maxInt)
                {
                    maxInt = current;
                }
                if (current < minInt)
                {
                    minInt = current;
                }
                maximumDifference = maxInt - minInt;
            }
            return maximumDifference;
        }
    }
}
