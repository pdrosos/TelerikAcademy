namespace PotatoCooking
{
    public class PotatoCooking
    {
        public static void Main(string[] args)
        {
            Potato potato = new Potato();

            if (potato.IsPeeled && potato.IsFresh)
            {
                Cook(potato);
            }
        }

        public static void Cook(Potato potato)
        {
            // ...
        }
    }
}
