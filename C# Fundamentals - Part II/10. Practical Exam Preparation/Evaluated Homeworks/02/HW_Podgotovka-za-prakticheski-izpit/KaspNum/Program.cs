using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace KaspNum
{
    class Program
    {
        static char ReturnBigChar(int num)
        {
            char letter = (char)(num + 65);
            return letter;
        }
        static char ReturnSmallChar(int num)
        {
            char letter = (char)(num + 96);
            return letter;
        }
        static string ReturnSingleNum(int num)
        {
            if (num < 26)
            {
                return ReturnBigChar(num).ToString();
            }
            int divNum = num / 26;
            char smallLett = ReturnSmallChar(divNum);
            int bigChar = num - (divNum * 26);
            char bigLett = ReturnBigChar(bigChar);
            string result = smallLett.ToString() + bigLett;
            return result;
        }
        static string ReturnBigNum(BigInteger num)
        {
            List<string> result = new List<string>();

            int biggestPower = CalcPower(num);
            for (int currentPower = biggestPower; currentPower >= 0; currentPower--)
            {
                BigInteger numberToPower = ReturnNumToPower(currentPower);
                int timesInNum = (int)(num / numberToPower);
                result.Add(ReturnSingleNum(timesInNum));
                num = num - (numberToPower*timesInNum);
            }
            return string.Join("", result);
        }
        static BigInteger ReturnNumToPower(int power)
        {
            BigInteger number = 1;
            for (int i = 0; i < power; i++)
			{
                number = number * 256;
			}
            return number;
        }
        static int CalcPower(BigInteger num)
        {
            int power = 0;
            while (num >= 256)
            {
                num = num / 256;
                power++;
            }
            return power;
        }
        static void Main(string[] args)
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine(ReturnBigNum(input));
        }
    }
}
