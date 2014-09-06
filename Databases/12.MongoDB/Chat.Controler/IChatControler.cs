namespace Chat.Controler
{
    using Chat.Models;
    using System;
    using System.Collections.Generic;

    public interface IChatControler
    {    
        List<Message> GetAllMessages();
        
        void InsertMessage(string text);
        
        User LoggedUser { get; }
    }
}
