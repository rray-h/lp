using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class  AllUsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public async Task<IActionResult> Index()
        {
            IEnumerable<User> users = await _userRepository.GetAll();
            return View(users);
        }
        public AllUsersController( IUserRepository userRepository)  
        {
            _userRepository = userRepository;
        }
    }
}
