namespace Students
{
    using System;

    class Test
    {
        static void Main(string[] args)
        {
            Student studentOne = new Student("Ivan", "Ivanov", "Ivanov", "456456");
            Console.WriteLine(studentOne);

            Student studentTwo = new Student("Ivanov", "Ivanov", "Ivanov", "456456");
            Student testStudentThree = new Student("Ivan", "Ivanov", "Petrov", "123123");

            // compare students
            Console.WriteLine(studentOne == studentTwo);
            Console.WriteLine(studentOne.Equals(studentTwo));

            Console.WriteLine(studentOne != testStudentThree);
            Console.WriteLine(studentOne.Equals(testStudentThree));

            // clone student
            var clone = studentOne.Clone();
            Console.WriteLine(clone);

            // compare with cloned student
            Console.WriteLine(studentOne.CompareTo(testStudentThree));
        }
    }
}
