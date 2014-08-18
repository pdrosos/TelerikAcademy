namespace Singleton
{
    using System;

    public class SingletonDemo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Very fast initiallization of a new random object:");
            for (int i = 0; i < 20; i++)
            {
                int randomNumber = new Random().Next(1, 10);
                Console.Write("{0} ", randomNumber);
            }

            Console.WriteLine();

            Console.WriteLine("Singleton pattern for a random number:");
            for (int i = 0; i < 20; i++)
            {
                int randomNumber = RandomGenerator.Generate(1, 10);
                Console.Write("{0} ", randomNumber);
            }

            Console.WriteLine();
        }
    }
}
