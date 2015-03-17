using System.Collections.Generic;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.ViewModel;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryProduct:Repository<Product>,IRepositoryProduct
    {
        public RepositoryProduct(IProductQuery productQuery, Logger logger) : base(productQuery, logger)
        {
            ProductQuery = productQuery;
        }

        public RepositoryProduct(IProductQuery productQuery): base(productQuery)
        {
            ProductQuery = productQuery;
        }

        public IProductQuery ProductQuery { get; set; }

        public IEnumerable<Category> GetCategoryByProduct(int productId)
        {
            return GetTable<Category>(ProductQuery.GetQueryCategoryByProduct(productId));
        }

        public bool SetProductCategory(int productId, int categoryId)
        {
            return ExecuteNonQuery(ProductQuery.GetQuerySetProductCategory(productId, categoryId));
        }

        public bool SetProductState(int productId, int stateId)
        {
            return ExecuteNonQuery(ProductQuery.GetQuerySetProductState(productId, stateId));
        }

        public bool DropProductCategory(int productId, int categoryId)
        {
            return ExecuteNonQuery(ProductQuery.GetQueryDropProductCategory(productId, categoryId));
        }
    }
}