namespace StudentSystem.Console
{
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Demo
    {
        public static void Main(string[] args)
        {
            var studentContext = new StudentSystemContext();

            studentContext.Courses
                .Where(x => x.CourseID == 1)
                .FirstOrDefault().Students.Add(
                    studentContext.Students
                        .Where(s => s.StudentID == 1)
                        .FirstOrDefault()
                );
            studentContext.Courses
                .Where(x => x.CourseID == 2)
                .FirstOrDefault().Students.Add(
                    studentContext.Students
                        .Where(s => s.StudentID == 2)
                        .FirstOrDefault()
                );
            
            studentContext.Homeworks.Add(
                  new Homework
                  {
                      Title = "Loops",
                      Content = @"ivan-loops-homework.zip",
                      TimeSent = DateTime.Now,
                      StudentID = 1,
                      CourseID = 1
                  }
              );

            studentContext.Homeworks.Add(
                new Homework
                {
                    Title = "Arrays",
                    Content = @"pesho-arrays-homework.zip",
                    TimeSent = DateTime.Now,
                    StudentID = 2,
                    CourseID = 2
                }
            );

            var courses = studentContext.Courses.Join(
                studentContext.Materials,
                c => c.CourseID,
                m => m.CourseID,
                (c, m) => new
                    {
                        CourseID = c.CourseID,
                        Name = c.Name,
                        Description = c.Description,
                        Material = m.Path
                    }
            );
            
            foreach (var course in courses)
            {
                Console.WriteLine("\nID: {0} \nName: {1} \nDescription: {2} \nPath: {3}", course.CourseID, course.Name, course.Description, course.Material);
            }

            studentContext.SaveChanges();
        }
    }
}
