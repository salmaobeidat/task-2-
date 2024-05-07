using Microsoft.AspNetCore.Mvc;

namespace task_2_.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
