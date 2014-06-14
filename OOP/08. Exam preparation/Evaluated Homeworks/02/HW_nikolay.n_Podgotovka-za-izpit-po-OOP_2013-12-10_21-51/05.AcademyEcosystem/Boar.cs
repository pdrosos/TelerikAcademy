using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private int biteSize;
        public Boar(string name, Point location):base(name,location,4)
        {
            this.biteSize = 2;
        }

        public int TryEatAnimal(Animal animal)
        {
            if(animal != null && animal.Size <= this.Size)
            {
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }

        public int EatPlant(Plant plant)
        {
            if(plant != null)
            {
                this.Size += 1;
                return plant.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }
    }
}