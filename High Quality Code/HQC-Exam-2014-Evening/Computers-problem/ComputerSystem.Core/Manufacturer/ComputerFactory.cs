namespace ComputerSystem.Core.Manufacturer
{
    using ComputerSystem.Core.Computers;

    public abstract class ComputerFactory
    {
        public abstract PersonalComputer CreatePC(); 
        
        public abstract Server CreateServer();

        public abstract Laptop CreateLaptop();
    }
}
