using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataModul.IQuery;
using DataModul.Repository;

namespace DataModul.BaseRepository
{
    public interface IBaseContextRepository : IDisposable
    {
        NLog.Logger Logger { get; set; }
        SqlConnection SqlConnection { get; set; }
        IConnectQuery ConnectQuery { get; set; }
        IEnumerable<T> GetTable<T>(string queryToSql);
        IEnumerable<T> GetTable<T>(string queryToSql, SqlParameter sqlParameter);
        IEnumerable<T> GetTable<T>(string queryToSql, SqlParameter[] sqlParameters);
        bool ExecuteNonQuery(string queryToSql);
        T GetValue<T>(string queryToSql);
    }
}