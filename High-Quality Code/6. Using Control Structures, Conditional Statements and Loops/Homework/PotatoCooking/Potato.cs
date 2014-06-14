namespace PotatoCooking
{
    public class Potato
    {
        private bool isPeeled;
        private bool isFresh;

        public Potato()
        {
            this.IsPeeled = false;
            this.IsFresh = true;
        }

        public bool IsPeeled
        {
            get
            {
                return this.isPeeled;
            }

            set
            {
                this.isPeeled = value;
            }
        }

        public bool IsFresh
        {
            get
            {
                return this.isFresh;
            }

            set
            {
                this.isFresh = value;
            }
        }
    }
}
