namespace ComputerSystem.Core.Computers
{
    public interface IComputer
    {
        IMotherboard Motherboard { get; set; }

        Cpu Cpu { get; set; }

        HardDriveComponent HardDrive { get; set; }
    }
}
