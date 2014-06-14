﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        public Wolf(string name, Point location)
            : base(name,location,4)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if(animal != null && (animal.State == AnimalState.Sleeping || animal.Size <= this.Size))
            {
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }

        public override void Update(int timeElapsed)
        {
            if (this.State == AnimalState.Sleeping)
            {
                if (timeElapsed >= sleepRemaining)
                {
                    this.Awake();
                }
                else
                {
                    this.sleepRemaining -= timeElapsed;
                }
            }
            base.Update(timeElapsed);
        }
    }
}
