namespace CombinationsOfKElementsOfArrayOfNElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CombinationsOfKElementsOfArrayOfNElements
    {
        /// <summary>
        /// Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
        /// Example:	N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a number >= 1:");
            int number = int.Parse(Console.ReadLine());

            List<string> numbers = new List<string>();

            for (int i = 0; i < number; i++)
            {
                numbers.Add((i + 1).ToString());
            }

            Console.WriteLine("Please, enter combinations length:");
            int combinationsLength = int.Parse(Console.ReadLine());

            IEnumerable<string> combinations = Combinations(numbers, combinationsLength);

            Console.WriteLine("All possible combinations of {" + string.Join(", ", numbers.Select(x => x.ToString()).ToArray()) + "} are:");            
            foreach (string combination in combinations)
            {
                Console.WriteLine("{" + string.Join(", ", combination.Select(x => x.ToString()).ToArray()) + "}");
            }
        }

        static IEnumerable<string> Combinations(List<string> characters, int length)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                // only want 1 character, just return this one
                if (length == 1)
                {
                    yield return characters[i];
                }

                // want more than one character, return this one plus all combinations one shorter
                // only use characters after the current one for the rest of the combinations
                else
                {
                    foreach (string next in Combinations(characters.GetRange(i + 1, characters.Count - (i + 1)), length - 1))
                    {
                        yield return characters[i] + next;
                    }
                }
            }
        }
    }


}
