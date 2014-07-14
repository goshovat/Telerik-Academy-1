namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class SchoolTests
    {

        [TestMethod]
        public void SchoolConstructorTest()
        {
            List<Course> courses = new List<Course>();
            School school = new School(courses);
            Assert.IsNotNull(school, "School cannot be null!");
        }

        [TestMethod]
        public void AddCourseTest()
        {
            List<Course> courses = new List<Course>();
            Course javaScript = new Course("JavaScript");
            School school = new School(courses);
            school.AddCourse(javaScript);
            Assert.AreEqual(javaScript.Name, school.Courses[0].Name, "Ivalid add course operation!");
        }

        [TestMethod]
        public void RemoveCourseTest()
        {
            List<Course> courses = new List<Course>();
            School school = new School(courses);
            Course javaScript = new Course("JavaScript");
            school.AddCourse(javaScript);
            school.RemoveCourse(javaScript);
            Assert.IsTrue(school.Courses.Count == 0, "Invalid remove course operation!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingCourseTest()
        {
            List<Course> courses = new List<Course>();
            School school = new School(courses);
            Course javaScript = new Course("JavaScript");
            school.RemoveCourse(javaScript);
        }
    }
}
