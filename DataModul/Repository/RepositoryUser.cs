using System.Collections.Generic;
using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using DataModul.ViewModel;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryUser:Repository<User>,IRepositoryUser
    {
        public RepositoryUser(IUserQuery userQuery, Logger logger)
            : base(userQuery, logger)
        {
            UserQuery = userQuery;
        }

        public RepositoryUser(IUserQuery userQuery)
            : base(userQuery)
        {
            UserQuery = userQuery;
        }

        public IUserQuery UserQuery { get; set; }

        public IEnumerable<UserRole> GetUserRole(string id)
        {
            return GetTable<UserRole>(UserQuery.GetQueryUserRole(id));
        }

        public bool SetUserRole(string userId, string roleId)
        {
            return ExecuteNonQuery(UserQuery.GetQuerySetUserRole(userId, roleId));
        }

        public bool RemoveUserRole(string userId, string roleId)
        {
            return ExecuteNonQuery(UserQuery.GetQueryDeleteUserRole(userId, roleId));
        }
    }
}