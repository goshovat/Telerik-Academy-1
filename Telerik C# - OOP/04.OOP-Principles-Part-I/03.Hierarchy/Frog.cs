namespace _03.Hierarchy
{
    using System;

    public class Frog : Animal
    {
        public Frog(string name, ushort age, bool isMale)
            : base(name, age, isMale)
        {
        }
        public override void Sound()
        {
            string message = "riddit-riddit";
            Console.WriteLine("{0}: {1}", this.name, message);
        }
    }
}
