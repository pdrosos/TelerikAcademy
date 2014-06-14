namespace Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int studentsNumber = 10;
            List<Student> students = HierarchyTest.CreateStudents(studentsNumber);

            Console.WriteLine("A list of {0} students:", studentsNumber);

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            var sortedStudents = students.OrderBy(x => x.Grade);

            Console.WriteLine("\nStudents ordered by grade:\n");

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }


            int workersNumber = 10;
            List<Worker> workers = HierarchyTest.CreateWorkers(workersNumber);

            Console.WriteLine("\nA list of {0} workers:\n", workersNumber);

            foreach (var worker in workers)
            {
                Console.WriteLine(worker);
            }

            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());

            Console.WriteLine("\nWorkers ordered by money per hour:\n");

            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }

            List<Human> combination = sortedStudents.Cast<Human>().Concat(sortedWorkers.Cast<Human>()).OrderBy(x => x.FirstName).ThenBy(x => x.FirstName).ToList();


            Console.WriteLine("\nStudents' list combined by workers' list and ordered by first and last names:\n");

            foreach (var item in combination)
            {
                Console.WriteLine(item);
            }

        }
    }
}
