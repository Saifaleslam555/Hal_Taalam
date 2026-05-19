using Hal_Taalam.Data;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
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
       
        //[HttpGet]
        //public async Task<IActionResult> CreateFirstAdmin(
        //    [FromServices] UserManager<ApplicationUser> userManager, 
        //    [FromServices] RoleManager<IdentityRole> roleManager)
        //{
        //    if (!await roleManager.RoleExistsAsync("Admin"))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole("Admin"));
        //    }

        //    var adminUser = await userManager.FindByEmailAsync("admin@haltaalam.com");
        //    if (adminUser == null)
        //    {
        //        adminUser = new ApplicationUser
        //        {
        //            UserName = "admin@haltaalam.com",
        //            Email = "admin@haltaalam.com",
        //            EmailConfirmed = true
        //        };

        //        var result = await userManager.CreateAsync(adminUser, "Admin@123456");

        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(adminUser, "Admin");
        //            return Content("✅ تم إنشاء حساب الأدمين بنجاح! يمكنك تسجيل الدخول الآن.");
        //        }

        //        return Content("❌ حدث خطأ: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        //    }

        //    return Content("⚠️ حساب الأدمين موجود بالفعل في قاعدة البيانات!");
        //}

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
