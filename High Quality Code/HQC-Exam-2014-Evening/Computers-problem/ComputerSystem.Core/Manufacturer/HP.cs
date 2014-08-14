namespace ComputerSystem.Core.Manufacturer
{
    using System;
    using ComputerSystem.Core.Computers;

    public class HP : ComputerFactory
    {
        public override PersonalComputer CreatePC()
        {
            var ram = new Ram((int)RamType.GB2);
            var videoCard = new VideoCard(false);
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new Cpu(2, (int)ArchitectureType.Bits32, motherBoard);
            var hardDrive = new HardDrive(500);
            var pc = new PersonalComputer(motherBoard, cpu, hardDrive);

            return pc;
        }

        public override Server CreateServer()
        {
            var ram = new Ram((int)RamType.GB32);
            var videoCard = new VideoCard();
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new Cpu(4, (int)ArchitectureType.Bits32, motherBoard);
            var hardDriveOne = new HardDrive(1000);
            var hardDriveTwo = new HardDrive(1000);
            var raid = new Raid(1000);
            raid.Add(hardDriveOne);
            raid.Add(hardDriveTwo);
            var server = new Server(motherBoard, cpu, raid);

            return server;
        }

        public override Laptop CreateLaptop()
        {
            var ram = new Ram((int)RamType.GB4);
            var videoCard = new VideoCard(false);
            var motherBoard = new Motherboard(ram, videoCard);
            var cpu = new Cpu(2, (int)ArchitectureType.Bits64, motherBoard);
            var hardDrive = new HardDrive(500);
            var laptopBattery = new LaptopBattery();
            var laptop = new Laptop(motherBoard, cpu, hardDrive, laptopBattery);

            return laptop;
        }
    }
}
