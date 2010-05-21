
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
public class DaoDOTTHI
{

	public DaoDOTTHI()
	{
	}
	#region "ExportFile" 
	public DtoDOTTHI getDataById(int maDT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoDOTTHI data = null;
        while (dr.Read())
        {
            data = new DtoDOTTHI();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MALOAICC =Convert.ToInt32(dr["maLoaiCC"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
			data.SOLUONGTHISINH =Convert.ToInt32(dr["soLuongThiSinh"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoDOTTHI>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDOTTHI> lst = new List<DtoDOTTHI>();
        DtoDOTTHI data = null;
        while (dr.Read())
        {
            data = new DtoDOTTHI();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MALOAICC =Convert.ToInt32(dr["maLoaiCC"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
			data.SOLUONGTHISINH =Convert.ToInt32(dr["soLuongThiSinh"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoDOTTHI>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataDOTTHISortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDOTTHI> lst = new List<DtoDOTTHI>();
        DtoDOTTHI data = null;
        while (dr.Read())
        {
            data = new DtoDOTTHI();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MALOAICC =Convert.ToInt32(dr["maLoaiCC"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
			data.SOLUONGTHISINH =Convert.ToInt32(dr["soLuongThiSinh"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoDOTTHI> getListDataBymaLoaiCC(int maLoaiCC)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHIBymaLoaiCC " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maLoaiCC", maLoaiCC);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDOTTHI> lst = new List<DtoDOTTHI>();
        DtoDOTTHI data = null;
        while (dr.Read())
        {
            data = new DtoDOTTHI();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MALOAICC =Convert.ToInt32(dr["maLoaiCC"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoDOTTHI> getListDataByngayThi(DateTime ngayThi)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHIByngayThi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayThi", ngayThi);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDOTTHI> lst = new List<DtoDOTTHI>();
        DtoDOTTHI data = null;
        while (dr.Read())
        {
            data = new DtoDOTTHI();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MALOAICC =Convert.ToInt32(dr["maLoaiCC"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoDOTTHI data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maLoaiCC", data.MALOAICC);
		cmd.Parameters.AddWithValue("@ngayThi", data.NGAYTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoDOTTHI data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymaLoaiCC(int maLoaiCC)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIBymaLoaiCC " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maLoaiCC", maLoaiCC);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayThi(DateTime ngayThi)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIByngayThi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayThi", ngayThi);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBysoLuongThiSinh(int soLuongThiSinh)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIBysoLuongThiSinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@soLuongThiSinh", soLuongThiSinh);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoDOTTHI data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maLoaiCC", data.MALOAICC);
		cmd.Parameters.AddWithValue("@ngayThi", data.NGAYTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaDT(DtoDOTTHI data,int maDT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHIBymaDT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maLoaiCC", data.MALOAICC);
		cmd.Parameters.AddWithValue("@ngayThi", data.NGAYTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
		cmd.Parameters.AddWithValue("@maDT",maDT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaLoaiCC(DtoDOTTHI data,int maLoaiCC)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHIBymaLoaiCC " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@ngayThi", data.NGAYTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
		cmd.Parameters.AddWithValue("@maLoaiCC",maLoaiCC);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayThi(DtoDOTTHI data,DateTime ngayThi)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHIByngayThi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maLoaiCC", data.MALOAICC);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
		cmd.Parameters.AddWithValue("@ngayThi",ngayThi);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
