using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployee();
    }
}
