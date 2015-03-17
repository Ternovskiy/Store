using System;
using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.Query
{
    public class StateBaseQuery:ConnectQuery,IBaseQuery<State>
    {
        public StateBaseQuery(string connectionString) : base(connectionString)
        {
        }

        public string QueryGetAll { get { return _queryGetAll; } }
        public string QuerySave { get { return _querySave; } }
        public string QueryDelete { get { return _queryDelete; } }
        public string QueryGetById { get { return _queryGetById; } }


        public string GetQuerySave(State domainModel)
        {
            return String.Format(
                    _querySave,
                    (domainModel.StateId == 0) ? "NULL" : domainModel.StateId.ToString(),
                    domainModel.Name,
                    domainModel.Description ?? "NULL"
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

        static private string _queryGetAll = "EXEC dbo.GetAllState";
        static private string _querySave = "EXEC dbo.SaveState @Id = {0}, @Name = {1}, @Description ={2}";
        static private string _queryDelete = "EXEC dbo.DeleteState @Id={0}";
        static private string _queryGetById = "EXEC dbo.GetByIdState @Id={0}";
    }
}