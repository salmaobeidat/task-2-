using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_2_.Models;

namespace Recipe_Blog.Controllers
{
    public class AuthController : Controller
    {
        private readonly ModelContext _context;

        public AuthController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user,string Email, string Password, decimal RoleId)
        {
            if (ModelState.IsValid)
            {
                user.RoleId = RoleId;
                _context.AddAsync(user);
                _context.SaveChanges();

                Credential credential = new Credential();
                credential.Email = Email;
                credential.Password = Password;
                credential.UserId = user.UserId;
                _context.Add(credential);
                _context.SaveChanges();

                return RedirectToAction("Login","Auth");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login([Bind("Email,Password")] Credential credential)
        {
            if (!ModelState.IsValid)
            {
                return View(credential);
            }
            var user = await _context.Credentials.Include(x=>x.User).SingleOrDefaultAsync(x=>x.Email==credential.Email &&x.Password==credential.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password.");
                return View(credential);
            }
            var userId=user.UserId;
            var roleId = user.User?.RoleId;
            if (roleId == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password.");
                return View(credential);
            }

            switch(roleId)
            {
                case 1:
                    HttpContext.Session.SetInt32("AdminSession",(int)userId);
                    return RedirectToAction("Index", "Admin");
                case 2:
                    HttpContext.Session.SetInt32("ChefSession", (int)userId);
                    return RedirectToAction("Index", "Chef");

                case 3:
                    HttpContext.Session.SetInt32("CustomerSession", (int)userId);
                    return RedirectToAction("Index", "Home");

                default:
                    ModelState.AddModelError("", "Error!");
                    return View(credential);
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View(nameof(Login));
        }
    }
}
