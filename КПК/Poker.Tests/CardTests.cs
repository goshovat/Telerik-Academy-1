using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            Card card = new Card(CardFace.Nine, CardSuit.Hearts);
            string cardAsText = card.ToString();
            string expectedText = "Nine of Hearts";
            Assert.IsTrue(cardAsText == expectedText, "Invalid string converting of a card!");
        }
    }
}
