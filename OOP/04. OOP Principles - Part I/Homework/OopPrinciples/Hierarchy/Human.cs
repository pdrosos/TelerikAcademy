namespace Hierarchy
{
    using System;

    /// <summary>
    /// Human
    /// </summary>
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Human(): this(null, null)
        {
        }

        public string FirstName
        {
            get 
            { 
                return firstName; 
            }
            set 
            { 
                firstName = value; 
            }
        }

        public string LastName
        {
            get 
            { 
                return lastName; 
            }
            set 
            { 
                lastName = value; 
            }
        }

        public override string ToString()
        {
            return String.Format("Human Name: {0, -10} {1, -10}", this.FirstName, this.LastName);
        }
    }
}
