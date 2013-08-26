using System;

/*
    Write a program that parses an URL address given in the format:
    [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements. 
    For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
	[protocol] = "http"
	[server] = "www.devbg.org"
	[resource] = "/forum/index.php"
*/

class URLAddress
{
    static void Main(string[] args)
    {
        Console.Title = "URL addres";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter URL address: ");
        string url = Console.ReadLine();

        try
        {
            int indexOfProtocol = url.IndexOf("://");
            string protocol = url.Substring(0, indexOfProtocol);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[protocol] = {0}", protocol);

            int indexOfServer = url.IndexOf('/', indexOfProtocol + 3);
            string server = url.Substring(indexOfProtocol + 3, indexOfServer - indexOfProtocol - 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[server] = {0}", server);

            string resource = url.Substring(indexOfServer, url.Length - indexOfServer);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[resource] = {0}", resource);
        }
        catch (ArgumentException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The url is incorrect !!!");           
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}