using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

enum AnimalSex
{
    M,
    F
}
abstract class Animal : ISound
{
    public int Age { get; set; }
    public string Name { get; set; }
    public AnimalSex Sex { get; set; }


    public abstract void ProduceSound();
    public Animal(string name, int age, AnimalSex sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }
}
