using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Worker : Human
{
    public double WeekSalary { get; set; }
    public double WorkHoursPerDay { get; set; }
    static private int WorkDaysPerWeek = 5;

    public Worker(string FN, string LN, double weekSal, double hourPerDay)
    {
        base.FistName = FN;
        base.LastName = LN;
        this.WeekSalary = weekSal;
        this.WorkHoursPerDay = hourPerDay;
    }

    public void PrintMoneyPerHour()
    {
        Console.WriteLine("Earend by hour by the worker is : " + WorkHoursPerDay * WorkDaysPerWeek / WeekSalary);
    }
    public double MoneyPerHour()
    {
        //Console.WriteLine("Earend by hour by the worker is : " + WorkHoursPerDay * WorkDaysPerWeek / WeekSalary);
        return WorkHoursPerDay * WorkDaysPerWeek / WeekSalary;
    }

}

