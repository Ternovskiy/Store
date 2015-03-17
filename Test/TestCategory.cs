using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using NUnit.Framework;

namespace Test
{/*
    [TestFixture]
    class TestCategory
    {
        string constr=@"Data Source=(LocalDb)\v11.0;AttachDbFilename=D:\Cloud@Mail.Ru\Store\Store\App_Data\StoreDataBase.mdf;Initial Catalog=StoreDataBase;Integrated Security=True";

        private string name = "sampel";
        [Test]
        public void TestCategory1()
        {
            var repository = new Repository<Category>(constr);
              var p = repository.GetAll();
            foreach (var item in p)
            {
                Console.WriteLine(item.Name);
            }
        }

        [Test]
        public void TestCategoryCreate()
        {

            var repository = new Repository<Category>(constr);
            var firstOrDefault = repository.GetAll().FirstOrDefault(p => p.Name == name);
            if (firstOrDefault != null)
            {
                var id = firstOrDefault.Id;
                repository.Delete(id);
                TestCategoryCreate();return;
            } 
            repository.Save(new Category()
            {
                Name = name
            });
            var s = repository.GetAll().Select(p=>p.Name).FirstOrDefault(p => p == name);
            Assert.AreEqual(s,name);
        }

        [Test]
        public void TestCategoryUpdata()
        {
            var repository = new Repository<Category>(constr);
            var firstOrDefault = repository.GetAll().FirstOrDefault(p => p.Name == name);
            if (firstOrDefault != null)
            {
                var id = firstOrDefault.Id;
                var name1 = "updatasample";
                repository.Save(new Category()
                {
                    Id = id,
                    Name = name1
                });

                Assert.AreEqual(name1,repository.GetById(id).Name,name1);
                repository.Save(new Category()
                {
                    Id = id,
                    Name = name
                });
                Assert.AreEqual(name, repository.GetById(id).Name, name);
            }
            else
            {
                throw new Exception("nono");
            }
            
            
        }
        
        [Test]
        public void TestCategoryDel()
        {
            var repository = new Repository<Category>(constr);
            var firstOrDefault = repository.GetAll().FirstOrDefault(p => p.Name == name);
            if (firstOrDefault != null)
            {
                var id=firstOrDefault.Id;
                repository.Delete(id);
            }
            else
            {
                throw new Exception("nono");
            }
            firstOrDefault = repository.GetAll().FirstOrDefault(p => p.Name == name);
            Assert.AreEqual(firstOrDefault,null);
        }

        
    }
  
  */
}
