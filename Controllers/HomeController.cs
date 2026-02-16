using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Repository;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    //[Route("[Controller]/[Action]")] // Token routing
    public class HomeController : Controller
    {
        private IEmployeeRepository _rep;

        //public HomeController([FromKeyedServices("KeyB")] IEmployeeRepository rep)  -- adding KeyBased Dependency Injection

        public HomeController (IEmployeeRepository rep)
        {
            _rep = rep; 
        }
        //[Route("/")]
        public JsonResult Index()
        {
            Employee data = _rep.GetEmployee(1);
            return Json(data);
        }
    }
}
