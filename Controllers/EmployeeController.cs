using Microsoft.AspNetCore.Mvc;
using MVD_DEMO.net6.Models;

namespace MVD_DEMO.net6.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var employees = _repo.GetAllEmployees();
            return View(employees);
        }

        public IActionResult ViewEmployee(int id)
        {
            var employee = _repo.GetEmployee(id);
            return View(employee);
        }

        public IActionResult UpdateEmployee(int id)
        {
            Employee employ = _repo.GetEmployee(id);
            if (employ == null)
            {
                return View("ProductNotFound");
            }
            return View(employ);
        }

        public IActionResult UpdateEmployeeToDatabase(Employee employee)
        {
            _repo.UpdateEmployee(employee);

            return RedirectToAction("ViewEmployee", new { id = employee.EmployeeID });
        }

        public IActionResult InsertEmployeeToDatabase(Employee employeeToInsert)
        {
            _repo.InsertEmployee(employeeToInsert);
            return RedirectToAction("Index");
        }

    }
}
