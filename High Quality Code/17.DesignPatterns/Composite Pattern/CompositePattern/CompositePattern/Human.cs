namespace CompositePattern
{
    public abstract class Human
    {
        protected string name;
        protected string position;

        public Human(string name, string position)
        {
            this.name = name;
            this.position = position;
        }

        public abstract void Add(Human person);

        public abstract void Remove(Human person);

        public abstract void Work(int counter);
    }
}
