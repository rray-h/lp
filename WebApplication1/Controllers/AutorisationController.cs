using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;
namespace WebApplication1.Controllers
{
    public class AutorisationController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }
/*        public AutorisationController(ApplicationDBContext context)
        {
            _context = context;
        }*/
        [HttpPost]
        public IActionResult Check(User user)
        {
            if(ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View("Index");
        }
    }
}
