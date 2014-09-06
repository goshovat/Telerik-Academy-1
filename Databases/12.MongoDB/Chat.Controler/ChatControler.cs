namespace Chat.Controler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Bson;
    
    using Chat.Data;
    using Chat.Models;
    using MongoDB.Driver.Builders;
    
    public class ChatControler : IChatControler
    {
        private static IChatControler controller;
        private User loggedUser;
        private IChatDB chatDB;

        private ChatControler()
        {
            this.chatDB = new ChatDB();
            this.loggedUser = new User()
            {
                Username = null
            };
        }

        public static IChatControler Controller
        {
            get
            {
                if (controller == null)
                {
                    controller = new ChatControler();
                }

                return controller;
            }
        }

        public User LoggedUser
        {
            get
            {
                return this.loggedUser;
            }

            private set
            {
                this.loggedUser = value;
            }
        }

        public DateTime UserLoggedTime { get; set; }

        public void InsertMessage(string text)
        {
            var messages = this.chatDB.Database.GetCollection<Message>("Messages");

            var newMessage = new Message()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Date = DateTime.Now,
                Text = text,
                User = this.loggedUser
            };

            messages.Insert(newMessage);
        }

        public List<Message> GetAllMessages()
        {
            var messages = this.chatDB.Database.GetCollection<Message>("Messages");

            var query = Query.Exists("Date");

            var allMessages = messages.FindAll()
                                      .SetSortOrder(SortBy.Ascending("Date")).ToList();

            return allMessages;
        }

        public List<Message> GetAllMessagesSinceUserLogged()
        {
            var messages = this.chatDB.Database.GetCollection<Message>("Messages");

            var query = Query<Message>.Where(m => m.Date > UserLoggedTime);

            var allMessages = messages.Find(query)
                                      .OrderBy(m => m.Date)
                                      .ToList();

            return allMessages;
        }
    }
}
