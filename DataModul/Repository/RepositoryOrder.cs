using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryOrder:Repository<Order>,IRepositoryOrder
    {
        public RepositoryOrder(IOrderQuery orderQuery, Logger logger)
            : base(orderQuery, logger)
        {
            OrderQuery = orderQuery;
        }

        public RepositoryOrder(IOrderQuery orderQuery)
            : base(orderQuery)
        {

            OrderQuery = orderQuery;
        }

        public IOrderQuery OrderQuery { get; set; }
    }
}