using Hal_Taalam.Data;
using Hal_Taalam.Models;
using Hal_Taalam.Repository.Interface;

namespace Hal_Taalam.Repository
{
    public class GameResultRepository : GenericRepository<GameResults>, IGameResultRepository
    {
        private readonly HalTaalamContext _context;
        public GameResultRepository(HalTaalamContext context) : base(context)
        {
            _context = context;

        }
    }
}
