using DataModul.IQuery;

namespace DataModul.Query
{
    public class ImageQuery:ImageBaseQuery,IImageQuery
    {
        public ImageQuery(string connectionString) : base(connectionString)
        {
        }
    }
}