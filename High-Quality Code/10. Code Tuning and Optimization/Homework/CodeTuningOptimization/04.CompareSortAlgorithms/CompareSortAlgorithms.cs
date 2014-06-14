namespace CompareSortAlgorithms
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    
    public static class CompareSortAlgorithms
    {
        public static readonly Stopwatch Stopwatch = new Stopwatch();

        public static readonly Random Random = new Random(0);

        public static void DisplayExecutionTime(string title, Action action)
        {
            Console.Write("{0, -30}", title);
            Stopwatch.Restart();

            action();

            Stopwatch.Stop();
            Console.WriteLine(Stopwatch.Elapsed);
        }

        public static void Shuffle<T>(this T[] arr)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                Swap(ref arr[i], ref arr[Random.Next(i + 1)]);
            }
        }

        public static void Main()
        {
            {
                int[] arr = Enumerable.Range(0, (int)3E4).ToArray();

                {
                    DisplayExecutionTime("Int Sorted QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("Int Sorted SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("Int Sorted InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("Int Sorted ArraySort", () => Array.Sort(arr));
                }

                Console.WriteLine();

                {
                    arr = arr.Reverse().ToArray();

                    DisplayExecutionTime("Int Reversed QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("Int Reversed SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("Int Reversed InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("Int Reversed ArraySort", () => Array.Sort(arr));
                }

                Console.WriteLine();

                {
                    arr.Shuffle();

                    DisplayExecutionTime("Int Shuffled QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("Int Shuffled SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("Int Shuffled InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("Int Shuffled ArraySort", () => Array.Sort(arr));
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            {
                double[] arr = Enumerable.Range(0, (int)3E4).Select(n => (double)n).ToArray();

                {
                    DisplayExecutionTime("Double Sorted QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("Double Sorted SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("Double Sorted InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("Double Sorted ArraySort", () => Array.Sort(arr));
                }

                Console.WriteLine();

                {
                    arr = arr.Reverse().ToArray();

                    DisplayExecutionTime("Double Reversed QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("Double Reversed SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("Double Reversed InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("Double Reversed ArraySort", () => Array.Sort(arr));
                }

                Console.WriteLine();

                {
                    arr.Shuffle();

                    DisplayExecutionTime("Double Shuffled QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("Double Shuffled SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("Double Shuffled InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("Double Shuffled ArraySort", () => Array.Sort(arr));
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            {
                string[] arr = Enumerable.Range(0, (int)1E4).Select(n => new string((char)Random.Next(255), 10)).ToArray();

                Array.Sort(arr);

                {
                    DisplayExecutionTime("String Sorted QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("String Sorted SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("String Sorted InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("String Sorted ArraySort", () => Array.Sort(arr));
                }

                Console.WriteLine();

                {
                    arr = arr.Reverse().ToArray();

                    DisplayExecutionTime("String Reversed QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("String Reversed SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("String Reversed InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("String Reversed ArraySort", () => Array.Sort(arr));
                }

                Console.WriteLine();

                {
                    arr.Shuffle();

                    DisplayExecutionTime("String Shuffled QuickSort", () => QuickSort(arr));

                    DisplayExecutionTime("String Shuffled SelectionSort", () => SelectionSort(arr));

                    DisplayExecutionTime("String Shuffled InsertionSort", () => InsertionSort(arr));

                    DisplayExecutionTime("String Shuffled ArraySort", () => Array.Sort(arr));
                }
            }
        }

        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        min = j;
                    }
                }

                Swap(ref arr[min], ref arr[i]);
            }
        }

        public static void QuickSort<T>(T[] arr) where T : IComparable<T>
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            if (left >= right)
            {
                return;
            }

            int middle = Partition(arr, left, right);

            QuickSort(arr, left, middle - 1);
            QuickSort(arr, middle + 1, right);
        }

        public static int Partition<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            int randomIndex = Random.Next(left, right + 1);
            Swap(ref arr[randomIndex], ref arr[right]);
            T pivot = arr[right];

            int smallerIndex = left;

            for (int i = left; i < right; i++)
            {
                if (arr[i].CompareTo(pivot) < 0)
                {
                    Swap(ref arr[smallerIndex++], ref arr[i]);
                }
            }

            Swap(ref arr[smallerIndex], ref arr[right]);

            return smallerIndex;
        }

        public static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        public static void InsertionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int insertionIndex = BinarySearch(arr, i);

                T currentValue = arr[i];
                Array.Copy(arr, insertionIndex, arr, insertionIndex + 1, i - insertionIndex);
                arr[insertionIndex] = currentValue;
            }
        }

        public static int BinarySearch<T>(T[] arr, int i) where T : IComparable<T>
        {
            int left = 0;
            int right = i;

            while (left < right)
            {
                int middle = left + ((right - left) / 2);

                if (arr[i].CompareTo(arr[middle]) >= 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }
    }
}