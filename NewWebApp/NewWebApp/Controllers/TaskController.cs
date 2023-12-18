using Microsoft.AspNetCore.Mvc;

namespace NewWebApp.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
