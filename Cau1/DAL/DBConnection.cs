using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cau1.DAL
{
    public class DBConnection
    {
        public DBConnection()
        {

        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=HR;User Id=sa;Password=sa"
            };
            return conn;
        }
    }
}
