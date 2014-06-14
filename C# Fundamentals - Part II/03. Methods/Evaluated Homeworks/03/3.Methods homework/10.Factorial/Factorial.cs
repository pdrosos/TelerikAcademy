using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Factorial
{
    class Factorial
    {
        static void revereseArrayDigits(int[] array)
        {
            int container;
            for (int i = 0; i < array.Length/2; i++)
            {
                container = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = container;
            }
        }
        static int[] sumArrays(int[] number1, int[] number2)
        {
            revereseArrayDigits(number1);
            revereseArrayDigits(number2);
            int reminder = 0;
            int length;
            int sumedDigits;
            int biggerLength = number1.Length < number2.Length ? number2.Length : number1.Length;
            int[] result = new int[biggerLength+1];
            length = number1.Length > number2.Length ? number2.Length : number1.Length;
            
            for (int i = 0; i < length; i++)
            {
                sumedDigits = number1[i]+number2[i];
                if (reminder != 0)
                {
                    sumedDigits += reminder;
                    reminder = 0;
                }
                if (sumedDigits >= 10)
                {       
                    reminder = sumedDigits / 10;
                    sumedDigits = sumedDigits % 10;
                }
                result[i] = sumedDigits;
                if (reminder != 0 && i == length - 1)
                {
                    result[i + 1] = reminder;
                }
            }
            revereseArrayDigits(number1);
            revereseArrayDigits(number2);
            revereseArrayDigits(result);

            return result;
        }
        static void Main(string[] args)
        {
            int[] array = { 9,9,9};
            int[] array2 = { 9,9,9,9 };
            int[] resultArr = sumArrays(array, array2);
            foreach (var item in resultArr)
            {
                Console.Write(item);
            }
        }
    }
}
