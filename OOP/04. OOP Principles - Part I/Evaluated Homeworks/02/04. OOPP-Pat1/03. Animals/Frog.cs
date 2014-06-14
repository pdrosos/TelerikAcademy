using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Frog : Animal,ISound
{
    public override void ProduceSound()
    {
        Console.WriteLine("I am {0} the frog - forgi, frogi", base.Name);
    }
    public Frog(string name, int age, AnimalSex sex)
        : base(name, age, sex)
    {
        //base.Name = name;
        //base.Age = age;
        //base.Sex = sex;
    }
}

