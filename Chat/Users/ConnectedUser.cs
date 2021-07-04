using System.Linq;
using Chat.Users.Models;
using System.Collections.Generic;

namespace Chat.Users
{
    public static class ConnectedUser
    {
        public static List<UsersOnline> ConnectedIds = new List<UsersOnline>();

        public static void AddUserOnline(string connectionId, string userName)
        {
            RemoveUser(userName);
            ConnectedIds.Add(new UsersOnline(connectionId, userName));
        }

        public static void RemoveUser(string userName)
        {
            var user = ConnectedIds.FirstOrDefault(f => f.UserName == userName);
            if (user != null)
                ConnectedIds.Remove(user);
        }
    }
}
