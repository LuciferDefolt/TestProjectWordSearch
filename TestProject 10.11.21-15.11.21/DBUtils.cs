using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace TestProject_10._11._21_15._11._21
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()// підключення до БД
        {
            string host = "localhost";
            int port = 3306;
            string database = "TestProject";
            string username = "root";
            string password = "root";
            return DBMySQLUtils.GetMySqlConnection(host, port, database, username, password);
        }

    }
}