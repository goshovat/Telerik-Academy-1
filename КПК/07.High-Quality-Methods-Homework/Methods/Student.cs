// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Methods
{
    using System;

    /// <summary>
    /// Describes the student.
    /// </summary>
    internal class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">First name of the student.</param>
        /// <param name="lastName">Second name of the student.</param>
        /// <param name="birthday">Birthday date of the student.</param>
        /// <param name="birthTown">Birth town of the student.</param>
        /// <param name="hobby">Hobby of the student.</param>
        /// <param name="averageMarks">Average marks of the student.</param>
        public Student(string firstName, string lastName, string birthday, string birthTown, string hobby, float averageMarks)
        {
            DateTime date = new DateTime();

            if (!DateTime.TryParse(birthday, out date))
            {
                throw new ArgumentException("Invalid birthday date.");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = date;
            this.BirthTown = birthTown;
            this.Hobby = hobby;
            this.AverageMarks = averageMarks;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">First name of the student.</param>
        /// <param name="lastName">Second name of the student.</param>
        /// <param name="birthday">Birthday date of the student.</param>
        /// <param name="birthTown">Birth town of the student.</param>
        public Student(string firstName, string lastName, string birthday, string birthTown)
            : this(firstName, lastName, birthday, birthTown, "not specified", 0)
        {
        }

        /// <summary>
        /// Gets or sets the first name of the student.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Gets or sets the last name of the student.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets the birthday date of the student.
        /// </summary>
        public DateTime Birthday { get; set; }
        
        /// <summary>
        /// Gets or sets the birthday town of the student.
        /// </summary>
        public string BirthTown { get; set; }
        
        /// <summary>
        /// Gets or sets the hobby of the student.
        /// </summary>
        public string Hobby { get; set; }

        /// <summary>
        /// Gets or sets the average marks of the student.
        /// </summary>
        public float AverageMarks { get; set; }
            
        /// <summary>
        /// Checks if this student is older than other
        /// </summary>
        /// <param name="other">Other student</param>
        /// <returns>Returns the value indicates whether this student is older than another student.</returns>
        public bool IsOlderThan(Student other)
        {
           bool isOlder = this.Birthday < other.Birthday;
            return isOlder;
        }
    }
}
