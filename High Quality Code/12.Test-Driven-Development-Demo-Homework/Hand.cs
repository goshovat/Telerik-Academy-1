using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder();

            stringRepresentation.AppendLine("Hand:");
            stringRepresentation.AppendLine(new string('-', 20));
            stringRepresentation.AppendLine(string.Join("\r\n", this.Cards));
            stringRepresentation.AppendLine(new string('-', 20));

            return stringRepresentation.ToString();
        }
    }
}
