namespace WarMachines.Pilots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    /// <summary>
    /// Pilot
    /// </summary>
    public class Pilot : IPilot
    {
        protected string name;

        protected List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be null or empty");
                }

                this.name = value;
            }
        }

        public ICollection<IMachine> Machines
        {
            get
            {
                return this.machines;
            }
        }

        /// <summary>
        /// Engage a machine to pilot
        /// </summary>
        /// <param name="machine"></param>
        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        /// <summary>
        /// Generate report
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            StringBuilder report = new StringBuilder();

            // (pilot name) – (number of machines/”no”) (“machine”/”machines”)
            report.AppendFormat("{0} - ", this.Name);

            if (this.Machines.Count > 0)
            {
                report.Append(this.Machines.Count);
                report.AppendFormat(" {0}", this.Machines.Count == 1 ? "machine" : "machines").AppendLine();

                foreach (IMachine machine in this.OrderMachines())
                {
                    report.AppendLine(machine.ToString());
                }
            }
            else
            {
                report.Append("no machines");
            }

            return report.ToString().TrimEnd();
        }

        protected List<IMachine> OrderMachines()
        {
            IOrderedEnumerable<IMachine> result = this.Machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);

            return result.ToList();
        }
    }
}
