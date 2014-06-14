using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Ptoblem #1: We are given a school. In the school there are classes of students. 
 * Each class has a set of teachers. Each teacher teaches a set of disciplines. 
 * Students have name and unique class number. Classes have unique text identifier. 
 * Teachers have name. Disciplines have name, number of lectures and number of exercises. 
 * Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
	Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate their fields, 
 * define the class hierarchy and create a class diagram with Visual Studio.*/

class TEST
{
    static void Main()
    {
        //create disciplines
        Discipline matematika = new Discipline("Math", 100, 100, "Math rocks");
        Discipline truditechnika = new Discipline("Trudovo", 10, 10);
        Discipline peene = new Discipline("Peene", 5, 5);
        Discipline history = new Discipline("History", 30, 30, "hail");
        Discipline prirodoznanie = new Discipline("Prirodoznanie", 30, 30, "Animal Planet");
        //create list of disciplines
        List<Discipline> Teach1Disc = new List<Discipline> { matematika };
        List<Discipline> Teach2Disc = new List<Discipline> { truditechnika, peene };
        List<Discipline> Teach3Disc = new List<Discipline> { history, prirodoznanie };
        //create teachers
        Teacher matematikov = new Teacher("Gosho", "Liniqta", "too pishe 2ki", Teach1Disc);
        Teacher ruletkov = new Teacher("Todor", "Letvata", "cql chas krastoslovici reshava", Teach2Disc);
        Teacher hitler = new Teacher("Bolen", "Bezpartiqhodi", "hail", Teach3Disc);
        //create lists of teachers
        List<Teacher> teachers9A = new List<Teacher> { matematikov, ruletkov };
        List<Teacher> teachers11E = new List<Teacher> { matematikov, ruletkov, hitler };
        //create students
        Student misho = new Student("Misho", "Petrov", 18);
        Student gosho = new Student("Gosho", "Todorov", 17);
        Student pesho = new Student("Pesho", "Mitkov", "Prepisvach", 22);
        Student mincho = new Student("Mincho", "Praznikov", "meka mara", 15);
        Student darina = new Student("Darina", "Andreeva", "eindsvenoto momiche", 4);
        //create list of students
        List<Student> List9A = new List<Student> { misho, gosho, pesho };
        List<Student> List11E = new List<Student> { mincho, darina };
        //create classes
        ClassOfStundets Class9A = new ClassOfStundets(9, 'A', List9A, teachers9A);
        ClassOfStundets Class11E = new ClassOfStundets(11, 'E', List11E, teachers11E);
        //create list of classes 
        List<ClassOfStundets> SPTU1Classes = new List<ClassOfStundets> { Class9A, Class11E };
        //create school
        School SPTU1 = new School("SPTU Don Kihot", SPTU1Classes);

        Console.Write("May I present you {0}.\nThere are {1} classes in the school: ", SPTU1.SchoolName, SPTU1Classes.Count);
        foreach (var item in SPTU1Classes)
        {
            Console.Write(item.ClassNb);
            Console.Write(item.ClassChar);
            Console.Write(";");
        }
        Console.WriteLine();
        foreach (var klas in SPTU1Classes)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("Class {0}{1}'s students are:", klas.ClassNb, klas.ClassChar);
            foreach (var uchenik in klas.ListOfStudents)
            {
                Console.WriteLine("-" + uchenik.FistName + " " + uchenik.LastName);
            }
            Console.WriteLine();
            Console.WriteLine("Class {0}{1}'s teachers and teached dispiplines are:", klas.ClassNb, klas.ClassChar);
            Console.WriteLine("--------------------------------------------");
            foreach (Teacher daskal in klas.ListOfTeachers)
            {
                Console.WriteLine("-" + daskal.FistName + " " + daskal.LastName + "-" + daskal.Comment);
                Console.WriteLine("This teacher teaches:");
                daskal.PrintTeachedDisciplines(daskal);
                Console.WriteLine();
            }
        }
    }
}

