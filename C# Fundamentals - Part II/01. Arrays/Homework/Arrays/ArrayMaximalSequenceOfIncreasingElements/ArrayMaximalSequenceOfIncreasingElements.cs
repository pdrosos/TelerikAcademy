namespace ArrayMaximalSequenceOfIncreasingElements
{
    using System;
    using System.Linq;
    
    public class ArrayMaximalSequenceOfIncreasingElements
    {
        /// <summary>
        /// Write a program that finds the maximal increasing sequence in an array. 
        /// Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 3, 2, 3, 4, 2, 2, 4 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");
            
            int startIndex = 0;
            int maxSequenceLength = MaximalSequenceOfIncreasingElements(array, out startIndex);

            if (maxSequenceLength > 0)
            {
                Console.WriteLine(
                    "The first maximal sequence of increasing elements starts with element {0} on index {1} and has length {2}",
                    array[startIndex],
                    startIndex,
                    maxSequenceLength);

                Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(maxSequenceLength)) + " }");

                maxSequenceLength = MaximalSequenceOfIncreasingElements(array, out startIndex, false);
                Console.WriteLine(
                    "The last maximal sequence of increasing elements starts with element {0} on index {1} and has length {2}",
                    array[startIndex],
                    startIndex,
                    maxSequenceLength);

                Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(maxSequenceLength)) + " }");
            }
            else
            {
                Console.WriteLine("There are no sequence of increasing elements.");
            }
        }

        /// <summary>
        /// This method finds the first maximal sequence of increasing elements in an array
        /// and returns the maximal sequence length and start index of the sequence
        /// If firstOccurence = false, it returns the last maximal sequence of increasing elements
        /// If increasingWithOne = true, it finds sequences, increasing with exactly one
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="startIndex">Start index</param>
        /// <param name="firstOccurence">Find the first occurence</param>
        /// <param name="increasingWithOne">The sequence increases with one</param>
        /// <returns>The length of the maximal sequence</returns>
        public static int MaximalSequenceOfIncreasingElements(int[] array, out int startIndex, bool firstOccurence = true, bool increasingWithOne = false)
        {
            startIndex = 0;
            int length = 0;

            int currentStart = 0;
            int currentLength = 0;
            bool isCurrentElementIncreasing = false;

            for (int i = 1; i < array.Length; i++)
            {
                if (increasingWithOne == true)
                {
                    isCurrentElementIncreasing = array[i] == array[i - 1] + 1;
                }
                else
                {
                    isCurrentElementIncreasing = array[i] > array[i - 1];
                }

                // the sequence continues
                if (isCurrentElementIncreasing)
                {
                    currentLength++;

                    bool isCurrentSequenceLonger;
                    if (firstOccurence == true)
                    {
                        isCurrentSequenceLonger = currentLength > length;
                    }
                    else
                    {
                        isCurrentSequenceLonger = currentLength >= length;
                    }

                    if (isCurrentSequenceLonger)
                    {
                        startIndex = currentStart;
                        length = currentLength;
                    }
                }
                else
                {
                    // new sequence
                    currentStart = i;
                    currentLength = 0;
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
