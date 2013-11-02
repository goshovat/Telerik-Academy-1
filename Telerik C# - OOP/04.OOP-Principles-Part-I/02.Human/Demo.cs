using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Human
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>(10);

            /*
            for (int index = 0; index < students.Capacity; index++)
            {
                Console.WriteLine("Enter the information for the {0} student:", index);

                Console.Write("First name: ");
                string firstName = Console.ReadLine();

                Console.Write("Last name: ");
                string lastName = Console.ReadLine();

                Console.Write("Grade: ");
                ushort grade = ushort.Parse(Console.ReadLine());

                Console.WriteLine();

                students.Add(new Student(firstName, lastName, grade));
            }*/

            students.Add(new Student("Ivan", "Ivailov", 3));
            students.Add(new Student("Stefan", "Minev", 2));
            students.Add(new Student("Goran", "Nikolov", 1));
            students.Add(new Student("Yulia", "Kirova", 2));
            students.Add(new Student("Borisa", "Yaneva", 4));
            students.Add(new Student("Kiril", "Zikov", 3));
            students.Add(new Student("Orlin", "Orlinov", 5));
            students.Add(new Student("Peter", "Petrov", 3));
            students.Add(new Student("Dimiter", "Pavlov", 2));
            students.Add(new Student("Ivan", "Ivanov", 3));
            
            var sortedStudents = students.OrderBy(student => student.Grade).ThenBy(student => student.FirstName).ThenBy(student => student.LastName);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Sorted students: ");
            Console.WriteLine(new string('_', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('_', Console.WindowWidth));


            List<Worker> workers = new List<Worker>(10);

            /*
            for (int index = 0; index < workers.Capacity; index++)
            {
                Console.WriteLine("Enter the information for the {0} worker:", index);

                Console.Write("First name: ");
                string firstName = Console.ReadLine();

                Console.Write("Last name: ");
                string lastName = Console.ReadLine();

                Console.Write("Week salary: ");
                double salary = double.Parse(Console.ReadLine());

                Console.Write("Work hours per day: ");
                ushort workHours = ushort.Parse(Console.ReadLine());

                Console.WriteLine();

                workers.Add(new Worker(firstName, lastName, salary, workHours));
            }*/

            workers.Add(new Worker("Peter", "Ivailov", 80, 8));
            workers.Add(new Worker("Stefan", "Minev", 60, 6));
            workers.Add(new Worker("Goran", "Nikolov", 30, 2));
            workers.Add(new Worker("Mariya", "Kirova", 50, 3));
            workers.Add(new Worker("Katrin", "Yaneva", 40, 7));
            workers.Add(new Worker("Pavel", "Nikolov", 100, 4));
            workers.Add(new Worker("Orlin", "Orlinov", 60, 5));
            workers.Add(new Worker("Nikolay", "Ivanov", 200, 3));
            workers.Add(new Worker("George", "Pavlov", 100, 10));
            workers.Add(new Worker("Stefan", "Petrov", 40, 2));

            var sortedWorkers = workers.OrderByDescending(worker => worker.MoneyPerHour()).ThenBy(worker => worker.FirstName).ThenBy(worker => worker.LastName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSorted workers: ");
            Console.WriteLine(new string('_', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('_', Console.WindowWidth));

            var mergedLists = 
                students.Select(student => new { student.FirstName, student.LastName }).
                Union(workers.Select(worker => new { worker.FirstName, worker.LastName })).
                OrderBy(person => person.FirstName).
                ThenBy(person => person.LastName);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMerged workers: ");
            Console.WriteLine(new string('_', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var person in mergedLists)
            {
                Console.WriteLine(person);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('_', Console.WindowWidth));

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
