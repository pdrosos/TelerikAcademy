using System;
using System.Text;
//Write a program that creates an array containing all letters from the alphabet (A-Z). 
//Read a word from the console and print the index of each of its letters in the array
class Program
{
    static void Main()
    {
      char[] alphabet = new char[26];     
      for (int i = 0; i < alphabet.Length; i++)
      {                   
          alphabet[i] = (char)('A' + i); ;
      }

      Console.Write("Input word:");
      char[] input;  
      input = (Console.ReadLine()).ToCharArray();

      StringBuilder builder = new StringBuilder();

      int result;
      for (int i = 0; i < input.Length; i++)
      {
          result = binarySearch(alphabet, input[i]);
          builder.Append(result).Append(" ");
      }
      Console.WriteLine("Word indexes: {0}",builder);
    }

    private static int binarySearch(char[] myArray, int search)
    {
        int start = 0;
        int end = myArray.Length - 1;
        int mid;
        while (start <= end)
        {
            mid = (start + end) / 2;
            if (myArray[mid] == search)
            {
                return mid;
            }
            else if (myArray[mid] < search)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }
        return -1; //if not found
    }
}

