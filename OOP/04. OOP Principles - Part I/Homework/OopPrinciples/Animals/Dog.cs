namespace Animals
{
    /// <summary>
    /// Dog
    /// </summary>
    public class Dog : Animal
    {
        public Dog(string name, double age, Sex sex) : base(name, age, sex)
        {
        }

        public override string ProduceSound()
        {
            return "Bau";
        }
    }
}
