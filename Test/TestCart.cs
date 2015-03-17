using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using DataModul.Repository;
using NUnit.Framework;

namespace Test
{
    /*
    [TestFixture]
    class TestCart
    {
        //string constr = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=D:\Cloud@Mail.Ru\Store\Store\App_Data\StoreDataBase.mdf;Initial Catalog=StoreDataBase;Integrated Security=True";
        private string constr =@"Data Source=(LocalDb)\v11.0;AttachDbFilename=D:\Cloud@Mail.Ru\Store\Store\App_Data\StoreDataBase.mdf;Initial Catalog=StoreDataBase;Integrated Security=True";
        private string userID = "55dbdac2-a3c2-4b02-91b2-fec6f3106456";
        private int prodId = 2;

        [Test]
        public void TestSave()
        {
            var cart = new Cart()
            {
                Bought = false,
                Count = 1,
                ProductId = prodId,
                UserId = userID
            };
            var repository = new Repository<Cart>(constr);
            repository.Save(cart);
        }


        [Test]
        public void TestGet()
        {
            var repository = new Repository<Cart>(constr);
            var m = repository.GetAll();
            foreach (Cart cart in m)
            {
                Console.WriteLine(cart.Id);
            }
        }
    }
    */
}
