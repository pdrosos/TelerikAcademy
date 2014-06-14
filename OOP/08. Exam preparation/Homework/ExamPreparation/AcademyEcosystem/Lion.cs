namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        public Lion(string name, Point location)
            : base(name, location, 6)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size * 2 >= animal.Size)
                {
                    this.Size++;
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
