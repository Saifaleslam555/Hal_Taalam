using Hal_Taalam.Data;
using Hal_Taalam.Models;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.Repository.UnitOfWork;
using Hal_Taalam.ViewModel.ShowPlayerInfo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hal_Taalam.Controllers
{
    public class VIewController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public VIewController(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }



        public async Task<IActionResult> ShowPlayerInfo()
        {

            var user = await userManager.GetUserAsync(User);
            
            Player player =  await unitOfWork.Player.GetById(user.Id);

            ShowPlayerInfoVM showPlayerInfoVM = new ShowPlayerInfoVM();

            showPlayerInfoVM.Name = player.Name;
            showPlayerInfoVM.Level = player.level;



            return View("_HTLayout",showPlayerInfoVM);
        }
    }
}
