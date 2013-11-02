namespace _03_05.Students
{
    using System;
    using System.Linq;

    class StudentsTest
    {
        static void Main(string[] args)
        {
            Students[] students = new Students[]{
                  new Students ("Ivan", "Kolev", 12),//<---- He is genious 
                  new Students("Petar","Ivailov", 21),
                  new Students("Liliana",  "Qneva", 42),
                  new Students( "Georgi",  "Chinkov", 67),
                  new Students( "Mariq",  "Manova", 30),
                  new Students( "Nikolay",  "Hristov", 24),
                  new Students( "Simona",  "Popova", 19),
                  new Students( "Todor",  "Arabadjiev", 20),
                  new Students( "Orlin",  "Elenkov", 21),
                  new Students( "Jana",  "Raikova", 27)
            };

            var result = Students.CompareFirstAndLastName(students);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Results from comparing first and last name:");
            Console.Write(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('-', Console.WindowWidth));

            Console.WriteLine();

            //4.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
           
            var studentRangeResult =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Students with age between 18 and 24:");
            Console.Write(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var student in studentRangeResult)
            {
                Console.WriteLine(student);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('-', Console.WindowWidth));

            Console.WriteLine();

            //5.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name 
            //and last name in descending order. Rewrite the same with LINQ.

            var orderedArray = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Sorted by names descending (using lambda expression):");
            Console.Write(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var student in orderedArray)
            {
                Console.WriteLine(student);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('-', Console.WindowWidth));

            Console.WriteLine();

            var ordeArrayWithLINQ =
                from student in students
                orderby student.FirstName descending, student.LastName descending 
                select student;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Sorted by names descending (using LINQ):");
            Console.Write(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var student in ordeArrayWithLINQ)
            {
                Console.WriteLine(student);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('-', Console.WindowWidth));

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
