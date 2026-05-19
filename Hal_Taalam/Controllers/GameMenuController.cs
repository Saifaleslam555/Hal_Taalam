using Hal_Taalam.Data;
using Hal_Taalam.Models;
using Hal_Taalam.Repository;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.Repository.UnitOfWork;
using Hal_Taalam.ViewModel.ShowPlayerInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hal_Taalam.Controllers
{
    [Authorize]
    public class GameMenuController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUnitOfWork unitOfWork;

        public GameMenuController(UserManager<ApplicationUser>userManager,IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult StartPage()
        {
            
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult AdminDashBoard() { 
        
             return View("AdminDashboard");
        }

        [Authorize]
        public IActionResult MainMenu() 
        {
            
            return View("MainMenu");
        }

        [Authorize]
        public IActionResult HowToPlay() 
        {
            return View();
        }
        
        [Authorize]
        public IActionResult LeaderBorad() 
        {
            return View();
        }

        public IActionResult OpenQuiz() 
        {
            return RedirectToAction("StartQuiz", "Question");
        }
    }
}
