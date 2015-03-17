using System.Collections.Generic;
using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using DataModul.Repository;
using DataModul.ViewModel;

namespace DataModul.BaseRepository
{
    public interface IRepositoryProduct:IRepository<Product>
    {
        IProductQuery ProductQuery { get; set; }

        IEnumerable<Category> GetCategoryByProduct(int productId);

        bool SetProductCategory(int productId, int categoryId);
        bool SetProductState(int productId, int stateId);
        bool DropProductCategory(int productId, int categoryId);
    }
}