using Hal_Taalam.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hal_Taalam.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {

        public IPlayerRepository Player { get; }
        public ICategoryRepository Category { get; }
        public IQusetionRepository Question { get; }
        public IGameResultRepository GameResult { get; }


        public bool DatabaseStatus();
        public Task<bool> Commit();
        public bool HasChanges();
    }
}
