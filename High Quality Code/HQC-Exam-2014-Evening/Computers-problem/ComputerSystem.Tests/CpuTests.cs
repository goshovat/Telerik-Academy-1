namespace ComputerSystem.Tests
{
    using System;
    using ComputerSystem.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CpuTests
    {
        private IMotherboard motherboard;
        private Cpu cpu;

        public CpuTests()
            : this(new JustMockMotherboard())
        {
        }

        public CpuTests(IMotherboardMoq motherboardMock)
        {
            this.motherboard = motherboardMock.MotherboardData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.cpu = new Cpu(2, 128, this.motherboard);
        }

        [TestMethod]
        public void TestWithHigherRange()
        {
            cpu.GenerateRandomNumber(20, 40);
            var number = motherboard.LoadRamValue();
            Assert.AreEqual(number, 10);
        }
    }
}
