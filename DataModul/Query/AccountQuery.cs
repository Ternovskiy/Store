using DataModul.IQuery;

namespace DataModul.Query
{
    public class AccountQuery:AccountBaseQuery,IAccountQuery
    {
        public AccountQuery(string connectionString) : base(connectionString)
        {
        }
    }
}