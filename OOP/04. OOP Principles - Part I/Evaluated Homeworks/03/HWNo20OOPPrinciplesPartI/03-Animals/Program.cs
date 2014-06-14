using System;
using MyAnimal;

public class Program
{
    public static void Main()
    {
        Dog lol = new Dog("Ivan", 12, Sex.Male);
        lol.MakeSound();

        Kitten test = new Kitten("Iva", 12, Sex.Female);

        Animal[] myZoo = 
        {
            new Cat("Iva", 12, Sex.Female),
            new Kitten("Iva", 12, Sex.Female),
            new Frog("Iva", 20, Sex.Female),
            new Frog("Iva", 10, Sex.Female),
            new Dog("Iva", 12, Sex.Female),
            new Cat("Iva", 12, Sex.Female),
            new Kitten("Iva", 12, Sex.Female),
            new Frog("Iva", 20, Sex.Female),
            new Frog("Iva", 10, Sex.Female),
            new Dog("Iva", 12, Sex.Female),
            new Cat("Iva", 12, Sex.Female),
            new Kitten("Iva", 12, Sex.Female),
            new Frog("Iva", 20, Sex.Female),
            new Frog("Iva", 10, Sex.Female),
            new Dog("Iva", 12, Sex.Female),
            new Cat("Iva", 12, Sex.Female),
            new Kitten("Iva", 12, Sex.Female),
            new Frog("Iva", 20, Sex.Female),
            new Frog("Iva", 10, Sex.Female),
            new Dog("Iva", 12, Sex.Female),
        };

        Animal.AgeAverage(myZoo);
    }
}