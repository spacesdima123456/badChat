using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Chat.Services.UserOnline;

namespace Chat.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
        private readonly IUserOnline _userOnline;

        public ChatHub(IUserOnline userOnline)
        {
            _userOnline = userOnline;
        }

        public async Task Send(string userName, string message)
        {
            await Clients.All.SendAsync("Send", message, userName);
        }

        public override async Task OnConnectedAsync()
        {
            await _userOnline.ConnectUserAsync(Context.User.Identity.Name, Context.ConnectionId);
            await RefreshUsersOnlineAsync();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await _userOnline.DisConnectUserAsync(Context.User.Identity.Name);
            await RefreshUsersOnlineAsync();
            await base.OnDisconnectedAsync(exception);
        }

        private async Task RefreshUsersOnlineAsync()
        {
            var users = await _userOnline.GetAllOnlineUsersAsync();
            await Clients.All.SendAsync("RefreshUsersOnline", users);
        }
    }
}
