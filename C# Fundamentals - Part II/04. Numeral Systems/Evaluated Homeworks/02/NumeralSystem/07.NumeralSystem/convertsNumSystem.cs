using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter the number you want to convert: ");
        string n = Console.ReadLine();
        int resultTemp = 0;
        string result = "";
        Console.WriteLine("Enter first numeral system: ");
        int s = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second numeral system: ");
        int d = int.Parse(Console.ReadLine());
        Console.WriteLine("Converting number.......please wait........");
        //Convert to 10 base number
        for (int i = 0; i < n.Length; i++)
        {
            resultTemp += Convert.ToInt32(n.Substring(i, 1)) * (int)Math.Pow(s, n.Length - 1 - i);
        }
        //Convert to d base number
        while (resultTemp > 0)
        {
            switch (resultTemp % d)
            {
                case 0: result += "0"; break;
                case 1: result += "1"; break;
                case 2: result += "2"; break;
                case 3: result += "3"; break;
                case 4: result += "4"; break;
                case 5: result += "5"; break;
                case 6: result += "6"; break;
                case 7: result += "7"; break;
                case 8: result += "8"; break;
                case 9: result += "9"; break;
                case 10: result += "a"; break;
                case 11: result += "b"; break;
                case 12: result += "c"; break;
                case 13: result += "d"; break;
                case 14: result += "e"; break;
                case 15: result += "f"; break;
                default: result += ""; break;
            }
            resultTemp = resultTemp / d;
        }
        //Reverse the string
        char[] arr = result.ToCharArray();
        Array.Reverse(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}