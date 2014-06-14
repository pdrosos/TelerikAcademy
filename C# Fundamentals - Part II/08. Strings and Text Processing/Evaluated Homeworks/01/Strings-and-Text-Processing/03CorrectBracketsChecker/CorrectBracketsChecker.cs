using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03CorrectBracketsChecker
{
    class CorrectBracketsChecker
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an expression wiyh brackets:");
            string consoleInput = Console.ReadLine();
            string isRight = "wrong";
            int brackets = 0;

            for (int i = 0; i < consoleInput.Length; i++)
            {


                if (consoleInput[i] == '(')
                {
                    brackets++;

                }

                if (consoleInput[i] == ')')
                {
                    brackets--;
                    if (brackets < 0)
                    {

                        break;
                    }

                }
            }
            if (brackets == 0)
            {
                isRight = "right";
            }
            Console.WriteLine("Expession {0} is {1}", consoleInput, isRight);
        }     
    }
}
//Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

