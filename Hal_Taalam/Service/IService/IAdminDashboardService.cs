using Hal_Taalam.Models;
using Microsoft.EntityFrameworkCore;

namespace Hal_Taalam.Service.IService
{
    public interface IAdminDashboardService
    {
        public Task<int> CountCategories();
        public Task< int> CountPlayers();
        public Task<int> CountGames();
        public Task<int> CountQuestions();
        public int CountQuestionsByCategory(int categoryID);
        public bool DatabaseStatus();
        public List<Player> RecentPlayers();

    }
}
