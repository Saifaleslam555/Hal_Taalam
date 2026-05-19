using Hal_Taalam.Data;
using Hal_Taalam.Repository;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.Repository.UnitOfWork;
using Hal_Taalam.ViewModel.Player;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hal_Taalam.Controllers
{
    public class PlayerController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUnitOfWork unitOfWork;

        public PlayerController(UserManager<ApplicationUser> userManager,IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }


        public IActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileVM profileVM) {

            if (ModelState.IsValid)
            {
                var player = await userManager.GetUserAsync(User);
                if (player == null) { return RedirectToAction("Login", "Account"); }

                await  unitOfWork.Player.UpdatePlayer(player.Id, profileVM);

                return RedirectToAction("MainMenu", "GameMenu");
            }

            return View("Profile",profileVM);
        }

    }
}
