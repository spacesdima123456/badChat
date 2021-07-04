using System;

namespace Chat.Users.Models
{
    public class UsersOnline
    {
        public string ConnectionId { get; private set; }
        public string UserName { get; private set; }

        public UsersOnline(string connectionId, string userName)
        {
            if (string.IsNullOrEmpty(connectionId))
                throw new Exception($"Is not {nameof(connectionId)} is null or empty");

            if (string.IsNullOrEmpty(userName))
                throw new Exception($"Is not {nameof(userName)} is null or empty");

            ConnectionId = connectionId;
            UserName = userName;
        }

    }
}
