
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Text;
using System.Data.SqlClient;
using System.IO;
using DataLayer.DTO;

namespace DataLayer.DAO
{
public class Config
{

    public Config()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string CONSTRING
    {
        get { return "Data Source=DHA-PC\\SQLEXPRESS;Initial Catalog=QuyTrinhThiDB;Integrated Security=True";} 
    }

}
}
