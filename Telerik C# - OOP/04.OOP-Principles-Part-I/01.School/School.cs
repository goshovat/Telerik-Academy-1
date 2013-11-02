namespace _01.School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class School
    {
        private string name;
        List<SchoolClass> schoolClasses;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<SchoolClass> SchoolClasses
        {
            get { return this.schoolClasses; }
        }

        public School(string name)
        {
            this.name = name;
            this.schoolClasses = new List<SchoolClass>();
        }

        public void AddClass(SchoolClass schoolClass)
        {
            this.schoolClasses.Add(schoolClass);
        }

        public void RemoveClass(SchoolClass schoolClass)
        {
            this.schoolClasses.Remove(schoolClass);
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            StringBuilder output = new StringBuilder();

            output.AppendFormat("School name: {0}\n", this.name);
            output.Append(new string('#', Console.WindowWidth));

            foreach (var schoolClass in this.schoolClasses)
            {
                output.AppendFormat("{0} \n", schoolClass);
            }

            output.Append(new string('#', Console.WindowWidth));
            return output.ToString();
        }
    }
}
