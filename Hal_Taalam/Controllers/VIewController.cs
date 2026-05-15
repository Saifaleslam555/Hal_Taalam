using Hal_Taalam.Data;
using Hal_Taalam.Models;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.ViewModel.ShowPlayerInfo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hal_Taalam.Controllers
{
    public class VIewController : Controller
    {
        private readonly IPlayerRepository playerRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public VIewController(IPlayerRepository playerRepository,UserManager<ApplicationUser> userManager)
        {
            this.playerRepository = playerRepository;
            this.userManager = userManager;
        }



        public async Task<IActionResult> ShowPlayerInfo()
        {

            var user = await userManager.GetUserAsync(User);
            
            Player player = await playerRepository.GetByUserID(user.Id);

            ShowPlayerInfoVM showPlayerInfoVM = new ShowPlayerInfoVM();

            showPlayerInfoVM.Name = player.Name;
            showPlayerInfoVM.Level = player.level;



            return View("_HTLayout",showPlayerInfoVM);
        }
    }
}
