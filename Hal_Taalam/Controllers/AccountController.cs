using Hal_Taalam.Repository.Interface;
using Hal_Taalam.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hal_Taalam.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }


        public IActionResult Register() 
        {
            return View("Register");
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegeisterVM regeisterVM)
        {
           
            if (ModelState.IsValid) 
            {
               var result=await accountRepository.Register(regeisterVM);
                if (result.Succeeded) 
                {
                   return RedirectToAction("Profile", "Player");
                }
                foreach (var items in result.Errors) 
                {
                    ModelState.AddModelError("", items.Description);
                }
            }
            return View("Register", regeisterVM);
        }

        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM) 
        {
            if (ModelState.IsValid) 
            {
                var result= await accountRepository.Login(loginVM);
                if (result.Succeeded)
                {
                    return RedirectToAction("MainMenu", "GameMenu");
                }
                else 
                {
                    ModelState.AddModelError("", "Email or Password is Wrong");
                }
            }

            return View("Login",loginVM);
        }

        public async Task<IActionResult> SignOut() 
        {
            
                await accountRepository.SignOut();
                return RedirectToAction("Login");
            
        }
    }
}
