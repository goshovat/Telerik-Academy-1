namespace _03.Hierarchy
{
    using System;

    public class Cat : Animal
    {
        public Cat(string name, ushort age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public override void Sound()
        {            
            string message = "Mew, purrrrr";
            Console.WriteLine("{0}: {1}", this.name, message);
        }
    }
}
