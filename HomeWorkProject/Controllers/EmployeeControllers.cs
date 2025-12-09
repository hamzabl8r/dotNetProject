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

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Details(int id)
        {
            var employee = _repository.FindByID(id);
            return employee == null ? NotFound() : View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _repository.Add(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var employee = _repository.FindByID(id);
            return employee == null ? NotFound() : View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            _repository.Update(id, employee);
            return RedirectToAction(nameof(Index));
        }
        

        public IActionResult Delete(int id)
        {
            var employee = _repository.FindByID(id);
            return employee == null ? NotFound() : View(employee);
        }

       [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search(string term)
        {
            return View("Index", _repository.Search(term));
        }
    }
}