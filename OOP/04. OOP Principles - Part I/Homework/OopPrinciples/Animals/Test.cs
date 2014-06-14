namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Test
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>
            {
                new Cat("Sammy", 1.6, Sex.Male),
                new Tomcat("Roni", 1.5),
                new Kitten("Jane", 4),
                new Dog("Bendji", 3, Sex.Male),
                new Frog("Greeny", 2, Sex.Female)
            };

            List<Cat> cats = new List<Cat>
            {
                new Cat("Tedi", 0.5, Sex.Male),
                new Cat("Ivi", 0.5, Sex.Male),
                new Kitten("Dodo", 2),
                new Tomcat("Tom", 5)
            };

            Console.WriteLine("Animals:");
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("Cats:");
            foreach (Cat cat in cats)
            {
                Console.WriteLine(cat);
            }

            Console.WriteLine("Animals average age");
            Console.WriteLine(animals.Average(animal => animal.Age));

            Console.WriteLine("Cats average age");
            Console.WriteLine(cats.Average(cat => cat.Age));
        }
    }
}
