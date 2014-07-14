namespace CompositePattern
{
    using System;

    public class Person : Human
    {
        public Person(string name, string position)
            : base(name, position)
        {
        }

        public override void Add(Human person)
        {
            Console.WriteLine("I can't add anything, I am just a person.");
        }

        public override void Remove(Human person)
        {
            Console.WriteLine("I can't remove anything, I am just a person.");
        }

        public override void Work(int counter)
        {
            Console.WriteLine("{0}Name: {1}, Position {2}, let's work!", new string(' ', counter), this.name, this.position);
        }
    }
}
