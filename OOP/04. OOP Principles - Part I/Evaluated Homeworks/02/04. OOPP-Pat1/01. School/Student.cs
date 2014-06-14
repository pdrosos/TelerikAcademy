using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Student : Human
{
    public int NB { get; set; }

    public Student(string FN, string LN, string comment, int nb)
    {
        base.FistName = FN;
        base.LastName = LN;
        base.Comment = comment;
        this.NB = nb;
    }
    public Student(string FN, string LN, int nb)
    {
        base.FistName = FN;
        base.LastName = LN;
        this.NB = nb;
    }
}
