namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        public Wolf(string name, Point location)
            : base(name, location, 4)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.State == AnimalState.Sleeping || this.Size >= animal.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
