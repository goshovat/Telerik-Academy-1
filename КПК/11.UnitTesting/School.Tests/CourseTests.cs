namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseConstructorTestName()
        {
            string name = "JavaScript";
            Course course = new Course(name);
            Assert.AreEqual(course.Name, "JavaScript", "Invalid name asigning!");
        }

        [TestMethod]
        public void CourseConstructorTestListStudents()
        {
            string name = "JavaScript";
            Student gosho = new Student("Gosho Goshev", 12345);
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            course.AddStudent(gosho);
            Assert.IsTrue(course.Students.Contains(gosho), "Invalid list asigning!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestNullValue()
        {
            string name = null;
            Course newCourse = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestEmptyString()
        {
            string name = string.Empty;
            Course newCourse = new Course(name);
        }

        [TestMethod]
        public void AddStudentTestOneStudent()
        {
            string name = "C#";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student gosho = new Student("Gosho Goshev", 12345);
            course.AddStudent(gosho);
            Assert.IsTrue(course.Students.Count == 1, "Invalid adding student operation!");
        }

        [TestMethod]
        public void AddStudentTestTwoStudents()
        {
            string name = "JavaScript";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student gosho = new Student("Gosho Goshev", 12345);
            Student pesho = new Student("Pesho Peshev", 23445);
            course.AddStudent(gosho);
            course.AddStudent(pesho);
            Assert.IsTrue(course.Students.Count == 2, "Invalid adding student operation!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentTestSameStudentTwoTimes()
        {
            string name = "JavaScript";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student gosho = new Student("Gosho Goshev", 12345);
            course.AddStudent(gosho);
            course.AddStudent(gosho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddStudentTestMoreThanMaximumStudents()
        {
            string name = "JavaScript";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            course.AddStudent(new Student("Gosho Goshev 1st", 12345));
            course.AddStudent(new Student("Gosho Goshev 2nd", 12346));
            course.AddStudent(new Student("Gosho Goshev 3rd", 12347));
            course.AddStudent(new Student("Gosho Goshev 4th", 12348));
            course.AddStudent(new Student("Gosho Goshev 5th", 12349));
            course.AddStudent(new Student("Gosho Goshev 6th", 12350));
            course.AddStudent(new Student("Gosho Goshev 7th", 12351));
            course.AddStudent(new Student("Gosho Goshev 8th", 12352));
            course.AddStudent(new Student("Gosho Goshev 9th", 12353));
            course.AddStudent(new Student("Gosho Goshev 10th", 12354));
            course.AddStudent(new Student("Gosho Goshev 11th", 12355));
            course.AddStudent(new Student("Gosho Goshev 12th", 12356));
            course.AddStudent(new Student("Gosho Goshev 13th", 12357));
            course.AddStudent(new Student("Gosho Goshev 14th", 12358));
            course.AddStudent(new Student("Gosho Goshev 15th", 12359));
            course.AddStudent(new Student("Gosho Goshev 16th", 12360));
            course.AddStudent(new Student("Gosho Goshev 17th", 12361));
            course.AddStudent(new Student("Gosho Goshev 18th", 12362));
            course.AddStudent(new Student("Gosho Goshev 19th", 12363));
            course.AddStudent(new Student("Gosho Goshev 20th", 12364));
            course.AddStudent(new Student("Gosho Goshev 21th", 12365));
            course.AddStudent(new Student("Gosho Goshev 22th", 12366));
            course.AddStudent(new Student("Gosho Goshev 23th", 12367));
            course.AddStudent(new Student("Gosho Goshev 24th", 12368));
            course.AddStudent(new Student("Gosho Goshev 25th", 12369));
            course.AddStudent(new Student("Gosho Goshev 26th", 12370));
            course.AddStudent(new Student("Gosho Goshev 27th", 12371));
            course.AddStudent(new Student("Gosho Goshev 28th", 12372));
            course.AddStudent(new Student("Gosho Goshev 29th", 23445));
            course.AddStudent(new Student("Gosho Goshev 30th", 23446));
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            string name = "JavaScript";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student gosho = new Student("Gosho Goshev", 12345);
            Student pesho = new Student("Pesho Peshev", 23445);
            course.AddStudent(gosho);
            course.AddStudent(pesho);
            course.RemoveStudent(pesho);
            Assert.IsTrue(course.Students.Count == 1, "Invalid removing student operation!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingStudentTest()
        {
            string name = "JavaScript";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student gosho = new Student("Gosho Goshev", 12345);
            course.RemoveStudent(gosho);
        }

        [TestMethod]
        public void ToStringTestOneStudent()
        {
            string name = "JavaScript";
            Student gosho = new Student("Gosho Goshev", 12345);
            IList<Student> students = new List<Student>();
            Course javaScript = new Course(name, students);
            javaScript.AddStudent(gosho);
            string expected = "Course name JavaScript; Student Gosho Goshev, ID 12345; ";
            string actual;
            actual = javaScript.ToString();
            Assert.AreEqual(expected, actual, "Invalid  converting student course to string!");
        }

        [TestMethod]
        public void ToStringTestTwoStudents()
        {
            string name = "JavaScript";
            Student gosho = new Student("Gosho Goshev", 12345);
            Student pesho = new Student("Pesho Peshev", 23445);
            IList<Student> students = new List<Student>();
            Course javascript = new Course(name, students);
            javascript.AddStudent(gosho);
            javascript.AddStudent(pesho);
            string expected = "Course name JavaScript; Student Gosho Goshev, ID 12345; Student Pesho Peshev, ID 23445; ";
            string actual;
            actual = javascript.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
