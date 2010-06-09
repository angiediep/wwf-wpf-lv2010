
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
	public DtoDotThi getDataById(int maDT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoDotThi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.TENDOTTHI =Convert.ToString(dr["tenDotThi"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
			data.SOLUONGTHISINH =Convert.ToInt32(dr["soLuongThiSinh"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
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
	public List<DtoDotThi>  getDataList()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = new List<DtoDotThi>();
        DtoDotThi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.TENDOTTHI =Convert.ToString(dr["tenDotThi"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
			data.SOLUONGTHISINH =Convert.ToInt32(dr["soLuongThiSinh"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoDotThi>  getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataDOTTHISortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = new List<DtoDotThi>();
        DtoDotThi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.TENDOTTHI =Convert.ToString(dr["tenDotThi"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
			data.SOLUONGTHISINH =Convert.ToInt32(dr["soLuongThiSinh"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoDotThi> getListDataBytenDotThi(string tenDotThi)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHIBytenDotThi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDotThi", tenDotThi);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = new List<DtoDotThi>();
        DtoDotThi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.TENDOTTHI =Convert.ToString(dr["tenDotThi"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoDotThi> getListDataByngayThi(DateTime ngayThi)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHIByngayThi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayThi", ngayThi);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = new List<DtoDotThi>();
        DtoDotThi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi();
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.TENDOTTHI =Convert.ToString(dr["tenDotThi"]);
			data.NGAYTHI =Convert.ToDateTime(dr["ngayThi"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoDotThi data)
    {
        DataConnector dc = new DataConnector(); 
        string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_themDotThi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDT", data.TENDOTTHI);
		cmd.Parameters.AddWithValue("@ngayThi", data.NGAYTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        cmd.Parameters.Add("@kq", SqlDbType.Int);
        cmd.Parameters["@kq"].Direction = ParameterDirection.Output;

        con.Open();
        cmd.ExecuteNonQuery();
        int result = int.Parse(cmd.Parameters["@kq"].Value.ToString());
        con.Close();
        return result;

    }
	public bool deleteData(DtoDotThi data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBytenDotThi(string tenDotThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIBytenDotThi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDotThi", tenDotThi);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayThi(DateTime ngayThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIBysoLuongThiSinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@soLuongThiSinh", soLuongThiSinh);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoDotThi data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHI " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@tenDotThi", data.TENDOTTHI);
		cmd.Parameters.AddWithValue("@ngayThi", data.NGAYTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaDT(DtoDotThi data,int maDT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHIBymaDT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDotThi", data.TENDOTTHI);
		cmd.Parameters.AddWithValue("@ngayThi", data.NGAYTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
		cmd.Parameters.AddWithValue("@maDT",maDT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenDotThi(DtoDotThi data,string tenDotThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHIBytenDotThi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@ngayThi", data.NGAYTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
		cmd.Parameters.AddWithValue("@tenDotThi",tenDotThi);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayThi(DtoDotThi data,DateTime ngayThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHIByngayThi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@tenDotThi", data.TENDOTTHI);
		cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
		cmd.Parameters.AddWithValue("@ngayThi",ngayThi);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
