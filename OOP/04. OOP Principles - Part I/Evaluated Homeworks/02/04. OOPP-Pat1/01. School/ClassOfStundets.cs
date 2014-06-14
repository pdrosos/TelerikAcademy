using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ClassOfStundets
{
    public int ClassNb { get; set; }
    public char ClassChar { get; set; }
    public List<Student> ListOfStudents { get; set; }
    public List<Teacher> ListOfTeachers { get; set; }

    public ClassOfStundets(int nb, char chr, List<Student> listOfStudents,List<Teacher> listOfTeachers )
    {
        this.ClassNb = nb;
        this.ClassChar = chr;
        this.ListOfStudents = listOfStudents;
        this.ListOfTeachers = listOfTeachers;
    }
}

