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

        public async Task<int> CountCategories()
        {
          return await _unitOfWork.Category.GetCount();
        }

        public async Task<int> CountGames()
        {
            return await _unitOfWork.GameResult.GetCount();
        }

        public async Task<int> CountPlayers()
        {
            return await _unitOfWork.Player.GetCount();
        }

        public async Task<int> CountQuestions()
        {
            return await _unitOfWork.Question.GetCount();
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
