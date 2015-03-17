using DataModul.DomainModel;
using DataModul.IQuery;

namespace DataModul.IRepository
{
    public interface IRepositoryCart:IRepository<Cart>
    {
        ICartQuery CartQuery { get; set; }
    }
}