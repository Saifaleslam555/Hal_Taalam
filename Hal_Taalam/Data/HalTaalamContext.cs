using Hal_Taalam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hal_Taalam.Data
{
    public class HalTaalamContext :IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<Player>Players { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameResults> GameResults { get; set; }

        public HalTaalamContext(DbContextOptions options) : base(options)
        {
        }

        
    }
}
