namespace ArrayMostFrequentNumber
{
    using System;
    
    public class ArrayMostFrequentNumber
    {
        /**
         * Write a program that finds the most frequent number in an array. 
         * Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
         */
        public static void Main(string[] args)
        {
            int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            Array.Sort(array);

            int startIndex = 0;
            int maxSequenceLength = FindMaximalSequenceOfEqualElements(array, out startIndex);

            if (maxSequenceLength > 0)
            {
                Console.WriteLine("The most frequent element in the array is {0} ({1} times)",  array[startIndex], maxSequenceLength);
            }
            else
            {
                Console.WriteLine("There are no repeating elements.");
            }
        }

        /// <summary>
        /// This method finds the most frequent number in an array
        /// and returns the number and the count of the occurences.
        /// If the array has equal elements - it returns the whole array's length
        /// </summary>
        /// <param name="sortedArray">Sorted array</param>
        /// <param name="startIndex">Start index</param>
        /// <returns>The count of the most frequent number</returns>
        public static int FindMaximalSequenceOfEqualElements(int[] sortedArray, out int startIndex)
        {
            startIndex = 0;
            int length = 0;

            int currentStart = 0;
            int currentLength = 0;

            for (int i = 1; i < sortedArray.Length; i++)
            {
                // new sequence
                if (sortedArray[i] != sortedArray[i - 1])
                {
                    currentStart = i;
                    currentLength = 0;
                }
                else
                {
                    // the sequence continues
                    currentLength++;
                    
                    if (currentLength > length)
                    {
                        startIndex = currentStart;
                        length = currentLength;
                    }
                }
            }

            if (length > 0)
            {
                length++;
            }

            return length;
        }
    }
}
