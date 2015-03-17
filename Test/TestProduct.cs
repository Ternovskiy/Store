using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using DataModul.IQuery;
using DataModul.Query;
using DataModul.Repository;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    class TestProduct
    {
        string constr = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=D:\Cloud@Mail.Ru\Store\Store\App_Data\StoreDataBase.mdf;Initial Catalog=StoreDataBase;Integrated Security=True";
        private string userID = "55dbdac2-a3c2-4b02-91b2-fec6f3106456";
        [Test]
        public void GetAll()
        {
            IProductQuery query=new ProductQuery(constr);
            IRepositoryProduct repository = new RepositoryProduct(query);
            var p = repository.GetAll();
            foreach (Product product in p)
            {
                Console.WriteLine(product.Name);
            }
        }


        [Test]
        public void GetById()
        {
            IProductQuery query = new ProductQuery(constr);
            IRepositoryProduct repository = new RepositoryProduct(query);
            var p = repository.GetById(13);
            Console.WriteLine(p.ProductId);
            Console.WriteLine(p.Name);
        }

        [Test]
        public void GetBySave()
        {
            IProductQuery query = new ProductQuery(constr);
            IRepositoryProduct repository = new RepositoryProduct(query);

            var pr = new Product()
            {
                Name = "Mytest",
                Price = 15,
                UserSellerID = userID,
                StateId = 1
            };
            
            Console.WriteLine(
            repository.Save(pr)
            );
        }
        [Test]
        public void GetDelete()
        {
            IProductQuery query = new ProductQuery(constr);
            IRepositoryProduct repository = new RepositoryProduct(query);
            
            Console.WriteLine(
            repository.Delete(48)
            );
        }

    }
}
