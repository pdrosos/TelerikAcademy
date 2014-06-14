namespace ArraySequenceOfGivenSum
{
    using System;
    using System.Linq;
    
    public class ArraySequenceOfGivenSum
    {
        /// <summary>
        /// Write a program that finds in given array of integers a sequence of given sum S (if present). 
        /// Example: {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 4, 3, 1, 4, 2, 5, 8 };
            int sum = 11;

            Console.WriteLine("{ " + string.Join(", ", array) + " }");           

            int startIndex = 0;
            int sequenceLength = SequenceWithGivenSum(array, sum, out startIndex);

            if (sequenceLength > 0)
            {
                Console.WriteLine(
                    "The first sequence with sum {0} starts with element {1} on index {2} and has length {3}",
                    sum,
                    array[startIndex],
                    startIndex,
                    sequenceLength);

                Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(sequenceLength)) + " }");

                sequenceLength = SequenceWithGivenSum(array, sum, out startIndex, false);
                Console.WriteLine(
                    "The last sequence with sum {0} starts with element {1} on index {2} and has length {3}",
                    sum,
                    array[startIndex],
                    startIndex,
                    sequenceLength);

                Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(sequenceLength)) + " }");
            }
            else
            {
                Console.WriteLine("There are no sequence with sum {0}.", sum);
            }

            // test with array with positive numbers
            Console.WriteLine();
            Console.WriteLine("Test with positive array:");
            int[] positiveArray = { 4, 3, 1, 4, 2, 5, 8 };
            sum = 11;

            Console.WriteLine("{ " + string.Join(", ", positiveArray) + " }");

            sequenceLength = PositiveArraySequenceWithGivenSum(positiveArray, sum, out startIndex);

            if (sequenceLength > 0)
            {
                Console.WriteLine(
                    "The sequence with sum {0} starts with element {1} on index {2} and has length {3}",
                    sum,
                    positiveArray[startIndex],
                    startIndex,
                    sequenceLength);

                Console.WriteLine("{ " + string.Join(", ", positiveArray.Skip(startIndex).Take(sequenceLength)) + " }");
            }
            else
            {
                Console.WriteLine("There are no sequence with sum {0}.", sum);
            }
        }

        /// <summary>
        /// This method finds the first sequence of elements with given sum in an array
        /// and returns the length and the start index of the sequence
        /// If firstOccurence = false, it returns the last sequence with this sum
        /// </summary>
        public static int SequenceWithGivenSum(int[] array, int sum, out int startIndex, bool firstOccurence = true)
        {
            startIndex = 0;
            int length = 0;
            int currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentSum = 0;

                for (int j = i; j < array.Length; j++)
                {
                    currentSum += array[j];

                    if (currentSum == sum)
                    {
                        startIndex = i;

                        if (firstOccurence)
                        {
                            return j - i + 1;
                        }
                        else
                        {
                            length = j - i + 1;
                        }
                    }
                }
            }
            
            return length;
        }

        /// <summary>
        /// This method finds the first sequence of elements with given sum in an array
        /// and returns the length and the start index of the sequence.
        /// It works only for array with positive elements!
        /// </summary>
        public static int PositiveArraySequenceWithGivenSum(int[] array, int sum, out int startIndex)
        {
            startIndex = 0;
            int currentIndex = 0;

            int length = 0;            
            int currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];

                if (currentSum > sum)
                {
                    while (currentSum > sum)
                    {
                        currentSum -= array[currentIndex];

                        currentIndex++;
                    }
                }

                if (currentSum == sum)
                {
                    startIndex = currentIndex;
                    length = i - currentIndex + 1;

                    return length;
                }
            }

            return length;
        }
    }
}