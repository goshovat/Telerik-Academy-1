namespace ComputerSystem.Core
{
    using System;

    public class HardDrive : HardDriveComponent
    {
        public HardDrive(int capacity)
            : base(capacity)
        {
        }

        public override int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public override void SaveData(int addr, string newData)
        {
            this.data[addr] = newData;
        }

        public override string LoadData(int address)
        {
            return this.data[address];
        }

        public override void Add(HardDriveComponent hardDrive)
        {
            throw new ArgumentException("Hard drivers cannot add another hard driver!");
        }
    }
}
