using DataModul.BaseRepository;
using DataModul.DomainModel;

namespace DataModul.Repository
{
    public interface ICategoryRepository<T> : IBaseCrudRepository<T>, IBaseContextRepository
        where T :Category
    {
         
    }
}