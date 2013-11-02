namespace _04.Person
{
    using System;

    public class Demo
    {
        static void Main(string[] args)
        {
            Console.Title = "People";

            Person[] people = new Person[]{
                new Person("Jaklin"),
                new Person("Kalin", 24),
                new Person("Yulia", 21),
                new Person("Georgi"),
                new Person("Victoria", 20)
            };

            int index = 0;foreach (var person in people)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen + index;
                Console.WriteLine(person);
                index++;
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
