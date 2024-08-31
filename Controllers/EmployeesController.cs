using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
        
            var employees = _db.Employees.AsNoTracking().ToList();
            return View(employees);
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Store(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var employee = _db.Employees.Find(id);
            return View(employee);
        }

        public IActionResult Update(Employee employ)
        {
            var employee = _db.Employees.Find(employ.Id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = employ.Name;
            employee.Email = employ.Email;
            employee.Password = employ.Password;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
