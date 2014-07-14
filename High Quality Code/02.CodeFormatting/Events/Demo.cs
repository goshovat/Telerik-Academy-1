namespace Events
{
    using System;
    using System.Text;

    /// <summary>
    /// <description>Demonstrate the use of events.</description>
    /// </summary>
    public class Demo
    {
        /// <summary>
        /// <description>Keep the events.</description>
        /// </summary>
        private static EventHolder events = new EventHolder();

        /// <summary>
        /// <description>Start method.</description>
        /// </summary>
        /// <param name="args">Starting arguments</param>
        public static void Main(string[] args)
        {
            while (ExecuteNextCommand()) 
            { 
            }

            Console.WriteLine(Message.Output);
        }

        /// <summary>
        /// <description>Get the use input and execute corresponding method</description>
        /// </summary>
        /// <returns>True for execution another command, false for exit or wrong command.</returns>
        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            switch (command[0])
            {
                case 'A':
                    AddEvent(command);
                    return true;
                case 'D':
                    DeleteEvents(command);
                    return true;
                case 'L':
                    ListEvents(command);
                    return true;
                case 'E':
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// <description>List events</description>
        /// </summary>
        /// <param name="command">The whole command</param>
        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);
            events.ListEvents(date, count);
        }

        /// <summary>
        /// <description>Delete event</description>
        /// </summary>
        /// <param name="command">The whole command</param>
        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            events.DeleteEvents(title);
        }

        /// <summary>
        /// <description>Add event</description>
        /// </summary>
        /// <param name="command">The whole command</param>
        private static void AddEvent(string command)
        {
            DateTime date; 
            string title; 
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);

            events.AddEvent(date, title, location);
        }

        /// <summary>
        /// <descrioption>Gets parameters</descrioption>
        /// </summary>
        /// <param name="commandForExecution">Command which will be executed</param>
        /// <param name="commandType">Type of the command</param>
        /// <param name="dateAndTime">Date and time of execution</param>
        /// <param name="eventTitle">Title of the event</param>
        /// <param name="eventLocation">Location of the event</param>
        private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        /// <summary>
        /// <description>Gets date</description>
        /// </summary>
        /// <param name="command">The whole command</param>
        /// <param name="commandType">Command type</param>
        /// <returns>Returns the date of execution</returns>
        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}