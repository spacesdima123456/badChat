using System;
using Microsoft.AspNetCore.Identity;

namespace Chat.Models
{
    public class User : IdentityUser
    {
        public Message Message { get; set; }
        public string ConnectionId { get; private set; }
        public string FullName { get; private set; }

        public User(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentException("Parameter cannot be null", nameof(fullName));

            FullName = fullName;
        }

        public void SetConnectionId(string connectionId)
        {
            ConnectionId = connectionId;
        }
    }
}
