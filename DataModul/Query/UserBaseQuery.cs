using System;
using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.Query
{
    public class UserBaseQuery:ConnectQuery, IBaseQuery<User>
    {
        public UserBaseQuery(string connectionString) : base(connectionString)
        {
        }

        public string QueryGetAll { get { return _queryGetAll; } }
        public string QuerySave { get { return _querySave; } }
        public string QueryDelete { get { return _queryDelete; } }
        public string QueryGetById { get { return _queryGetById; } }
        public string GetQuerySave(User domainModel)
        {
            return String.Format(_querySave,
                domainModel.Id==""?"NULL":domainModel.Id,
                domainModel.UserName
                );
        }

        public string GetQueryDelete(object id)
        {
            return string.Format(_queryDelete, id);
        }

        public string GetQueryGetById(object id)
        {
            return String.Format(_queryGetById, id);
        }

        static private string _queryGetAll = "EXEC dbo.GetAllUser";
        static private string _querySave = "EXEC dbo.SaveUser @Id = '{0}', @UserName = '{1}'";
        static private string _queryDelete = "EXEC dbo.DeleteUser @Id='{0}'";
        static private string _queryGetById = "EXEC dbo.GetUserById @Id='{0}'";
        
    }
}