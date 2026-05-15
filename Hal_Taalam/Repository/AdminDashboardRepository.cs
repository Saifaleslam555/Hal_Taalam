using Hal_Taalam.Data;
using Hal_Taalam.Models;
using Hal_Taalam.Repository.Interface;

namespace Hal_Taalam.Repository
{
    public class AdminDashboardRepository :IAdminDashboardRepository
    {
        private HalTaalamContext _context;
        public AdminDashboardRepository(HalTaalamContext context)
        {
            _context = context;
        }

        public int CountCategories()
        {
             return _context.Categories.Count();
             
        }

        public int CountPlayers()
        {
            return _context.Players.Count();
        }

        public int CountGames() 
        {
            return _context.GameResults.Count();
        }

        public int CountQuestions()
        {
            return _context.Questions.Count();
        }

        public int CountQuestionsByCategory(int categoryID)
        {
            return _context.Questions.Where(q => q.CategoryID == categoryID).Count();

        }

        public bool DatabaseStatus()
        {
            return _context.Database.CanConnect();
        }

        public List<Player> RecentPlayers()
        {
            return _context.Users.OrderByDescending(r=>r.RegistirationDate).Take(5).Select(u => new Player
            {
                Name = u.UserName,
                
            }).ToList();
        }
    }
}
