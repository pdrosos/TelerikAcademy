//Define a class Student, which contains data about a student – first, middle and last name, SSN,
//permanent address, mobile phone e-mail, course, specialty, university, faculty. 
//Use an enumeration for the specialties, universities and faculties. Override the standard methods,
//inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

//Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields
//into a new object of type Student.

//Implement the  IComparable<Student> interface to compare students by names (as first criteria,
//in lexicographic order) and by social security number (as second criteria, in increasing order).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentInfo
{
    class StudentInfo
    {
        static void Main(string[] args)
        {
            Student firstStudent = new Student("Pesho", "Peshev", "Peshev", 1234567891, "Tam Nqkude N2",
                        "0987654321", "blablabla@abv.bg",1, Specialties.Biology, Universities.SU, Faculties.BiologyFaculty);
            Student secondStudent = new Student("Gosho", "Goshev", "Goshev", 5463546354, "Nqkude Drugade N3",
                        "0896767667", "tralalalaal@abv.bg", 2, Specialties.Chemistry, Universities.NBU, Faculties.ChemistryFaculty);

            Console.WriteLine(firstStudent);
            Console.WriteLine(firstStudent.Equals(secondStudent));
            Console.WriteLine(firstStudent.CompareTo(secondStudent));

            var thirdStudent = firstStudent.Clone();
            thirdStudent.FirstName = "Dragan";
            Console.WriteLine(thirdStudent);
        }
    }
}
