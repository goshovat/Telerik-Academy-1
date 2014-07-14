namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public class Course
    {
        public const byte MaxStudentsCountInCourse = 29;

        private string name;

        public Course(string name, IList<Student> students = null)
        {
            this.Students = new List<Student>();
            this.Name = name;
        }

        public List<Student> Students { get; set; }

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
                    throw new ArgumentNullException("name", "Name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            bool studentFound = this.CheckIfStudentIsFound(student);

            if (studentFound)
            {
                throw new ArgumentException("The student already exists in the course!", "student");
            }

            if (this.Students.Count + 1 <= MaxStudentsCountInCourse)
            {
                this.Students.Add(student);
            }
            else
            {
                throw new ArgumentOutOfRangeException("student", "The course is full. No more students can be added!");
            }
        }

        public void RemoveStudent(Student student)
        {
            bool studentFound = this.CheckIfStudentIsFound(student);

            if (!studentFound)
            {
                throw new ArgumentException("The student is not find!", "student");
            }

            this.Students.Remove(student);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Course name {0}; ", this.Name));

            for (int i = 0; i < this.Students.Count; i++)
            {
                sb.Append(this.Students[i]);
            }

            return sb.ToString();
        }

        private bool CheckIfStudentIsFound(Student student)
        {
            bool studentFound = false;
            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i].UniqueNumber == student.UniqueNumber)
                {
                    studentFound = true;
                }
            }

            return studentFound;
        }
    }
}
