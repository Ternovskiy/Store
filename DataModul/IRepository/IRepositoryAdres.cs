using DataModul.DomainModel;
using DataModul.IQuery;

namespace DataModul.IRepository
{
    public interface IRepositoryAdres:IRepository<Adres>
    {
        IAdresQuery AdresQuery { get; set; }
    }
}