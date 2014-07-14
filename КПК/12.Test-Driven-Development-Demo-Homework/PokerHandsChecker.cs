using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private readonly IEnumerable<CardFace> faces = Enum.GetValues(typeof(CardFace)).Cast<CardFace>();
        private readonly IEnumerable<CardSuit> suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();

        public bool IsValidHand(IHand hand)
        {
            bool isValid = true;

            if (hand.Cards.Count != 5)
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < hand.Cards.Count; i++)
                {
                    for (int j = i + 1; j < hand.Cards.Count; j++)
                    {
                        if (hand.Cards[i].Face == hand.Cards[j].Face && hand.Cards[i].Suit == hand.Cards[j].Suit)
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool areEqualSuits = false;
            bool isStraightFlush = false;

            foreach (var suit in suits)
            {
                if (hand.Cards.Select(x => x).Where(x => x.Suit == suit).Count() == 5)
                {
                    areEqualSuits = true;
                }
            }

            if (areEqualSuits)
            {
                isStraightFlush = true;
                ICard[] sortedCards = hand.Cards.ToArray();
                Array.Sort(sortedCards, ((a, b) => a.Face.CompareTo(b.Face)));

                for (int i = 0; i < sortedCards.Length - 1; i++)
                {
                    if (sortedCards[i].Face != sortedCards[i + 1].Face - 1)
                    {
                        isStraightFlush = false;
                        break;
                    }
                }
            }

            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            List<int> fourOfAKinds = new List<int>();
            bool isFourOfAKind = false;

            foreach (var face in faces)
            {
                fourOfAKinds.Add(hand.Cards.Select(x => x).Where(x => x.Face == face).Count());

                if (fourOfAKinds.Last() == 4)
                {
                    isFourOfAKind = true;
                    break;
                }
            }

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            List<int> fullHouses = new List<int>();
            bool hasThreeOfAKind = false;
            bool hasTwoOfAKind = false;

            foreach (var face in faces)
            {
                fullHouses.Add(hand.Cards.Select(x => x).Where(x => x.Face == face).Count());

                if (fullHouses.Last() == 3)
                {
                    hasThreeOfAKind = true;
                }

                if (fullHouses.Last() == 2)
                {
                    hasTwoOfAKind = true;
                }
            }

            return hasThreeOfAKind && hasTwoOfAKind;
        }

        public bool IsFlush(IHand hand)
        {
            bool areEqualSuits = false;

            foreach (var suit in suits)
            {
                if (hand.Cards.Select(x => x).Where(x => x.Suit == suit).Count() == 5)
                {
                    areEqualSuits = true;
                }
            }

            return areEqualSuits;
        }

        public bool IsStraight(IHand hand)
        {
            bool areEqualSuits = false;
            bool isStraight = false;

            foreach (var suit in suits)
            {
                if (hand.Cards.Select(x => x).Where(x => x.Suit == suit).Count() == 5)
                {
                    areEqualSuits = true;
                }
            }

            if (!areEqualSuits)
            {
                isStraight = true;
                ICard[] sortedCards = hand.Cards.ToArray();
                Array.Sort(sortedCards, ((a, b) => a.Face.CompareTo(b.Face)));

                for (int i = 0; i < sortedCards.Length - 1; i++)
                {
                    if (sortedCards[i].Face != sortedCards[i + 1].Face - 1)
                    {
                        isStraight = false;
                    }
                }
            }

            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            List<int> threeOfAKinds = new List<int>();
            bool isThreeOfAKind = false;

            foreach (var face in faces)
            {
                threeOfAKinds.Add(hand.Cards.Select(x => x).Where(x => x.Face == face).Count());

                if (threeOfAKinds.Last() == 3)
                {
                    isThreeOfAKind = true;
                }

                if (threeOfAKinds.Last() == 2)
                {
                    isThreeOfAKind = false;
                    break;
                }
            }

            return isThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            List<int> pairs = new List<int>();
            bool isOnePair = false;
            bool isTwoPair = false;

            foreach (var face in faces)
            {
                pairs.Add(hand.Cards.Select(x => x).Where(x => x.Face == face).Count());

                if (pairs.Last() == 2)
                {
                    if (isOnePair)
                    {
                        isTwoPair = true;
                        break;
                    }
                    else
                    {
                        isOnePair = true;
                    }
                }
            }

            return isTwoPair;
        }

        public bool IsOnePair(IHand hand)
        {
            List<int> pairs = new List<int>();
            bool isOnePair = false;

            foreach (var face in faces)
            {
                pairs.Add(hand.Cards.Select(x => x).Where(x => x.Face == face).Count());

                if (pairs.Last() == 2)
                {
                    if (isOnePair)
                    {
                        isOnePair = false;
                        break;
                    }
                    else
                    {
                        isOnePair = true;
                    }
                }

                if (pairs.Last() == 3)
                {
                    isOnePair = false;
                    break;
                }
            }

            return isOnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            bool isHighCard = true;

            if (IsStraightFlush(hand) ||
                IsFourOfAKind(hand) ||
                IsFullHouse(hand) ||
                IsFlush(hand) ||
                IsStraight(hand) ||
                IsThreeOfAKind(hand) ||
                IsTwoPair(hand) ||
                IsOnePair(hand))
            {
                isHighCard = false;
            }

            return isHighCard;
        }

        private HandType GetHandType(IHand hand)
        {
            HandType handType = HandType.HighCard;

            if (IsStraightFlush(hand))
            {
                handType = HandType.StraightFlush;
            }
            else if (IsFourOfAKind(hand))
            {
                handType = HandType.FourOfAKind;
            }
            else if (IsFullHouse(hand))
            {
                handType = HandType.FullHouse;
            }
            else if (IsFlush(hand))
            {
                handType = HandType.Flush;
            }
            else if (IsStraight(hand))
            {
                handType = HandType.Straight;
            }
            else if (IsThreeOfAKind(hand))
            {
                handType = HandType.ThreeOfAKind;
            }
            else if (IsTwoPair(hand))
            {
                handType = HandType.TwoPair;
            }
            else if (IsOnePair(hand))
            {
                handType = HandType.OnePair;
            }

            return handType;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            HandType firstHandType = GetHandType(firstHand);
            HandType secondHandType = GetHandType(secondHand);

            if (firstHandType == secondHandType)
            {
                return 0;
            }
            else if (firstHandType > secondHandType)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
