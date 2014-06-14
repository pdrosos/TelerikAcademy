using System;
using System.Collections.Generic;
using System.Linq;

internal struct Worker
{
    public string NameFirst { get; set; }
    public string NameLast { get; set; }
    public string Positon { get; set; }
    public int Rang { get; set; }
}

public class Employees
{

    internal static void Main()
    {
        int numberOfPositions = int.Parse(Console.ReadLine());
        Dictionary<string, int> posAndRanks = new Dictionary<string, int>();

        for (int i = 0; i < numberOfPositions; i++)
        {
            string[] input = Console.ReadLine().Split('-');
            string trimed = input[0].Trim();

            if (!posAndRanks.ContainsKey(trimed))
            {
                posAndRanks.Add(trimed, int.Parse(input[1]));
            }
        }

        List<Worker> people = new List<Worker>();
        int numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] input = Console.ReadLine().Split('-');
            Worker emp = new Worker();
            string[] splited = input[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string trimed = input[1].Trim();
            emp.NameFirst = splited[0];
            emp.NameLast = splited[splited.Length - 1];
            emp.Positon = trimed;
            if (posAndRanks.ContainsKey(trimed))
            {
                emp.Rang = posAndRanks[trimed];
            }

            people.Add(emp);
        }

        var orederedPpl = people.OrderByDescending(x => x.Rang).ThenBy(x => x.NameLast).ThenBy(x => x.NameFirst);
        foreach (var person in orederedPpl)
        {
            Console.WriteLine("{0} {1}", person.NameFirst, person.NameLast);
        }
    }
}