using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.IRepository;
using NLog;

namespace DataModul.Repository
{
    public class RepositoryState:Repository<State>,IRepositoryState
    {
        public RepositoryState(IStateQuery stateQuery, Logger logger)
            : base(stateQuery, logger)
        {
            StateQuery = stateQuery;
        }

        public RepositoryState(IStateQuery stateQuery)
            : base(stateQuery)
        {
            StateQuery = stateQuery;
        }

        public IStateQuery StateQuery { get; set; }
    }
}