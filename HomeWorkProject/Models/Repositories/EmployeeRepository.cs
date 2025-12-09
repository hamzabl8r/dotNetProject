using System.Collections.Generic;
using System.Linq;
using HomeWorkProject.Models;

namespace HomeWorkProject.Models.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly List<Employee> employees = new List<Employee>();

        public EmployeeRepository()
        {
            employees.Add(new Employee { Id = 1, Name = "Sofien Ben Ali", Departement = "Comptabilite", Salary = 1000 });
            employees.Add(new Employee { Id = 2, Name = "Mourad Triki", Departement = "HR", Salary = 1500 });
            employees.Add(new Employee { Id = 3, Name = "Ali Ben Mohamed", Departement = "Informatique", Salary = 1700 });
            employees.Add(new Employee { Id = 4, Name = "Tarek Aribi", Departement = "Informatique", Salary = 1100 });
        }

        public List<Employee> GetAll() => employees;

        public Employee FindByID(int id) => employees.FirstOrDefault(e => e.Id == id);

        public void Add(Employee employee)
        {
            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
        }

        public void Update(int id, Employee newEmployee)
        {
            var existing = FindByID(id);
            if (existing != null)
            {
                existing.Name = newEmployee.Name;
                existing.Departement = newEmployee.Departement;
                existing.Salary = newEmployee.Salary;
            }
        }

        public void Delete(int id)
        {
            employees.RemoveAll(e => e.Id == id);
        }

        public List<Employee> Search(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return employees;
            }
            return employees.Where(e => 
                e.Name.Contains(term, System.StringComparison.OrdinalIgnoreCase) ||
                e.Departement.Contains(term, System.StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}