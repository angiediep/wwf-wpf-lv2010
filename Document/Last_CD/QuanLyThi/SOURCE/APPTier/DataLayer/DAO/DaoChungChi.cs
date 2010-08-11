
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
public class DaoChungChi
{

	public DaoChungChi()
	{
	}
    #region "ExportFile"
    public DtoChungChi getDataById(int maCC)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCC", maCC);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoChungChi data = null;
        while (dr.Read())
        {
            data = new DtoChungChi();
            data.MACC = Convert.ToInt32(dr["maCC"]);
            data.TENCC = Convert.ToString(dr["tenCC"]);
        }
        con.Close();
        return data;
    }
    public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
    public List<DtoChungChi> getDataList()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoChungChi> lst = new List<DtoChungChi>();
        DtoChungChi data = null;
        while (dr.Read())
        {
            data = new DtoChungChi();
            data.MACC = Convert.ToInt32(dr["maCC"]);
            data.TENCC = Convert.ToString(dr["tenCC"]);
            lst.Add(data);
        }
        con.Close();
        return lst;
    }
    public List<DtoChungChi> getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sp = "spGetListDataChungChiSortBy";
        SqlCommand cmd = new SqlCommand(sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag);
        cmd.Parameters.AddWithValue("@col", col);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoChungChi> lst = new List<DtoChungChi>();
        DtoChungChi data = null;
        while (dr.Read())
        {
            data = new DtoChungChi();
            data.MACC = Convert.ToInt32(dr["maCC"]);
            data.TENCC = Convert.ToString(dr["tenCC"]);
            lst.Add(data);
        }
        con.Close();
        return lst;
    }
    public int insertData(DtoChungChi data)
    {
        int Id = -1;
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenCC", data.TENCC);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
    public bool deleteData(DtoChungChi data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCC", data.MACC);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBytenCC(string tenCC)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataChungChiBytenCC ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenCC", tenCC);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateData(DtoChungChi data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataChungChi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCC", data.MACC);
        cmd.Parameters.AddWithValue("@tenCC", data.TENCC);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataBymaCC(DtoChungChi data, int maCC)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataChungChiBymaCC ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenCC", data.TENCC);
        cmd.Parameters.AddWithValue("@maCC", maCC);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    #endregion
}

}
