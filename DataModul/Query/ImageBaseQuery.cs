using System;
using DataModul.DomainModel;
using DataModul.Repository;

namespace DataModul.Query
{
    public class ImageBaseQuery:ConnectQuery,IBaseQuery<Image>
    {
        public ImageBaseQuery(string connectionString) : base(connectionString)
        {
        }
        public string QueryGetAll { get { return _queryGetAll; } }
        public string QuerySave { get { return _querySave; } }
        public string QueryDelete { get { return _queryDelete; } }
        public string QueryGetById { get { return _queryGetById; } }
        

        public string GetQuerySave(Image domainModel)
        {
            return String.Format(
                    _querySave,
                    (domainModel.ImageId == 0) ? "NULL" : domainModel.ImageId.ToString(),
                    domainModel.ImageData,
                    domainModel.ImageMimeType,
                    domainModel.ProductId
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


        private string _queryGetAll = "EXEC dbo.GetAllImage";
        private string _querySave = "EXEC dbo.SaveImage @Id = {0}, @ImageData = '{1}', @ImageMimeType = '{2}', @ProductId = {3}";
        private string _queryDelete = "EXEC dbo.DeleteImage @Id={0}";
        private string _queryGetById = "EXEC dbo.GetByIdImage @Id={0}"; 
    }
}