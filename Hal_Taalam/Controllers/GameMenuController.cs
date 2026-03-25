using Hal_Taalam.Models;
using Hal_Taalam.Models.DBcontext;
using Hal_Taalam.Repository;
using Hal_Taalam.Repository.Interface;
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
        private readonly IPlayerRepository playerRepository;

        public GameMenuController(UserManager<ApplicationUser>userManager,IPlayerRepository playerRepository)
        {
            this.userManager = userManager;
            this.playerRepository = playerRepository;
        }

        public IActionResult StartPage()
        {
            
            return View();
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
