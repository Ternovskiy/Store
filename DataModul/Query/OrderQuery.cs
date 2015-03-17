using DataModul.IQuery;

namespace DataModul.Query
{
    public class OrderQuery:OrderBaseQuery,IOrderQuery
    {
        public OrderQuery(string connectionString) : base(connectionString)
        {
        }
    }
}