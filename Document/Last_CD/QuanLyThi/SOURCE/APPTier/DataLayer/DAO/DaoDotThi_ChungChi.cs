
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
public class DaoDotThi_ChungChi
{

	public DaoDotThi_ChungChi()
	{
	}
    #region "ExportFile"
    public DtoDotThi_ChungChi getDataById(int maDT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataDotThi_ChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoDotThi_ChungChi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi_ChungChi();
            data.MADT = Convert.ToInt32(dr["maDT"]);
            data.MACC = Convert.ToInt32(dr["maCC"]);
            data.SOLUONGTHISINH = Convert.ToInt32(dr["soLuongThiSinh"]);
        }
        con.Close();
        return data;
    }
    public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDotThi_ChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
    public List<DtoDotThi_ChungChi> getDataList()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDotThi_ChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi_ChungChi> lst = new List<DtoDotThi_ChungChi>();
        DtoDotThi_ChungChi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi_ChungChi();
            data.MADT = Convert.ToInt32(dr["maDT"]);
            data.MACC = Convert.ToInt32(dr["maCC"]);
            data.SOLUONGTHISINH = Convert.ToInt32(dr["soLuongThiSinh"]);
            lst.Add(data);
        }
        con.Close();
        return lst;
    }
    public List<DtoDotThi_ChungChi> getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sp = "spGetListDataDotThi_ChungChiSortBy";
        SqlCommand cmd = new SqlCommand(sp, con);
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
            data.MADT = Convert.ToInt32(dr["maDT"]);
            data.MACC = Convert.ToInt32(dr["maCC"]);
            data.SOLUONGTHISINH = Convert.ToInt32(dr["soLuongThiSinh"]);
            lst.Add(data);
        }
        con.Close();
        return lst;
    }
    public List<DtoDotThi_ChungChi> getListDataBymaCC(int maCC)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDotThi_ChungChiBymaCC ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCC", maCC);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi_ChungChi> lst = new List<DtoDotThi_ChungChi>();
        DtoDotThi_ChungChi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi_ChungChi();
            data.MADT = Convert.ToInt32(dr["maDT"]);
            data.MACC = Convert.ToInt32(dr["maCC"]);
            lst.Add(data);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    public int insertData(DtoDotThi_ChungChi data)
    {
        int Id = -1;
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataDotThi_ChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);
        cmd.Parameters.AddWithValue("@maCC", data.MACC);
        cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
    public bool deleteData(DtoDotThi_ChungChi data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDotThi_ChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBymaCC(int maCC)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDotThi_ChungChiBymaCC ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCC", maCC);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBysoLuongThiSinh(int soLuongThiSinh)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDotThi_ChungChiBysoLuongThiSinh ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@soLuongThiSinh", soLuongThiSinh);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateData(DtoDotThi_ChungChi data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDotThi_ChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);
        cmd.Parameters.AddWithValue("@maCC", data.MACC);
        cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataBymaDT(DtoDotThi_ChungChi data, int maDT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDotThi_ChungChiBymaDT ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCC", data.MACC);
        cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        cmd.Parameters.AddWithValue("@maDT", maDT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataBymaCC(DtoDotThi_ChungChi data, int maCC)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDotThi_ChungChiBymaCC ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);
        cmd.Parameters.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        cmd.Parameters.AddWithValue("@maCC", maCC);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    #endregion
}

}
