using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        private readonly PokerHandsChecker checker = new PokerHandsChecker();

        [TestMethod]
        public void IsValidHandCardsNumberTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            Assert.IsTrue(checker.IsValidHand(hand), "Invalid cards count checker!");
        }

        [TestMethod]
        public void IsValidHandCardsNumberFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            });

            Assert.IsFalse(checker.IsValidHand(hand), "Invalid cards count checker!");
        }

        [TestMethod]
        public void IsValidHandDifferentCardsTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            Assert.IsTrue(checker.IsValidHand(hand), "Invalid checker for different cards!");
        }

        [TestMethod]
        public void IsValidHandDifferentCardsFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            Assert.IsFalse(checker.IsValidHand(hand), "Invalid checker for different cards!");
        }

        [TestMethod]
        public void IsStraightFlushTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            Assert.IsTrue(checker.IsStraightFlush(hand), "Invalid checker for straight flush!");
        }

        [TestMethod]
        public void IsStraightFlushFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            });

            Assert.IsFalse(checker.IsStraightFlush(hand), "Invalid checker for straight flush!");
        }

        [TestMethod]
        public void IsStraightFlushFalseActualFlushTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });

            Assert.IsFalse(checker.IsStraightFlush(hand), "Invalid checker for straight flush!");
        }

        [TestMethod]
        public void IsFourOfAKindTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            Assert.IsTrue(checker.IsFourOfAKind(hand), "Invalid checker for four of a kind!");
        }

        [TestMethod]
        public void IsFourOfAKindFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            });

            Assert.IsFalse(checker.IsFourOfAKind(hand), "Invalid checker for four of a kind!");
        }

        [TestMethod]
        public void IsFullHouseTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts)
            });

            Assert.IsTrue(checker.IsFullHouse(hand), "Invalid checker for full house!");
        }

        [TestMethod]
        public void IsFullHouseFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts)
            });

            Assert.IsFalse(checker.IsFullHouse(hand), "Invalid checker for full house!");
        }

        [TestMethod]
        public void IsFlushTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades)
            });

            Assert.IsTrue(checker.IsFlush(hand), "Invalid checker for flush!");
        }

        [TestMethod]
        public void IsFlushFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades)
            });

            Assert.IsFalse(checker.IsFlush(hand), "Invalid checker for flush!");
        }

        [TestMethod]
        public void IsFlushFalseActualStraightTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades)
            });

            Assert.IsFalse(checker.IsFlush(hand), "Invalid checker for flush!");
        }

        [TestMethod]
        public void IsStraightTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsTrue(checker.IsStraight(hand), "Invalid checker for straight!");
        }

        [TestMethod]
        public void IsStraightFalseActualStraightFlushTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            });

            Assert.IsFalse(checker.IsStraight(hand), "Invalid checker for straight!");
        }

        [TestMethod]
        public void IsStraightFalseActualFlushTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            });

            Assert.IsFalse(checker.IsStraight(hand), "Invalid checker for straight!");
        }

        [TestMethod]
        public void IsThreeOfAKindTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsTrue(checker.IsThreeOfAKind(hand), "Invalid checker for three of a kind!");
        }

        [TestMethod]
        public void IsThreeOfAKindFalseActualFullHouseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs)
            });

            Assert.IsFalse(checker.IsThreeOfAKind(hand), "Invalid checker for three of a kind!");
        }

        [TestMethod]
        public void IsTwoPairTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsTrue(checker.IsTwoPair(hand), "Invalid checker for two pair!");
        }

        [TestMethod]
        public void IsTwoPairFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsFalse(checker.IsTwoPair(hand), "Invalid checker for two pair!");
        }

        [TestMethod]
        public void IsOnePairTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsTrue(checker.IsOnePair(hand), "Invalid checker for one pair!");
        }

        [TestMethod]
        public void IsOnePairFalseActualFullHouseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs)
            });

            Assert.IsFalse(checker.IsOnePair(hand), "Invalid checker for one pair!");
        }

        [TestMethod]
        public void IsOnePairFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsFalse(checker.IsOnePair(hand), "Invalid checker for one pair!");
        }

        [TestMethod]
        public void IsHighCardTrueTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsTrue(checker.IsHighCard(hand), "Invalid checker for high card!");
        }

        [TestMethod]
        public void IsHighCardFalseTest()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });

            Assert.IsFalse(checker.IsHighCard(hand), "Invalid checker for high card!");
        }

        [TestMethod]
        public void CompareHandsTrueEqualTest()
        {
            IHand firstHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });

            IHand secondHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });


            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 0, "Invalid comparison hands operations!");
        }

        [TestMethod]
        public void CompareHandsTrueFirstHandBetterTest1()
        {
            IHand firstHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            IHand secondHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });


            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1, "Invalid comparison hands operations!");
        }

        [TestMethod]
        public void CompareHandsTrueFirstHandBetterTest2()
        {
            IHand firstHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            IHand secondHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });


            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1, "Invalid comparison hands operations!");
        }

        [TestMethod]
        public void CompareHandsTrueFirstHandBetterTest3()
        {
            IHand firstHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            IHand secondHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });


            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1, "Invalid comparison hands operations!");
        }

        [TestMethod]
        public void CompareHandsTrueSecondHandBetterTest1()
        {
            IHand firstHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            IHand secondHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });


            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1, "Invalid comparison hands operations!");
        }


        [TestMethod]
        public void CompareHandsTrueSecondHandBetterTest2()
        {
            IHand firstHand = new Hand(new List<ICard>() {   
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });

            IHand secondHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades)
            });

            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1, "Invalid comparison hands operations!");
        }
    }
}
