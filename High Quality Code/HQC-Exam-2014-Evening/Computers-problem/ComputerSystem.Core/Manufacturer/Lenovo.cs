namespace ComputerSystem.Core.Manufacturer
{
    using System;
    using ComputerSystem.Core.Computers;

    public class Lenovo : ComputerFactory
    {
        public override PersonalComputer CreatePC()
        {
            var ram = new Ram((int)RamType.GB4);
            var videoCard = new VideoCard();
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new AdvancedCpu(2, (int)ArchitectureType.Bits64, motherBoard);
            var hardDrive = new HardDrive(2000);
            var pc = new PersonalComputer(motherBoard, cpu, hardDrive);

            return pc;
        }

        public override Server CreateServer()
        {
            var ram = new Ram((int)RamType.GB8);
            var videoCard = new VideoCard();
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new AdvancedCpu(2, (int)ArchitectureType.Bits128, motherBoard);
            var hardDriveOne = new HardDrive(500);
            var hardDriveTwo = new HardDrive(500);
            var raid = new Raid(500);
            raid.Add(hardDriveOne);
            raid.Add(hardDriveTwo);
            var server = new Server(motherBoard, cpu, raid);

            return server;
        }

        public override Laptop CreateLaptop()
        {
            var ram = new Ram((int)RamType.GB16);
            var videoCard = new VideoCard(false);
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new AdvancedCpu(2, (int)ArchitectureType.Bits64, motherBoard);
            var hardDrive = new HardDrive(1000);
            var laptopBattery = new LaptopBattery();
            var laptop = new Laptop(motherBoard, cpu, hardDrive, laptopBattery);

            return laptop;
        }
    }
}
