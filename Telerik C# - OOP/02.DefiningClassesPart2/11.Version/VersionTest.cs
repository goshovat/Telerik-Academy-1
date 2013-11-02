namespace _11.Version
{
    using System;
    using System.Reflection;

    [Version(1.11)]
    class VersionTest
    {
        [Version(1.00)]
        public static void Test(){}

        [Version(1.01)]
        public static void Test1(){}

        [Version(1.02)]
        protected static void Test2(){}

        [Version(1.03)]
        private static void Test3(int x){}

        static void Main(string[] args)
        {
            Console.Title = "Version attribute test";

            Console.ForegroundColor = ConsoleColor.Cyan;
            
            // Class attribute
            Type type = typeof(VersionTest);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute versionAttribute in allAttributes)
            {
                Console.WriteLine("Class version = {0:F} ", versionAttribute.Version);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Methods attributes
            MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (MethodInfo method in methods)
            {
                object[] methodAttributes = method.GetCustomAttributes(false);
                if (methodAttributes.Length > 0 && methodAttributes[0] is VersionAttribute)
                {
                    Console.WriteLine("Method \"{0}\" has version {1:F} ", method.Name, (methodAttributes[0] as VersionAttribute).Version);
                }
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
