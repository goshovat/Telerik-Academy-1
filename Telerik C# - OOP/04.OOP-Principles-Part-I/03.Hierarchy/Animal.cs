namespace _03.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : ISound
    {
        protected string name;
        protected bool isMale;
        protected ushort age;

        protected string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected ushort Age
        {
            get { return age; }
            set { age = value; }
        }
      
        protected bool IsMale
        {
            get { return isMale; }
            set { isMale = value; }
        }

        protected Animal(string name, ushort age, bool isMale)
        {
            this.name = name;
            this.age = age;
            this.isMale = isMale;
        }

        public abstract void Sound();

        public static dynamic CalculateAverageAge(IEnumerable<Animal> animals)
        {
            var averageAge = 
                from animal in animals
                group animal by animal.GetType() into kind
                select new 
                { 
                    KindName = kind.Key.Name, 
                    AverageAge = kind.Average(animal => animal.Age) 
                };

            return averageAge;
        }

        public override string ToString()
        {
            return string.Format("My name is {0} and I am {1} years old. My kind is {2} and my gender is {3}.",
                this.name, this.age, this.GetType().Name, this.isMale == true? "male" : "female");
        }
        
    }
}
