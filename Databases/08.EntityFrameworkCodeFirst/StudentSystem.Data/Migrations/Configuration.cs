namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            SeedCourses(context);
            SeedMaterials(context);
            SeedStudents(context);
        }

        private void SeedCourses(StudentSystemContext context)
        {
            context.Courses.Add(
                new Course
                {
                    Name = "C# 1",
                    Description = "fundamentals of programming"
                }
            );

            context.Courses.Add(
                new Course
                {
                    Name = "Arrays",
                    Description = "Data structures"
                }
            );
        }

        private void SeedMaterials(StudentSystemContext context)
        {
            context.Materials.Add(
                new Material
                {
                    Name = "Loops",
                    Path = @"C:\Temp\loops.ppt",
                    CourseID = 1
                }
            );

            context.Materials.Add(
                new Material
                {
                    Name = "Arrays",
                    Path = @"C:\Temp\arrays.ppt",
                    CourseID = 2
                }
            );
        }

        private void SeedStudents(StudentSystemContext context)
        {
            context.Students.Add(
              new Student
              {
                  Name = "Ivan Ivanov"
              }
            );

            context.Students.Add(
                new Student
                {

                    Name = "Pesho Peshev"
                }
            );
        }
    }
}
