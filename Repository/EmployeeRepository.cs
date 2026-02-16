using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetEmployee (int id)
        {
            Employee emp = new Employee { 
                Id = 1,
                Name="Sample",
                Email="Sample@gmail.com",
                Department="IT"
            };
            return emp;
        }
    }
}
