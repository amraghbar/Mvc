using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class AcccountsController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
