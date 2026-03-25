using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hal_Taalam.Models.DBcontext
{
    public class HalTaalamContext :IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<Player>Players { get; set; }
        public DbSet<Question> Questions { get; set; }
        
        public HalTaalamContext(DbContextOptions options) : base(options)
        {
        }

        
    }
}
