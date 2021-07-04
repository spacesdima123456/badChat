using Microsoft.AspNetCore.Identity;

namespace Chat.Entities
{
    public class User : IdentityUser
    {
        public Message Message { get; private set; }
    }
}
