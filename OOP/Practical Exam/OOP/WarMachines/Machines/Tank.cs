namespace WarMachines.Machines
{
    using System;
    using System.Text;
    using WarMachines.Interfaces;

    /// <summary>
    /// Tank
    /// </summary>
    public class Tank : Machine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 100;
            this.DefenseMode = true;
        }

        public override double AttackPoints
        {
            get
            {
                if (this.DefenseMode == true)
                {
                    return this.attackPoints - 40;
                }

                return this.attackPoints;
            }
        }

        public override double DefensePoints
        {
            get
            {
                if (this.DefenseMode == true)
                {
                    return this.defensePoints + 30;
                }

                return this.defensePoints;
            }
        }

        public bool DefenseMode { get; protected set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
        }

        /// <summary>
        /// Tank info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(base.ToString()).AppendLine();

            // *Defense: (“ON”/”OFF” – when applicable)
            info.AppendFormat(" *Defense: {0}", this.DefenseMode == true ? "ON" : "OFF");

            return info.ToString();
        }
    }
}
