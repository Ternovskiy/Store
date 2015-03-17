using System;
using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.Query
{
    public class ProductBaseQuery:ConnectQuery,IBaseQuery<Product>
    {
        public ProductBaseQuery(string connectionString) : base(connectionString)
        {
        }

        public string QueryGetAll { get { return _queryGetAll; } }
        public string QuerySave{get{return _querySave;}}
        public string QueryDelete { get { return _queryDelete; } }
        public string QueryGetById { get { return _queryGetById; } }
        public string GetQuerySave(Product domainModel)
        {
            return String.Format(
                    _querySave,
                    (domainModel.ProductId == 0) ? "NULL" : domainModel.ProductId.ToString(),
                    domainModel.Name,
                    domainModel.Description==""?"NULL":domainModel.Description,
                    domainModel.Price,
                    domainModel.UserSellerID
                );
        }

        public string GetQueryDelete(object id)
        {
            return String.Format(_queryDelete,(int)id);
        }

        public string GetQueryGetById(object id)
        {
            return String.Format(_queryGetById, (int)id);
        }


        private string _queryGetAll = "EXEC dbo.GetAllProduct";
        private string _querySave = "EXEC dbo.SaveProduct @Id = {0}, @Name = '{1}', @Description = '{2}', @Price = {3},  @UserSellerID = '{4}'";
        private string _queryDelete = "EXEC dbo.DeleteProduct @Id={0}";
        private string _queryGetById = "EXEC dbo.GetByIdProduct @Id={0}"; 
    }
}