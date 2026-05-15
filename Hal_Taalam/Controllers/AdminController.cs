using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hal_Taalam.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
            
        }

        public IActionResult AdminDashboard()
        {
            return View("AdminDashboard");
        }
    }
}
