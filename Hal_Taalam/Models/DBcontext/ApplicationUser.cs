using Microsoft.AspNetCore.Identity;

namespace Hal_Taalam.Models.DBcontext
{
    public class ApplicationUser:IdentityUser
    {
       // public String Address { get; set; }

        public Player Player { get; set; }
    }
}
