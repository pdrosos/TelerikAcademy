namespace Restaurant
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            Bowl bowl = this.GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();
            return carrot;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();
            return potato;
        }

        private void Peel(Vegetable vegetable)
        {
        }

        private void Cut(Vegetable vegetable)
        {
        }

        private Bowl GetBowl()
        {
            Bowl bowl = new Bowl();
            return bowl;
        }
    }
}
