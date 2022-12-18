using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TaskController : Controller
    {
        private readonly IQueryRepository _queryRepository;
        public async Task<IActionResult> Index()
        {
            IEnumerable<Query> query = await _queryRepository.GetAll();
            return View(query);

        }
        public async Task<IActionResult> Detail(int id)
        {
            Query query = await _queryRepository.GetById(id);
            return View(query);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Query query)
        {
           if (!ModelState.IsValid)
            {
                return View(query);
            }
           _queryRepository.Add(query);
            return RedirectToAction ("Index");
        }
        
        public TaskController(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }
    }
}

