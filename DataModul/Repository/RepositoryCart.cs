using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryCart:Repository<Cart>,IRepositoryCart
    {
        public RepositoryCart(ICartQuery cartQuery, Logger logger)
            : base(cartQuery, logger)
        {
            CartQuery = cartQuery;
        }

        public RepositoryCart(ICartQuery cartQuery): base(cartQuery)
        {
            CartQuery = cartQuery;
        }

        public ICartQuery CartQuery { get; set; }
    }
}