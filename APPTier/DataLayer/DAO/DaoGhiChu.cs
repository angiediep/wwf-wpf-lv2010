
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
public class DaoGhiChu
{

	public DaoGhiChu()
	{
	}
	#region "ExportFile" 
	public DtoGhiChu getDataById(int maTD)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataGhiChu " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", maTD);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoGhiChu data = null;
        while (dr.Read())
        {
            data = new DtoGhiChu();
			data.MATD =Convert.ToInt32(dr["maTD"]);
			data.GHICHU =Convert.ToString(dr["GhiChu"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataGhiChu " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoGhiChu>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataGhiChu " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoGhiChu> lst = new List<DtoGhiChu>();
        DtoGhiChu data = null;
        while (dr.Read())
        {
            data = new DtoGhiChu();
			data.MATD =Convert.ToInt32(dr["maTD"]);
			data.GHICHU =Convert.ToString(dr["GhiChu"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoGhiChu>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataGhiChuSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoGhiChu> lst = new List<DtoGhiChu>();
        DtoGhiChu data = null;
        while (dr.Read())
        {
            data = new DtoGhiChu();
			data.MATD =Convert.ToInt32(dr["maTD"]);
			data.GHICHU =Convert.ToString(dr["GhiChu"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public int insertData(DtoGhiChu data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataGhiChu " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@GhiChu", data.GHICHU);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoGhiChu data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataGhiChu " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", data.MATD);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByGhiChu(string GhiChu)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataGhiChuByGhiChu " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GhiChu", GhiChu);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoGhiChu data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataGhiChu " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@GhiChu", data.GHICHU);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaTD(DtoGhiChu data,int maTD)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataGhiChuBymaTD " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@GhiChu", data.GHICHU);
		cmd.Parameters.AddWithValue("@maTD",maTD);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
