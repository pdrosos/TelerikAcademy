namespace FirstElementBiggerThanItsNeighbours
{
    using System;

    public class FirstElementBiggerThanItsNeighbours
    {
        /// <summary>
        /// Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, 
        /// if there’s no such element. Use the method from the previous exercise.
        /// </summary>
        static void Main(string[] args)
        {
            int[] array = { 2, 3, 5, -6, 4, 3, 8 };

            Console.WriteLine("{ " + string.Join(", ", array) + " }");

            Console.Write("The index of the first element that is bigger than its neighbours is: ");
            Console.WriteLine(IndexOfFirstElementBiggerThanNeighbours(array));
        }

        static int IndexOfFirstElementBiggerThanNeighbours(int[] numbers)
        {
            if (numbers.Length == 1 || numbers[0] > numbers[1])
            {
                return 0;
            }

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                {
                    return i;
                }
            }

            if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2])
            {
                return numbers.Length - 1;
            }

            return -1;
        }
    }
}
