using System;
using System.Collections.Generic;
using System.Text;

class VariationsGenerator
{
    static void Main()
    {
        //Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
        //Example: N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

        Console.Write("N: ");
        int N = Convert.ToInt32(Console.ReadLine());
        Console.Write("K: ");
        int K = Convert.ToInt32(Console.ReadLine());
        int index = K - 1;
        int oldValue = 0;

        List<int> nums = new List<int>();
        for (int i = 0; i < K; i++) nums.Add(1);

        while (true)
        {
            foreach (int item in nums) Console.Write(item + " ");
            Console.WriteLine();

            while (index > -1 && nums[index] == N)
            {
                oldValue = nums[index];
                nums[index] = 1;
                --index;
            }

            if (index == -1 && oldValue == N) break;

            ++nums[index];
            index = K - 1;
        }
    }
}