using DataModul.IQuery;

namespace DataModul.Query
{
    public class CategoryQuery:CategoryBaseQuery,ICategoryQuery
    {
        public CategoryQuery(string connectionString) : base(connectionString)
        {
        }
    }
}