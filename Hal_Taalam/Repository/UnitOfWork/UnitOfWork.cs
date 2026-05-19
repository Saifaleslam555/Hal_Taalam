using Hal_Taalam.Data;
using Hal_Taalam.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hal_Taalam.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HalTaalamContext _context;
        private PlayerRepository? _playerRepository;
        private CategoryRepository? _categoryRepository;
        private QuestionRepository? _questionRepository;
        private GameResultRepository? _gameResultRepository;

        public UnitOfWork(HalTaalamContext context)
        {
            _context = context;
        }

        public IPlayerRepository Player => _playerRepository?? new PlayerRepository(_context);

        public ICategoryRepository Category => _categoryRepository?? new CategoryRepository(_context);

        public IQusetionRepository Question => _questionRepository?? new QuestionRepository(_context);

        public IGameResultRepository GameResult => _gameResultRepository?? new GameResultRepository(_context);


        public async Task<bool> Commit()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("error while saving changes", ex);
            }
        }
        public bool DatabaseStatus()
        {
            return _context.Database.CanConnect();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
