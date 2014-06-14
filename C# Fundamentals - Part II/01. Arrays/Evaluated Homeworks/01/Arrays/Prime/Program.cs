using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //***********************************
        //*implementation with list(to slow)*
        //***********************************
        //string now = DateTime.Now.ToString();
        //Console.WriteLine("started at: {0}",now);
        //List<int> primeNumbers = new List<int>();
        //int max = 10000000;

        //for (int i = 2; i < max + 1; i++)
        //{
        //    primeNumbers.Add(i);
        //}
        //double stop = Math.Sqrt((double)max);

        //for (int i = 2; i <= stop; i++)
        //{
        //    Console.WriteLine(i);
        //    if (!primeNumbers.Contains(i))
        //    {
        //        continue;
        //    }
        //    for (int remove = 2*i; remove <= max + 1; remove+=i)
        //    {
        //        Console.WriteLine(remove);
        //        primeNumbers.Remove(remove);

        //    }          
        //}

        //foreach (var item in primeNumbers)
        //{
        //    Console.Write(item +" ");
        //}
        //now = DateTime.Now.ToString();
        //Console.WriteLine("ended at: {0}", now);

        //***************************
        //*implementation with array*
        //***************************

        bool[] myArray = new bool[10000000];
        
        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = true;
        }
        
        for (int i = 2; i < myArray.Length; i++)
        {
            if (i * 2 < myArray.Length)
            {
                for (int j = i * 2; j < myArray.Length; j += i)
                {
                    myArray[j] = false;
                }
            }
        }
        for (int i = 2; i < myArray.Length; i++)
        {
            if (myArray[i] == true) 
            {
                Console.WriteLine(i);               
            }
        }
    }
}

