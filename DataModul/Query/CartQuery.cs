using DataModul.DomainModel;
using DataModul.IQuery;

namespace DataModul.Query
{
    public class CartQuery:CartBaseQuery,ICartQuery
    {
        public CartQuery(string connectionString) : base(connectionString)
        {
        }
    }
}