
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace DataLayer.DAO
{
    public static class DataConnector
    {

        public static string getConnectionString()
        {
            return "Data Source=NMBINH\\SQLEXPRESS;Initial Catalog=QuyTrinhThiDB;Integrated Security=True;User ID=sa;Password=123456";
        }
       
    }
}
