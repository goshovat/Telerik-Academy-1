// <copyright file="LocalCourse.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describes the local course in Telerik
    /// </summary>
    internal class LocalCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="courseName">Course name.</param>
        /// <param name="teacherName">Teacher name.</param>
        /// <param name="students">Enrolled students for the course.</param>
        /// <param name="lab">Laboratory, where the course will be in.</param>
        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="courseName">Course name.</param>
        /// <param name="teacherName">Teacher name.</param>
        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="courseName">Course name.</param>
        public LocalCourse(string courseName)
            : this(courseName, null, new List<string>(), null)
        {
        }

        /// <summary>
        /// Gets or sets laboratory name
        /// </summary>
        public string Lab { get; set; }

        /// <summary>
        /// Convert local course to its string representation.
        /// </summary>
        /// <returns>Returns the string representation of the local course.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");

            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
          
            result.Append(" }");
            return result.ToString();
        }
    }
}
