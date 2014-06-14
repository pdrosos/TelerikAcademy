using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheRabbit
{
    class Program
    {

        static void Main(string[] args)
        {
            int maxRoute = 0;
            string input = Console.ReadLine();
            string[] splitInput = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[splitInput.Length];
            for (int i = 0; i < splitInput.Length; i++)
            {
                numbers[i] = int.Parse(splitInput[i]);
            }
            for (int start =0; start < numbers.Length; start++)
            {
                for (int step = 0; step < numbers.Length; step++)
                {
                    int currentRoute = 1;
                    int startNum = numbers[start];
                    int nextNum =0 ;
                    for (int currNum =start; true; currNum+=step)
                    {
                        if (currNum>=numbers.Length)
                        {
                            currNum -= numbers.Length;
                        }
                        nextNum = currNum + step;

                        if (nextNum >= numbers.Length)
                        {
                            nextNum -= numbers.Length;
                        }
                        if (numbers[currNum]<numbers[nextNum])
                        {
                            currentRoute++;
                        }
                        else
                        {
                            break;
                        }

                    }
                    if (currentRoute > maxRoute)
                    {
                        maxRoute = currentRoute;
                    }
                    
                }

            }
            Console.WriteLine(maxRoute);
        }

    }
}
