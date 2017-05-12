using System.Linq;

namespace Domain.Abstract
{
    public interface ICategoryRepository
    {
         IQueryable<Categories> Categories { get; } 
    }
}