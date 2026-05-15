using Hal_Taalam.Models;
using Microsoft.AspNetCore.Identity;

namespace Hal_Taalam.Data
{
    public class ApplicationUser:IdentityUser
    {
       // public String Address { get; set; }

        public DateTime RegistirationDate { get; set; } = DateTime.Now;

        public Player Player { get; set; }
    }
}
