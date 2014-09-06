namespace Chat.Models
{
    using System;

    interface IMessage
    {
        DateTime Date { get; set; }

        string Id { get; set; }

        string Text { get; set; }

        User User { get; set; }
    }
}
