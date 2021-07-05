using System;
using Chat.Services.UserOnline.Models;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Chat.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Chat.Services.UserOnline
{
    public class UserOnline : IUserOnline
    {
        private readonly ApplicationDbContext _context;
        public UserOnline(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ConnectUserAsync(string userName, string connectedId)
        {
            await SetConnectUserIdAsync(userName, connectedId);
        }

        public async Task DisConnectUserAsync(string userId)
        {
            await SetConnectUserIdAsync(userId, String.Empty);
        }

        private async Task SetConnectUserIdAsync(string userName, string connectedId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(f => f.UserName == userName);
            if (user != null)
            {
                user.SetConnectionId(connectedId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllOnlineUsersAsync()
        {
            var users = await _context.Users.Where(w=>!string.IsNullOrEmpty(w.ConnectionId)).ToListAsync();
            return users.Select(s => new UserDto
            {
                FullName = s.FullName,
                UserId = s.Id
            });
        }
    }
}
