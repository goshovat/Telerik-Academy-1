namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Models;
    using StudentSystem.Data.Migrations;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
         : base("StudentSystemDataBase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Material> Materials { get; set; }
    }
}
