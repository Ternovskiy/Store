using System.Collections.Generic;
using System.Linq;
using DataModul.BaseRepository;
using DataModul.IRepository;
using NLog;

namespace DataModul.Repository
{
    public class Repository<T>:BaseContext, IRepository<T>
        where T:class 
    {
        public Repository(IBaseQuery<T> baseQuery, Logger logger) : base(baseQuery, logger)
        {
            BaseQuery = baseQuery;
        }
        public Repository(IBaseQuery<T> baseQuery)
            : base(baseQuery)
        {
            BaseQuery = baseQuery;
        }

        public IBaseQuery<T> BaseQuery { get; set; }
        public IEnumerable<T> GetAll()
        {
            return GetTable<T>(BaseQuery.QueryGetAll);
        }

        public T GetById(object id)
        {
            var q = BaseQuery.GetQueryGetById(id);
            var r = GetTable<T>(q);
            return r.Any() ?r.First() :null;
            //return GetValue<T>(BaseQuery.GetQueryGetById(id));
        }

        public bool Save(T item)
        {
            //GetTable<T>(BaseQuery.GetQuerySave(item));
            return ExecuteNonQuery(BaseQuery.GetQuerySave(item));
        }

        
        public bool Delete(object id)
        {
            //GetTable<T>(string.Format(t.QueryDelete, id), t.GetIdSqlParameter(id));
            //GetTable<T>(BaseQuery.GetQueryDelete(id));
            return ExecuteNonQuery(BaseQuery.GetQueryDelete(id));
        }
    }
}