namespace Computers.Types
{
    using System;
    using System.Collections.Generic;
    using Computers.Components;

    public class Laptop : Computer
    {
        private readonly Battery battery;

        public Laptop(
            Cpu cpu, 
            Ram ram, 
            IEnumerable<HardDrive> hardDrives, 
            VideoCard videoCard,
            Battery battery)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}%", this.battery.Percentage));
        }
    }
}