using DataModul.BaseRepository;
using DataModul.DomainModel;

namespace DataModul.Repository
{
    public  interface IRepository<T> : IBaseCrudRepository<T>, IBaseContextRepository 
        where T : User
    {

    }
}