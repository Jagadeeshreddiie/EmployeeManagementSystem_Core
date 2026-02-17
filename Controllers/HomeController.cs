using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Repository;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

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
        public ActionResult Index()
        {
            var details = _rep.GetAllEmployee();
            return View(details);
        }

        public ViewResult Details (int id)
        {
            HomeDetailsViewModel details = new HomeDetailsViewModel()
            {
                employee=_rep.GetEmployee(id),
                Title="Employee Details"
            };
            
            return View(details);
        }
    }
}
