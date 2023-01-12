using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDBContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if(!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if (user != null)
            {
                //Пользователь найден и проверка
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    //Пароль правильный и вход
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Create", "Task");
                    }
                }
                //Пароль неверный
                TempData["Error"] = "Данные указанны не верно!";
                return View(loginVM);
                
            }
            //Пользователь не найден
            TempData["Error"] = "Такого пользователя не существует!";
            return View(loginVM);
        }
    }
}
