using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.IQuery
{
    public interface IUserQuery:IBaseQuery<User>
    {
        string GetQueryUserRole(string id);
        string GetQueryDeleteUserRole(string userId, string roleId);
        string GetQuerySetUserRole(string userId, string roleId);
    }
}