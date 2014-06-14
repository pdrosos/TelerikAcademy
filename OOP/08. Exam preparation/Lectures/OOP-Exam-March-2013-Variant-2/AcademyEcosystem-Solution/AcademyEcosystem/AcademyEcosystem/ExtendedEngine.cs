namespace AcademyEcosystem
{
    public class ExtendedEngine : Engine
    {
        private const string WolfType = "wolf";
        private const string LionType = "lion";
        private const string GrassType = "grass";
        private const string BoarType = "boar";
        private const string ZombieType = "zombie";

        protected override void ExecuteBirthCommand(string[] commandWords)
        {
            string organismType = commandWords[1];
            string name = null;
            Point position = default(Point);
            switch (organismType)
            {
                case WolfType:
                    name = commandWords[2];
                    position = Point.Parse(commandWords[3]);
                    Wolf newWolf = new Wolf(name, position);
                    this.AddOrganism(newWolf);
                    break;
                case LionType:
                    name = commandWords[2];
                    position = Point.Parse(commandWords[3]);
                    Lion newLion = new Lion(name, position);
                    this.AddOrganism(newLion);
                    break;
                case GrassType:
                    position = Point.Parse(commandWords[2]);
                    Grass newGrass = new Grass(position);
                    this.AddOrganism(newGrass);
                    break;
                case BoarType:
                    name = commandWords[2];
                    position = Point.Parse(commandWords[3]);
                    Boar newBoar = new Boar(name, position);
                    this.AddOrganism(newBoar);
                    break;
                case ZombieType:
                    name = commandWords[2];
                    position = Point.Parse(commandWords[3]);
                    Zombie newZombie = new Zombie(name, position);
                    this.AddOrganism(newZombie);
                    break;
                default:
                    base.ExecuteBirthCommand(commandWords);
                    break;
            }
        }
    }
}
