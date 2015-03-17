using DataModul.DomainModel;
using DataModul.IQuery;

namespace DataModul.IRepository
{
    public interface IRepositoryState:IRepository<State>
    {
        IStateQuery StateQuery { get; set; }
    }
}