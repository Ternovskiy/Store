using DataModul.BaseRepository;
using DataModul.DomainModel;

namespace DataModul.Repository
{
    public interface IOrderRepository<T> : IBaseCrudRepository<T>, IBaseContextRepository
        where T :Order
    {
         
    }
}