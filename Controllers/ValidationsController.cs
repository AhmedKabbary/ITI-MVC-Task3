using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class ValidationsController : Controller
    {
        public IActionResult IsAgeValid(int age)
        {
            if (age > 13)
            {
                return Json(true);
            }
            else
            {
                return Json("Age cannot be less than 13");
            }

        }
    }
}