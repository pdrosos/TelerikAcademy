namespace ArraySubsetWithGivenLengthSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArraySubsetWithGivenLengthSum
    {
        /// <summary>
        /// Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
        /// Find in the array a subset of K elements that have sum S or indicate about its absence.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter array length:");
            int arrayLength = int.Parse(Console.ReadLine());

            int[] array = new int[arrayLength];

            Console.WriteLine("Please, enter array elements (integers):");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Please, enter subsets length:");
            int subsetsLength = int.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter sum:");
            int sum = int.Parse(Console.ReadLine());

            // get all subsets with the given length
            List<List<int>> subsets = GetSubsets(array.ToList(), subsetsLength);

            bool noSubsets = true;
            Console.WriteLine("Subsets of {{" + string.Join(", ", array) + "}} with sum = {0}:", sum);
            foreach (List<int> subset in subsets)
            {
                if (subset.Sum() == sum)
                {
                    noSubsets = false;
                    Console.WriteLine("{" + string.Join(", ", subset) + "}");
                }
            }

            if (noSubsets)
            {
                Console.WriteLine(0);
            }
        }

        /// <summary>
        /// This method finds all subsets of a set, which have specific length
        /// </summary>
        public static List<List<int>> GetSubsets(List<int> superSet, int subsetsLength)
        {
            List<List<int>> subsets = new List<List<int>>();

            GetSubsets(superSet, subsetsLength, 0, new List<int>(), subsets);

            return subsets;
        }

        private static void GetSubsets(List<int> superSet, int subsetsLength, int index, List<int> currentSubset, List<List<int>> solution)
        {
            // successful stop clause
            if (currentSubset.Count == subsetsLength)
            {
                solution.Add(new List<int>(currentSubset));

                return;
            }

            // unseccessful stop clause
            if (index == superSet.Count)
            {
                return;
            }

            int subset = superSet[index];
            currentSubset.Add(subset);

            // "guess" x is in the subset
            GetSubsets(superSet, subsetsLength, index + 1, currentSubset, solution);
            currentSubset.Remove(subset);

            // "guess" x is not in the subset
            GetSubsets(superSet, subsetsLength, index + 1, currentSubset, solution);
        }
    }
}
