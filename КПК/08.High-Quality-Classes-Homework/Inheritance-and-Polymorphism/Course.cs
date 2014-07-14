// <copyright file="Course.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describes Telerik course
    /// </summary>
    internal abstract class Course
    {
        /// <summary>
        /// Course name
        /// </summary>
        private string name;

        /// <summary>
        /// Teacher name
        /// </summary>
        private string teacherName;

        /// <summary>
        /// Enrolled students
        /// </summary>
        private IList<string> students;

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="name">The name of the class.</param>
        /// <param name="teacherName">The name of the teacher.</param>
        /// <param name="students">Enrolled students for the course.</param>
        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        /// <summary>
        /// Gets or sets the name of the course
        /// </summary>
        /// <exception cref="System.ArgumentException">When name is null or white space.</exception>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the teacher name.
        /// </summary>
        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.teacherName = value;
            }
        }

        /// <summary>
        /// Gets or sets the students
        /// </summary>
        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        /// <summary>
        /// Convert course to its string representation.
        /// </summary>
        /// <returns>Returns the string representation of the course.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
        
        /// <summary>
        /// Convert students to their string representation.
        /// </summary>
        /// <returns>Returns the string representation of the students.</returns>
        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
