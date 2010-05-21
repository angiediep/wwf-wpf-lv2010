
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
public class DaoPhanCong
{

	public DaoPhanCong()
	{
	}
	#region "ExportFile" 
	public DtoPhanCong getDataById(int maTN)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTN", maTN);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoPhanCong data = null;
        while (dr.Read())
        {
            data = new DtoPhanCong();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoPhanCong>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoPhanCong> lst = new List<DtoPhanCong>();
        DtoPhanCong data = null;
        while (dr.Read())
        {
            data = new DtoPhanCong();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoPhanCong>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataPhanCongSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoPhanCong> lst = new List<DtoPhanCong>();
        DtoPhanCong data = null;
        while (dr.Read())
        {
            data = new DtoPhanCong();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public int insertData(DtoPhanCong data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoPhanCong data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTN", data.MATN);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymaNV(int maNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCongBymaNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoPhanCong data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTN", data.MATN);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaTN(DtoPhanCong data,int maTN)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCongBymaTN " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@maTN",maTN);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
