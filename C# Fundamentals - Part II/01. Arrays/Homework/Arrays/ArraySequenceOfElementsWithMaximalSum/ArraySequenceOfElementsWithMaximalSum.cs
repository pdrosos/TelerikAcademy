namespace ArraySequenceOfElementsWithMaximalSum
{
    using System;
    using System.Linq;

    public class ArraySequenceOfElementsWithMaximalSum
    {
        /// <summary>
        /// Write a program that finds the sequence of maximal sum in given array. 
        /// Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            int maxSum = 0;
            int startIndex = 0;
            int endIndex = 0;

            maxSum = SequenceWithMaximalSum(array, out startIndex, out endIndex);

            Console.WriteLine("The subsequence with maximal sum {0} is: ", maxSum);
            Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(endIndex - startIndex + 1)) + " }");

            maxSum = SequenceWithMaximalSum(array, out startIndex, out endIndex, true);

            Console.WriteLine("The longest subsequence with maximal sum {0} is: ", maxSum);
            Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(endIndex - startIndex + 1)) + " }");
        }

        /// <summary>
        /// This method finds the first sequence of elements with maximal sum in an array
        /// and returns the sum, the start index and the end index of the sequence
        /// If longestSequence = true, it returns the first longest sequence with maximal sum
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="startIndex">Start index</param>
        /// <param name="endIndex">End index</param>
        /// <param name="longestSequence">Find the longest sequence</param>
        /// <returns>The maximal sum</returns>
        public static int SequenceWithMaximalSum(int[] array, out int startIndex, out int endIndex, bool longestSequence = false)
        {
            int maxSum = int.MinValue;
            int currentSum = 0;

            int currentStartIndex = 0;
            startIndex = 0;
            endIndex = 0;

            bool isCurrentSumBigger = false;

            for (int index = 0; index < array.Length; index++)
            {
                currentSum += array[index];
                
                // if the sum is equal, choose the one with more elements
                if (longestSequence == true)
                {
                    isCurrentSumBigger = currentSum > maxSum || (currentSum == maxSum && (endIndex - startIndex) < (index - currentStartIndex));
                }
                else
                {
                    isCurrentSumBigger = currentSum > maxSum;
                }

                if (isCurrentSumBigger)
                {
                    maxSum = currentSum;
                    startIndex = currentStartIndex;
                    endIndex = index;
                }

                if (currentSum < 0)
                {
                    currentSum = 0;
                    currentStartIndex = index + 1;
                }
            }

            return maxSum;
        }
    }
}