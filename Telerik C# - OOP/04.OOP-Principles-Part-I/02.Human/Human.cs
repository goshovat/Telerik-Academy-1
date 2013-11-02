namespace _02.Human
{
    using System;

    public abstract class Human
    {
        protected string firstName;
        protected string lastName;

        public string FirstName
        {
            get
            {
                return firstName; 
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid first name!");
                }
 
                firstName = value; 
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid last name!");
                }

                lastName = value; 
            }
        }

        protected Human(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Invalid first name!");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Invalid last name!");    
            }

            this.firstName = firstName;
            this.lastName = lastName;
        }

    }
}
