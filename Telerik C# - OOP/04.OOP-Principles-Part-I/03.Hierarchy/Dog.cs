namespace _03.Hierarchy
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, ushort age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public override void Sound()
        {
            string message = "woof woof, bow wow, grrrrrrr";
            Console.WriteLine("{0}: {1}", this.name, message);
        }
    }
}
