namespace Chef
{
    using System;

    internal class Carrot : Vegetable
    {
        private const string NAME = "Carrot";

        public Carrot()
        {
            Console.WriteLine("Carrot was gotten");
        }

        public override void Peel()
        {
            string peelMessage = "Carrot was peeled";
            Console.WriteLine(peelMessage);
        }

        public override void Cut()
        {
            string cutMessage = "Carrot was cut";
            Console.WriteLine(cutMessage);
        }

        public override string ToString()
        {
            return NAME;
        }
    }
}
