using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModels;

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
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _queryRepository.GetById(id);
            if (task == null) return View("Error");
            var taskVM = new EditTaskViewModel
            {
                Name = task.Name,
                Description = task.Description,
                Model = task.Model,
                Problem = task.Problem,
                PhoneNumber= task.PhoneNumber,
                IsItQuick = task.IsItQuick
            };
            return View(taskVM);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EditTaskViewModel taskVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Редактирование неудачно.");
                return View("Edit",taskVM);
            }
            var userClub = await _queryRepository.GetByIdNoTracking(id);
            if (userClub != null)
            {
                var task = new Query
                {
                    Id = id,
                    Name = taskVM.Name,
                    Description = taskVM.Description,
                    Model = taskVM.Model,
                    Problem = taskVM.Problem,
                    PhoneNumber = taskVM.PhoneNumber,
                    IsItQuick = taskVM.IsItQuick
                };
                _queryRepository.Update(task);
                return RedirectToAction("Index");
            }
            else
            {
                return View(taskVM);
            }
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Query query)
        {
            _queryRepository.Delete(query);
            return RedirectToAction("Index", "Task");
        }
        public TaskController(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }
           
    }
}

