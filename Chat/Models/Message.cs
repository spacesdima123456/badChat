using System;
using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class Message
    {
        [Key]
        public int Id { get; private set; }
        public string Text { get; private set; }
        public User User { get; set; }
        public string UserId { get; private set; }
        public DateTime TimeSend { get; private set; }

        public Message(int id, string userId, string text, DateTime timeSend)
        {
            Id = id;
            Text = text;
            UserId = userId;
            TimeSend = timeSend;
        }
    }
}
