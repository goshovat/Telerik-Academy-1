namespace CompositePattern
{
    using System;
    using System.Collections.Generic;

    public class Boss : Human
    {
        private ICollection<Human> people;

        public Boss(string name, string position)
            : base(name, position)
        {
            this.people = new List<Human>();
        }

        public override void Add(Human person)
        {
            this.people.Add(person);
        }

        public override void Remove(Human person)
        {
            this.people.Remove(person);
        }

       public override void Work(int counter)
        {
            Console.WriteLine("{0}Name: {1}, Position {2}, let's work!", new string(' ', counter), this.name, this.position);
        
            foreach (var person in this.people)
            {
                person.Work(counter + 1);
            }
        }
    }
}
