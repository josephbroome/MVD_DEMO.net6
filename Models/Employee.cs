﻿namespace MVD_DEMO.net6.Models
{
    public class Employee
    {
        public Employee()
        {

        }

        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Title { get; set; }

        public DateTime DateOfBirth { get; set; }   
    }
}
