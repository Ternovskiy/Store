using DataModul.DomainModel;
using DataModul.IQuery;

namespace DataModul.IRepository
{
    public interface IRepositoryAccount:IRepository<Accounts>
    {
        IAccountQuery AccountQuery { get; set; }
    }
}