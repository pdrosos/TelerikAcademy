namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Test
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Пешо", "Пешев", 24));
            students.Add(new Student("Жоро", "Георгиев", 34));
            students.Add(new Student("Тодор", "Стоянов", 14));
            students.Add(new Student("Иван", "Иванов", 18));
            students.Add(new Student("Владимир", "Петров", 21));
            students.Add(new Student("Димитър", "Тодоров", 35));

            // 3. students whose first name is before their last name
            Console.WriteLine("Students whose first name is before their last name:");
            List<Student> result = GetStudentsWithFirstNameBeforeLastName(students);
            foreach (Student student in result)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // 4. students with age between 18 and 24
            Console.WriteLine("Students with age between 18 and 24:");
            List<SimpleStudent> list = GetStudentsWithAgeBetween(students, 18, 24);
            foreach (SimpleStudent student in list)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            Console.WriteLine();

            // 5. sorted students by first name and last name in descending order
            Console.WriteLine("Sorted students by first name and last name in descending order:");
            result = GetStudentsOrderByFirstNameLastName(students);
            foreach (Student student in result)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            Console.WriteLine("Sorted students by first name and last name in descending order (with extension methods):");
            IOrderedEnumerable<Student> items = students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);
            foreach (Student student in items)
            {
                Console.WriteLine(student);
            }
        }

        /// <summary>
        /// Returns all students whose first name is before its last name alphabetically, ordered by name
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        static List<Student> GetStudentsWithFirstNameBeforeLastName(List<Student> students)
        {
            IOrderedEnumerable<Student> result = from student in students
                                                 where student.FirstName.CompareTo(student.LastName) < 0
                                                 orderby student.FirstName ascending, student.LastName ascending
                                                 select student;

            return result.ToList();
        }

        /// <summary>
        /// Returns all students with age between minAge and maxAge, ordered by age and name
        /// </summary>
        /// <param name="students"></param>
        /// <param name="minAge"></param>
        /// <param name="maxAge"></param>
        /// <returns></returns>
        static List<SimpleStudent> GetStudentsWithAgeBetween(List<Student> students, int minAge, int maxAge)
        {
            var result = from student in students
                         where student.Age >= minAge && student.Age <= maxAge
                         orderby student.Age ascending, student.FirstName ascending, student.LastName ascending
                         select new SimpleStudent { FirstName = student.FirstName, LastName = student.LastName };

            return result.ToList();
        }

        /// <summary>
        /// Returns students sorted by first name and last name in descending order
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        static List<Student> GetStudentsOrderByFirstNameLastName(List<Student> students)
        {
            IOrderedEnumerable<Student> result = from student in students
                                                 orderby student.FirstName descending, student.LastName descending
                                                 select student;

            return result.ToList();
        }
    }
}
