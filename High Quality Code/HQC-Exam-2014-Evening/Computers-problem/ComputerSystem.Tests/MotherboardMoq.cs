namespace ComputerSystem.Tests
{
    using ComputerSystem.Core;

    public abstract class MotherboardMoq : IMotherboardMoq
    {
        public MotherboardMoq()
        {

            this.ArrangeCarsRepositoryMock();
        }

        public IMotherboard MotherboardData { get; protected set; }

        protected abstract void ArrangeCarsRepositoryMock();
    }
}
