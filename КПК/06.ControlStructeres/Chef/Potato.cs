namespace Chef
{
    using System;

    public class Potato : Vegetable
    {
        private const string NAME = "Potato";

        public Potato()
        {
            Console.WriteLine("Potato was gotten");
            this.HasBeenPeeled = false;
            this.IsFresh = true;
        }

        public bool HasBeenPeeled { get; private set; }

        public bool IsFresh { get; private set; }

        public override void Peel()
        {
            string peelMessage = "Potato was peeled";
            this.HasBeenPeeled = true;
            Console.WriteLine(peelMessage);
        }

        public override void Cut()
        {
            string cutMessage = "Potato was cut";
            Console.WriteLine(cutMessage);
        }

        public override string ToString()
        {
            return NAME;
        }
    }
}
