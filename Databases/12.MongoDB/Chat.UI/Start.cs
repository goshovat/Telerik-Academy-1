namespace Chat.UI
{
    using System;
    using System.Diagnostics;

    public class Start
    {
        public static void Main(string[] args)
        {
            // Rebuild the solution if the exe was not found
            var uiPath = @"..\..\..\Chat.UI.WPF\bin\Debug\Chat.UI.WPF.exe";

            Process.Start(uiPath);
            Process.Start(uiPath);
            Console.WriteLine("The two chat UI clients are opened. Feel free to chat with yourself :)");
        }
    }
}
