namespace Students
{
    using System;
    using System.Text;

    /// <summary>
    /// Student
    /// </summary>
    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string secondName;
        private string lastName;
        private string ssn;
        private string address;
        private string phoneNumber;
        private string email;
        private string course;
        private Specialty? specialty;
        private University? university;
        private Faculty? faculty;

        public Student(string firstName, string secondName, string lastName, string ssn)
            : this(firstName, secondName, lastName, ssn, null, null, null, null, null, null, null)
        {
        }

        public Student(
            string firstName,
            string secondName,
            string lastName,
            string ssn,
            string address,
            string phoneNumber,
            string email,
            string course,
            Specialty? specialty,
            University? university,
            Faculty? faculty)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        // properties
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

        public string SecondName
        {
            get
            {
                return this.secondName;
            }

            set
            {
                this.secondName = value;
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

        public string Ssn
        {
            get
            {
                return this.ssn;
            }

            set
            {
                this.ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.phoneNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string Course
        {
            get
            {
                return this.course;
            }

            set
            {
                this.course = value;
            }
        }

        public Specialty? Specialty
        {
            get
            {
                return this.specialty;
            }

            set
            {
                this.specialty = value;
            }
        }

        public University? University
        {
            get
            {
                return this.university;
            }

            set
            {
                this.university = value;
            }
        }

        public Faculty? Faculty
        {
            get
            {
                return this.faculty;
            }

            set
            {
                this.faculty = value;
            }
        }

        // methods
        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Ssn == secondStudent.Ssn;
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Ssn != secondStudent.Ssn;
        }

        /// <summary>
        /// Performs a deep cloning of student
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Student(
                this.FirstName,
                this.SecondName,
                this.LastName,
                this.Ssn,
                this.Address,
                this.PhoneNumber,
                this.Email,
                this.Course,
                this.Specialty,
                this.University,
                this.Faculty) as object;
        }

        /// <summary>
        /// Compares students
        /// </summary>
        /// <param name="stud"></param>
        /// <returns></returns>
        public int CompareTo(Student stud)
        {
            if (this.FirstName.CompareTo(stud.FirstName) != 0)
            {
                return this.FirstName.CompareTo(stud.FirstName);
            }
            else if (this.SecondName.CompareTo(stud.LastName) != 0)
            {
                return this.SecondName.CompareTo(stud.LastName);
            }
            else if (this.Ssn.CompareTo(stud.Ssn) != 0)
            {
                return this.Ssn.CompareTo(stud.Ssn);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if students are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (this.Ssn != student.Ssn)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get student hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Ssn.GetHashCode() ^ this.LastName.GetHashCode() ^ this.FirstName.GetHashCode();
        }

        /// <summary>
        /// Student info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder endText = new StringBuilder();

            endText.AppendFormat("First Name: {0} \n", this.FirstName);
            endText.AppendFormat("Second Name: {0} \n", this.SecondName);
            endText.AppendFormat("Last Name: {0} \n", this.LastName);
            endText.AppendFormat("SNN : {0} \n", this.Ssn);
            endText.AppendFormat("Address: {0} \n", this.Address);
            endText.AppendFormat("Phone number : {0} \n", this.PhoneNumber);
            endText.AppendFormat("Email: {0} \n", this.Email);
            endText.AppendFormat("Course: {0} \n", this.Course);
            endText.AppendFormat("Specialty: {0} \n", this.Specialty);
            endText.AppendFormat("University: {0} \n", this.University);
            endText.AppendFormat("Faculty: {0} \n", this.Faculty);

            return endText.ToString();
        }
    }
}