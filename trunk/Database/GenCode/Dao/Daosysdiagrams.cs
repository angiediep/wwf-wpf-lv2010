
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
public class Daosysdiagrams
{

	public Daosysdiagrams()
	{
	}
	#region "ExportFile" 
	public Dtosysdiagrams getDataById(string name)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDatasysdiagrams " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", name);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        Dtosysdiagrams data = null;
        while (dr.Read())
        {
            data = new Dtosysdiagrams();
			data.NAME =Convert.ToString(dr["name"]);
			data.PRINCIPAL_ID =Convert.ToInt32(dr["principal_id"]);
			data.DIAGRAM_ID =Convert.ToInt32(dr["diagram_id"]);
			data.VERSION =Convert.ToInt32(dr["version"]);
			data.DEFINITION =Convert.ToByte[](dr["definition"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDatasysdiagrams " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<Dtosysdiagrams>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDatasysdiagrams " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<Dtosysdiagrams> lst = new List<Dtosysdiagrams>();
        Dtosysdiagrams data = null;
        while (dr.Read())
        {
            data = new Dtosysdiagrams();
			data.NAME =Convert.ToString(dr["name"]);
			data.PRINCIPAL_ID =Convert.ToInt32(dr["principal_id"]);
			data.DIAGRAM_ID =Convert.ToInt32(dr["diagram_id"]);
			data.VERSION =Convert.ToInt32(dr["version"]);
			data.DEFINITION =Convert.ToByte[](dr["definition"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<Dtosysdiagrams>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDatasysdiagramsSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<Dtosysdiagrams> lst = new List<Dtosysdiagrams>();
        Dtosysdiagrams data = null;
        while (dr.Read())
        {
            data = new Dtosysdiagrams();
			data.NAME =Convert.ToString(dr["name"]);
			data.PRINCIPAL_ID =Convert.ToInt32(dr["principal_id"]);
			data.DIAGRAM_ID =Convert.ToInt32(dr["diagram_id"]);
			data.VERSION =Convert.ToInt32(dr["version"]);
			data.DEFINITION =Convert.ToByte[](dr["definition"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<Dtosysdiagrams> getListDataByprincipal_id(int principal_id)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDatasysdiagramsByprincipal_id " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@principal_id", principal_id);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<Dtosysdiagrams> lst = new List<Dtosysdiagrams>();
        Dtosysdiagrams data = null;
        while (dr.Read())
        {
            data = new Dtosysdiagrams();
			data.NAME =Convert.ToString(dr["name"]);
			data.PRINCIPAL_ID =Convert.ToInt32(dr["principal_id"]);
			data.DIAGRAM_ID =Convert.ToInt32(dr["diagram_id"]);
			data.VERSION =Convert.ToInt32(dr["version"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<Dtosysdiagrams> getListDataBydiagram_id(int diagram_id)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDatasysdiagramsBydiagram_id " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@diagram_id", diagram_id);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<Dtosysdiagrams> lst = new List<Dtosysdiagrams>();
        Dtosysdiagrams data = null;
        while (dr.Read())
        {
            data = new Dtosysdiagrams();
			data.NAME =Convert.ToString(dr["name"]);
			data.PRINCIPAL_ID =Convert.ToInt32(dr["principal_id"]);
			data.DIAGRAM_ID =Convert.ToInt32(dr["diagram_id"]);
			data.VERSION =Convert.ToInt32(dr["version"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<Dtosysdiagrams> getListDataByversion(int version)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDatasysdiagramsByversion " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@version", version);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<Dtosysdiagrams> lst = new List<Dtosysdiagrams>();
        Dtosysdiagrams data = null;
        while (dr.Read())
        {
            data = new Dtosysdiagrams();
			data.NAME =Convert.ToString(dr["name"]);
			data.PRINCIPAL_ID =Convert.ToInt32(dr["principal_id"]);
			data.DIAGRAM_ID =Convert.ToInt32(dr["diagram_id"]);
			data.VERSION =Convert.ToInt32(dr["version"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(Dtosysdiagrams data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDatasysdiagrams " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@principal_id", data.PRINCIPAL_ID);
		cmd.Parameters.AddWithValue("@diagram_id", data.DIAGRAM_ID);
		cmd.Parameters.AddWithValue("@version", data.VERSION);
		cmd.Parameters.AddWithValue("@definition", data.DEFINITION);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(Dtosysdiagrams data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDatasysdiagrams " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", data.NAME);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByprincipal_id(int principal_id)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDatasysdiagramsByprincipal_id " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@principal_id", principal_id);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBydiagram_id(int diagram_id)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDatasysdiagramsBydiagram_id " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@diagram_id", diagram_id);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByversion(int version)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDatasysdiagramsByversion " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@version", version);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBydefinition(System.Byte[] definition)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDatasysdiagramsBydefinition " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@definition", definition);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(Dtosysdiagrams data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDatasysdiagrams " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@name", data.NAME);
		cmd.Parameters.AddWithValue("@principal_id", data.PRINCIPAL_ID);
		cmd.Parameters.AddWithValue("@diagram_id", data.DIAGRAM_ID);
		cmd.Parameters.AddWithValue("@version", data.VERSION);
		cmd.Parameters.AddWithValue("@definition", data.DEFINITION);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByname(Dtosysdiagrams data,string name)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDatasysdiagramsByname " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@principal_id", data.PRINCIPAL_ID);
		cmd.Parameters.AddWithValue("@diagram_id", data.DIAGRAM_ID);
		cmd.Parameters.AddWithValue("@version", data.VERSION);
		cmd.Parameters.AddWithValue("@definition", data.DEFINITION);
		cmd.Parameters.AddWithValue("@name",name);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByprincipal_id(Dtosysdiagrams data,int principal_id)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDatasysdiagramsByprincipal_id " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@name", data.NAME);
		cmd.Parameters.AddWithValue("@diagram_id", data.DIAGRAM_ID);
		cmd.Parameters.AddWithValue("@version", data.VERSION);
		cmd.Parameters.AddWithValue("@definition", data.DEFINITION);
		cmd.Parameters.AddWithValue("@principal_id",principal_id);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBydiagram_id(Dtosysdiagrams data,int diagram_id)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDatasysdiagramsBydiagram_id " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@name", data.NAME);
		cmd.Parameters.AddWithValue("@principal_id", data.PRINCIPAL_ID);
		cmd.Parameters.AddWithValue("@version", data.VERSION);
		cmd.Parameters.AddWithValue("@definition", data.DEFINITION);
		cmd.Parameters.AddWithValue("@diagram_id",diagram_id);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByversion(Dtosysdiagrams data,int version)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDatasysdiagramsByversion " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@name", data.NAME);
		cmd.Parameters.AddWithValue("@principal_id", data.PRINCIPAL_ID);
		cmd.Parameters.AddWithValue("@diagram_id", data.DIAGRAM_ID);
		cmd.Parameters.AddWithValue("@definition", data.DEFINITION);
		cmd.Parameters.AddWithValue("@version",version);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
