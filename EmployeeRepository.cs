using Dapper;
using MVD_DEMO.net6.Models;
using System.Data;

namespace MVD_DEMO.net6
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _conn;

        public EmployeeRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _conn.Query<Employee>("SELECT * FROM employees;");
        }

        public Employee GetEmployee(int id)
        {
            return _conn.QuerySingle<Employee>("SELECT * FROM EMPLOYEES WHERE EMPLOYEEID= @id", new { id });
        }


    }
}
