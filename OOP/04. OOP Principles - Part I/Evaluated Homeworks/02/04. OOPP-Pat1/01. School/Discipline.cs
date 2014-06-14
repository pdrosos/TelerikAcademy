using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Discipline
{
    public string Name { get; set; }
    public int NbLectures { get; set; }
    public int NbExercises { get; set; }
    public string Comment { get; set; }

    public void PrintDisciplineName(Discipline disc)
    {
        Console.WriteLine(disc.Name);
    }

    public Discipline(string name, int lecs, int exs)
    {
        this.Name = name;
        this.NbLectures = lecs;
        this.NbExercises = exs;
    }

    public Discipline(string name, int lecs, int exs, string comment)
    {
        this.Name = name;
        this.NbLectures = lecs;
        this.NbExercises = exs;
        this.Comment = comment;
    }

}

