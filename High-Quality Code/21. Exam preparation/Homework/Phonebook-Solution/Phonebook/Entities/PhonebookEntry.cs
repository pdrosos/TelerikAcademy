namespace Phonebook.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string name;
        private string nameToLower;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.nameToLower = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> Phones { get; set; }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            
            info.Append('[');
            info.Append(this.Name);

            bool isFirstPhone = true;
            foreach (var phone in this.Phones)
            {
                if (isFirstPhone)
                {
                    info.Append(": ");
                    isFirstPhone = false;
                }
                else
                {
                    info.Append(", ");
                }

                info.Append(phone);
            }

            info.Append(']');
            return info.ToString();
        }

        public int CompareTo(PhonebookEntry other)
        {
            return this.nameToLower.CompareTo(other.nameToLower);
        }
    }
}