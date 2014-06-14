namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int ZombieSize = 0;
        private const int MeatUnits = 10;

        public Zombie(string name, Point position)
            : base(name, position, ZombieSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return MeatUnits;
        }
    }
}
