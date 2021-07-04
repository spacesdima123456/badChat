using Chat.Entities;
using Chat.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()=> View();

        [HttpGet]
        public IActionResult Register()=> View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var userInfo = await _userManager.FindByEmailAsync(register.Email);
                if (userInfo == null)
                {
                    var user = new User { Email = register.Email, UserName = register.UserName };
                    var result = await _userManager.CreateAsync(user, register.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Chat", "UserPage");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel register)
        {
            if (ModelState.IsValid)
            {
                var isAuth = await _signInManager.PasswordSignInAsync(register.UserName, register.Password, false, false);
                if (isAuth.Succeeded)
                    return RedirectToAction("Chat", "UserPage");

                else
                    ModelState.AddModelError("", "Логин либо пароль не корректны.");
            }

            if (string.IsNullOrEmpty(register.Password))
                ModelState.AddModelError("", "Проверьте логин или пароль.");

            return View(register);
        }
    }
}
