using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class  AllUsersController : Controller
    {
        private readonly ApplicationDBContext _context;

        public IActionResult Index()
        {
            var users = _context.users.ToList();
            return View(users);
        }
        public AllUsersController(ApplicationDBContext context)
        {
            _context = context;
        }
    }
}
