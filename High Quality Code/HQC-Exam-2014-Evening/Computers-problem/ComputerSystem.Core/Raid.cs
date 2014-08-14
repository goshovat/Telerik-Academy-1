namespace ComputerSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Raid : HardDriveComponent
    {
        private readonly ICollection<HardDriveComponent> hardDrives;

        public Raid(int capacity, ICollection<HardDriveComponent> hardDrives)
            : base(capacity)
        {
            this.hardDrives = hardDrives;
        }

        public Raid(int capacity)
            : this(capacity, new List<HardDriveComponent>())
        {
        }

        public override int Capacity
        {
            get
            {
                return this.hardDrives.First().Capacity;
            }
        }

        public override void SaveData(int addr, string newData)
        {
            foreach (var hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(addr, newData);
            }
        }

        public override string LoadData(int address)
        {
            if (!this.hardDrives.Any())
            {
                throw new OutOfMemoryException("No hard drive in the RAID array!");
            }

            return this.hardDrives.First().LoadData(address);
        }

        public override void Add(HardDriveComponent hardDrive)
        {
            this.hardDrives.Add(hardDrive);
        }
    }
}
