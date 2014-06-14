namespace ArrayMaximalSequenceOfEqualElements
{
    using System;
    using System.Linq;
    
    public class ArrayMaximalSequenceOfEqualElements
    {
        /// <summary>
        /// Write a program that finds the maximal sequence of equal elements in an array.
        /// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            int startIndex = 0;
            int maxSequenceLength = MaximalSequenceOfEqualElements(array, out startIndex);

            if (maxSequenceLength > 0)
            {
                Console.WriteLine(
                    "The first maximal sequence of equal elements starts with element {0} on index {1} and has length {2}",
                    array[startIndex], 
                    startIndex,
                    maxSequenceLength);

                Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(maxSequenceLength)) + " }");

                maxSequenceLength = MaximalSequenceOfEqualElements(array, out startIndex, false);
                Console.WriteLine(
                    "The last maximal sequence of equal elements starts with element {0} on index {1} and has length {2}",
                    array[startIndex], 
                    startIndex,
                    maxSequenceLength);

                Console.WriteLine("{ " + string.Join(", ", array.Skip(startIndex).Take(maxSequenceLength)) + " }");
            }
            else
            {
                Console.WriteLine("There are no sequence of equal elements.");
            }
        }

        /// <summary>
        /// This method finds the first maximal sequence of equal elements in an array
        /// and returns the sequence length and the start index of the sequence
        /// If firstOccurence = false, it returns the last maximal sequence of equal elements
        /// If the array has equal elements - it returns the whole array's length
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="startIndex">Start index</param>
        /// <param name="firstOccurence">Find the first occurence</param>
        /// <returns>The length of the maximal sequence</returns>
        public static int MaximalSequenceOfEqualElements(int[] array, out int startIndex, bool firstOccurence = true)
        {
            startIndex = 0;
            int length = 0;

            int currentStart = 0;
            int currentLength = 0;
            bool isCurrentSequenceLonger = false;

            for (int i = 1; i < array.Length; i++)
            {
                // new sequence
                if (array[i] != array[i - 1])
                {
                    currentStart = i;
                    currentLength = 0;
                }
                else
                {
                    // the sequence continues
                    currentLength++;
                    
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
            }

            if (length > 0)
            {
                length++;
            }

            return length;
        }
    }
}
