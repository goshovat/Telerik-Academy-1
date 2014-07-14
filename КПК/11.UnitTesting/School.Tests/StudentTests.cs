namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentConstructorTestName()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
            Assert.AreEqual(student.Name, "Gosho Goshev", "Invalid name asigning!");
        }

        [TestMethod]
        public void StudentConstructorTestUniqueNumber()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
            Assert.AreEqual(student.UniqueNumber, 12345, "Invalid unique number asigning!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "")]
        public void NameTestNullValue()
        {
            string name = null;
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "")]
        public void NameTestEmptyString()
        {
            string name = string.Empty;
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        public void UniqueNumberTestStartValue()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = 10000;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999, "Invalid check for unique number!");
        }

        [TestMethod]
        public void UniqueNumberTestEndValue()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = 99999;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999, "Invalid check for unique number!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestStartValueMinusOne()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = 9999;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999, "Invalid check for unique number!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestEndValuePlusOne()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = 1123200;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999, "Invalid check for unique number!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestEndValuePlus10000()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = 101239;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999, "Invalid check for unique number!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestNegativeValue()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = -55555;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999, "Invalid check for unique number!");
        }

        [TestMethod]
        public void ToStringTest()
        {
            string name = "Gosho Goshev";
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
            string expected = "Student Gosho Goshev, ID 12345; ";
            string actual;
            actual = student.ToString();
            Assert.AreEqual(expected, actual, "Invalid converting student to string!");
        }
    }
}
