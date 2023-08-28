using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;

        public StudentsController(IStudentService studentService, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var students = _studentService.Index();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            Student? student = _studentService.Details(id);
            if (student == null)
            {
                return NotFound();
            }

            // Add to cookie
            Response.Cookies.Append("id", student.Id.ToString());
            Response.Cookies.Append("name", student.Name.ToString());

            return View(student);
        }

        public IActionResult Cookie()
        {
            string id = Request.Cookies["id"]!.ToString();
            string name = Request.Cookies["name"]!.ToString();

            ViewBag.Id = id;
            ViewBag.Name = name;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Department> departments = _departmentService.Index();
            ViewBag.departments = new SelectList(departments, nameof(Department.Id), nameof(Department.Name));
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Student student)
        {
            if (!ModelState.IsValid)
            {
                return Create();
            }
            _studentService.Create(student);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student? student = _studentService.Details(id);
            if (student == null)
            {
                return NotFound();
            }

            IEnumerable<Department> departments = _departmentService.Index();
            ViewBag.departments = departments;

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] Student student)
        {
            student.Id = id;
            _studentService.Edit(student);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Student? student = _studentService.Details(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentService.Delete(student);
            return RedirectToAction(nameof(Index));
        }
    }
}