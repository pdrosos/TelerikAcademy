using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Problem #2: Define abstract class Human with first name and last name. 
 * Define new class Student which is derived from Human and has new field – grade. 
 * Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() 
 * that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy. 
 * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method). 
 * Initialize a list of 10 workers and sort them by money per hour in descending order. 
 * Merge the lists and sort them by first name and last name.*/




class Test
{
    static void Main()
    {


        Student s01 = new Student("Arsene", "Wenger", 9.5);
        Student s02 = new Student("Matieu", "Flamini", 7.4);
        Student s03 = new Student("Theo", "Walcott", 7.8);
        Student s04 = new Student("Yanogo", "Sanogo", 4.5);
        Student s05 = new Student("Lucas", "Podolski", 1.5);
        Student s06 = new Student("Alex", "Oxlade-Chamberlain", 6.1);
        Student s07 = new Student("Laurent", "Kos", 9.1);
        Student s08 = new Student("Per", "Mertezaker", 5.8);
        Student s09 = new Student("Gencho", "Genev", 5.1);
        Student s10 = new Student("Gencho", "Penev", 7.9);
        //Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method). 
        List<Student> StudentsList = new List<Student> { s01, s02, s03, s04, s05, s06, s07, s08, s09, s10 };
        var SortedByGradeStudentsList =
          from student in StudentsList
          orderby student.grade ascending
          select new { student.FistName, student.LastName, /*grade = student.grade*/ };
        //Console.WriteLine("SortedByGradeStudentsList:");
        //foreach (var item in SortedByGradeStudentsList)
        //{
        //    Console.WriteLine(item);
        //}

        //Initialize a list of 10 workers and sort them by money per hour in descending order. 
        Worker w01 = new Worker("Boiko", "BIRIsov", 20, 3);
        Worker w02 = new Worker("Ceci", "Cvetan$ff", 10, 3);
        Worker w03 = new Worker("Organ", "Murad", 409, 5);
        Worker w04 = new Worker("Veselin", "Marinov", 353, 4);
        Worker w05 = new Worker("Peio", "Qvorov", 300, 2);
        Worker w06 = new Worker("Kamen", "Donev", 406, 6);
        Worker w07 = new Worker("Ico", "100ichkov", 1000, 2);
        Worker w08 = new Worker("Misho", "Birata", 160, 1);
        Worker w09 = new Worker("Iskra", "Fidosova", 200, 4);
        Worker w10 = new Worker("Ivet", "Lalova", 900, 7);
        List<Worker> WorkersList = new List<Worker> { w01, w02, w03, w04, w05, w06, w07, w08, w09, w10 };
        var SortedByNadnicaWorkers =
        from worker in WorkersList
        orderby worker.MoneyPerHour()
        select new { worker.FistName, worker.LastName/*, nadnica = worker.MoneyPerHour()*/};
        //Console.WriteLine("SortedByNadnicaWorkers:");
        //foreach (var item in SortedByNadnicaWorkers)
        //{
        //    Console.WriteLine(item);
        //}
        //Merge the lists and sort them by first name and last name
        Console.WriteLine("Merged lists sorded by 1st and then last name: ");
        var MerrgedList = SortedByGradeStudentsList.Union(SortedByNadnicaWorkers);
        var SortedMegedList =
        from human in MerrgedList
        orderby human.FistName, human.LastName
        select human;
        Console.WriteLine("SortedByNadnicaWorkers:");
        foreach (var item in SortedMegedList)
        {
            Console.WriteLine(item);
        }
    }
}

