using System.Collections.Generic;
using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.ViewModel;

namespace DataModul.IRepository
{
    public interface IRepositoryUser:IRepository<User>
    {
        IUserQuery UserQuery { get; set; }

        IEnumerable<UserRole> GetUserRole(string id);
        bool SetUserRole(string userId, string roleId);
        bool RemoveUserRole(string userId, string roleId);
    }
}