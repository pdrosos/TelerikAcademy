///03.Write a method that from a given array of students finds all students 
///whose first name is before its last name alphabetically. Use LINQ query operators.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringExtensionMethod
{
    class StudentList
    {
        private Student[] arrOfStudens;

        public StudentList(int length)
        {
            this.arrOfStudens = new Student[length];
        }
        //Indexer
        public Student this[int index]
        {
            get
            {
                return this.arrOfStudens[index];
            }
            set
            {
                this.arrOfStudens[index] = value;
            }
        }
        //Print students from the array
        public void PrintStudentsList()
        {
            foreach (var item in this.arrOfStudens)
            {
                Console.WriteLine("Name:{0} {1} Age:{2}",item.FirstName,item.LastName,item.Age);
            }
        }
        public void NameAlphabetically()
        {
            var returnedStudent =
                from student in this.arrOfStudens
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            foreach (var st in returnedStudent)
            {
                Console.WriteLine("Student: {0} {1}",st.FirstName,st.LastName);
            }
        }
        //Find student
        public void FindStudentByAge(int minAge, int maxAge)
        {
            var returnedStudent =
                  from student in this.arrOfStudens
                  where student.Age >= minAge & student.Age <= maxAge
                  select student;
            foreach (var st in returnedStudent)
            {
                Console.WriteLine("Student: {0} {1} Age:{2}", st.FirstName, st.LastName,st.Age);
            }
        }
        //Get list of student
        public List<Student> GetStudentsList()
        {
            List<Student> myList = new List<Student>();
            foreach (var item in this.arrOfStudens)
            {
                myList.Add(item);
            }
            return myList;
        }

    }
}
