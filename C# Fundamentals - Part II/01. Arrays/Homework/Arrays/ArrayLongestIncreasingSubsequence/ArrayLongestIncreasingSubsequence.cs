namespace ArrayLongestIncreasingSubsequence
{
    using System;
    using System.Linq;
    
    public class ArrayLongestIncreasingSubsequence
    {
        /// <summary>
        /// Write a program that reads an array of integers and removes from it a minimal number of elements 
        /// in such way that the remaining array is sorted in increasing order. 
        /// Print the remaining sorted array. 
        /// Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter array length:");
            int arrayLength = int.Parse(Console.ReadLine());

            int[] array = new int[arrayLength];

            Console.WriteLine("Please, enter array elements (integers):");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int[] longestIncreasingSubsequence = LongestIncreasingSubsequence(array);
            Console.WriteLine("The longest increasing subsequence in {" + string.Join(", ", array) + "} is:");
            Console.WriteLine("{" + string.Join(", ", longestIncreasingSubsequence) + "}");
        }

        public static int[] LongestIncreasingSubsequence(int[] array)
        {
            // search the longest increasing subsequence using Dynamic Programming
            int[] increasingLengths = new int[array.Length];
            increasingLengths[0] = 1;

            for (int i = 1; i < increasingLengths.Length; i++)
            {
                int maxLength = 0;

                for (int j = 0; j < i; j++)
                {
                    if (array[j] <= array[i] && increasingLengths[j] > maxLength)
                    {
                        maxLength = increasingLengths[j];
                    }
                }

                increasingLengths[i] = maxLength + 1;
            }

            // build the longest increasing subsequence
            int[] reversedSubsequence = new int[increasingLengths.Max()];
            int serialNumber = increasingLengths.Max();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (serialNumber == increasingLengths[i])
                {
                    reversedSubsequence[serialNumber - 1] = array[i];

                    serialNumber--;
                }
            }

            return reversedSubsequence;
        }
    }
}
