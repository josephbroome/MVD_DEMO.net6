using Microsoft.AspNetCore.Mvc;

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

    }
}
