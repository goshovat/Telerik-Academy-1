namespace _02.Human
{
    using System;
    using System.Text;

    public class Student : Human
    {
        private ushort grade;

        public ushort Grade
        {
            get
            {
                return grade;
            }
            set 
            {
                grade = value; 
            }
        }

        public Student(string firstName, string lastName, ushort grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("Name: {0} {1}", firstName, lastName);
            output.AppendFormat("\nGrade: {0}\n", grade);

            return output.ToString();
        }
    }
}
