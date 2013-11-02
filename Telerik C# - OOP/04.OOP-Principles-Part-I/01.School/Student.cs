namespace _01.School
{
    using System;
    using System.Text;

    public class Student : Person
    {
        private int uniqueClassNumber;

        public int UniqueClassNumber
        {
            get { return uniqueClassNumber; }
            set { uniqueClassNumber = value; }
        }


        public Student(string name, ushort age, long pin, int uniqueClassNumber)
            : base(name, age, pin)
        {
            this.uniqueClassNumber = uniqueClassNumber;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            
            output.Append(new string('.', Console.WindowWidth));

            output.AppendFormat("{0}\nUnique number: {1}\n{2}", base.ToString(), this.uniqueClassNumber, this.Comment != null ? "Comment: " + this.Comment + "\n" : "");

            output.Append(new string('.', Console.WindowWidth));

            return output.ToString();
        }

    }
}
