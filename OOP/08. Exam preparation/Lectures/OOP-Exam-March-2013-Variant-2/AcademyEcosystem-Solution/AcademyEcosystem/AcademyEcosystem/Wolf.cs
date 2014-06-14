namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        private const int WolfSize = 4;

        public Wolf(string name, Point position)
            : base(name, position, WolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping)
                {
                    return animal.GetMeatFromKillQuantity();                    
                }
            }

            return 0;
        }
    }
}
