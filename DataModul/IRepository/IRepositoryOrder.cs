using DataModul.DomainModel;
using DataModul.IQuery;

namespace DataModul.IRepository
{
    public interface IRepositoryOrder:IRepository<Order>
    {
        IOrderQuery OrderQuery { get; set; }
    }
}