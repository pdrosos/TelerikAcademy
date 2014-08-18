namespace Computers.Factories
{
    using System.Collections.Generic;
    using Computers.Components;
    using Computers.Components.Factories;
    using Computers.Types;

    public class LenovoFactory : AbstractComputerFactory
    {
        private const int PcRam = 4;
        private const int PcCpuCores = 2;
        private const int PcCpuBits = 64;
        private const int PcHddCapacity = 2000;

        private const int ServerRam = 8;
        private const int ServerCpuCores = 2;
        private const int ServerCpuBits = 128;
        private const int ServerHddCapacity = 500;

        private const int LaptopRam = 16;
        private const int LaptopCpuCores = 2;
        private const int LaptopCpuBits = 64;
        private const int LaptopHddCapacity = 1000;

        public override Pc CreatePc()
        {
            Ram ram = this.CreateRam(PcRam);
            VideoCard videoCard = this.CreateVideoCard(true);
            Cpu cpu = this.CreateCpu(PcCpuCores, PcCpuBits, ram, videoCard);
            IList<HardDrive> hardDrives = this.CreateHardDrivesForPc();

            Pc pc = new Pc(cpu, ram, hardDrives, videoCard);

            return pc;
        }

        public override Server CreateServer()
        {
            Ram ram = this.CreateRam(ServerRam);
            VideoCard videoCard = this.CreateVideoCard(true);
            Cpu cpu = this.CreateCpu(ServerCpuCores, ServerCpuBits, ram, videoCard);
            IList<HardDrive> hardDrives = this.CreateHardDrivesForServer();

            Server server = new Server(cpu, ram, hardDrives, videoCard);

            return server;
        }

        public override Laptop CreateLaptop()
        {
            Ram ram = this.CreateRam(LaptopRam);
            VideoCard videoCard = this.CreateVideoCard(false);
            Cpu cpu = this.CreateCpu(LaptopCpuCores, LaptopCpuBits, ram, videoCard);
            IList<HardDrive> hardDrives = this.CreateHardDrivesForLaptop();
            Battery battery = new Battery();

            Laptop laptop = new Laptop(cpu, ram, hardDrives, videoCard, battery);

            return laptop;
        }

        protected override Cpu CreateCpu(byte numberOfCores, byte numberOfBits, Ram ram, VideoCard videoCard)
        {
            return new Cpu(numberOfCores, numberOfBits, ram, videoCard);
        }

        protected override Ram CreateRam(int amount)
        {
            return new Ram(amount);
        }

        protected override HardDrive CreateHardDrive(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            return new HardDrive(capacity, isInRaid, hardDrivesInRaid);
        }

        protected override IList<HardDrive> CreateHardDrivesForPc()
        {
            List<HardDrive> hardDrives = new List<HardDrive>();

            HardDrive hardDrive = this.CreateHardDrive(PcHddCapacity, false, 0);
            hardDrives.Add(hardDrive);

            return hardDrives;
        }

        protected override IList<HardDrive> CreateHardDrivesForServer()
        {
            List<HardDrive> hardDrives = new List<HardDrive>();

            HardDrive hardDrive = this.CreateHardDrive(ServerHddCapacity, false, 0);
            hardDrives.Add(hardDrive);
            hardDrive = this.CreateHardDrive(ServerHddCapacity, false, 0);
            hardDrives.Add(hardDrive);

            return hardDrives;
        }

        protected override IList<HardDrive> CreateHardDrivesForLaptop()
        {
            List<HardDrive> hardDrives = new List<HardDrive>();

            HardDrive hardDrive = new HardDrive(LaptopHddCapacity, false, 0);
            hardDrives.Add(hardDrive);

            return hardDrives;
        }

        protected override VideoCard CreateVideoCard(bool isMonochrome)
        {
            return VideoCardFactory.CreateVideoCard(isMonochrome);
        }
    }
}
