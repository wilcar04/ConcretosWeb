using Microsoft.AspNetCore.Mvc;

namespace Concretos.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
