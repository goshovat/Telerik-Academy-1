namespace Chef
{
    using System;
    using System.Collections.Generic;

    internal class Bowl
    {
        private List<Vegetable> vegetables;

        public Bowl()
        {
            this.Vegetables = new List<Vegetable>();
        }

        public List<Vegetable> Vegetables
        {
            get
            {
                return this.vegetables;
            }

            set
            {
                this.vegetables = value;
            }
        }

        public void Add(Vegetable vegetable)
        {
            this.Vegetables.Add(vegetable);
            Console.WriteLine("{0} was added to the bowl", this.vegetable);
        }
    }
}
