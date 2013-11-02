namespace _03_05.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Students
    {
        private string firstName;
        private string lastName;
        private ushort age;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
  
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public ushort Age
        {
            get { return age; }
            set { age = value; }
        }


        public Students(string firstName, string lastName, ushort age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}\nAge: {2}", this.firstName, this.lastName, this.age);
        }

        // 3. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.
        public static IEnumerable<Students> CompareFirstAndLastName(IEnumerable<Students> students)
        {
            var result =
                from student in students
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;

            return result;
        }
    }
}
