using Hal_Taalam.Models;
using Hal_Taalam.Models.DBcontext;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hal_Taalam.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPlayerRepository playerRepository;

        //private readonly PlayerRepository playerRepository;

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IPlayerRepository playerRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.playerRepository = playerRepository;
        }

        public async Task<SignInResult> Login(LoginVM loginVM)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(loginVM.Email);
            if (user != null) 
            {
                bool found= await userManager.CheckPasswordAsync(user, loginVM.Password);
                if (found==true)
                {
                  await  signInManager.SignInAsync(user, loginVM.Remeberme);  
                  return SignInResult.Success;
                }
            }
            return SignInResult.Failed;
            
        }

        public async Task<IdentityResult> Register(RegeisterVM regeisterVM)
        {
            ApplicationUser user = new ApplicationUser();
            //mapping
            user.UserName = regeisterVM.UserName;
            user.Email = regeisterVM.Email;
            //user.PasswordHash = regeisterVM.Password;
          
            //saveDB
            IdentityResult result= await userManager.CreateAsync(user,regeisterVM.Password);
            //signin
            if (result.Succeeded) 
            {
               await signInManager.SignInAsync(user, true);

                Player player = new Player();

                player.UserID = user.Id;

                player.Name = null;
                player.Age = 0;
                player.level = 0;
                
                player.IsPlaying = false;
                player.rank = 0;
                player.Score = 0;
                player.ImgURL = null;

                playerRepository.Add(player);
                await playerRepository.SaveChangesAsync();

                //playerRepository.MakePlayer(user.Id);

            }

            return result;
            
        }

        public async Task SignOut()
        {
             await signInManager.SignOutAsync();

        }
    }
}
