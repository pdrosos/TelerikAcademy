namespace People
{
    using System;

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public static Person MakePerson(int age)
        {
            Person person = new Person();

            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Gender = Gender.Female;
            }

            return person;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}; Age: {1}; Gender: {2}", this.Name, this.Age, this.Gender);
        }
    }
}
