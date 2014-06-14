namespace ArraySequenceOfKElementsWithMaximalSum
{
    using System;
    using System.Linq;
    
    public class ArraySequenceOfKElementsWithMaximalSum
    {
        /// <summary>
        /// Write a program that reads two integer numbers N and K and an array of N elements from the console.
        /// Find in the array those K elements that have maximal sum.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter array length:");
            int arrayLength = int.Parse(Console.ReadLine());
            Console.WriteLine("Please, enter sequence length of array elements:");
            int sequenceLength = int.Parse(Console.ReadLine());

            int[] array = new int[arrayLength];

            Console.WriteLine("Please, enter array elements (integers):");
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            int startIndex = 0;
            Console.WriteLine(
                "The first sequence with length {0} with maximal sum has sum {1} and starts from index {2}",
                sequenceLength,
                SequenceWithMaximalSum(array, sequenceLength, out startIndex),
                startIndex);

            Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(sequenceLength)) + " }");

            Console.WriteLine(
                "The last sequence with length {0} with maximal sum has sum {1} and starts from index {2}",
                sequenceLength,
                SequenceWithMaximalSum(array, sequenceLength, out startIndex, false),
                startIndex);

            Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(sequenceLength)) + " }");
        }

        /// <summary>
        /// This method finds the first sequence of sequenceLength elements with maximal sum in an array
        /// and returns the sum and the start index of the sequence
        /// If firstOccurence = false, it returns the last sequence with maximal sum
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="sequenceLength">Sequence length</param>
        /// <param name="startIndex">Start index</param>
        /// <param name="firstOccurence">Find the first occurence</param>
        /// <returns>The maximal sum of the sequence</returns>
        public static int SequenceWithMaximalSum(int[] array, int sequenceLength, out int startIndex, bool firstOccurence = true)
        {
            startIndex = 0;
            int sum = 0;
            int currentSum = 0;

            for (int i = 0; i < sequenceLength; i++)
            {
                currentSum += array[i];
            }

            sum = currentSum;
            bool isCurrentSumBigger = false;

            for (int i = 1; i <= array.Length - sequenceLength; i++)
            {
                currentSum = currentSum - array[i - 1] + array[i + sequenceLength - 1];

                if (firstOccurence == true)
                {
                    isCurrentSumBigger = currentSum > sum;
                }
                else
                {
                    isCurrentSumBigger = currentSum >= sum;
                }

                if (isCurrentSumBigger == true)
                {
                    startIndex = i;
                    sum = currentSum;
                }
            }

            return sum;            
        }
    }
}
