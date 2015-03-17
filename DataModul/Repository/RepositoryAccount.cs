using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryAccount:Repository<Accounts>,IRepositoryAccount
    {
        public RepositoryAccount(IAccountQuery accountQuery, Logger logger) : base(accountQuery, logger)
        {
            AccountQuery = accountQuery;
        }

        public RepositoryAccount(IAccountQuery accountQuery) : base(accountQuery)
        {
            AccountQuery = accountQuery;
        }

        public IAccountQuery AccountQuery { get; set; }
    }
}