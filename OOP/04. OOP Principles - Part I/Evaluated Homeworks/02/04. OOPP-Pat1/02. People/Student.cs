using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Student : Human
{
    public double grade { get; set; }
    public double Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            if (this.grade < 1 && this.grade > 10)
            {
                throw new Exception("Grade must be between 1 and 10");
            }
            else Grade = value;
        }
    }

    public Student(string FN, string LN, double gr)
    {
        base.FistName = FN;
        base.LastName = LN;
        this.grade = gr;
    }
    public Student(string FN, string LN)
    {
        base.FistName = FN;
        base.LastName = LN;
    }
}

