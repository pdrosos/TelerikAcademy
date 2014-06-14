using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._04.SortStudents
{
    class MainProg
    {
        static void Main()
        {
            Student st1 = new Student("Ivan", "Ivanov", 23);
            Student st2 = new Student("Dragan", "Draganov", 21);
            Student st3 = new Student("Petkan", "Petkov", 22);
            Student st4 = new Student("Ganio", "Asenov", 33);
            Student st5 = new Student("Petur", "Hitur", 24);
            
            List<Student> studentList = new List<Student>();

            studentList.Add(st1);
            studentList.Add(st2);
            studentList.Add(st3);
            studentList.Add(st4);
            studentList.Add(st5);

            Console.WriteLine();
            Console.WriteLine("Sort by last name: ");
            var result =
                from student in studentList
                where student.Name.CompareTo(student.LastName) == -1
                select student;
            
            foreach (var student in result)
            {
                Console.WriteLine("{0} - {1}", student.Name, student.LastName);
            }

            Console.WriteLine();
            Console.WriteLine("Sort by age: ");           
            var ageResult =
                from student in studentList
                where student.Age >= 18 && student.Age <= 24
                select student;

            foreach (var student in ageResult)
            {
                Console.WriteLine("{0} {1} {2}", student.Name, student.LastName, student.Age);
            }

            Console.WriteLine();
            Console.WriteLine("Sort by first-last name: ");
            Console.WriteLine("-using lambda");
            var names = studentList.OrderByDescending(a => a.Name).ThenByDescending(a => a.LastName);

            foreach (var student in names)
            {
                Console.WriteLine("{0} - {1}", student.Name, student.LastName);
            }


            Console.WriteLine("-using LinQ");
            var namesTwo = 
                from student in studentList
                orderby student.Name descending, student.LastName descending
                select student;

            foreach (var student in studentList)
	        {
		        Console.WriteLine("{0} - {1}", student.Name, student.LastName);
	        }

        }
    }
}
