using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryImage:Repository<Image>,IRepositoryImage
    {
        public RepositoryImage(IImageQuery imageQuery, Logger logger)
            : base(imageQuery, logger)
        {
            ImageQuery = imageQuery;
        }

        public RepositoryImage(IImageQuery imageQuery)
            : base(imageQuery)
        {
            ImageQuery = imageQuery;
        }

        public IImageQuery ImageQuery { get; set; }
    }
}