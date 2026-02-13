using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    //[Route("[Controller]/[Action]")] // Token routing
    public class HomeController : Controller
    {
        //[Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
