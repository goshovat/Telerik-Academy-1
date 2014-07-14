namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// <description>Keep information about the event.</description>
    /// </summary>
    public class Event : IComparable
    {
        /// <summary>
        /// <description>Date of the event</description>
        /// </summary>
        private DateTime date;
        
        /// <summary>
        /// <description>Title of the event</description>
        /// </summary>
        private string title;
        
        /// <summary>
        /// <description>Title of the event</description>
        /// </summary>
        private string location;

        /// <summary>
        /// <description>Initializes a new instance of the Event class.</description>
        /// </summary>
        /// <param name="date">The date of execution.</param>
        /// <param name="title">The title of event.</param>
        /// <param name="location">The location of the even.</param>
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        /// <summary>
        /// <description>Gets or sets the location value.</description>
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

        /// <summary>
        /// <description>Gets or sets the title value.</description>
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

        /// <summary>
        /// <description>Gets or sets the date value.</description>
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }

        /// <summary>
        /// <description>Compare to events.</description>
        /// </summary>
        /// <param name="obj">Event that will be compare to the current one.</param>
        /// <returns>Returns comparison of the elements</returns>
        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int compareByDate = this.date.CompareTo(other.date);
            int compareByTitle = this.title.CompareTo(other.title);
            int compareByLocation = this.location.CompareTo(other.location);

            if (compareByDate == 0)
            {
                if (compareByTitle == 0)
                {
                    return compareByLocation;
                }
                else
                {
                    return compareByTitle;
                }
            }
            else
            {
                return compareByDate;
            }
        }

        /// <summary>
        /// <description>Make event information readable for user.</description>
        /// </summary>
        /// <returns>String with information about the event.</returns>
        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                toString.Append(" | " + this.Location);
            }

            return toString.ToString();
        }
    }
}