using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Kitten : Cat, ISound
{
    public override void ProduceSound()
    {
        Console.WriteLine("I am {0} the kitten - hey, kitty, kitty", base.Name);
    }
    public Kitten(string name, int age, AnimalSex sex)
        : base(name, age, sex)
    {
        //base.Name = name;
        //base.Age = age;
        //base.Sex = sex;
        if (sex != AnimalSex.F)
        {
            throw new ArgumentException("Kittens can only be females");
        }
    }
}

