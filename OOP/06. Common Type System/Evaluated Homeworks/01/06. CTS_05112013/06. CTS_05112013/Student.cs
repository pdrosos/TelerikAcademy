using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

enum Course { None, First, Second, Third, Fourth, Fifth };
enum University { None, SofiaUni, PlovdivUni, VarnaUni, BurgasUni };
enum Specialty { None, Stroitelstv, Kofraji, Peene, Svirene, Smqtane };
enum Faculty { None, FMI, StopFac, Medicine, Languages, Law };

class Student : ICloneable, IComparable<Student>
{
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string lastName { get; set; }
    public int ssn { get; set; }
    public string permanentAddress { get; set; }
    public string mobilePhone { get; set; }
    public string eMail { get; set; }
    public Course course { get; set; }
    public Specialty specialty { get; set; }
    public University uni { get; set; }
    public Faculty faculty { get; set; }
    public int facNumber { get; set; }
    public int age { get; set; }

    public Student(string fName, string lName, int socialSecNum, University university)
    {
        this.firstName = fName;
        this.lastName = lName;
        this.ssn = socialSecNum;
        this.uni = university;
    }

    public Student()
    {
    }

    /*Promlem #1:*/
    public override bool Equals(object obj)//if the social sec number maches then it is the same student
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }
        // If parameter cannot be cast to Point return false.
        Student stdObject = obj as Student;
        if ((Object)stdObject == null)
        {
            return false;
        }
        // Return true if the fields match:
        return (ssn == stdObject.ssn);
    }

    public override string ToString()//stirned student is student name, last name and sssn
    {
        StringBuilder stringedStuden = new StringBuilder();
        stringedStuden.Append(this.firstName);
        stringedStuden.Append(" ");
        stringedStuden.Append(this.lastName);
        stringedStuden.Append(" : ");
        stringedStuden.Append(this.ssn);
        return stringedStuden.ToString();
    }

    public override int GetHashCode()
    {
        return facNumber ^ age;
    }

    public static bool operator ==(Student student1, Student student2)
    {
        return Student.Equals(student1, student2);
    }
    public static bool operator !=(Student student1, Student student2)
    {
        return !(Student.Equals(student1, student2));
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }

    /*Problem #2: Add implementations of the ICloneable interface. 
     * The Clone() method should deeply copy all object's fields into a new object of type Student.*/
    public Student Clone()
    {
        Student newStudent = new Student();
        newStudent.firstName = (string)this.firstName.Clone();
        if (this.middleName != null)
        {
            newStudent.middleName = (string)this.middleName.Clone();
        }
        else
        {
            newStudent.middleName = null;
        }

        newStudent.lastName = (string)this.lastName.Clone();

        newStudent.ssn = (int)this.ssn;

        if (this.permanentAddress != null)
        {
            newStudent.permanentAddress = (string)this.permanentAddress.Clone();
        }
        else
        {
            newStudent.permanentAddress = null;
        }

        if (this.mobilePhone != null)
        {
            newStudent.mobilePhone = (string)this.mobilePhone.Clone();
        }
        else
        {
            newStudent.mobilePhone = null;
        }

        if (this.eMail != null)
        {
            newStudent.eMail = (string)this.eMail.Clone();
        }
        else
        {
            newStudent.eMail = null;
        }

        newStudent.facNumber = (int)this.facNumber;//value type
        newStudent.age = (int)this.age;//value type

        newStudent.course = (Course)this.course;
        newStudent.specialty = (Specialty)this.specialty;
        newStudent.uni = (University)this.uni;
        newStudent.faculty = (Faculty)this.faculty;
        return newStudent;
    }
    /*Prblem #3: Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) 
     * and by social security number (as second criteria, in increasing order).*/
    public int CompareTo(Student compareStudent)
    {
        string thisFullName = this.firstName + this.middleName + this.lastName;
        string compareStudentname = compareStudent.firstName + compareStudent.middleName + compareStudent.lastName;
        int thisSSN = this.ssn;
        int compareSSN = compareStudent.ssn;

        if (thisFullName != compareStudentname)
        {
            return String.Compare(thisFullName, compareStudentname);
        }
        else if (thisSSN != compareSSN)
        {
            return thisSSN - compareSSN;
        }
        else
        {
            return 0;
        }
    }
}

