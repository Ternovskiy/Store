using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModul.IQuery;
using DataModul.Repository;

namespace DataModul.BaseRepository
{
    public class BaseContext : IBaseContextRepository
    {
        public BaseContext(IConnectQuery connectQuery, NLog.Logger logger)
        {
            try
            {
                Logger = logger;
                SqlConnection = new SqlConnection(connectQuery.ConnectinString);
                ConnectQuery=connectQuery;
                SqlConnection.Open();
            }
            catch (Exception exception)
            {
                if (Logger != null) Logger.Fatal(exception.Message);
                throw new Exception(exception.Message);
            }
            
        }
        public BaseContext(IConnectQuery connectQuery)
        {
            try
            {
                SqlConnection = new SqlConnection(connectQuery.ConnectinString);
                ConnectQuery = connectQuery;
                SqlConnection.Open();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            
        }

        public SqlConnection SqlConnection { get; set; }

        public NLog.Logger Logger { get; set; }

        public IConnectQuery ConnectQuery { get; set; }

        public IEnumerable<T> GetTable<T>(string queryToSql)
        {
            IEnumerable<T> list;
            try
            {
                using (SqlCommand cmd = new SqlCommand(queryToSql, SqlConnection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    list = new List<T>().FromDataReader(dr).ToList();
                    dr.Close();
                }
            }
            catch (Exception e)
            {
                if (Logger != null) Logger.Info(e);
                return null;
            }
            return list;
        }

        public IEnumerable<T> GetTable<T>(string queryToSql, SqlParameter sqlParameters)
        {
            SqlParameter[] sqlParameterses=new SqlParameter[]{sqlParameters};
            return GetTable<T>(queryToSql, sqlParameterses);
        }

        public  IEnumerable<T> GetTable<T>(string queryToSql,SqlParameter[] sqlParameters)
        {
            IEnumerable<T> list;
            try
            {
                using (SqlCommand cmd = new SqlCommand(queryToSql, SqlConnection))
                {
                    if (sqlParameters != null)
                        cmd.Parameters.AddRange(sqlParameters);
                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    list = new List<T>().FromDataReader(dr).ToList();
                    dr.Close();
                }
            }
            catch (Exception e)
            {
                if (Logger != null) Logger.Info(e);
                return null;
            }

            
            return list;
        }

        public bool ExecuteNonQuery(string queryToSql)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(queryToSql, SqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                if (Logger != null) Logger.Info(e);
                return false;
            }
            return true;
        }
        public T GetValue<T>(string queryToSql)
        {
            T item = default(T);
            try
            {
                using (SqlCommand cmd = new SqlCommand(queryToSql, SqlConnection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    ////Object instance=Activator.CreateInstance(item.GetType().GetGenericArguments()[0]);
                    //Type tOb2 = item.GetType();
                    
                    //foreach (DataRow drow in dr.GetSchemaTable().Rows)
                    //{
                    //    tOb2.GetProperty(drow.ItemArray[0].ToString()).SetValue(item, dr[drow.ItemArray[0].ToString()]);
                    //}
                    //item = (T)Convert.ChangeType(item, typeof(T));

                    while (dr.Read())
                    {
                        item = (T)Convert.ChangeType(dr.GetValue(0), typeof(T));
                    }
                    dr.Close();
                }
            }
            catch (Exception e)
            {
                if (Logger != null) Logger.Info(e);
            }
            return item;
        }




        public void Dispose()
        {   //Connect.Close();
            if (SqlConnection != null)
                SqlConnection.Dispose();
        }
    }
}
