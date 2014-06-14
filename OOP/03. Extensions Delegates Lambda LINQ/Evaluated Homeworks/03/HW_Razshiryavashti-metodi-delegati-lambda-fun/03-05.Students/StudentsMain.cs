using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05.Students
{
    class StudentsMain
    {
        static void Main()
        {
            //initialize an array of students
            Student[] studentArr= new Student[5] {
                new Student("Kristina", "Georgieva", 23),
                new Student("Ivan", "Georgiev", 19), 
                new Student("Georgi", "Mariyanov", 21), 
                new Student("Georgi", "Ivanov", 25),
                new Student("Maria","Dimitrova", 33),
            };

            var selectedByTwoNames = StudentQueries.SelectFirstBeforeLastName(studentArr);
            //var selectedByTwoNames = StudentQueries.SelectFirstBeforeLastNameLambda(studentArr);
            Console.WriteLine("By names (first name before last name):\n");
            foreach (var student in selectedByTwoNames)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("------------\nBy age:\n");
            var selectedByAge = StudentQueries.SelectByAgeBetween18_24(studentArr);
            //var selectedByAge = StudentQueries.SelectByAgeBetween18_24Labda(studentArr);
            foreach (var student in selectedByAge)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("--------------\nOrdered descending:\n");
            StudentQueries.OrderStudentsByName(studentArr);
            //StudentQueries.OrderStudentsByNameLambda(studentArr);
            foreach (var student in studentArr)
            {
                Console.WriteLine(student);
            }
        }
    }
}
