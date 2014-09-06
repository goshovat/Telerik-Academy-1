using System.ComponentModel.DataAnnotations;
namespace StudentSystem.Models
{
    public class Material
    {
        public int MaterialID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
    }
}
