namespace ArrayValuesItsIndicesMultipliedByFive
{
    using System;
    
    public class ArrayValuesItsIndicesMultipliedByFive
    {
        /// <summary>
        /// Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. 
        /// Print the obtained array on the console.
        /// </summary>
        public static void Main(string[] args)
        {
            int arrayLength = 20;
            int[] array = new int[arrayLength];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
                Console.WriteLine(array[i]);
            }
        }
    }
}
