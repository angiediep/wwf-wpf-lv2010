
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
public class DaoThongBao
{

    public DaoThongBao()
    {
    }
    #region "ExportFile"
    public DtoThongBao getDataById(int maTB)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataThongBao ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTB", maTB);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoThongBao data = null;
        while (dr.Read())
        {
            data = new DtoThongBao();
            data.MATB = Convert.ToInt32(dr["maTB"]);
            data.NOIDUNG = Convert.ToString(dr["noiDung"]);
            data.MATD = Convert.ToInt32(dr["maTD"]);
            data.TRANGTHAI = Convert.ToInt32(dr["trangThai"]);
        }
        con.Close();
        return data;
    }
    public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataThongBao ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
    public List<DtoThongBao> getDataList()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataThongBao ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoThongBao> lst = new List<DtoThongBao>();
        DtoThongBao data = null;
        while (dr.Read())
        {
            data = new DtoThongBao();
            data.MATB = Convert.ToInt32(dr["maTB"]);
            data.NOIDUNG = Convert.ToString(dr["noiDung"]);
            data.MATD = Convert.ToInt32(dr["maTD"]);
            data.TRANGTHAI = Convert.ToInt32(dr["trangThai"]);
            lst.Add(data);
        }
        con.Close();
        return lst;
    }
    public List<DtoThongBao> getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        string sp = "spGetListDataThongBaoSortBy";
        SqlCommand cmd = new SqlCommand(sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag);
        cmd.Parameters.AddWithValue("@col", col);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoThongBao> lst = new List<DtoThongBao>();
        DtoThongBao data = null;
        while (dr.Read())
        {
            data = new DtoThongBao();
            data.MATB = Convert.ToInt32(dr["maTB"]);
            data.NOIDUNG = Convert.ToString(dr["noiDung"]);
            data.MATD = Convert.ToInt32(dr["maTD"]);
            data.TRANGTHAI = Convert.ToInt32(dr["trangThai"]);
            lst.Add(data);
        }
        con.Close();
        return lst;
    }
    public List<DtoThongBao> getListDataBynoiDung(string noiDung)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataThongBaoBynoiDung ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@noiDung", noiDung);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoThongBao> lst = new List<DtoThongBao>();
        DtoThongBao data = null;
        while (dr.Read())
        {
            data = new DtoThongBao();
            data.MATB = Convert.ToInt32(dr["maTB"]);
            data.NOIDUNG = Convert.ToString(dr["noiDung"]);
            data.MATD = Convert.ToInt32(dr["maTD"]);
            lst.Add(data);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoThongBao> getListDataBymaTD(int maTD)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataThongBaoBymaTD ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", maTD);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoThongBao> lst = new List<DtoThongBao>();
        DtoThongBao data = null;
        while (dr.Read())
        {
            data = new DtoThongBao();
            data.MATB = Convert.ToInt32(dr["maTB"]);
            data.NOIDUNG = Convert.ToString(dr["noiDung"]);
            data.MATD = Convert.ToInt32(dr["maTD"]);
            lst.Add(data);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoThongBao> getDataByMaNV(int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSTBCuaMotNhanVien ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoThongBao> lst = new List<DtoThongBao>();
        DtoThongBao data = null;
        while (dr.Read())
        {
            data = new DtoThongBao();
            data.MATB = Convert.ToInt32(dr["maTB"]);
            data.NOIDUNG = Convert.ToString(dr["noiDung"]);
            data.MATD = Convert.ToInt32(dr["maTD"]);
            lst.Add(data);
        }
        dr.Close();
        con.Close();
        return lst;
    }

    public int insertData(DtoThongBao data)
    {
        int Id = -1;
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataThongBao ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@noiDung", data.NOIDUNG);
        cmd.Parameters.AddWithValue("@maTD", data.MATD);
        cmd.Parameters.AddWithValue("@trangThai", data.TRANGTHAI);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
    public bool deleteData(DtoThongBao data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataThongBao ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTB", data.MATB);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBynoiDung(string noiDung)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataThongBaoBynoiDung ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@noiDung", noiDung);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBymaTD(int maTD)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataThongBaoBymaTD ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", maTD);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBytrangThai(int trangThai)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataThongBaoBytrangThai ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@trangThai", trangThai);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateData(DtoThongBao data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataThongBao ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTB", data.MATB);
        cmd.Parameters.AddWithValue("@noiDung", data.NOIDUNG);
        cmd.Parameters.AddWithValue("@maTD", data.MATD);
        cmd.Parameters.AddWithValue("@trangThai", data.TRANGTHAI);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataBymaTB(DtoThongBao data, int maTB)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataThongBaoBymaTB ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@noiDung", data.NOIDUNG);
        cmd.Parameters.AddWithValue("@maTD", data.MATD);
        cmd.Parameters.AddWithValue("@trangThai", data.TRANGTHAI);
        cmd.Parameters.AddWithValue("@maTB", maTB);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataBynoiDung(DtoThongBao data, string noiDung)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataThongBaoBynoiDung ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTB", data.MATB);
        cmd.Parameters.AddWithValue("@maTD", data.MATD);
        cmd.Parameters.AddWithValue("@trangThai", data.TRANGTHAI);
        cmd.Parameters.AddWithValue("@noiDung", noiDung);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataBymaTD(DtoThongBao data, int maTD)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataThongBaoBymaTD ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTN", data.MATB);
        cmd.Parameters.AddWithValue("@noiDung", data.NOIDUNG);
        cmd.Parameters.AddWithValue("@trangThai", data.TRANGTHAI);
        cmd.Parameters.AddWithValue("@maTD", maTD);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }

    /// <summary>
    /// tạo thông báo nhắc nhở nhân viên bắt đầu các công việc sắp tới và có nguy cơ trễ cao.
    /// </summary>
    /// <param name="strMess">Nội dung thông báo.</param>
    /// <param name="NumOfUpcomingDay">Ngưỡng trễ. Những công việc dự kiến bắt đầu trước NumOfComingDay sẽ 
    /// được thông báo. Nếu muốn thông báo cho các công việc bắt đầu trễ hạn, thông số này âm.</param>
    /// <returns></returns>
    public int createMessageForUpcomingTaskStarting(string strMess, int NumOfUpcomingDay)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_taoThongBaoNhacViecSapToi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@strMess", strMess);
        cmd.Parameters.AddWithValue("@numOfUpcomingDay", NumOfUpcomingDay);
        cmd.Parameters.Add("@numMessCreated", SqlDbType.Int);
        cmd.Parameters["@numMessCreated"].Direction = ParameterDirection.Output;
        con.Open();
        cmd.ExecuteNonQuery();
        int num = 0;
        int.TryParse(cmd.Parameters["@numMessCreated"].Value.ToString(),out num);
        return num;

    }
    /// <summary>
    /// tạo thông báo nhắc nhở nhân viên hoàn thành các công việc đang thực thi và có nguy cơ trễ cao.
    /// </summary>
    /// <param name="strMess">Nội dung thông báo.</param>
    /// <param name="NumOfUpcomingDay">Ngưỡng trễ. Những công việc dự kiến kết thúc trước NumOfComingDay sẽ 
    /// được thông báo. Nếu muốn thông báo cho các công việc kết thúc trễ hạn, thông số này âm.</param>
    /// <returns></returns>
    public int createMessageForUpcomingTaskCompletion(string strMess, int NumOfUpcomingDay)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_taoThongBaoNhacHoanThanhCongViec ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@strMess", strMess);
        cmd.Parameters.AddWithValue("@numOfUpcomingDay", NumOfUpcomingDay);
        cmd.Parameters.Add("@numMessCreated", SqlDbType.Int);
        cmd.Parameters["@numMessCreated"].Direction = ParameterDirection.Output;
        con.Open();
        cmd.ExecuteNonQuery();
        int num = 0;
        int.TryParse(cmd.Parameters["@numMessCreated"].Value.ToString(), out num);
        return num;

    }

    /// <summary>
    /// tạo thông báo nhắc nhở nhân viên bắt đầu một công việc sắp tới có tính
    /// chất quan trọng hoặc có nguy cơ trễ cao.
    /// </summary>
    /// <param name="strMess">Nội dung thông báo.</param>
    /// <param name="NumOfUpcomingDay">Ngưỡng trễ. Những công việc dự kiến bắt đầu trước NumOfComingDay sẽ 
    /// được thông báo. Nếu muốn thông báo cho các công việc bắt đầu trễ hạn, thông số này âm.</param>
    /// <returns></returns>
    public int createMessageForUpcomingTaskStarting(string strMess,int maCV, int NumOfUpcomingDay)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_taoThongBaoNhacBatDauMotCongViec ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@strMess", strMess);
        cmd.Parameters.AddWithValue("@maCV", maCV);
        cmd.Parameters.AddWithValue("@numOfUpcomingDay", NumOfUpcomingDay);
        cmd.Parameters.Add("@numMessCreated", SqlDbType.Int);
        cmd.Parameters["@numMessCreated"].Direction = ParameterDirection.Output;
        con.Open();
        cmd.ExecuteNonQuery();
        int num = 0;
        int.TryParse(cmd.Parameters["@numMessCreated"].Value.ToString(), out num);
        return num;

    }
    /// <summary>
    /// tạo thông báo nhắc nhở nhân viên hoàn thành một công việc đang thực thi và có tinh
    /// chất quan trọng hoặc có nguy cơ trễ cao.
    /// </summary>
    /// <param name="strMess">Nội dung thông báo.</param>
    /// <param name="NumOfUpcomingDay">Ngưỡng trễ. Những công việc dự kiến kết thúc trước NumOfComingDay sẽ 
    /// được thông báo. Nếu muốn thông báo cho các công việc kết thúc trễ hạn, thông số này âm.</param>
    /// <returns></returns>
    public int createMessageForUpcomingTaskCompletion(string strMess, int maCV, int NumOfUpcomingDay)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_taoThongBaoNhacHoanThanhCongViec ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@strMess", strMess);
        cmd.Parameters.AddWithValue("@maCV", maCV);
        cmd.Parameters.AddWithValue("@numOfUpcomingDay", NumOfUpcomingDay);
        cmd.Parameters.Add("@numMessCreated", SqlDbType.Int);
        cmd.Parameters["@numMessCreated"].Direction = ParameterDirection.Output;
        con.Open();
        cmd.ExecuteNonQuery();
        int num = 0;
        int.TryParse(cmd.Parameters["@numMessCreated"].Value.ToString(), out num);
        return num;

    }


    #endregion
}

}
