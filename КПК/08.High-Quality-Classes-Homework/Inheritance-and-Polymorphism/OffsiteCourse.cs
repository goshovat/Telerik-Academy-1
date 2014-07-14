// <copyright file="OffsiteCourse.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describes the offsite course in Telerik
    /// </summary>
    internal class OffsiteCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="courseName">Course name.</param>
        /// <param name="teacherName">Teacher name.</param>
        /// <param name="students">Enrolled students for the course.</param>
        /// <param name="town">Town, where the course will be in.</param>
        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="courseName">Course name.</param>
        /// <param name="teacherName">Teacher name.</param>
        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="courseName">Course name.</param>
        public OffsiteCourse(string courseName)
            : this(courseName, null, new List<string>(), null)
        {
        }

        /// <summary>
        /// Gets or sets the town name.
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Convert offsite course to its string representation.
        /// </summary>
        /// <returns>Returns the string representation of the offsite course.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");

            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
