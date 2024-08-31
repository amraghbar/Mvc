using CRUD.Data;
using CRUD.Models; // Assuming your user model is in the Models namespace
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

       

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user) 
        {
            
                _db.Users.Add(user); 
                _db.SaveChanges();
             return RedirectToAction("Login");
          
        }
        public IActionResult Login()
        {
           return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var check = _db.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password);
            if (check.Any())
            {
                return RedirectToAction("DisplayUsers");
            }
            ViewBag.Error = "invalid username / password";
            return View(user);
        }
        public IActionResult IsActivea(Guid UserId)
        {
            var ACTi = _db.Users.Find(UserId);

            if (ACTi == null)
            {
                return NotFound();
            }

            if (ACTi.IsActive == false)
            {
                ACTi.IsActive = true;
            }

            _db.SaveChanges();
            return RedirectToAction("DisplayUsers");
        }
        public IActionResult DisplayUsers()
        {
            var Users = _db.Users.Where(U => U.IsActive == false).ToList();




            return View(Users);
        }

        public IActionResult TrueUsers()
        {
            var Users = _db.Users.Where(U => U.IsActive == true).ToList();


            return View(Users);
        }
    }
}
