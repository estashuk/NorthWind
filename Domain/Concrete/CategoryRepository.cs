using System.Linq;
using Domain.Abstract;

namespace Domain.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NORTHWNDEntities _context = new NORTHWNDEntities();
        public IQueryable<Categories> Categories => _context.Categories;
    }
}