using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModul.IQuery;

namespace DataModul.Query
{
    public class ConnectQuery:IConnectQuery
    {
        public ConnectQuery(string connectionString)
        {
            _connection = connectionString;
        }

        public string ConnectinString { get { return _connection; } set { _connection = value; } }

        private string _connection = "";
    }
}
