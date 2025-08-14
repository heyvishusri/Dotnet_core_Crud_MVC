using Microsoft.AspNetCore.Mvc;

namespace WebAppDotNetCoreCrudNew.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentList()
        {
            return View();
        }
    }
}
