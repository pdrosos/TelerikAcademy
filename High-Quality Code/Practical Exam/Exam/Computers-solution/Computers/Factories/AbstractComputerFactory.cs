namespace Computers.Factories
{
    using System.Collections.Generic;
    using Computers.Components;
    using Computers.Types;

    public abstract class AbstractComputerFactory
    {
        public abstract Pc CreatePc();

        public abstract Server CreateServer();

        public abstract Laptop CreateLaptop();

        protected abstract Cpu CreateCpu(byte numberOfCores, byte numberOfBits, Ram ram, VideoCard videoCard);

        protected abstract Ram CreateRam(int amount);

        protected abstract HardDrive CreateHardDrive(int capacity, bool isInRaid, int hardDrivesInRaid);

        protected abstract IList<HardDrive> CreateHardDrivesForPc();

        protected abstract IList<HardDrive> CreateHardDrivesForLaptop();

        protected abstract IList<HardDrive> CreateHardDrivesForServer();

        protected abstract VideoCard CreateVideoCard(bool isMonochrome);
    }
}
