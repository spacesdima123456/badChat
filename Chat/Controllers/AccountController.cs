using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost("Register")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateAccount(RegisterViewModel register)
        //{
        //    return null;
        //}

        //[HttpPost("Login")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel login)
        //{
        //    return null;
        //}
    }
}
