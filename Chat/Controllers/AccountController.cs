using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
