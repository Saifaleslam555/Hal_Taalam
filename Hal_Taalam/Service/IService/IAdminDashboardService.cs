using Hal_Taalam.Models;
using Microsoft.EntityFrameworkCore;

namespace Hal_Taalam.Service.IService
{
    public interface IAdminDashboardService
    {
        public int CountCategories();
        public int CountPlayers();
        public int CountGames();
        public int CountQuestions();
        public int CountQuestionsByCategory(int categoryID);
        public bool DatabaseStatus();
        public List<Player> RecentPlayers();

    }
}
