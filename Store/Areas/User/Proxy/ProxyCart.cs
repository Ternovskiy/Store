using System.Collections.Generic;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using DataModul.IRepository;
using Store.Areas.User.Models;

namespace Store.Areas.User.Proxy
{
    public class ProxyCart
    {
        public ProxyCart(IRepository<Cart> repository)
        {
            Repository = repository;
        }

        private string queryGetView = "EXEC ProcGetViewCart @idUser = N'{0}'";

        private string upCount = "EXEC [dbo].[ProcUpCountCart] @id ={0}";
        private string downCount = "EXEC [dbo].[ProcDownCountCart] @id ={0}";
        IRepository<Cart> Repository { get; set; }

        public IEnumerable<ViewCart> GetViewCart(string idUser)
        {
            var q = string.Format(queryGetView, idUser);
            return Repository.GetTable<ViewCart>(q);
        }

        public void UpCountCart(int id)
        {
            Repository.GetValue<int>(string.Format(upCount, id));
        }

        public void DownCountCart(int id)
        {
            Repository.GetValue<int>(string.Format(downCount, id));
        }
    }
}