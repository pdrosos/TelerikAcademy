using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class School
{
    public string SchoolName { get; set; }
    public List<ClassOfStundets> SchoolClasses { get; set; }

    public School(string Name, List<ClassOfStundets> Classes)
    {
        this.SchoolName = Name;
        this.SchoolClasses = Classes;
    }
}
