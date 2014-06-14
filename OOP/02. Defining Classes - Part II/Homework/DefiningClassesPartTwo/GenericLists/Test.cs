namespace GenericLists
{
    using System;

    class Test
    {
        static void Main(string[] args)
        {
            // create list and add some elements
            GenericList<int> list = new GenericList<int>();
            list.Add(23);
            list.Add(-12);
            list.Add(13);
            list.Add(134);
            list.Add(-217);

            // print list, print count of elements
            Console.WriteLine(list);
            Console.WriteLine("Elements count: " + list.Count);

            // find specific element's index
            Console.WriteLine("Index of 134 = " + list.Find(134));

            // remove element
            list.Remove(134);
            Console.WriteLine(list);
            Console.WriteLine("Elements count: " + list.Count);

            // use indexer
            Console.WriteLine(list[list.Count - 1]);

            // insert new element at specific position
            list.Insert(list.Count - 2, 100);
            Console.WriteLine(list);
            Console.WriteLine("Elements count: " + list.Count);

            // min and max element
            Console.WriteLine("Minimal element: " + list.Min());
            Console.WriteLine("Maximal element: " + list.Max());

            // clear list
            list.Clear();
            Console.WriteLine(list);
            Console.WriteLine("Elements count: " + list.Count);
        }
    }
}
