namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class Demo
    {
         [ExcludeFromCodeCoverage]
        public static void Main()
        {
            Course cSharp = new Course("C#");
            Student pesho = new Student("Pesho Peshev", 12345);
            Student gosho = new Student("Gosho Goshev", 13451);

            cSharp.AddStudent(pesho);
            cSharp.AddStudent(gosho);

            Course javaScript = new Course("JavaScript");
            javaScript.AddStudent(pesho);
            javaScript.AddStudent(gosho);

            Student vankata = new Student("Vankata Vankov", 13124);
            javaScript.AddStudent(vankata);
        }
    }
}
