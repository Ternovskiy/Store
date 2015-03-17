using System;
using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.Query
{
    public class CartBaseQuery:ConnectQuery,IBaseQuery<Cart>
    {
        public CartBaseQuery(string connectionString) : base(connectionString)
        {
        }

        public string QueryGetAll { get { return _queryGetAll; } }
        public string QuerySave{get { return _querySave; }}
        public string QueryDelete { get { return _queryDelete; } }
        public string QueryGetById { get { return _queryGetById; } }
        public string GetQuerySave(Cart domainModel)
        {           
            return String.Format(
                    _querySave,
                    (domainModel.CartId == 0) ? "NULL" : domainModel.CartId.ToString(),
                    domainModel.Count,
                    domainModel.ProductId,
                    domainModel.UserId
                );
        }

        public string GetQueryDelete(object id)
        {
            return String.Format(_queryDelete, (int) id);
        }

        public string GetQueryGetById(object id)
        {
            return String.Format(_queryGetById, (int)id);
        }

        private string _queryGetAll = "EXEC GetAllCart";
        private string _querySave = "EXEC SaveCart @Id = {0}, @Count={1},@ProductId={2},@UserId='{3}'";
        private string _queryDelete = "EXEC DeleteCart @Id={0}";
        private string _queryGetById = "EXEC GetByIdCart @Id={0}";
        
    }
}