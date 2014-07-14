namespace PersonFactory
{
    using System;

    internal class Person
    {
        private string name;
        private ushort? age;
        private Sex sex;

        public Person(string name, ushort? age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public Person()
            : this(string.Empty, null, Sex.Female)
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ushort? Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be positive.");
                }

                this.age = value;
            }
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }

            set
            {
                this.sex = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}, Age: {1}, Sex: {2}",
                string.IsNullOrWhiteSpace(this.Name) ? "[no name specified]" : this.Name,
                this.Age.HasValue ? this.Age.ToString() : "[no age specified]",
                this.Sex);
        }
    }
}