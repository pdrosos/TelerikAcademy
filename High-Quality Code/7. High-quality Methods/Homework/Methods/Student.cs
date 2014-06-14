namespace Methods
{
    using System;
    using System.Globalization;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string additionalDetails;
        private DateTime birthDate;

        public Student(string firstName, string lastName, string birthDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = this.ParseDate(birthDate);
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

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                this.birthDate = value;
            }
        }

        public string AdditionalDetails
        {
            get
            {
                return this.additionalDetails;
            }

            set
            {
                this.additionalDetails = value;
            }
        }

        public DateTime ParseDate(string birthDateString)
        {
            DateTime birthDate;

            try
            {
                birthDate = DateTime.ParseExact(birthDateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw;
            }

            return birthDate;
        }

        public bool IsOlderThan(Student otherStudent)
        {
            bool isOlder;

            if (this.BirthDate < otherStudent.BirthDate)
            {
                isOlder = true;
            }
            else
            {
                isOlder = false;
            }

            return isOlder;
        }
    }
}