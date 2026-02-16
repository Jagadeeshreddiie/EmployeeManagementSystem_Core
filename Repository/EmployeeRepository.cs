using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>(){
            new Employee(){
                Id = 1,
                Name = "Bhogesh",
                Department = "IT",
                Email = "bhogesh@inubesolutions.com"
            },
            new Employee()
            {
                Id = 2,
                Name = "Jagadeesh",
                Department = "IT",
                Email = "jagadeesh@inubesolutions.com"
            },
            new Employee()
            {
                Id = 3,
                Name = "Kotesh",
                Department = "QA",
                Email = "kotesh@inubesolutions.com"
            }
        };
        }
        


        public Employee GetEmployee (int id)
        {
            return _employees.FirstOrDefault(a=>a.Id==id) ?? new Employee();
        }

        public List<Employee> GetAllEmployee()
        {
            return _employees;
        }
    }
}
