using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            StringBuilder stringRepresentation = new StringBuilder();

            stringRepresentation.AppendLine("Hand:");
            stringRepresentation.AppendLine(new string('-', 20));
            stringRepresentation.AppendLine("Ace of Clubs");
            stringRepresentation.AppendLine("Eight of Spades");
            stringRepresentation.AppendLine(new string('-', 20));

            Hand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Spades)
            });

            string handAsText = hand.ToString();
            string expectedText = stringRepresentation.ToString();
            Assert.IsTrue(handAsText == expectedText, "Invalid string converting of a hand!");
        }
    }
}
