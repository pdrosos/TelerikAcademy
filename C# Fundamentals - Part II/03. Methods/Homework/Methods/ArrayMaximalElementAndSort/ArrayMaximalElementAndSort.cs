namespace ArrayMaximalElementAndSort
{
    using System;

    public class ArrayMaximalElementAndSort
    {
        /// <summary>
        /// Write a method that return the maximal element in a portion of array of integers starting at given index. 
        /// Using it write another method that sorts an array in ascending / descending order.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 2, 3, 5, -5, 8, -7, 3, 4, 0, 2 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            int maxElementIndex;
            int maxElement = MaxElement(array, 0, array.Length - 1, out maxElementIndex);
            Console.WriteLine("Max element: {0} on index {1}", maxElement, maxElementIndex);

            ArraySortAsc(array);
            Console.WriteLine("Ascending sort: { " + string.Join(", ", array) + " }");

            ArraySortDesc(array);
            Console.WriteLine("Descending sort: { " + string.Join(", ", array) + " }");            
        }

        public static int MaxElement(int[] numbers, int startIndex, int endIndex, out int maxElementIndex)
        {
            int maxElement = int.MinValue;
            maxElementIndex = startIndex;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (numbers[i] > maxElement)
                {
                    maxElement = numbers[i];
                    maxElementIndex = i;
                }
            }

            return maxElement;
        }

        public static void ArraySortDesc(int[] numbers)
        {
            int tempElement;
            int maxElementIndex;

            for (int i = 0; i < numbers.Length; i++)
            {
                tempElement = numbers[i];
                numbers[i] = MaxElement(numbers, i, numbers.Length - 1, out maxElementIndex);
                numbers[maxElementIndex] = tempElement;
            }
        }

        public static void ArraySortAsc(int[] numbers)
        {
            int tempElement;
            int maxElementIndex;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                tempElement = numbers[i];
                numbers[i] = MaxElement(numbers, 0, i, out maxElementIndex);
                numbers[maxElementIndex] = tempElement;
            }
        }
    }
}
