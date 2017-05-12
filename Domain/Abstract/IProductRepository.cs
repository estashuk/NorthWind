using System.Linq;

namespace Domain.Abstract
{
    public interface IProductRepository
    {
         IQueryable<Products> Products { get; } 
    }
}