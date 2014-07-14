namespace PersonFactory
{
    using System;

    internal class Demo
    {
        public static void Main(string[] args)
        {
            PersonFactory factory = new PersonFactory();

            Person peter = factory.CreatePerson("Peter Spiderman", 29, Sex.Male);
            Console.WriteLine(peter);

            Person julia = factory.CreatePerson("Julia Jackson", 35, Sex.Female);
            Console.WriteLine(julia);
        }
    }
}
