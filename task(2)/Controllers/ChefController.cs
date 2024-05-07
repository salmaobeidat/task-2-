using Microsoft.AspNetCore.Mvc;

namespace task_2_.Controllers
{
    public class ChefController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
