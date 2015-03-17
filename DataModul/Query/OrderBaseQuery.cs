using System;
using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.Repository;

namespace DataModul.Query
{
    public class OrderBaseQuery:ConnectQuery,IBaseQuery<Order>
    {
        public OrderBaseQuery(string connectionString) : base(connectionString)
        {
        }

        public string QueryGetAll { get { return _queryGetAll; } }
        public string QuerySave { get { return _querySave; } }
        public string QueryDelete { get { return _queryDelete; } }
        public string QueryGetById { get { return _queryGetById; } }
        
        public string GetQuerySave(Order domainModel)
        {
            return String.Format(
                    _querySave,
                    (domainModel.OrderId == 0) ? "NULL" : domainModel.OrderId.ToString(),
                    domainModel.Data==null?"NULL" :domainModel.Data.ToString(),
                    domainModel.CartId,
                    domainModel.StateId==null?"NULL":domainModel.StateId.ToString(),
                    domainModel.AdresId
                );
        }

        public string GetQueryDelete(object id)
        {
            return String.Format(_queryDelete, (int)id);
        }

        public string GetQueryGetById(object id)
        {
            return String.Format(_queryGetById, (int)id);
        }


        private string _queryGetAll = "EXEC dbo.GetAllOrder";
        private string _querySave = "EXEC dbo.SaveOrder @Id = {0}, @Data = {1}, @CartId = '{2}', @StateId = {3}, @AdresId = {4}";
        private string _queryDelete = "EXEC dbo.DeleteOrder @Id={0}";
        private string _queryGetById = "EXEC dbo.GetByIdOrder @Id={0}";


    }
}