namespace Computers.Types
{
    using System;
    using System.Collections.Generic;
    using Computers.Components;

    public abstract class Computer
    {
        public Computer(Cpu cpu, Ram ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
        }

        protected IEnumerable<HardDrive> HardDrives { get; set; }

        protected VideoCard VideoCard { get; set; }

        protected Cpu Cpu { get; set; }

        protected Ram Ram { get; set; }
    }
}
