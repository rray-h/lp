using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepository;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDBContext context, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _userRepository = userRepository;
        }
        //Регистрация
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel RegisterVM)
        {
            if (!ModelState.IsValid) return View(RegisterVM);

            var user = await _userManager.FindByEmailAsync(RegisterVM.EmailAddress);

            if (user != null)
            {
                TempData["Error"] = "Данная почта уже занята другим пользователем";
                return View(RegisterVM);
            }
            var newUser = new AppUser()
            {
                Email = RegisterVM.EmailAddress,
                UserName = RegisterVM.EmailAddress,
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, RegisterVM.Password);
            if (newUserResponse.Succeeded)
            {
                if (RegisterVM.Freelance == true) await _userManager.AddToRoleAsync(newUser, UserRoles.Freelancer);
                else await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return RedirectToAction("Login", "Account");
        }

        // Логин
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

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
        //Выход 
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        public async Task<IActionResult> AllUsers()
        {
            var users = await _userRepository.GetAppUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    Email= user.Email,
                };
                result.Add(userViewModel);
            }
            return View(result);
        }
        //Удаление
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userRepository.GetById(id);
            _userManager.DeleteAsync(user);
            return RedirectToAction("AllUsers");
        }
    }
}
