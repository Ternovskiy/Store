using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using NLog;

namespace DataModul.Repository
{
    public class UserRepository:BaseContext,IRepository<User>
    {
        public UserRepository(string connectionString, Logger logger) 
            : base(connectionString, logger)
        {
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> list;
            Connect.Open();
            //string sql = "SELECT * FROM [dbo].[GetAllUsers]()";
            string sql = "EXEC ProcGetAllUsers";
            using (SqlCommand cmd = new SqlCommand(sql, Connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                list = new List<User>().FromDataReader(dr).ToList(); 
                dr.Close();
            }
            Connect.Close();
            return list;
        }

        public User GetById(int id)
        {
            
            return new User() {UserName = "eeeeee"};
        }

        public void Save(User item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}