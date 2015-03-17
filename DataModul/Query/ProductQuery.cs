using System;
using DataModul.IQuery;
using DataModul.Repository;

namespace DataModul.Query
{
    public class ProductQuery:ProductBaseQuery,IProductQuery
    {
        public ProductQuery(string connectionString) : base(connectionString)
        {
        }

        public string GetQueryCategoryByProduct(int productId)
        {
            return string.Format(_queryCategoryByProduct, productId);
        }

        public string GetQuerySetProductCategory(int productId, int categoryId)
        {
            return string.Format(_querySetProductCategory, productId,categoryId);
        }

        public string GetQuerySetProductState(int productId, int stateId)
        {
            return string.Format(_querySetProductCategory, productId, stateId);
        }

        public string GetQueryDropProductCategory(int productId, int categoryId)
        {
            return string.Format(_queryDropProductCategory, productId, categoryId);
        }

        private string _queryCategoryByProduct = "exec dbo.GetCategoryByProduct @ProductId={0}";
        private string _querySetProductCategory = "exec dbo.SetProductCategory @ProductId={0}, @CategoryId={1}";
        private string _querySetProductState = "exec dbo.SetProductState @ProductId={0}, @StateId={1}";
        private string _queryDropProductCategory = "exec dbo.DropProductCategory @ProductId={0}, @CategoryId={1}";
    }
}