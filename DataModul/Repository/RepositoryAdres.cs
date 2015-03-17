using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryAdres:Repository<Adres>,IRepositoryAdres
    {
        public RepositoryAdres(IAdresQuery adresQuery, Logger logger)
            : base(adresQuery, logger)
        {
            AdresQuery = adresQuery;
        }

        public RepositoryAdres(IAdresQuery adresQuery)
            : base(adresQuery)
        {
            AdresQuery = adresQuery;
        }

        public IAdresQuery AdresQuery { get; set; }
    }
}