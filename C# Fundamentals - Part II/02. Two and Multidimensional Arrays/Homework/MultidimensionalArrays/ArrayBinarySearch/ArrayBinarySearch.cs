namespace ArrayBinarySearch
{
    using System;

    public class ArrayBinarySearch
    {
        /// <summary>
        /// Write a program, that reads from the console an array of N integers and an integer K, 
        /// sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter array lenght:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please, enter integer number:");
            int number = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);
            int resultIndex = Array.BinarySearch(numbers, number);
            int resultIndexBitwiseComplement = ~Array.BinarySearch(numbers, number);

            int resultNumber;

            /* Array.Binary Search Method (http://msdn.microsoft.com/en-us/library/y15ef976.aspx) application: 
             * 1. If resultIndex > 0, then resultIndex is the index of the array element that is equal to k
             * 2. If resultIndex < 0 and Abs(resultIndex) <= numbers.Length, 
             * then ~Array.BinarySearch(numbers, k) is the index of the first number within the array that is larger than k
             * 3. If resultIndex < 0 and Abs(resultIndex) > numbers.Length, then all array elements are < k;
             */
            if (resultIndex >= 0)
            {
                resultNumber = numbers[resultIndex]; //in this case there is array element equal to K
            }
            else if (resultIndex < 0 && resultIndexBitwiseComplement <= numbers.Length - 1)
            {
                resultNumber = numbers[resultIndexBitwiseComplement - 1]; //the largest number in the array which is < K
            }
            else
            {
                resultNumber = numbers[numbers.Length - 1];
            }

            Console.WriteLine("The largest number in the array which is <= {0} is: {1}", number, resultNumber);
        }
    }
}
