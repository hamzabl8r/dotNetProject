using Microsoft.AspNetCore.Mvc;
using HomeWorkProject.Models;
using HomeWorkProject.Models.Repositories;

namespace HomeWorkProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        // GET: Employee
        public IActionResult Index()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }

        // GET: Employee/Details/5
        public IActionResult Details(int id)
        {
            var employee = _repository.FindByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _repository.FindByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(id, employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = _repository.FindByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Employee/Search
        public IActionResult Search(string term)
        {
            var employees = _repository.Search(term);
            return View("Index", employees);
        }
    }
}