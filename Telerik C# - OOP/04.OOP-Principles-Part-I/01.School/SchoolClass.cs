namespace _01.School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SchoolClass : ICommentable
    {
        private string name;
        private List<Student> students;
        private List<Teacher> teachers;
        private List<Discipline> disciplines;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Student> Students
        {
            get { return students; }
        }
        
        public List<Teacher> Teachers
        {
            get { return teachers; }
        }

        public List<Discipline> Disciplines
        {
            get { return disciplines; }
        }

        public string Comment { get; set; }

        public SchoolClass(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid name!!!");
            }

            this.name = name;
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
            this.disciplines = new List<Discipline>();
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
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

            output.AppendFormat("School class: {0}{1}\nClass students:\n", this.name, this.Comment != null ? "Comment: " + this.Comment + "\n" : "");
            
            output.Append(new string('*', Console.WindowWidth));

            foreach (var student in this.students)
            {
                output.AppendFormat("{0} \n", student);
            }

            output.Append("Class disciplines: \n");
            foreach (var discipline in this.disciplines)
            {
                output.AppendFormat("{0} \n", discipline);
            }

            output.Append("\nClass teachers: \n");
            foreach (var teacher in this.teachers)
            {
                output.AppendFormat("{0} \n", teacher);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            output.Append(new string('*', Console.WindowWidth));

            return output.ToString();
        }
    }
}
