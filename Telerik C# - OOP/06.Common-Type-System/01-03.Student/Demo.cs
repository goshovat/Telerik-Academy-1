namespace _01_03.Student
{
    using System;

    class Demo
    {
        static void Main(string[] args)
        {
            Console.Title = "Students";

            Student st1 = new Student("Ivan", "Petkov", "Minev", "123456", "ul.Nishava №1", "+359883554422", "chuknimi@abv.bg", 3, Specialty.ComputerScientce, University.SofiaUniversity, Faculty.Computers);
            var st2 = st1.Clone();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(st1);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(st2);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Student1 equals student2 ? : {0}", st1.Equals(st2));
            Console.WriteLine("Student1 compare to student2 ? : {0}", st1.CompareTo(st2));

            Console.WriteLine();

            st2.FirstName = "Georgi";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(st1);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(st2);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Student1 equals student2 ? : {0}", st1.Equals(st2));
            Console.WriteLine("Student1 compare to student2 ? : {0}", st1.CompareTo(st2));
            Console.WriteLine();

            st1.FirstName = "Georgi";
            st2.SSN = "123459";
            st2.Address = "ul. James Bourchier №123";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(st1);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(st2);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Student1 equals student2 ? : {0}", st1.Equals(st2));
            Console.WriteLine("Student1 compare to student2 ? : {0}", st1.CompareTo(st2));

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
