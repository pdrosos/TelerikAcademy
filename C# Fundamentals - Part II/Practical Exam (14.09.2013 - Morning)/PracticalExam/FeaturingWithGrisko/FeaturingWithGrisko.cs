using System;
using System.Collections.Generic;

namespace FeaturingWithGrisko
{
    class FeaturingWithGrisko
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            List<char[]> permutations = Permutations(letters.ToCharArray());
            List<string> words = new List<string>();

            ulong wordsCount = 0;
            for (int i = 0; i < permutations.Count; i++)
			{
                string word = new string(permutations[i]);
                if (IsWithNoConsecutiveEqualCharacters(permutations[i]) == true &&
                    words.Contains(word) == false)
                {
                    words.Add(word);
                    wordsCount++;
                }
			}

            Console.WriteLine(wordsCount);
        }
  
        private static bool IsWithNoConsecutiveEqualCharacters(char[] word)
        {
            bool result = true;

            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] == word[i - 1])
                {
                    return false;
                }
            }

            return result;
        }

        public static List<char[]> Permutations(char[] array)
        {
            List<char[]> permutations = new List<char[]>();
            CalculatePermutations(array, 0, permutations);

            return permutations;
        }

        protected static void CalculatePermutations(char[] array, int index, List<char[]> permutations)
        {
            if (index == array.Length)
            {
                permutations.Add((char[])array.Clone());
            }
            else
            {
                CalculatePermutations(array, index + 1, permutations);

                char tempElement;
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
    }
}
