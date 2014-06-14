namespace Restaurant
{
    using System.Collections.Generic;

    public class Bowl
    {
        private IList<Vegetable> items = new List<Vegetable>();

        public IList<Vegetable> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
            }
        }

        public void Add(Vegetable vegetable)
        {
            this.items.Add(vegetable);
        }
    }
}
