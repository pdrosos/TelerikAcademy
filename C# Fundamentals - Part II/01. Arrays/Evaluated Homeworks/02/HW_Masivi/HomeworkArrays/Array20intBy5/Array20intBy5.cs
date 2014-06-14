/*Write a program that allocates array of 20 integers and initializes each 
 * element by its index multiplied by 5. Print the obtained array on the console.
 */
using System;

class Array20intBy5
{
    static void Main()
    {
        int[] Numbers = new int[20];
        for (int i = 0; i < Numbers.Length; i++)
        {
            Numbers[i] = (i * 5);               //initialize array by its index multiplied by 5
        }
        for (int i = 0; i < Numbers.Length; i++)
        {
            Console.WriteLine(Numbers[i]);      //print the array on the console
        }
    }
}
