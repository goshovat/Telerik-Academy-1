using System;

/*
    Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a>
    with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
    <p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. 
    Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
    
    <p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. 
    Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

*/

class HTMLDocument
{
    static void Main(string[] args)
    {
        Console.Title = "HTML document";

        string html = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course." +
                      "Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The HTML document:");
        Console.Write(new string('-', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(html);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', Console.WindowWidth));

        string changedHTML = html.Replace("<a href=\"", "[URL=");
        changedHTML = changedHTML.Replace("\">", "]");
        changedHTML = changedHTML.Replace("</a>", "[/URL]");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("The changed HTML document:");
        Console.Write(new string('-', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(changedHTML);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine();
        Console.ResetColor();
    }
}