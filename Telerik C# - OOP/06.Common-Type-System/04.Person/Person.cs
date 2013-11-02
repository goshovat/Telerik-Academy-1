namespace _04.Person
{
    using System;

    public class Person
    {
        // Class fields
        private string name;
        private ushort? age;

        // Class constructor
        public Person(string name, ushort? age = null)
        {
            this.name = name;
            this.age = age;
        }

        // Class properties
        public ushort? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid name!");
                }

                this.name = value;
            }
        }


        public override string ToString()
        {
            return string.Format("Name: {0}\nAge: {1}\n", name, age != null? age.ToString() : "Not specified");
        }
    }
}
