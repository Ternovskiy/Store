using DataModul.DomainModel;
using DataModul.IQuery;

namespace DataModul.IRepository
{
    public interface IRepositoryImage:IRepository<Image>
    {
        IImageQuery ImageQuery { get; set; }
    }
}