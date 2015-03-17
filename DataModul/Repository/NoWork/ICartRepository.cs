using DataModul.BaseRepository;
using DataModul.DomainModel;

namespace DataModul.Repository
{
    public interface ICartRepository<T> : IBaseCrudRepository<T>, IBaseContextRepository
        where T : Cart
    {

    }
}