using System;

namespace InsertionSort
{
    /// <summary>
    /// Input Format: There will be two lines of input: the size of the array and the unsorted array of integers
    /// Output Format: On each line, output the entire array every time an item is shifted in it.
    /// Sample input:
    /// 5
    /// 2 4 6 8 3
    /// Sample output:
    /// 2 4 6 8 8 
    /// 2 4 6 6 8 
    /// 2 4 4 6 8 
    /// 2 3 4 6 8 
    /// </summary>
    class Program
    {
        static void insertionSort(int[] ar)
        {
            var lastPosition = ar.Length;
            var breakNow = false;
            var elementToInsert = ar[lastPosition - 1];
            for (int i = lastPosition - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    ar[0] = elementToInsert;
                }
                else if (elementToInsert < ar[i - 1])
                {
                    ar[i] = ar[i - 1];
                }
                else
                {
                    ar[i] = elementToInsert;
                    //we are done, so kill the loop
                    breakNow = true;
                }
                Console.WriteLine(string.Join(" ", ar));
                if (breakNow)
                {
                    break;
                }
            }
        }

        public static void MergeSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(input, left, middle);
                MergeSort(input, middle + 1, right);

                //Merge
                int[] leftArray = new int[middle - left + 1];
                int[] rightArray = new int[right - middle];

                Array.Copy(input, left, leftArray, 0, middle - left + 1);
                Array.Copy(input, middle + 1, rightArray, 0, right - middle);

                int i = 0;
                int j = 0;
                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i] <= rightArray[j])
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }

        /* Tail starts here */
        static void Main(String[] args)
        {

            int _ar_size;
            _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            insertionSort(_ar);

            Console.ReadLine();
        }
    }
}
