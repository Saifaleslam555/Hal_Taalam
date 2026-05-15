using Hal_Taalam.Models;

namespace Hal_Taalam.Repository.Interface
{
    public interface IAdminDashboardRepository
    {
        public int CountPlayers();
        public int CountQuestions();
        public int CountCategories();
        public int CountQuestionsByCategory(int categoryID);
        public bool DatabaseStatus();
        public List<Player> RecentPlayers();
        //public List<Question> RecentQuestions();
    }
}
