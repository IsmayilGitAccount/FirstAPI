using FirstAPI.Repositories.Interfaces;

namespace FirstAPI.Repositories.Implementations
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context) { }
       
    }
}
