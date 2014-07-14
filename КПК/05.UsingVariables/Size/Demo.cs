namespace Size
{
    using System;

    internal class Demo
    {
        public static void Main() 
        {
            Size size = new Size(3, 4);
            Console.WriteLine(size);

            size = SizeRotation.GetRotatedSize(size, 90);
            Console.WriteLine(size);
        }
    }
}
