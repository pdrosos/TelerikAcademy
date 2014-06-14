using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Student[] myStudents = 
        {
            new Student("Doncho", "Minkov", 2),
            new Student("Kancho", "Praskov", 4),
            new Student("Kuncho", "Nedelchev", 3),
            new Student("Jana", "Markova", 4),
            new Student("Elisaveta", "Dobreva", 5),
            new Student("Ognian", "Manev", 3),
            new Student("Dobri", "Hristov", 6),
            new Student("Pencho", "Totev", 4),
            new Student("Yanislav", "Velikov", 5),
            new Student("Dona", "Kuteva", 6),
        };

        Worker[] myWorkers = 
        {
            new Worker("Doncho", "Minkov", 500, 8),
            new Worker("Kancho", "Praskov", 500, 4),
            new Worker("Kuncho", "Nedelchev", 600, 6),
            new Worker("Jana", "Markova", 700, 8),
            new Worker("Elisaveta", "Dobreva", 400, 8),
            new Worker("Ognian", "Manev", 900, 8),
            new Worker("Dobri", "Hristov", 100, 2),
            new Worker("Pencho", "Totev", 350, 6),
            new Worker("Yanislav", "Velikov", 600, 6),
            new Worker("Dona", "Kuteva", 700, 8),
        };

        var sortedStudents = myStudents.OrderBy(x => x.Grade);

        foreach (var student in sortedStudents)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.SecondName, student.Grade);
        }

        Console.WriteLine("--------------------------------------------");

        var sortedWorkers = myWorkers.OrderByDescending(x => x.MoneyPerHour());

        foreach (var worker in sortedWorkers)
        {
            Console.WriteLine("{0} {1} {2}", worker.FirstName, worker.SecondName, worker.MoneyPerHour());
        }

        List<Human> merged = new List<Human>();

        merged.AddRange(sortedStudents.ToList());
        merged.AddRange(sortedWorkers.ToList());

        foreach (var human in merged)
        {
            Console.WriteLine("{0} {1}", human.FirstName, human.SecondName);
        }

        var sortedFinal = merged.OrderBy(x => x.FirstName).ThenBy(x => x.SecondName);

        foreach (var human in sortedFinal)
        {
            Console.WriteLine("{0} {1}", human.FirstName, human.SecondName);
        }
    }
}