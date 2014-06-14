namespace Hierarchy
{
    using System;

    /// <summary>
    /// Worker
    /// </summary>
    public class Worker: Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay): base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public Worker()
        {
        }
        
        public decimal WeekSalary
        {
            get 
            { 
                return this.weekSalary; 
            }
            set 
            { 
                this.weekSalary = value; 
            }
        }

        public double WorkHoursPerDay
        {
            get 
            { 
                return this.workHoursPerDay; 
            }
            set 
            { 
                this.workHoursPerDay = value; 
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = WeekSalary / (decimal)(WorkHoursPerDay * 5);
            return moneyPerHour;
        }

        public override string ToString()
        {
            return String.Format("Worker Name: {0, -11} {1, -10}, Week Salary: {2, -5}, Work Hours Per Day: {3, -3}, Money Per Hour: {4, -4:F2}"
                , this.FirstName, this.LastName, this.WeekSalary, this.WorkHoursPerDay, this.MoneyPerHour());
        }
    }
}
