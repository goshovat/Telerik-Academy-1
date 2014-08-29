namespace _12.Stack
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            var stack = new CustomStack<string>();

            stack.Push("pesho");
            stack.Push("gosho");
            stack.Push("vankata");

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack);

            var popedElement = stack.Pop();
            Console.WriteLine(popedElement);
            Console.WriteLine(stack);
        }
    }
}
