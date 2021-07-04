using Chat.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;


namespace Chat.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {

        public async Task Send(string userName, string message)
        {
            await Clients.All.SendAsync("Send", message, userName);
        }

        public override async Task OnConnectedAsync()
        {
            ConnectedUser.AddUserOnline(Context.ConnectionId, Context.User.Identity.Name);
            await RefreshUsersOnlineAsync();
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedUser.RemoveUser(Context.User.Identity.Name);
            await RefreshUsersOnlineAsync();
            await base.OnDisconnectedAsync(exception);
        }

        private async Task RefreshUsersOnlineAsync()
        {
            await Clients.All.SendAsync("RefreshUsersOnline", ConnectedUser.ConnectedIds);
        }
    }
}
