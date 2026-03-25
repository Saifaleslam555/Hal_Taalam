using Hal_Taalam.Models;
using Hal_Taalam.ViewModel.Player;
using Microsoft.AspNetCore.Mvc;

namespace Hal_Taalam.Repository.Interface
{
    public interface IPlayerRepository:IGenericRepository<Player>
    {
        //public Task CreatePlayer(ProfileVM profileVM);

        //public Task MakePlayer(string UserID);
        public Task UpdatePlayer(string userid, ProfileVM profileVM);

        public Task<Player> GetByUserID(string userid);

        public Task UpdateStats(int? score,string userid);


    }
}
