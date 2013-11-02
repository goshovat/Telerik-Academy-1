namespace _01.School
{
    using System;

    // The class is abstract to prohibit making instance of it
    public abstract class Person : ICommentable
    {
        private string name;
        private ushort age;
        private long pin; // PIN = Personal Identification Number

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ushort Age
        {
            get { return age; }
            set { age = value; }
        }
        public long PIN
        {
            get { return pin; }
            set { pin = value; }
        }

        protected Person(string name, ushort age, long pin)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                    throw new ArgumentException("Invalid name!!!");
            }

            if (age < 0)
            {
                    throw new ArgumentException("The age connot be negativ!!!");
            }

            if (pin.ToString().Length != 10)
            {
                    throw new ArgumentException("Invalid PIN!!!");
            }

            this.name = name;
            this.age = age;
            this.pin = pin;
        }

        public string Comment { get; set; }

        public override string ToString()
        {
            return String.Format("Name: {0}\nAge: {1}\nPIN: {2}", this.name, this.age, this.pin);
        }

    }
}
