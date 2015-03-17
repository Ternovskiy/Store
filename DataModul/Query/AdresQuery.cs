using DataModul.IQuery;

namespace DataModul.Query
{
    public class AdresQuery:AdresBaseQuery,IAdresQuery
    {
        public AdresQuery(string connectionString) : base(connectionString)
        {
        }
    }
}