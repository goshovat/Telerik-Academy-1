namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Course> course;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.course = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int StudentID { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        public int StudentNumber { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.course;
            }

            set
            {
                this.course = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }
    }
}
