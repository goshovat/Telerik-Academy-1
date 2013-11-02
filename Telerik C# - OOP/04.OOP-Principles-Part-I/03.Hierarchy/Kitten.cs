namespace _03.Hierarchy
{
    using System;

    public class Kitten : Cat
    {
        public Kitten(string name, ushort age)
            : base(name, age, false)
        {
        }
    }
}
