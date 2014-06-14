using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> firstElement = new LinkedList<int>(3);
            LinkedList<int> secondElement = new LinkedList<int>(5);
            firstElement.NextNode = secondElement;
            LinkedList<int> thirdElement = new LinkedList<int>(9);
            secondElement.NextNode = thirdElement;

            LinkedList<int> koiavz = firstElement.Clone(); // Ончек яде бой тук!
        }
    }
}
