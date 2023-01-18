using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    //Контроллер
    public class TaskController : Controller
    {
        private readonly IQueryRepository _queryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public TaskController(IQueryRepository queryRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _queryRepository = queryRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Query> query = await _queryRepository.GetAllbyUserID();
            return View(query);
        }
        public async Task<ActionResult> FreelancerTask()
        {
            List<Query> query = await _queryRepository.GetAllbyFreelancerName();
            return View(query);
        }
        public async Task<IActionResult> AllTasks()
        {
            IEnumerable<Query> query = await _queryRepository.GetAll();
            return View(query);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Query query = await _queryRepository.GetById(id);
            return View(query);
        }
        //Создание
        [HttpGet]
        public IActionResult Create()
        {
            var curUserID = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createTaskVM = new CreateTaskViewModel { AppUserId = curUserID };
            return View(createTaskVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel taskVM)
        {
            if (ModelState.IsValid)
            {
                var task = new Query
                {
                    Name = taskVM.Name,
                    Description = taskVM.Description,
                    Model = taskVM.Model,
                    Problem = taskVM.Problem,
                    PhoneNumber = taskVM.PhoneNumber,
                    IsItQuick = taskVM.IsItQuick,
                    AppUserId = taskVM.AppUserId,
                    QueryStatus = QueryStatus.Free
                };
                _queryRepository.Add(task);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Create is not accurate");
            }

            return View(taskVM);
        }
        //Редактирование
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
                PhoneNumber = task.PhoneNumber,
                IsItQuick = task.IsItQuick,
                QueryStatus = QueryStatus.Free.ToString(),
                AppUserId = task.AppUserId
            };
            return View(taskVM);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EditTaskViewModel taskVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Редактирование неудачно.");
                return View("Edit", taskVM);
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
                    IsItQuick = taskVM.IsItQuick,
                    QueryStatus = QueryStatus.Free,
                    AppUserId = taskVM.AppUserId
                };
                _queryRepository.Update(task);
                return RedirectToAction("Index");
            }
            else
            {
                return View(taskVM);
            }
        }
        //Фрилансер взял работу
        [HttpPost]
        public async Task<IActionResult> Detail(Query task)
        {
            var _task = await _queryRepository.GetByIdNoTracking(task.Id);
            var curUserName = _httpContextAccessor.HttpContext?.User.GetUserName();
            if (_task.QueryStatus == QueryStatus.Free)
            {
                task = new Query
                {
                    Id = _task.Id,
                    Name = _task.Name,
                    Description = _task.Description,
                    Model = _task.Model,
                    Problem = _task.Problem,
                    PhoneNumber = _task.PhoneNumber,
                    IsItQuick = _task.IsItQuick,
                    QueryStatus = QueryStatus.Working,
                    AppUserId = _task.AppUserId,
                    FreelancerID = curUserName,
                };
            }
            else
            {
                task = new Query
                {
                    Id = _task.Id,
                    Name = _task.Name,
                    Description = _task.Description,
                    Model = _task.Model,
                    Problem = _task.Problem,
                    PhoneNumber = _task.PhoneNumber,
                    IsItQuick = _task.IsItQuick,
                    QueryStatus = QueryStatus.Finished,
                    AppUserId = _task.AppUserId,
                    FreelancerID = curUserName,
                };
            }
            _queryRepository.Update(task);
            return View(task);
        }
        

        //Удаление
        [HttpGet]
        public async Task<ActionResult> Delete(Query query)
        {
            _queryRepository.Delete(query);
            return RedirectToAction("Index", "Task");
        }

    }
}

