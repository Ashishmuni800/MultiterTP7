using System;
using Microsoft.Data.SqlClient;
using CommonLayer.Models;
namespace DataAccessLayer
{
    public class DbConnection
    {
        public SqlConnection cnn;
        public DbConnection()
        {
            cnn = new SqlConnection(Connection.connectionStr);
        }
    }
}
