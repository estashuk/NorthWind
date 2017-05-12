using System.Data.Entity;
using System.Linq;
using Domain.Abstract;

namespace Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly NORTHWNDEntities _context = new NORTHWNDEntities();
        public IQueryable<Products> Products => _context.Products.Include(x => x.Categories)
            .Where(x => x.Categories.CategoryName == "Beverages" || x.Categories.CategoryName == "Confections"); 
    }
}