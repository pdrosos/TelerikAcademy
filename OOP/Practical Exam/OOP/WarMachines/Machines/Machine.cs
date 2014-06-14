namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    /// <summary>
    /// Abstract machine
    /// </summary>
    public abstract class Machine : IMachine
    {
        protected string name;
        protected double attackPoints;
        protected double defensePoints;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;

            this.Targets = new List<string>();
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

        public IPilot Pilot { get; set; }

        public double HealthPoints { get; set; }

        public virtual double AttackPoints 
        { 
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                this.attackPoints = value;
            }
        }

        public virtual double DefensePoints 
        {
            get
            {
                return this.defensePoints;
            }
            protected set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets { get; protected set; }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        /// <summary>
        /// Machine info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            //- (machine name)
            // *Type: (“Tank”/”Fighter”)
            // *Health: (machine health points)
            // *Attack: (machine attack points)
            // *Defense: (machine defense points)
            // *Targets: (machine target names/”None” – comma separated)

            info.AppendFormat("- {0}", this.Name).AppendLine();
            info.AppendFormat(" *Type: {0}", this.GetType().Name).AppendLine();
            info.AppendFormat(" *Health: {0}", this.HealthPoints).AppendLine();
            info.AppendFormat(" *Attack: {0}", this.AttackPoints).AppendLine();
            info.AppendFormat(" *Defense: {0}", this.DefensePoints).AppendLine();

            info.Append(" *Targets: ");
            if (this.Targets.Count > 0)
            {
                info.Append(string.Join(", ", this.Targets));
            }
            else
            {
                info.Append("None");
            }

            return info.ToString();
        }
    }
}
