using Hal_Taalam.Data;
using Hal_Taalam.Models;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.ViewModel.Player;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hal_Taalam.Repository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        private readonly HalTaalamContext context;
        

        public PlayerRepository(HalTaalamContext context ) : base(context)
        {
            {
                this.context = context;
            }
        }

        //public Task<Player> GetByUserID(string userid)
        //{
        //    return context.Players.FirstAsync(p => p.UserID == userid);
        //}

        public async Task UpdatePlayer(string userid, ProfileVM profileVM) 
        {
            Player player = await context.Players.FirstOrDefaultAsync(p => p.UserID == userid);

            if (player != null)
            {
                player.Name = profileVM.Name;
                player.Age = profileVM.Age;
                player.ImgURL = null;
            }
            
            Update(player);
            await SaveChangesAsync();
        }


        public async Task UpdateStats(int? score,string userid) 
        {

            Player player = context.Players.FirstOrDefault(p=>p.UserID==userid);

            if (player != null) {
                
                player.Score = player.Score+score;
                if (player.Score >= player.xp) 
                {
                    player.level += 1;
                    player.xp += 30;
                }
            }

            Update(player);
            await SaveChangesAsync();
            
            
            
        }

        public List<Player> RecentPlayers()
        {
            return context.Users.OrderByDescending(r => r.RegistirationDate).Take(5).Select(u => new Player
            {
                Name = u.UserName,

            }).ToList();
        }

    }

        
    }
