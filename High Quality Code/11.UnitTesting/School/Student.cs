namespace School
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            [ExcludeFromCodeCoverage]
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be missing!");
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            [ExcludeFromCodeCoverage]
            get
            {
                return this.uniqueNumber;
            }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException(
                        "uniqueNumber", "Student's unique number should be between 10000 and 99999!");
                }

                this.uniqueNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Student {0}, ID {1}; ", this.Name, this.UniqueNumber);
        }
    }
}
