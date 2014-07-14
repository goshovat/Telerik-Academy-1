namespace Events
{
    using System.Text;

    /// <summary>
    /// <description>Containing information about messages.</description> 
    /// </summary>
    public static class Message
    {
        /// <summary>
        /// <description>Store the messages.</description>
        /// </summary>
        private static StringBuilder output = new StringBuilder();

        /// <summary>
        /// <description> Gets or sets the value of output.</description>
        /// </summary>
        /// <value>A value tag is used to describe the property value</value>
        public static StringBuilder Output
        {
            get
            {
                return Message.output;
            }

            set
            {
                Message.output = value;
            }
        }

        /// <summary>
        /// <description>Add event message to the output.</description>
        /// </summary>
        public static void EventAdded()
        {
            Output.Append("Event added\n");
        }

        /// <summary>
        /// <description>Add delete event message to the output.</description>
        /// </summary>
        /// <param name="x">Number of events</param>
        public static void EventDeleted(int deletedEventsNumber)
        {
            if (deletedEventsNumber == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} events deleted\n", deletedEventsNumber);
            }
        }

        /// <summary>
        /// <description>Add no events found message to the output.</description>
        /// </summary>
        public static void NoEventsFound()
        {
            Output.Append("No events found\n");
        }

        /// <summary>
        /// <description>Add event to the output.</description>
        /// </summary>
        /// <param name="eventToPrint">Event that will be printed</param>
        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint + "\n");
            }
        }
    }
}