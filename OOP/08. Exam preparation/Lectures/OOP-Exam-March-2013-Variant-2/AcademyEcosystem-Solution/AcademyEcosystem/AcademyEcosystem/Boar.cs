namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int BoarSize = 4;
        private const int BiteSize = 2;

        public Boar(string name, Point position)
            : base(name, position, BoarSize)
        {
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(BiteSize);
            }

            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
