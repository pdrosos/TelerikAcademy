namespace AreBracketsPutCorrectly
{
    using System;

    class AreBracketsPutCorrectly
    {
        /// <summary>
        /// Write a program to check if in a given expression the brackets are put correctly.
        /// Example of correct expression: ((a+b)/5-d).
        /// Example of incorrect expression: )(a+b)).
        /// </summary>
        public static void Main(string[] args)
        {
            string expressionOne = "((a+b)/5-d)";
            string expressionTwo = ")(a+b))";

            Console.WriteLine(expressionOne + " is " + (AreBracketsCorrect(expressionOne) ? "correct" : "incorrect"));
            Console.WriteLine(expressionTwo + " is " + (AreBracketsCorrect(expressionTwo) ? "correct" : "incorrect"));
        }

        public static bool AreBracketsCorrect(string expression)
        {
            int bracketsCount = 0;

            foreach (char symbol in expression)
            {
                if (symbol == '(')
                {
                    bracketsCount++;
                }
                else if (symbol == ')')
                {
                    bracketsCount--;
                }
            }

            if (bracketsCount == 0)
            {
                return true;
            }

            return false;
        }
    }
}
