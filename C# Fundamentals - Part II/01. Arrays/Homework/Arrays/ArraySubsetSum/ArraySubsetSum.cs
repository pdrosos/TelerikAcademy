namespace ArraySubsetSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArraySubsetSum
    {
        /// <summary>
        /// We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. 
        /// Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
            int sum = 14;

            List<int[]> subsets = FindSubsets(array);

            Console.WriteLine("Subsets of {{" + string.Join(", ", array) + "}} with sum = {0}:", sum);
            foreach (int[] subset in subsets)
            {
                if (subset.Sum() == sum)
                {
                    Console.WriteLine("{" + string.Join(", ", subset) + "}");
                }
            }
        }

        /// <summary>
        /// All possible subsets of a given array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalArray">Array</param>
        /// <returns>Subsets</returns>
        public static List<T[]> FindSubsets<T>(T[] originalArray)
        {
            List<T[]> subsets = new List<T[]>();

            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;
                subsets.Add(new T[] { originalArray[i] });

                for (int j = 0; j < subsetCount; j++)
                {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }

            return subsets;
        }
    }
}
