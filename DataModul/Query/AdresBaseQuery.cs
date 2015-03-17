using System;
using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.Query
{
    public class AdresBaseQuery:ConnectQuery,IBaseQuery<Adres>
    {
        public AdresBaseQuery(string connectionString) : base(connectionString)
        {
        }

        public string QueryGetAll { get { return _queryGetAll; } }
        public string QuerySave { get { return _querySave; } }
        public string QueryDelete { get { return _queryDelete; } }
        public string QueryGetById { get { return _queryGetById; } }
        
        public string GetQuerySave(Adres domainModel)
        {
            return String.Format(_querySave,
                domainModel.AdresId==0?"NULL":domainModel.AdresId.ToString(),
                domainModel.AdresString
                );
        }

        public string GetQueryDelete(object id)
        {
            return String.Format(_queryDelete, (int)id);
        }

        public string GetQueryGetById(object id)
        {
            return String.Format(_queryGetById, (int)id);
        }


        private string _queryGetAll = "EXEC dbo.GetAllAdres";
        private string _querySave = "EXEC SaveAdres @Id = {0}, @AdresString = '{1}'";
        private string _queryDelete = "EXEC DeleteAdres @Id={0}";
        private string _queryGetById = "EXEC GetByIdAdres @Id={0}"; 
    }
}