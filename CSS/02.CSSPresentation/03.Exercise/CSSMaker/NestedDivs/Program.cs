/*
    I wrote this application to make the css file, needed for exercise 3. 
*/

namespace NestedDivs
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("..\\..\\..\\..\\css\\styles.css"); // the folder where the file will be saved is CSSPresentation\03.Exercise\css

            writer.WriteLine("div {");
            writer.WriteLine("\tborder: 2px solid red;");
            writer.WriteLine("\tborder-radius: 40px;");
            writer.WriteLine("\tbackground-color: black;");
            writer.WriteLine("}");

            writer.WriteLine();
            writer.WriteLine("#div1 {");
            writer.WriteLine("\tposition: absolute;");
            writer.WriteLine("\ttop: 0px;");
            writer.WriteLine("\tleft: 0px;");
            writer.WriteLine("\twidth: 1200px;");
            writer.WriteLine("\theight: 80px;");
            writer.WriteLine("}");

            int width = 1200;
            int height = 80;
            int topLeft = 0;
            int len = 100;
            int counter = 1;

            for (int i = 2; i <= 60; i++)
            {
                counter++;

                if (len > 20)
                {
                    len -= 5;
                }

                if (height >= 0)
                {
                    topLeft += 2;
                    height -= 4;

                }

                width -= len;

                writer.WriteLine();
                writer.WriteLine(string.Format("#div{0} ", i) + "{");
                writer.WriteLine("\tposition: absolute;");
                writer.WriteLine(string.Format("\ttop: {0}px;", topLeft));
                writer.WriteLine(string.Format("\tleft: {0}px;", topLeft));
                writer.WriteLine(string.Format("\twidth: {0}px;", width));
                writer.WriteLine(string.Format("\theight: {0}px;", height));
                writer.WriteLine("}");
            }

            writer.Close();
        }
    }
}
