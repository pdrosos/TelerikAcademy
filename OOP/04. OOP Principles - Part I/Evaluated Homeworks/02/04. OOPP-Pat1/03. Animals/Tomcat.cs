using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Tomcat : Cat, ISound
{
    public override void ProduceSound()
    {
        Console.WriteLine("I am {0} the tomcat. Call me Mr.Tomcat!", base.Name);
    }

    public Tomcat(string name, int age, AnimalSex sex)
        : base(name, age, sex)
    {
        //base.Name = name;
        //base.Age = age;
        //base.Sex = sex;
        if (sex != AnimalSex.M)
        {
            throw new ArgumentException("Tomcats can only be males");
        }
    }
}

