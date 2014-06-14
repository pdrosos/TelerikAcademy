namespace Banks.Library.Customers
{
    using System.Text;

    /// <summary>
    /// Individual customer
    /// </summary>
    public class Individual : Customer
    {
        protected string firstName;
        protected string lastName;
        protected string egn;

        public Individual(string firstName, string lastName, string egn)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Egn = egn;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string Egn
        {
            get
            {
                return this.egn;
            }
            set
            {
                this.egn = value;
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
            info.Append("Name: ").Append(this.FirstName).Append(" ").AppendLine(this.LastName);
            info.Append("Egn: ").AppendLine(this.Egn);

            return info.ToString();
        }
    }
}
