namespace Chef
{
    using System;

    public class Vegetable
    {
        public virtual void Peel()
        {
            string peelMessage = "Vegetable was peeled";
            Console.WriteLine(peelMessage);
        }

        public virtual void Cut()
        {
            string cutMessage = "Vegetable was cut";
            Console.WriteLine(cutMessage);
        }
    }
}
