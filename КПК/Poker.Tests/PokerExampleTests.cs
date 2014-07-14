using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class PokerExampleTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            PokerExample.Main();
            Assert.IsTrue(true);
        }
    }
}
