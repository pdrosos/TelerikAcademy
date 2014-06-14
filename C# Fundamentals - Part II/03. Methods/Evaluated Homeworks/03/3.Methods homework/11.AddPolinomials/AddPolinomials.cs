using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AddPolinomials
{
    class AddPolinomials
    {
        static void orderElements(List<string> elList)
        {
            List<int> powersList = new List<int>();
            List<int> xBaseList = new List<int>();

            for (int i = 0; i < elList.Capacity-1; i++)
            {
                //get index of the power symbol'^' and index of x
                int indexOfPower = elList[i].LastIndexOf("^");
                int indexOfX = elList[i].LastIndexOf("x");

                //if power symbol exists write the power in list and value before the x in other list
                //both values with the same index in the lists
                if (indexOfPower != -1)
                {
                    StringBuilder number = new StringBuilder();
                    for (int j = indexOfPower+1; j < elList[i].Length; j++)
                    {
                        number.Append(elList[i][j]);
                    }
                    int power = int.Parse(number.ToString());
                    powersList.Add(power);

                    StringBuilder number2 = new StringBuilder();
                    for (int j = 0; j < indexOfPower - 1; j++)
                    {
                        number2.Append(elList[i][j]);
                    }
                    int xBase = int.Parse(number2.ToString());
                    xBaseList.Add(xBase);
                }
                else if (indexOfX != -1)
                {
                    StringBuilder number = new StringBuilder();
                    for (int j = 0; j < indexOfX; j++)
                    {
                        number.Append(elList[i][j]);
                    }
                    int xBase = int.Parse(number.ToString());
                    xBaseList.Add(xBase);
                    powersList.Add(1);
                }
                else
                {
                    xBaseList.Add(int.Parse(elList[i]));
                    powersList.Add(0);
                }
            }

        }
        static void Main(string[] args)
        {
            string polinomial = "2x^2 + 2x + 5";
            string[] splited = polinomial.Split(' ');
            List<string> elements = new List<string>();
            foreach (var item in splited)
            {
                if (item != "+" && item!= "-")
                {
                    elements.Add(item);
                }
            }

            orderElements(elements);
        }
    }
}
