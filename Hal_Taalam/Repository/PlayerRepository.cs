using Hal_Taalam.Models;
using Hal_Taalam.Models.DBcontext;
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

        public Task<Player> GetByUserID(string userid)
        {
            return context.Players.FirstAsync(p => p.UserID == userid);
        }

        public async Task UpdatePlayer(string userid, ProfileVM profileVM) 
        {
            //Player? player = null;

            //try
            //{
            //     player =  context.Players.FirstOrDefault(p => p.UserID == userid);
            //}
            //catch (Exception ex) 
            //{ 
            //    ContentResult content = new ContentResult();
            //    content.Content = ex.Message;
            //};

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

        //public async Task CreatePlayer()
        //{
        //    using var stream= new MemoryStream();
        //    await profileVM.imgUrl.CopyToAsync(stream);

        //    Player player = new Player();



        //    player.Name = profileVM.Name;
        //    player.Age=profileVM.Age;
        //    player.level = 0;
        //    player.IsPlaying = true;
        //    player.rank = 0;
        //    player.level = 0;
        //    player.Score = 0;
        //    player.ImgURL = null;

        //    Add(player);
        //    SaveChangesAsync();

    }

        
    }
