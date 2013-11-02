namespace _03.Hierarchy
{
    using System;
    using System.Linq;

    public class Demo
    {
        static void Main(string[] args)
        {
            Tomcat tomcat1 = new Tomcat("Pesho", 10);
            Tomcat tomcat2= new Tomcat("Ivan", 20);
            Tomcat tomcat3 = new Tomcat("Kiro", 30);

            Kitten kitten1 = new Kitten("Mila", 20);
            Kitten kitten2 = new Kitten("Lila", 50);
            Kitten kitten3 = new Kitten("Cura", 20);

            Dog dog1 = new Dog("Sharo", 20, true);
            Dog dog2 = new Dog("Hristo", 10, true);
            Dog dog3 = new Dog("Ziko", 5, true);

            Frog frog1 = new Frog("Kwak Kwak", 20, false);
            Frog frog2 = new Frog("Kwaaaaak", 20, false);
            Frog frog3 = new Frog("Kwak", 20, false);

            Cat cat1 = new Cat("Frodo", 10, true);
            Cat cat2 = new Cat("Obama", 40, true);

            Animal[] animals = 
            {                    
                tomcat1, kitten1, frog1, dog1, cat1,
                tomcat2, kitten2, frog2, dog2, cat2,
                tomcat3, kitten3, frog3, dog3
            };

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("All animals:");
            Console.Write(new string('_', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('_', Console.WindowWidth));

            var kinds = Animal.CalculateAverageAge(animals);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nKinds and their average age:");
            Console.Write(new string('_', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var kind in kinds)
            {
                Console.WriteLine("{0} - {1:F2} years", kind.KindName, kind.AverageAge);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('_', Console.WindowWidth));

            Console.WriteLine();

            Console.ResetColor();
        }
    }
}
