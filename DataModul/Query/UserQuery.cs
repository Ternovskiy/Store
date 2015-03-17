using DataModul.IQuery;

namespace DataModul.Query
{
    public class UserQuery:UserBaseQuery,IUserQuery
    {
        public UserQuery(string connectionString) : base(connectionString)
        {
        }

        public string GetQueryUserRole(string id)
        {
            return string.Format(qGetUserRole, id);
        }

        public string GetQueryDeleteUserRole(string userId, string roleId)
        {
            return string.Format(qDeleteUserRole, userId, roleId);
        }

        public string GetQuerySetUserRole(string userId, string roleId)
        {
            return string.Format(qSaveUserRole, userId, roleId);
        }

        string qGetUserRole = "EXEC dbo.GetUserRole @Id='{0}'";
        string qSaveUserRole = "EXEC dbo.SaveUserRole @IdUser='{0}', @IdRole='{1}'";
        string qDeleteUserRole = "EXEC dbo.DeleteUserRole @IdUser='{0}', @IdRole='{1}'";

    }
}