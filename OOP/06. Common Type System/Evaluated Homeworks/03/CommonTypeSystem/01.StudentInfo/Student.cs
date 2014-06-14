using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentInfo
{
    public class Student : IComparable<Student>, ICloneable
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long SSN { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte Course { get; set; }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }

        public Student(string firstName, string middleName, string lastName, long ssn, string addres, string phone,
                        string email, byte course, Specialties specialty, Universities university, Faculties faculty) 
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Addres = addres;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public override bool Equals(object param)
        {
            Student student = param as Student;
            if ((object)student == null)
            {
                return false;
            }
            if (this.FirstName != student.FirstName || this.MiddleName != student.MiddleName ||
                this.LastName != student.LastName || this.SSN != student.SSN)
            {
                return false;
            }
                return true;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} SSN: {3}, Addres: {4}, Phone: {5}, Email {6}, Course: {7}, Specialty: {8}, University: {9}, Faculty: {10}",
                                    this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Addres, this.Phone,
                                    this.Email, this.Course, this.Specialty, this.University, this.Faculty);
        }

        public static bool operator == (Student firstStudent, Student secondStudent) 
        {
            return Student.Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !(Student.Equals(firstStudent, secondStudent));
        }

        public override int GetHashCode()
        {
            return this.LastName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public Student Clone()
        {
            Student clone = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Addres, this.Phone,
                                    this.Email, this.Course, this.Specialty, this.University, this.Faculty);
            return clone;
        }

        object ICloneable.Clone() 
        {
            return this.Clone();
        }

        public int CompareTo(Student secondStudent)
        {
            if (this.LastName != secondStudent.LastName)
            {
                return String.Compare(this.LastName, secondStudent.LastName);
            }
            if (this.SSN != secondStudent.SSN)
            {
                return this.SSN.CompareTo(secondStudent.SSN);
            }
            else
            {
                return 0;
            }
        }
    }
}