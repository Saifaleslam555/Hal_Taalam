using Hal_Taalam.Models;
using Hal_Taalam.ViewModel.Player;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hal_Taalam.Repository.Interface
{
    public interface IPlayerRepository:IGenericRepository<Player>
    {

        public Task UpdatePlayer(string userid, ProfileVM profileVM);
        public Task UpdateStats(int? score,string userid);
        public List<Player> RecentPlayers();
        

        //public Task CreatePlayer(ProfileVM profileVM);
        //public Task MakePlayer(string UserID);
        //public Task<Player> GetByUserID(string userid);

    }
}
