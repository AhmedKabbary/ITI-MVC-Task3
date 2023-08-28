using Microsoft.AspNetCore.Mvc;

using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var deaprtments = _departmentService.Index();
            return View(deaprtments);
        }

        public IActionResult Details(int id)
        {
            Department? department = _departmentService.Details(id);
            if (department == null)
            {
                return NotFound();
            }

            // Add to session
            HttpContext.Session.SetString("id", department.Id.ToString());
            HttpContext.Session.SetString("name", department.Name.ToString());

            return View(department);
        }

        public IActionResult Session()
        {
            string id = HttpContext.Session.GetString("id")!;
            string name = HttpContext.Session.GetString("name")!;
        
            ViewBag.id = id;
            ViewBag.name = name;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Department department)
        {
            if (!ModelState.IsValid)
            {
                return Create();
            }
            _departmentService.Create(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit([FromQuery] int id)
        {
            Department? department = _departmentService.Details(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] Department department)
        {
            department.Id = id;
            _departmentService.Edit(department);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Department? department = _departmentService.Details(id);
            if (department == null)
            {
                return NotFound();
            }
            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        }
    }
}