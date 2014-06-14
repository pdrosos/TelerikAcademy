namespace Hierarchy
{
    using System;
    using System.Collections.Generic;

    public class HierarchyTest
    {
        private static readonly Random random = new Random();

        private static string CreateFirstName()
        {
            string firstName = null;
            List<string> firstNames = new List<string>()
            {
                "Andrew", "Toby", "Michelle", "Billie", "Courtney", "Bradley", "Stan", "Stefani"
            };

            firstName = firstNames[random.Next(0, 8)];
            return firstName;
        }

        private static string CreateLastName()
        {
        
            string lastName; 
            List<string> lastNames = new List<string>()
            {
                "Sinclair", "Manley", "Grimmer", "Anable", "Flemings", "Lakins", "Freestone", "Summers"
            };

            lastName = lastNames[random.Next(0, 8)];
            return lastName;
        }

        private static string CreateGrade()
        {
            string grade;
            List<string> grades = new List<string>() { "A", "B", "C", "D", "E"};
            grade = grades[random.Next(0, 5)];
            return grade;
        }

        private static Student CreateStudent()
        {
            string firstName = CreateFirstName();
            string lastName = CreateLastName();
            string grade = CreateGrade();
            Student student = new Student(firstName, lastName, grade);
            return student;
        }

        public static List<Student> CreateStudents(int numberOfStudents)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                Student student = CreateStudent();
                students.Add(student);
            }

            return students;
        }

        private static Worker CreateWorker()
        {
            string firstName = CreateFirstName();
            string lastName = CreateLastName();
            decimal weekSalary = random.Next(200, 401);
            double workHoursPerDay = random.Next(8, 13);
            Worker worker = new Worker(firstName, lastName, weekSalary, workHoursPerDay);
            return worker;
        }

        public static List<Worker> CreateWorkers(int numberofWorkers)
        {
            List<Worker> workers = new List<Worker>();

            for (int i = 0; i < numberofWorkers; i++)
            {
                Worker worker = CreateWorker();
                workers.Add(worker);
            }

            return workers;
        }


    }
}
