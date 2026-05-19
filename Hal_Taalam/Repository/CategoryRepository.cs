using Hal_Taalam.Data;
using Hal_Taalam.Models;
using Hal_Taalam.Repository.Interface;

namespace Hal_Taalam.Repository
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        private readonly HalTaalamContext context;

        public CategoryRepository(HalTaalamContext context) : base(context)
        {
            this.context = context;
        }
    }
}
