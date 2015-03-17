using System;
using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.Query
{
    public class AccountBaseQuery:ConnectQuery,IBaseQuery<Accounts>
    {
        public AccountBaseQuery(string connectionString) : base(connectionString)
        {
        }

        public string QueryGetAll { get { return _queryGetAll; } }
        public string QuerySave { get { return _querySave; } }
        public string QueryDelete { get { return _queryDelete; } }
        public string QueryGetById { get { return _queryGetById; } }


        public string GetQuerySave(Accounts domainModel)
        {
            return String.Format(_querySave,
                domainModel.AccountId == 0 ? "NULL" : domainModel.AccountId.ToString(),
                domainModel.Account,
                domainModel.Description,
                domainModel.StateId,
                domainModel.UserId
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


        private string _queryGetAll = "EXEC dbo.GetAllAccount";
        private string _querySave = "EXEC dbo.SaveAccount @Id = {0}, @Account = '{1}', @Description='{2}', @StateId={3},UserId='{4}'";
        private string _queryDelete = "EXEC dbo.DeleteAccount @Id={0}";
        private string _queryGetById = "EXEC dbo.GetByIdAccount @Id={0}"; 
    }
}