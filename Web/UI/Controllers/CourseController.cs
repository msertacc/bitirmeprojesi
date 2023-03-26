using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
