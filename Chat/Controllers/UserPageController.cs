using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers
{
    [Authorize]
    [Route("UserPage")]
    public class UserPageController : Controller
    {
        [HttpGet("Chat")]
        public IActionResult Chat()
        {
            return View();
        }
    }
}
