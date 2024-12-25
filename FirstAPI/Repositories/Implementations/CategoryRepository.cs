using FirstAPI.Repositories.Interfaces;

namespace FirstAPI.Repositories.Implementations
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context) { }
    
    }
}
