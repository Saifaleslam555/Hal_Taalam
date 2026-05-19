using Hal_Taalam.Models;
using Hal_Taalam.Repository.UnitOfWork;
using Hal_Taalam.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace Hal_Taalam.Service
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminDashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int CountCategories()
        {
          return _unitOfWork.Category.GetCount();
        }

        public int CountGames()
        {
            return _unitOfWork.GameResult.GetCount();
        }

        public int CountPlayers()
        {
            return _unitOfWork.Player.GetCount();
        }

        public int CountQuestions()
        {
            return _unitOfWork.Question.GetCount();
        }

        public int CountQuestionsByCategory(int categoryID)
        {
            return _unitOfWork.Category.GetAll(c => c.Id == categoryID).Count();
        }

        public bool DatabaseStatus()
        {
            return _unitOfWork.DatabaseStatus();
        }

        public List<Player> RecentPlayers()
        {
            return _unitOfWork.Player.RecentPlayers();
        }
 
    }

}
