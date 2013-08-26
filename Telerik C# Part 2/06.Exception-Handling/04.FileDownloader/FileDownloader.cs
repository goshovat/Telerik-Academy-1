using System;
using System.Net;

/*
    Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
    and stores it the current directory. Find in Google how to download files in C#. Be sure to catch 
    all exceptions and to free any used resources in the finally block.
*/

class FileDownloader
{
    static void Main(string[] args)
    {
        Console.Title = "File downloader";

        WebClient client = new WebClient();

        using (client) // Automatically close the stream after the program finish using it
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                client.DownloadFile("http://academy.telerik.com/Sitefinity/WebsiteTemplates/MyTemplate/App_Themes/Academy/Images/telerik-academy-logo.jpg", @"..\..\logo.jpg");
                Console.WriteLine("The file was successfully downloaded! It was saved in the project's directory with name logo.jpg.");
            }
            catch (ArgumentNullException)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Null reference is passed to a method !!!");
            }
            catch (WebException)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Error with web connection !!!");
            }
            catch (NotSupportedException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The quary is not supported");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("FATAL ERROR !!!");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nGood bye!\n");
                Console.ResetColor();
            }
        }
    }
}