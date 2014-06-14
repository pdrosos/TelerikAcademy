namespace SimpleSolver
{
    using System;
    using System.Collections.Generic;

    public class SimpleSolver
    {
        /// <summary>
        /// Write a program that can solve these tasks:
        /// - Reverses the digits of a number
        /// - Calculates the average of a sequence of integers
        /// - Solves a linear equation a * x + b = 0
		/// Create appropriate methods.
		/// Provide a simple text-based menu for the user to choose which task to solve.
		/// Validate the input data:
        /// - The decimal number should be non-negative
        /// - The sequence should not be empty
        /// - a should not be equal to 0
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("This program solves three tasks:");
            Console.WriteLine("1. Reversing the digits of a number;");
            Console.WriteLine("2. Calculating the average of a sequence of integers;");
            Console.WriteLine("3. Solving a linear equation a * x + b = 0.");
            Console.WriteLine();

            int choice;
            do
            {                
                Console.WriteLine("Please, choose a number of task:");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3);
            
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                {
                    Console.WriteLine("Please, enter a non-negative number:");

                    int number;
                    while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
                    {
                        Console.WriteLine("Invalid number. Enter a non-negative number:");
                    }

                    Console.WriteLine("The reversed number is {0}.", Reverse(number));

                    break;
                }
                case 2:
                {
                    string input = "";
                    List<int> numbers = new List<int>();
                    Console.WriteLine("Please, enter a sequence of integers:");

                    int number;
                    do
                    {
                        Console.WriteLine("Enter an integer (Type \"000\" to stop): ");
                        input = Console.ReadLine();

                        if (input == "000")
                        {
                            if (numbers.Count > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The sequence can not be empty.");
                                continue;
                            }
                        }

                        if (int.TryParse(input, out number))
                        {
                            numbers.Add(number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                    } while (true);

                    Console.WriteLine("The avarage of the sequence of integers is {0}.", Avg(numbers.ToArray()));

                    break;
                }
                case 3:
                {
                    Console.WriteLine("Please, enter values of coefficients a (> 0) and b:");
                    
                    double a;
                    Console.WriteLine("a:");
                    while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
                    {
                        Console.WriteLine("Invalid coefficient a. Please, enter a > 0:");
                    }

                    double b;
                    Console.WriteLine("b:");
                    while (!double.TryParse(Console.ReadLine(), out b))
                    {
                        Console.WriteLine("Invalid coefficient b. Please, enter b:");
                    }
                    
                    Console.WriteLine("The root of the equation is {0}.", SolveEquation(a, b));

                    break;
                }
            }
        }

        protected static int Reverse(int number)
        {
            int reversedNumber = 0;
            int check = number;
            int index = 0;

            do
            {
                index++;
                check = check / 10;
            } while (check != 0);

            for (int i = index - 1; i >= 0; i--)
            {
                reversedNumber = reversedNumber + number % 10 * (int)Math.Pow(10, i);
                number = number / 10;
            }

            return reversedNumber;
        }

        protected static double Avg(int[] array)
        {
            int sum = 0;
            int count = 0;

            foreach (int number in array)
            {
                sum += number;
                count++;
            }

            return ((double)sum / (double)count);
        }

        protected static double SolveEquation(double a, double b)
        {
            return (-1) * b / a;
        }
    }
}
