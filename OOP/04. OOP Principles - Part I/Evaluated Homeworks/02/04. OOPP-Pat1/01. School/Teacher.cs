using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Teacher : Human
{
    List<Discipline> TeachedDisciplines { get; set; }

    public Teacher(string FN, string LN, string comment, List<Discipline> teachedDisciplines)
    {
        base.FistName = FN;
        base.LastName = LN;
        base.Comment = comment;
        this.TeachedDisciplines = teachedDisciplines;
    }
    public Teacher(string FN, string LN, List<Discipline> teachedDisciplines)
    {
        base.FistName = FN;
        base.LastName = LN;
        this.TeachedDisciplines = teachedDisciplines;
    }
    public Teacher(string FN, string LN)
    {
        base.FistName = FN;
        base.LastName = LN;
    }

    public void PrintTeachedDisciplines(Teacher t)
    {

        foreach (Discipline discipline in t.TeachedDisciplines)
        {
            Console.WriteLine("-Discipline {0}, hours lectures {1}, hours exercises {2} ", discipline.Name, discipline.NbLectures, discipline.NbExercises);
        }
    }
}
