
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
public class DaoDotThi_ChungChi
{

	public DaoDotThi_ChungChi()
	{
	}
	#region "ExportFile" 
	public DtoDotThi_ChungChi getDataById(int maDT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataDotThi_ChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoDotThi_ChungChi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi_ChungChi();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MACC =Convert.ToInt32(dr["maCC"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDotThi_ChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoDotThi_ChungChi>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDotThi_ChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi_ChungChi> lst = new List<DtoDotThi_ChungChi>();
        DtoDotThi_ChungChi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi_ChungChi();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MACC =Convert.ToInt32(dr["maCC"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoDotThi_ChungChi>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataDotThi_ChungChiSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi_ChungChi> lst = new List<DtoDotThi_ChungChi>();
        DtoDotThi_ChungChi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi_ChungChi();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MACC =Convert.ToInt32(dr["maCC"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public int insertData(DtoDotThi_ChungChi data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataDotThi_ChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCC", data.MACC);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoDotThi_ChungChi data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDotThi_ChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymaCC(int maCC)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDotThi_ChungChiBymaCC " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCC", maCC);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoDotThi_ChungChi data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDotThi_ChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCC", data.MACC);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaDT(DtoDotThi_ChungChi data,int maDT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDotThi_ChungChiBymaDT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCC", data.MACC);
		cmd.Parameters.AddWithValue("@maDT",maDT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
