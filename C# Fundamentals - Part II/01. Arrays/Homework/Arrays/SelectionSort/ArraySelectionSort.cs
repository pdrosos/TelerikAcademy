namespace ArraySelectionSort
{
    using System;
    
    public class ArraySelectionSort
    {
        /// <summary>
        /// Write a program to sort an array. Use the "selection sort" algorithm
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 2, 4, -3, 0, 0, 5, 11, -9, 23, 18, 7 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            SelectionSort(array);
            
            Console.WriteLine("{ " + string.Join(", ", array) + " }");
        }

        public static void SelectionSort(int[] array)
        {
            int currentIndex;
            int currentElement;

            for (int j = 0; j < array.Length - 1; j++)
            {
                currentIndex = j;

                for (int k = j + 1; k < array.Length; k++)
                {
                    if (array[k] < array[currentIndex])
                    {
                        currentIndex = k;
                    }
                }

                currentElement = array[currentIndex];
                array[currentIndex] = array[j];
                array[j] = currentElement;
            }
        }
    }
}
