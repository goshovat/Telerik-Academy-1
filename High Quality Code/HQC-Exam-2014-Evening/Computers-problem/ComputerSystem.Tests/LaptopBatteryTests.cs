namespace ComputerSystem.Tests
{
    using ComputerSystem.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LaptopBatteryTests
    {
        [TestMethod]
        public void TestInitialValue()
        {
            var laptopBattery = new LaptopBattery();
            var initalPercentage = laptopBattery.Percentage;
            Assert.AreEqual(initalPercentage, 50);
        }

        [TestMethod]
        public void TestChargeWithNegativeNumber()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(-20);
            var initalPercentage = laptopBattery.Percentage;
            Assert.AreEqual(initalPercentage, 30);
        }

        [TestMethod]
        public void TestChargeWithPositiveNumber()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(50);
            var initalPercentage = laptopBattery.Percentage;
            Assert.AreEqual(initalPercentage, 100);
        }

        [TestMethod]
        public void TestChargeWithNegativeOutOfLimitNumber()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(-300);
            var initalPercentage = laptopBattery.Percentage;
            Assert.AreEqual(initalPercentage, 0);
        }

        [TestMethod]
        public void TestChargeWithPositiveOutOfLimitNumber()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(300);
            var initalPercentage = laptopBattery.Percentage;
            Assert.AreEqual(initalPercentage, 100);
        }

        [TestMethod]
        public void TestChargeWithZero()
        {
            var laptopBattery = new LaptopBattery();
            laptopBattery.Charge(0);
            var initalPercentage = laptopBattery.Percentage;
            Assert.AreEqual(initalPercentage, 50);
        }
    }
}
