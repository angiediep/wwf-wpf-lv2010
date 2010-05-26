
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Text;
using System.Data.SqlClient;
using System.IO;
using DTO;
namespace DAO
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
         get {return "your connection here";} 
    }

}
}
