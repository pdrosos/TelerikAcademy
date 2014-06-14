namespace ArrayQuickSort
{
    using System;

    public class ArrayQuickSort
    {
        /// <summary>
        /// Write a program that sorts an array of strings using the quick sort algorithm.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 23, 34, -24, 0, 1, 24, 90, -123, 97, 29, 17, -19 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            QuickSort(array);

            // or alternatively - use the Array.Sort method, which implements the Quick Sort algorithm
            // Array.Sort(array);

            Console.WriteLine("The sorted array is:");
            Console.WriteLine("{ " + string.Join(", ", array) + " }");
        }

        public static void QuickSort(int[] array)
        {
            if (array.Length > 1)
            {
                QuickSortInternal(array, 0, array.Length - 1);
            }
        }

        private static void QuickSortInternal(int[] array, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(array, left, right);

                QuickSortInternal(array, left, q - 1);
                QuickSortInternal(array, q + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    temp = array[j];
                    array[j] = array[i];
                    array[i] = temp;
                    i++;
                }
            }

            array[right] = array[i];
            array[i] = pivot;

            return i;
        }
    }
}
