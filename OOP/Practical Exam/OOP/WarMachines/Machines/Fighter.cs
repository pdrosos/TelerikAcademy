namespace WarMachines.Machines
{
    using System;
    using System.Text;
    using WarMachines.Interfaces;

    /// <summary>
    /// Fighter
    /// </summary>
    public class Fighter : Machine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 200;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; protected set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        /// <summary>
        /// Fighter info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append(base.ToString()).AppendLine();

            // *Stealth: (“ON”/”OFF” – when applicable)
            info.AppendFormat(" *Stealth: {0}", this.StealthMode == true ? "ON" : "OFF");

            return info.ToString();
        }
    }
}
