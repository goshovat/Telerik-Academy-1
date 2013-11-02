namespace _01_03.Student
{
    using System;
   
    public class Student : ICloneable, IComparable<Student>
    {
        // Class fields
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string address;
        private string mobilePhone;
        private string email;
        private ushort course;
        private Specialty specialty;
        private University university;
        private Faculty faculty;

        // Class constructors
        public Student(string firstName, string middleName, string lastName, string ssn, string address, string mobilePhone, string email, ushort course, Specialty specialty, University university, Faculty faculty)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.ssn = ssn;
            this.address = address;
            this.mobilePhone = mobilePhone;
            this.email = email;
            this.course = course;
            this.specialty = specialty;
            this.university = university;
            this.faculty = faculty;
        }

        // This constructor is used only for the Clone method and cannot be evoked outside the class Student
        private Student(string ssn, ushort course, Specialty specialty, University university, Faculty faculty)
        : this(null, null, null, ssn, null, null, null, course,  specialty, university, faculty)
        {
        }

        // Class properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid first name!");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid middle name!");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid last name!");
                }

                this.lastName = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid SSN!");
                }

                this.ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid address!");
                }

                this.address = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid mobile phone!");
                }

                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid email!");
                }

                this.email = value;
            }
        }

        public ushort Course
        {
            get
            {
                return this.course;
            }
            set
            {
                if (value > 10)
                {
                    throw new ArgumentException("Invalid course");
                }

                this.course = value;
            }
        }

        public Specialty Specialty
        {
            get
            {
                return this.specialty;
            }
            set
            {
                this.specialty = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }
            set
            {
                this.university = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }
            set
            {
                this.faculty = value;
            }
        }

        // Override obeject methods
        public override string ToString()
        {
            return string.Format(" First name: {0}\n Middle Name: {1}\n Last Name: {2}\n SSN: {3}\n Address: {4}\n Mobile Phone: {5}\n Email: {6}\n Course: {7}\n Specialty: {8}\n University: {9}\n Faculty: {10}",
                 firstName, middleName, lastName, ssn, address, mobilePhone, email, course, specialty, university, faculty);
        }

        public override bool Equals(object param)
        {
            // If the cast is invalid, the result will be null
            Student student = param as Student;

            // Check if we have valid not null Student object
            if (student == null)
            {
                return false;
            }

            // Compare the reference type member fields
            if (!(Object.Equals(this.FirstName, student.FirstName) && Object.Equals(this.MiddleName, student.MiddleName) &&
                Object.Equals(this.LastName, student.LastName) && Object.Equals(this.Address, student.Address) && Object.Equals(this.SSN, student.SSN)))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ MiddleName.GetHashCode() ^ LastName.GetHashCode() ^ SSN.GetHashCode();
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return Student.Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !(Student.Equals(firstStudent, secondStudent));
        }

        // Implement the ICloneable method Clone
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student student = new Student(this.SSN, this.Course, this.Specialty, this.University, this.Faculty);

            if (this.FirstName == null)
            {
                throw new ArgumentNullException("The first name of the student was not set!");
            }
            student.FirstName = String.Copy(this.FirstName);

            if (this.middleName == null)
            {
                throw new ArgumentNullException("The middle name of the student was not set!");     
            }
            student.MiddleName = String.Copy(this.MiddleName);

            if (this.LastName == null)
            {
                throw new ArgumentNullException("The last name of the student was not set!");
            }
            student.LastName = String.Copy(this.LastName);

            if (this.Address == null)
            {
                throw new ArgumentNullException("The address of the student was not set!");
            }
            student.Address = String.Copy(this.Address);

            if (this.MobilePhone == null)
            {
                throw new ArgumentNullException("The mobile phone of the student was not set!");
            }
            student.MobilePhone = String.Copy(this.MobilePhone);

            if (this.Email == null)
            {
                throw new ArgumentNullException("The email of the student was not set!");
            }
            student.Email = String.Copy(this.Email);
            
            return student;
        }

        // Implement the Icomparable<T> method CompareTo
        public int CompareTo(Student other)
        {
            int comparator = String.Compare(this.FirstName, other.FirstName);

            if (comparator == 0)
            {
                comparator = String.Compare(this.MiddleName, other.MiddleName);

                if (comparator == 0)
                {
                    comparator = String.Compare(this.LastName, other.LastName);

                    if (comparator == 0)
                    {
                        comparator = String.Compare(this.SSN, other.SSN);
                        if (comparator == 0)
                        {
                            return 0;
                        }

                        return comparator;
                    }
                }
            }

            return comparator;
        }
    }
}