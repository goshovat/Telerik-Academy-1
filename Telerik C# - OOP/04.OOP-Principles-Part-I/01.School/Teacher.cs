namespace _01.School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public List<Discipline> Disciplines
        {
            get { return disciplines; }
        }

        public Teacher(string name, ushort age, long pin)
            : base(name, age, pin)
        {
            this.disciplines = new List<Discipline>();
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append(new string('_', Console.WindowWidth));

            output.AppendFormat("{0}\n{1}His disciplines:\n", base.ToString(), this.Comment != null ? "Comment: " + this.Comment + "\n" : "");

            foreach (var discipline in this.disciplines)
            {
                output.AppendFormat("{0}", discipline);
            }

            output.Append(new string('_', Console.WindowWidth));

            return output.ToString();
        }
    }
}
