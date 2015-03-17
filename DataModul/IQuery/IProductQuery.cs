using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.IQuery
{
    public interface IProductQuery:IBaseQuery<Product>
    {
        string GetQueryCategoryByProduct(int productId);
        string GetQuerySetProductCategory(int productId, int categoryId);
        string GetQuerySetProductState(int productId, int stateId);
        string GetQueryDropProductCategory(int productId, int categoryId);
    }
}