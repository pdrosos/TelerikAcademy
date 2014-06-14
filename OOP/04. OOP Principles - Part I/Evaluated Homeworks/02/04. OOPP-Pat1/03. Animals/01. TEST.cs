using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Test
{
    static void Main()
    {
        //create animals
        Cat maca = new Cat("Maca", 5, AnimalSex.F);
        Dog sharo = new Dog("Sharo", 3, AnimalSex.M);
        Dog spike = new Dog("Spike", 4, AnimalSex.M);
        Frog disco = new Frog("Vasko jabata", 1, AnimalSex.F);
        Kitten pussy = new Kitten("Pusssycat", 2, AnimalSex.F);
        Tomcat chocho = new Tomcat("Chochko", 6, AnimalSex.M);
        //add then in one animal list
        List<Animal> animasList1 = new List<Animal> { maca, sharo, chocho, spike, pussy };
        //using LINQ create e query to display the average age per animal
        var AvgAgeList1 =
            from an in animasList1
            group an by an.GetType() into grp
            select new { Animal = grp.Key, AverageAge = grp.Average(an => an.Age) };
        foreach (var item in AvgAgeList1)
        {
            Console.WriteLine(item);
        }
    }
}

