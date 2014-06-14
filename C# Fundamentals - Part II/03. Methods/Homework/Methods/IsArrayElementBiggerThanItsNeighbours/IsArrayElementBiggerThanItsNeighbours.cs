namespace IsArrayElementBiggerThanItsNeighbours
{
    using System;

    public class IsArrayElementBiggerThanItsNeighbours
    {
        /// <summary>
        /// Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors 
        /// (when such exist).
        /// </summary>
        public static void Main(string[] args)
        {
            int[] array = { 2, 3, 5, -6, 4, 3, 8 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            Console.WriteLine("Please, enter array index between 0 and 6:");
            int index = int.Parse(Console.ReadLine());

            if (IsElementBiggerThanItsNeighbours(array, index))
            {
                Console.WriteLine("{0} is bigger than its neighbours.", array[index]);
            }
            else
            {
                Console.WriteLine("{0} is not bigger than its neighbours.", array[index]);
            }
        }

        public static bool IsElementBiggerThanItsNeighbours(int[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new Exception("Index is out of range");
            }

            if (index - 1 >= 0 && array[index] < array[index - 1])
            {
                return false;                
            }

            if (index + 1 < array.Length && array[index] < array[index + 1])
            {
                return false;
            }

            return true;
        }
    }
}
