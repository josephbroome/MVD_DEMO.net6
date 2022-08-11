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

        public Employee GetEmployee(int employeeid)
        {
            return _conn.QuerySingle<Employee>("SELECT * FROM EMPLOYEES WHERE EMPLOYEEID= @employeeid", new { employeeid });
        }

        public void UpdateEmployee(Employee employee)
        {
            _conn.Execute("UPDATE employees SET FirstName = @firstname, LastName = @lastname , EmailAddress = @emailaddress, PhoneNumber= @number WHERE EmployeeID = @id",
             new { firstname = employee.FirstName, lastname = employee.LastName, emailaddress = employee.EmailAddress, number = employee.PhoneNumber, id = employee.EmployeeID });
        }

        public void InsertEmployee(Employee employeeToInsert)
        {
            _conn.Execute("INSERT INTO employees (FIRSTNAME, MIDDLEINITIAL, LASTNAME, EMAILADDRESS, PHONENUMBER, TITLE, DATEOFBIRTH) VALUES (@firstname, @middleinitial, @lastname, @emailaddress, @phonenumber, @title,@dateofbirth);",
                new { firstname = employeeToInsert.FirstName, middleinitial = employeeToInsert.MiddleInitial, lastname = employeeToInsert.LastName, emailaddress = employeeToInsert.EmailAddress, phonenumber = employeeToInsert.PhoneNumber, dateofbirth = employeeToInsert.DateOfBirth });
        }



    }
}
