using System;

class MainClass
{
    static void Main()
    {
        //Generating sample list and adding a few elements
        GenericList<int> list = new GenericList<int>(10);
        list.Add(1);
        list.Add(2);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        Console.WriteLine("Initial list");
        Console.WriteLine(list.ToString());

        //Testing RemoveAt method
        list.RemoveAt(2);
        Console.WriteLine("After removing the element with index 2");
        Console.WriteLine(list.ToString());

        //Testing AddAt method
        list.AddAt(3, 3);
        Console.WriteLine("After adding 3 at index 3");
        Console.WriteLine(list.ToString());

        //Finding element by it's value
        Console.WriteLine("Looking for a specific element by its value.");
        int index = list.IndexOf(2);
        if (index == -1)
        {
            Console.WriteLine("The specified element was not found in list!");
        }
        else
        {
            Console.WriteLine("The specified element (2) is at index [{0}]", index);
        }
        Console.WriteLine();

        //testing Min/Max methods
        Console.WriteLine("The max value in the list is {0}", list.Max());
        Console.WriteLine("The min value in the list is {0}", list.Min());
        Console.WriteLine();

        //Testing ClearList method
        list.ClearList();
        Console.WriteLine("After clearing the list");
        Console.WriteLine(list.ToString());
    }
}

