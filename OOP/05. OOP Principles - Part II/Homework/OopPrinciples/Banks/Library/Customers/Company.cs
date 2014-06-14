namespace Banks.Library.Customers
{
    using System.Text;

    /// <summary>
    /// Company customer
    /// </summary>
    public class Company : Customer
    {
        protected string name;
        protected string bulstat;

        public Company(string name, string bulstat)
        {
            this.Name = name;
            this.Bulstat = bulstat;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Bulstat
        {
            get
            {
                return this.bulstat;
            }
            set
            {
                this.bulstat = value;
            }
        }

        /// <summary>
        /// Customer information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(base.ToString());
            info.Append("Name: ").AppendLine(this.Name);
            info.Append("Bulstat: ").AppendLine(this.Bulstat);

            return info.ToString();
        }
    }
}
