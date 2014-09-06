namespace Chat.Controler
{
    using Chat.Models;
    using System;
    using System.Collections.Generic;

    public interface IChatControler
    {    
        List<Message> GetAllMessages();

        List<Message> GetAllMessagesSinceUserLogged();

        void InsertMessage(string text);
        
        User LoggedUser { get; }

        DateTime UserLoggedTime { get; set; }
    }
}
