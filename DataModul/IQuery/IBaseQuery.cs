using DataModul.IQuery;

namespace DataModul.Repository
{
    public interface IBaseQuery<T>:IConnectQuery
       where T:class 
    {

        string QueryGetAll { get; }

        string QuerySave { get; }

        string QueryDelete { get; }

        string QueryGetById { get; }

        string GetQuerySave(T domainModel);
        string GetQueryDelete(object id);
        string GetQueryGetById(object id);

    }
}