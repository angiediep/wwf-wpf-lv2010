
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
	public DtoPhanCong getDataById(int maCV)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoPhanCong data = null;
        while (dr.Read())
        {
            data = new DtoPhanCong();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.NGAYAPDUNG =Convert.ToDateTime(dr["ngayApDung"]);
			data.NGAYHETHAN =Convert.ToDateTime(dr["ngayHetHan"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.NGAYAPDUNG =Convert.ToDateTime(dr["ngayApDung"]);
			data.NGAYHETHAN =Convert.ToDateTime(dr["ngayHetHan"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoPhanCong>  getDataListSortBy(string col, bool flag)
    {
        string conStr = DataConnector.getConnectionString();
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
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.NGAYAPDUNG =Convert.ToDateTime(dr["ngayApDung"]);
			data.NGAYHETHAN =Convert.ToDateTime(dr["ngayHetHan"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoPhanCong> getListDataBymaNV(int maNV)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataPhanCongBymaNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoPhanCong> lst = new List<DtoPhanCong>();
        DtoPhanCong data = null;
        while (dr.Read())
        {
            data = new DtoPhanCong();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.NGAYAPDUNG =Convert.ToDateTime(dr["ngayApDung"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoPhanCong> getListDataByngayApDung(DateTime ngayApDung)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataPhanCongByngayApDung " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayApDung", ngayApDung);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoPhanCong> lst = new List<DtoPhanCong>();
        DtoPhanCong data = null;
        while (dr.Read())
        {
            data = new DtoPhanCong();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.NGAYAPDUNG =Convert.ToDateTime(dr["ngayApDung"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoPhanCong data)
    {
        int Id = -1;
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@ngayApDung", data.NGAYAPDUNG);
		cmd.Parameters.AddWithValue("@ngayHetHan", data.NGAYHETHAN);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoPhanCong data)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", data.MACV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymaNV(int maNV)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCongBymaNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayApDung(DateTime ngayApDung)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCongByngayApDung " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayApDung", ngayApDung);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayHetHan(DateTime ngayHetHan)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCongByngayHetHan " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayHetHan", ngayHetHan);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoPhanCong data)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCong " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@ngayApDung", data.NGAYAPDUNG);
		cmd.Parameters.AddWithValue("@ngayHetHan", data.NGAYHETHAN);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaCV(DtoPhanCong data,int maCV)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCongBymaCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@ngayApDung", data.NGAYAPDUNG);
		cmd.Parameters.AddWithValue("@ngayHetHan", data.NGAYHETHAN);
		cmd.Parameters.AddWithValue("@maCV",maCV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaNV(DtoPhanCong data,int maNV)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCongBymaNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@ngayApDung", data.NGAYAPDUNG);
		cmd.Parameters.AddWithValue("@ngayHetHan", data.NGAYHETHAN);
		cmd.Parameters.AddWithValue("@maNV",maNV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayApDung(DtoPhanCong data,DateTime ngayApDung)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCongByngayApDung " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@ngayHetHan", data.NGAYHETHAN);
		cmd.Parameters.AddWithValue("@ngayApDung",ngayApDung);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}