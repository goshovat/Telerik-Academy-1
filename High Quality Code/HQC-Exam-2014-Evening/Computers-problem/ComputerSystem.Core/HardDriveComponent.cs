namespace ComputerSystem.Core
{
    using System.Collections.Generic;

    public abstract class HardDriveComponent
    {
        protected readonly int capacity;
        protected readonly Dictionary<int, string> data;

        public HardDriveComponent(int capacity)
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
        }

        public abstract int Capacity
        {
            get;
        }

        public abstract void SaveData(int address, string newData);

        public abstract string LoadData(int address);

        public abstract void Add(HardDriveComponent hardDrive);
    }
}
