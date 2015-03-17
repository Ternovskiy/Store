using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryCategory:Repository<Category>,IRepositoryCategory
    {
        public RepositoryCategory(ICategoryQuery categoryQuery, Logger logger) : base(categoryQuery, logger)
        {
            CategoryQuery = categoryQuery;
        }

        public RepositoryCategory(ICategoryQuery categoryQuery): base(categoryQuery)
        {
            CategoryQuery = categoryQuery;
        }

        public ICategoryQuery CategoryQuery { get; set; }
    }
}