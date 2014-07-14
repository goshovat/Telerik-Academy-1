namespace Events
{
    using System;
    using Wintellect.PowerCollections;

    /// <summary>
    /// <description>Hold the events comparison</description>
    /// </summary>
    public class EventHolder
    {
        /// <summary>
        /// <descriotion>Comparison of events by title</descriotion>
        /// </summary>
        private MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string, Event>(true);
        
        /// <summary>
        /// <descriotion>Comparison of events by date</descriotion>
        /// </summary>
        private OrderedBag<Event> eventsByDate = new OrderedBag<Event>();

        /// <summary>
        /// <descriotion>Gets or sets eventsByTitle value</descriotion>
        /// </summary>
        public MultiDictionary<string, Event> EventsByTitle
        {
            get 
            {
                return this.eventsByTitle; 
            }

            set 
            {
                this.eventsByTitle = value; 
            }
        }

        /// <summary>
        /// <descriotion>Gets or sets eventsByDate value</descriotion>
        /// </summary>
        public OrderedBag<Event> EventsByDate
        {
            get 
            { 
                return this.eventsByDate; 
            }

            set 
            {
                this.eventsByDate = value; 
            }
        }

        /// <summary>
        /// <descriotion>Add event</descriotion>
        /// </summary>
        /// <param name="date">Date of the event</param>
        /// <param name="title">Title of the event</param>
        /// <param name="location">Location of the event</param>
        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.EventsByTitle.Add(title.ToLower(), newEvent);
            this.EventsByDate.Add(newEvent);
            Message.EventAdded();
        }

        /// <summary>
        /// <descriotion>Delete events</descriotion>
        /// </summary>
        /// <param name="titleToDelete">Title of the event that will be deleted</param>
        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.EventsByTitle[title])
            {
                removed++;
                this.EventsByDate.Remove(eventToRemove);
            }

            this.EventsByTitle.Remove(title);
            Message.EventDeleted(removed);
        }

        /// <summary>
        /// <descriotion>List events</descriotion>
        /// </summary>
        /// <param name="date">Date of the event</param>
        /// <param name="count">Count of events</param>
        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View
            eventsToShow = this.EventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Message.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Message.NoEventsFound();
            }
        }
    }
}