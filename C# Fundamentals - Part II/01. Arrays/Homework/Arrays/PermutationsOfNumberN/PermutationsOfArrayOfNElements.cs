namespace PermutationsOfArrayOfNElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PermutationsOfArrayOfNElements
    {
        protected List<int[]> permutations = new List<int[]>();

        /// <summary>
        /// Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
        /// Example:	n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a number >= 1:");
            int number = int.Parse(Console.ReadLine());

            int[] numbers = new int[number];

            for (int i = 0; i < number; i++)
            {
                numbers[i] = i + 1;
            }

            List<int[]> permutations = Permutations(numbers);
            //List<int[]> permutations = HeapPermutations(numbers);

            Console.WriteLine("All possible permutations of {" + string.Join(", ", numbers.Select(x => x.ToString()).ToArray()) + "} are:");
            foreach (int[] permutation in permutations)
            {
                Console.WriteLine("{" + string.Join(", ", permutation.Select(x => x.ToString()).ToArray()) + "}");
            }
        }

        public static List<int[]> Permutations(int[] array)
        {
            List<int[]> permutations = new List<int[]>();
            CalculatePermutations(array, 0, permutations);

            return permutations;
        }

        protected static void CalculatePermutations(int[] array, int index, List<int[]> permutations)
        {
            if (index == array.Length)
            {
                permutations.Add((int[])array.Clone());
            }
            else
            {
                CalculatePermutations(array, index + 1, permutations);

                int tempElement;
                for (int j = index + 1; j < array.Length; j++)
                {
                    tempElement = array[index];
                    array[index] = array[j];
                    array[j] = tempElement;

                    CalculatePermutations(array, index + 1, permutations);

                    tempElement = array[index];
                    array[index] = array[j];
                    array[j] = tempElement;
                }
            }
        }

        // Heap algorithm
        public static List<int[]> HeapPermutations(int[] array)
        {
            List<int[]> permutations = new List<int[]>();
            CalculateHeapPermutations(array, array.Length, permutations);
            return permutations;
        }

        protected static void CalculateHeapPermutations(int[] array, int arrayLength, List<int[]> permutations)
        {
            if (arrayLength == 1)
            {
                permutations.Add((int[])array.Clone());
            }
            else
            {
                int tempElement;
                for(int i = 0; i < arrayLength; i++)
                {
                    CalculateHeapPermutations(array, arrayLength - 1, permutations);  
  
                    if (arrayLength % 2 == 1)
                    {
                        tempElement = array[0];
                        array[0] = array[arrayLength - 1];
                        array[arrayLength - 1] = tempElement;
                    }
                    else
                    {
                        tempElement = array[i];
                        array[i] = array[arrayLength - 1];
                        array[arrayLength - 1] = tempElement;
                    }
                }
            }
        }
    }
}