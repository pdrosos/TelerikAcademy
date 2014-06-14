namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    public class SchoolTest
    {
        private static readonly Random random = new Random();

        public static string CreateName()
        {
            string name = null;
            List<string> firstNames = new List<string>()
            {
                "Andrew", "Toby", "Michelle", "Billie", "Courtney", "Bradley", "Stan", "Stefani"
            };

            List<string> lastNames = new List<string>()
            {
                "Sinclair", "Manley", "Grimmer", "Anable", "Flemings", "Lakins", "Freestone", "Summers"
            };

            StringBuilder sb = new StringBuilder();

            string randomFirstName = firstNames[random.Next(0, 8)];
            string randomLastName = lastNames[random.Next(0, 8)];

            sb.Append(randomFirstName).Append(" ").Append(randomLastName);
            name = sb.ToString();
            sb.Clear();
            return name;
        }


        private static Student CreateStudent(int classNumber)
        {
            Student student = new Student(CreateName(), classNumber);

            return student;
        }

        private static List<Student> CreateStudentsSet()
        {
            List<Student> studentsSet = new List<Student>();

            int studentsNumber = random.Next(18, 26);

            for (int i = 1; i < studentsNumber; i++)
            {
                Student student = CreateStudent(i);
                studentsSet.Add(student);
                Thread.Sleep(3);
            }
            return studentsSet;
        }

        private static Subject CreateSubject()
        {
            List<Subject> subjects = new List<Subject>()
            {
                new Subject("Biology", 15, 6), 
                new Subject("Physics", 17, 4, "excellent subject"), 
                new Subject("Mathematics", 13, 3), 
                new Subject("Chemistry", 12, 5), 
                new Subject("Literature", 12, 5),  
                new Subject("Geography", 10, 7),
                new Subject("History", 16, 8),
            };


            Subject randomSubject = subjects[random.Next(0, 7)];
            return randomSubject;
        }


        private static List<Subject> CreateSubjectsSet()
        {
            List<Subject> subjectsSet = new List<Subject>();

            int subjectsNumber = random.Next(1, 6);
           
            for (int i = 0; i < subjectsNumber; i++)
            {
                Subject subject = CreateSubject();

                if (!subjectsSet.Contains(subject))
                {
                    subjectsSet.Add(subject);
                }
                else
                {
                    i--;
                }
                
            }

            return subjectsSet;
        }

        private static Teacher CreateTeacher()
        {
            string randomName = CreateName();
            List<Subject> randomSubjectsSet = CreateSubjectsSet();
            Teacher teacher = new Teacher(randomName, randomSubjectsSet);
            return teacher;
        }


        private static List<Teacher> CreateTeachersSet()
        {
            List<Teacher> teachersSet = new List<Teacher>();

            int teachersNumber = random.Next(4, 7);

            for (int i = 0; i < teachersNumber; i++)
            {
                Teacher teacher = CreateTeacher();
                teachersSet.Add(teacher);
            }
            return teachersSet;
        }       

        private static SchoolClass CreateClass(string textId)
        {
            List<Student> studentsSet = CreateStudentsSet();
            List<Teacher> teachersSet = CreateTeachersSet();

            SchoolClass schoolClass = new SchoolClass(studentsSet, teachersSet, textId);

            return schoolClass;
        }

        private static List<SchoolClass> CreateClasses()
        {
            int classesNumber = random.Next(3, 5);

            List<SchoolClass> classes = new List<SchoolClass>();

            int lastLetter = Convert.ToChar((Convert.ToInt32('A') + classesNumber));
            string textId;
            for (char letter = 'A'; letter < lastLetter; letter++)
            {
                textId = letter.ToString();
                SchoolClass schoolClass = CreateClass(textId);
                classes.Add(schoolClass);                
            }

            return classes;
        }

        public static School CreateSchool()
        {
            List<SchoolClass> classes = CreateClasses();
            School school = new School(classes);
            return school;
        }
       
    }
}
