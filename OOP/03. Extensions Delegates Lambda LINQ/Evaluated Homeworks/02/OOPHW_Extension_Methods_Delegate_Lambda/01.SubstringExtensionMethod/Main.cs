using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SubstringExtensionMethod
{
    class MainMethod
    {
        //Main method
        
        static void Main()
        {
            Console.WriteLine("\tExercise 1 ");
            StringBuilder myList = new StringBuilder("123456789");
            StringBuilder result = new StringBuilder();
            //Calling extension method 
            Console.WriteLine("Whole string :{0} ", myList);
            Console.WriteLine(ExtensionString.Substring(myList, 1, 2));
            //Second way to call the same method
            result = myList.Substring(4, 5);
            Console.WriteLine(result);
            Console.WriteLine("\n\tExercise 2 ");
            //Call Min and Max with 2 parameters
            Console.WriteLine("The MIN element is:{0}", ExtensionFunction.Min<double>(7d, 6d));
            Console.WriteLine("The MAX element is:{0}", ExtensionFunction.Max<int>(7, 3));
            //Create array and call methods SUM() , Product() and Average() with this array as parameter
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            ExtensionFunction.Print<int>(arr);
            Console.WriteLine("The SUM is:{0}", ExtensionFunction.Sum<int>(arr));
            Console.WriteLine("The Product is:{0}", ExtensionFunction.Product<int>(arr));
            Console.WriteLine("The Average is:{0}", ExtensionFunction.Average<int>(arr));
            Console.WriteLine("\n\tExercise 3 ");
            Student first = new Student("Jorko", "Aivanov", 17);
            Student second = new Student("Evanka", "Ivanova", 20);
            Student third = new Student("Jorko", "Draganov", 34);
            Student fourd = new Student("Atanas", "Botev", 19);
            StudentList studList = new StudentList(4);
            studList[0] = first;
            studList[1] = second;
            studList[2] = third;
            studList[3] = fourd;
            Console.WriteLine("All students in list:");
            studList.PrintStudentsList();
            Console.WriteLine("\nStudents whose first name is before its last name alphabetically :");
            studList.NameAlphabetically();
            Console.WriteLine("\n\tExercise 4 ");
            Console.WriteLine("\nStudents whose age is between 18 and 24 years :");
            studList.FindStudentByAge(18, 24);
            Console.WriteLine("\n\tExercise 5 ");//
            ///05.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name 
            ///and last name in descending order. Rewrite the same with LINQ.

            List<Student> studentList = new List<Student>();
            studentList = studList.GetStudentsList();
            Console.WriteLine("Sorted descending by first name and last name with OrderBy() and ThenBy()");
            var sortedDescending = studentList.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);
            //Printing result
            foreach (var student in sortedDescending)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            var sortedStudents =
                from student in studentList
                orderby student.FirstName descending, student.LastName descending
                select student;
            Console.WriteLine("\nSorted descending by first name and last name with LINQ");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("\n\tExercise 6 ");
            ///06.Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
            ///Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

            List<int> intList = new List<int>() { 1, 3, 55, 4, 21, 14, 42, 77, 33, 84 };
            foreach (var ints in intList)
            {
                Console.Write(" {0}", ints);
            }
            Console.WriteLine(" - Given list of integers");
            Console.WriteLine("The numbers that are divisible by 7 and 3 using FindAll() are:");
            var returnedInts = intList.FindAll((x) =>
            {
                if ((x % 3 == 0) & (x % 7 == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            foreach (var ints in returnedInts)
            {
                Console.Write(" {0}", ints);

            }

            var linqresult = from integer in intList
                             where (integer % 3 == 0) & (integer % 7 == 0)
                             select integer;
            Console.WriteLine("\nThe numbers that are divisible by 7 and 3 using LINQ are:");
            foreach (var ints in linqresult)
            {
                Console.Write(" {0}", ints);
            }
            Console.WriteLine("\n\n\tExercise 7 ");
            //Period of calling the delegate in seconds
            int period = 2000;//in miliseconds 
            Console.WriteLine("An event will be raise every {0} seconds",period/1000);
            TimerDelegate myDelegate = new TimerDelegate(Time.ShowTime);
            //Attach another methed ShowDayOfWeek() to the delegate 
            myDelegate += Time.ShowDayOfWeek;
            DateTime time = new DateTime();
            time = DateTime.Now;
            int repeated = 4;
            while (repeated > 0)
            {
                Thread.Sleep(period);
                myDelegate();
                repeated--;
            }
            // 08.* Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.

            Console.WriteLine("\n\n\tExercise 8 ");
            Console.WriteLine("An event will be raise every 3 seconds");
            EventRaiseTimer timer = new EventRaiseTimer();
            EventListener lisener = new EventListener();
            lisener.Subscribe(timer);
            timer.RaiseMyEvent();
  
            Console.WriteLine();



        }
    }
}
