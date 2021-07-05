using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Services.UserOnline.Models;

namespace Chat.Services.UserOnline
{
    public interface IUserOnline
    {
        Task ConnectUserAsync(string userName, string connectedId);
        Task DisConnectUserAsync(string userId);
        Task<IEnumerable<UserDto>> GetAllOnlineUsersAsync();
    }
}
