using MVD_DEMO.net6.Models;

namespace MVD_DEMO.net6
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();


        public Employee GetEmployee(int employeeid);

        public void UpdateEmployee(Employee employee);

        public void InsertEmployee(Employee employeeToInsert);


    }

    
}