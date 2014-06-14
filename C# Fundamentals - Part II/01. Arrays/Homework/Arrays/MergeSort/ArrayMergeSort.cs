namespace ArrayMergeSort
{
    using System;

    public class ArrayMergeSort
    {
        /// <summary>
        /// Write a program that sorts an array of integers using the merge sort algorithm.
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { -2, -5, 0, 6, -12, 13, 18, 23, 290, 50, -30, 1 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            MergeSort(array);

            Console.WriteLine("The sorted array is:");
            Console.WriteLine("{ " + string.Join(", ", array) + " }");
        }

        public static void MergeSort(int[] array)
        {
            if (array.Length > 1)
            {
                MergeSortInternal(array, 0, array.Length - 1);
            }
        }

        protected static void MergeSortInternal(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSortInternal(array, left, middle);
                MergeSortInternal(array, middle + 1, right);

                // Merge
                int[] leftArray = new int[middle - left + 1];
                int[] rightArray = new int[right - middle];

                Array.Copy(array, left, leftArray, 0, middle - left + 1);
                Array.Copy(array, middle + 1, rightArray, 0, right - middle);

                int i = 0;
                int j = 0;
                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        array[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        array[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i] <= rightArray[j])
                    {
                        array[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        array[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }
    }
}
