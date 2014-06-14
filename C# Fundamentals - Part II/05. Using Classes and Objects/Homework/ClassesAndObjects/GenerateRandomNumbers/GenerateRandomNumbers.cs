namespace GenerateRandomNumbers
{
    using System;

    public class GenerateRandomNumbers
    {
        protected static Random generator = new Random();

        /// <summary>
        /// Write a program that generates and prints to the console 10 random values in the range [100, 200].
        /// </summary>
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(RandomNumber());
            }
        }

        public static int RandomNumber()
        {
            return generator.Next(100, 201);
        }
    }
}
