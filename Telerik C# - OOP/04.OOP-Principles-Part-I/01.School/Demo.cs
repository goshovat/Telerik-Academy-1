namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Demo
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Angel Angelov", 22, 9002120011,1),
                new Student("Vasil Ivanov", 22, 9012121212, 2),
                new Student("Nikolay Niklov", 22, 9012200014, 3),
                new Student("Nikolina Jekova", 22, 9011141113, 4),
                new Student("Julia Ribarska", 22, 9005132259, 5)
            };

            students[3].Comment = "Play games during the class hour";

            SchoolClass schoolClass = new SchoolClass("7 A");

            foreach (var student in students)
            {
                schoolClass.AddStudent(student);    
            }

            List<Discipline> disciplines = new List<Discipline>()
            {
                new Discipline("Computer architectures", 20, 10),
                new Discipline("Programin languages", 20, 10),
                new Discipline("Mangement of new technologies", 20, 10),
                new Discipline("Operating systems", 30, 15),
            };

            foreach (var discipline in disciplines)
            {
                schoolClass.AddDiscipline(discipline);
            }

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Ivan Peshev", 60, 4301010012),
                new Teacher("Peter Petrov", 50, 5311121112)
            };

            teachers[0].AddDiscipline(disciplines[0]);
            teachers[0].AddDiscipline(disciplines[1]);

            teachers[1].AddDiscipline(disciplines[2]);
            teachers[1].AddDiscipline(disciplines[3]);

            foreach (var teacher in teachers)
            {
                schoolClass.AddTeacher(teacher);
            }

            School school = new School("The Alien Education");

            school.AddClass(schoolClass);

            Console.WriteLine(school);

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}