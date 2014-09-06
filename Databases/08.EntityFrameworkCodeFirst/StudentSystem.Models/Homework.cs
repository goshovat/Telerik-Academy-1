namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int HomeworkID { get; set; }

        [StringLength(50)]
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentID { get; set; }

        public virtual Student Student { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
    }
}
