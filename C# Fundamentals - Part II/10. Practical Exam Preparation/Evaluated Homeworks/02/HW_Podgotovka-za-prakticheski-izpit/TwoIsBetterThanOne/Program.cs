using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoIsBetterThanOne
{
    class Program
    {
        static long counter = 0;
        static bool IsPalindrome(long number) 
        {
            string num = number.ToString();
            for (int i = 0; i < num.Length/2; i++)
            {
                if (num[i]!= num[num.Length-i-1])
                {
                  return false;
                }
            }
            return true;

        }
        static bool IsLucky(long number)
        {
            string num = number.ToString();
            bool isLuckyMyNum = true;
            char luckyTree = '3';
            char luckyFive = '5';
            for (int i = 0; i < num.Length; i++)
            {
                if ((num[i] != luckyTree) && (num[i] != luckyFive))
                {
                  isLuckyMyNum = false;
                }
            }
            return isLuckyMyNum;
        }
        static void Main(string[] args)
        {
            string enteredNumbers = Console.ReadLine();
             string[] enteredDigs = enteredNumbers.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            long startNum = long.Parse(enteredDigs[0]);
            long endNum =long.Parse(enteredDigs[1]);
            for (long i = startNum; i <= endNum; i++)
			{
			 if (IsPalindrome(i))
            {
                if (IsLucky(i)) 
                {
                    counter++;
                }
            }
			}
            if (counter > 0)
            {
                Console.WriteLine(counter);
            }
            else 
            {
                Console.WriteLine(0);
            }
            string enteredListOfInt = Console.ReadLine();
             string[] enteredlist = enteredListOfInt.Split(',');
            List<int> numbers = new List<int>();
            for (int i = 0; i < enteredlist.Length; i++)
            {
                numbers.Add(int.Parse(enteredlist[i]));
            }

            int percent =int.Parse(Console.ReadLine());
            int answerSecondTask = FindAnswerSecondTask(numbers, percent);
            Console.WriteLine(answerSecondTask);

        }
        private static int FindAnswerSecondTask(List<int> numbers, int percent)
        {
            numbers.Sort();
            for (int i = 0; i < numbers.Count; i++)
            {
                int countSmaller = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] >= numbers[j])
                    {
                        countSmaller++;
                    }
                }

                if (countSmaller >= (numbers.Count * (percent / 100.0)))
                {
                    return numbers[i];
                }
            }

            return numbers[numbers.Count - 1];
        }

    }
}
