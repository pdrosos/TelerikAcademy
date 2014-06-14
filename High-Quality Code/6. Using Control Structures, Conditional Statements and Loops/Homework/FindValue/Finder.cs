namespace FindValue
{
    using System;

    public class Finder
    {
        public static void Main(string[] args)
        {
            int number = 12;
            int[] array = PopulateArray(100);

            if (IsFound(number, array))
            {
                Console.WriteLine("{0} is found", number);
            }
            else
            {
                Console.WriteLine("{0} is not found", number);
            }

            number = 20;
            if (IsFound(number, array))
            {
                Console.WriteLine("{0} is found", number);
            }
            else
            {
                Console.WriteLine("{0} is not found", number);
            }
        }

        private static bool IsFound(int number, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 10 == 0)
                {
                    if (array[i] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static int[] PopulateArray(int length)
        {
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
