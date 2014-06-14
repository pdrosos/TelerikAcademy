namespace ArrayMaximalSequenceOfEqualElements
{
    using System;
    using System.Linq;

    public class ArrayMaximalSequenceOfEqualElements
    {
        /// <summary>
        /// We are given a matrix of strings of size N x M. 
        /// Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. 
        /// Write a program that finds the longest sequence of equal strings in the matrix.
        /// </summary>
        public static void Main(string[] args)
        {
            //Console.WriteLine("Please, enter array rows:");
            //int rows = int.Parse(Console.ReadLine());

            //Console.WriteLine("Please, enter array columns:");
            //int columns = int.Parse(Console.ReadLine());

            //string[,] array = new string[rows, columns];

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < columns; j++)
            //    {
            //        Console.Write("array[{0}, {1}] = ", i, j);
            //        array[i, j] = Console.ReadLine();
            //    }
            //}

            string[,] array = { { "ha", "fifi", "ho", "hi" }, { "fo", "ha", "hi", "xx" }, { "xxx", "ho", "ha", "xx" } };
            //string[,] array = { { "s", "qq", "s" }, { "pp", "pp", "s" }, { "pp", "qq", "s" } };

            // find longest sequence with equal elements
            string element;
            int length = MaximalSequenceOfEqualElements(array, out element);

            if (length > 0)
            {
                Console.WriteLine("The longest sequence with equal elements is: {0}", String.Concat(Enumerable.Repeat(element + " ", length)), length);
            }
            else
            {
                Console.WriteLine("There is no sequence with equal elements");
            }
        }
        
        /// <summary>
        /// This method finds the first maximal sequence of equal elements,
        /// located on the same line, column or diagonal in a two-dimensional array
        /// and returns the sequence length and the repeating element
        /// If firstOccurence = false, it returns the last maximal sequence of equal elements
        /// If the array has only positive values - it returns the whole array's sum and length
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="element">The repeating element's value</param>
        /// <returns>The length of the maximal sequence of equal elements</returns>
        public static int MaximalSequenceOfEqualElements(string[,] array, out string element)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            int length = 0;
            element = string.Empty;

            // search in rows
            for (int i = 0; i < rows; i++)
            {
                SearchMaximalSequenceOfEqualElements(array, i, 0, 0, 1, ref length, ref element);
            }

            // search in columns
            for (int i = 0; i < columns; i++)
            {
                SearchMaximalSequenceOfEqualElements(array, 0, i, 1, 0, ref length, ref element);
            }
            
            // search in positive diagonals
            for (int i = 0; i < rows; i++)
            {
                SearchMaximalSequenceOfEqualElements(array, i, 0, -1, 1, ref length, ref element);
            }
            for (int i = 0; i < columns; i++)
            {
                SearchMaximalSequenceOfEqualElements(array, rows - 1, i, -1, 1, ref length, ref element);
            }
            
            // search in negative diagonals
            for (int i = rows - 1; i >= 0; i--)
            {
                SearchMaximalSequenceOfEqualElements(array, i, 0, 1, 1, ref length, ref element);
            }
            for (int i = 0; i < columns; i++)
            {
                SearchMaximalSequenceOfEqualElements(array, 0, i, 1, 1, ref length, ref element);
            }

            return length;
        }

        protected static void SearchMaximalSequenceOfEqualElements (string[,] array, int startRow, int startColumn, int directionRow, int directionColumn, 
            ref int length, ref string element)
        {
            int currentRow = startRow;
            int currentColumn = startColumn;

            int currentLength = 1;

            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            
            string currentElement = array[startRow, startColumn];

            while (true)
            {
                currentRow += directionRow;
                currentColumn += directionColumn;

                if (currentRow < 0 || currentRow >= rows || currentColumn < 0 || currentColumn >= columns)
                {
                    break;
                }

                if (array[currentRow, currentColumn] != currentElement)
                {
                    if (currentLength > length)
                    {
                        length = currentLength;
                        element = currentElement;
                    }

                    currentLength = 1;
                    currentElement = array[currentRow, currentColumn];
                }
                else
                {
                    currentLength++;
                }
            }

            if (currentLength > length)
            {
                length = currentLength;
                element = currentElement;
            }
        }
    }
}
