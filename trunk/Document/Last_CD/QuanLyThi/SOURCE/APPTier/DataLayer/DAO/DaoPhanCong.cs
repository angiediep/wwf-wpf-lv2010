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
    private List<DtoPhanCong> extractData(SqlDataReader dr)
    {
        List<DtoPhanCong> lst = new List<DtoPhanCong>();
        DtoPhanCong data = null;
        while (dr.Read())
        {
            data = new DtoPhanCong();
            data.MACV = Convert.ToInt32(dr["maCV"]);
            data.MANV = Convert.ToInt32(dr["maNV"]);
            data.NGAYAPDUNG = Convert.ToDateTime(dr["ngayApDung"]);
            try
            {
                data.NGAYHETHAN = Convert.ToDateTime(dr["ngayHetHan"]);
            }
            catch (Exception)
            {
                data.NGAYHETHAN = new DateTime(9999,1,1);
            }
            lst.Add(data);
        }
        return lst;
    }
    private void bindData(SqlParameterCollection para, DtoPhanCong data)
    {
        para.AddWithValue("@maCV", data.MACV);
        para.AddWithValue("@maNV", data.MANV);
        para.AddWithValue("@ngayApDung", data.NGAYAPDUNG);
        para.AddWithValue("@ngayHetHan", data.NGAYHETHAN);
    }
    public DtoPhanCong getDataById(int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataPhanCong ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoPhanCong data = null;
        while (dr.Read())
        {
            data = new DtoPhanCong();
            data.MACV = Convert.ToInt32(dr["maCV"]);
            data.MANV = Convert.ToInt32(dr["maNV"]);
            data.NGAYAPDUNG = Convert.ToDateTime(dr["ngayApDung"]);
            data.NGAYHETHAN = Convert.ToDateTime(dr["ngayHetHan"]);
        }
        con.Close();
        return data;
    }
    public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataPhanCong ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
    public List<DtoPhanCong> getDataList()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataPhanCong ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoPhanCong> lst = extractData(dr);
        con.Close();
        return lst;
    }
    public List<DtoPhanCong> getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sp = "spGetListDataPhanCongSortBy";
        SqlCommand cmd = new SqlCommand(sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag);
        cmd.Parameters.AddWithValue("@col", col);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoPhanCong> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoPhanCong> getListDataBymaNV(int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataPhanCongBymaNV ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoPhanCong> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoPhanCong> getListDataByngayApDung(DateTime ngayApDung)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataPhanCongByngayApDung ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayApDung", ngayApDung);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoPhanCong> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public int insertData(DtoPhanCong data)
    {
        int Id = -1;
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataPhanCong ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        bindData(cmd.Parameters, data);
        con.Open();
        try
        {
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch
        { }
        return Id;
    }
    public bool deleteData(DtoPhanCong data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCong ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", data.MACV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBymaNV(int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCongBymaNV ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataByngayApDung(DateTime ngayApDung)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCongByngayApDung ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayApDung", ngayApDung);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataByngayHetHan(DateTime ngayHetHan)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataPhanCongByngayHetHan ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayHetHan", ngayHetHan);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateData(DtoPhanCong data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCong ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataBymaCV(DtoPhanCong data, int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCongBymaCV ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.MACV = maCV;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataBymaNV(DtoPhanCong data, int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCongBymaNV ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.MANV = maNV;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataByngayApDung(DtoPhanCong data, DateTime ngayApDung)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataPhanCongByngayApDung ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.NGAYAPDUNG = ngayApDung;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    #endregion

    public int CheckCoChua(int p, int p_2)
    {
        try
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select maNV from PhanCong where maNV=@maNV and maCV=@maCV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maNV", SqlDbType.Int).Value = p_2;
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p;
            con.Open();
            int res = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return res;
        }
        catch
        {
            return -1;
        }
    }

    public void deleteDataBymaNVAndMaCV(int p, int p_2)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sql = "delete from PhanCong where maNV=@maNV and maCV=@maCV";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add("@maNV", SqlDbType.Int).Value = p_2;
        cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public DtoPhanCong getDataByIdAndTenNV(int p, int p_2)
    {
        try
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select * from PhanCong where maNV=@maNV and maCV=@maCV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maNV", SqlDbType.Int).Value = p_2;
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p;
            con.Open();
            SqlDataReader sr = cmd.ExecuteReader();
            DtoPhanCong res = new DtoPhanCong();
            while (sr.Read())
            {
                try
                {
                    res.NGAYAPDUNG = DateTime.Parse(sr.GetValue(2).ToString());
                }
                catch
                {
                    res.NGAYAPDUNG = new DateTime(9999, 1, 1);
                }

                try
                {
                    res.NGAYHETHAN = DateTime.Parse(sr.GetValue(3).ToString());
                }
                catch
                {
                    res.NGAYHETHAN = new DateTime(9999, 1, 1);
                }
            }
            con.Close();
            return res;
        }
        catch
        {
            return null;
        }
    }
}

}