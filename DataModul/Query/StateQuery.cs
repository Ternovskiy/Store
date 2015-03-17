using DataModul.IQuery;

namespace DataModul.Query
{
    public class StateQuery:StateBaseQuery,IStateQuery
    {
        public StateQuery(string connectionString) : base(connectionString)
        {
        }
    }
}