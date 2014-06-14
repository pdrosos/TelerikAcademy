using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05.Students
{
    class StudentQueries
    {
        //03
        //03.Write a method that from a given array of students finds all students whose 
        //first name is before its last name alphabetically. Use LINQ query operators.
        public static IEnumerable<Student> SelectFirstBeforeLastName(Student[] arr)
        {
            var selected =
                from student in arr
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            return selected;
        }
        //using lambda predicate
        public static IEnumerable<Student> SelectFirstBeforeLastNameLambda(Student[] arr)
        {
            var selected = arr.Where(student => student.FirstName.CompareTo(student.LastName) < 0);
            return selected;
        }

        //04
        //04.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        public static IEnumerable<Student> SelectByAgeBetween18_24(Student[] arr)
        {
            var selected =
                from student in arr
                where student.Age >= 18 && student.Age < +24
                select student;

            return selected;
        }
        //using lambda predicate
        public static IEnumerable<Student> SelectByAgeBetween18_24Labda(Student[] arr)
        {
            var selected = arr.Where(student => student.Age >= 18 && student.Age <= 24);
            return selected;
        }

        //05
        //05.Using the extension methods OrderBy() and ThenBy() with lambda expressions 
        //sort the students by first name and last name in descending order. Rewrite the same with LINQ.
        public static void OrderStudentsByName(Student[] arr)
        {
            var selected = 
                from student in arr
                orderby student.FirstName descending, student.LastName descending
                select student;

            //overwrite the array (without ref as it is a reference type)
            int counter = 0;
            foreach (var student in selected)
            {
                arr[counter] = student;
                counter++;
            }
        }
        //using lambda predicate
        public static void OrderStudentsByNameLambda(Student[] arr)
        {
            var ordered = arr.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);
            int counter = 0;
            foreach (var student in ordered)
            {
                arr[counter] = student;
                counter++;
            }
        }


    }
}
