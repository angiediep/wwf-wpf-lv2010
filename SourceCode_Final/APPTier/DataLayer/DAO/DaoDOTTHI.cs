
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
public class DaoDotThi
{

	public DaoDotThi()
	{
	}
    #region "ExportFile"
    private List<DtoDotThi> extractData(SqlDataReader dr)
    {
        List<DtoDotThi> lst = new List<DtoDotThi>();
        DtoDotThi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi();
            data.MADT = Convert.ToInt32(dr["maDT"]);
            data.TENDOTTHI = Convert.ToString(dr["tenDotThi"]);
            data.NGAYTHI = Convert.ToDateTime(dr["ngayThi"]);
            data.SOLUONGTHISINH = Convert.ToInt32(dr["soLuongThiSinh"]);
            data.WORKFLOWINSTANCEID = Convert.ToString(dr["workflowInstanceID"]);
            lst.Add(data);
        }
        return lst;
    }
    private void bindData(SqlParameterCollection para, DtoDotThi data)
    {
        para.AddWithValue("@tenDotThi", data.TENDOTTHI);
        para.AddWithValue("@ngayThi", data.NGAYTHI);
        para.AddWithValue("@soLuongThiSinh", data.SOLUONGTHISINH);
        if (data.WORKFLOWINSTANCEID == null)
            para.AddWithValue("@workflowInstanceID", string.Empty);
        else
            para.AddWithValue("@workflowInstanceID", data.WORKFLOWINSTANCEID);
    }
    public DtoDotThi getDataById(int maDT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataDOTTHI ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoDotThi data = null;
        while (dr.Read())
        {
            data = new DtoDotThi();
            data.MADT = Convert.ToInt32(dr["maDT"]);
            data.TENDOTTHI = Convert.ToString(dr["tenDotThi"]);
            data.NGAYTHI = Convert.ToDateTime(dr["ngayThi"]);
            data.SOLUONGTHISINH = Convert.ToInt32(dr["soLuongThiSinh"]);
            data.WORKFLOWINSTANCEID = Convert.ToString(dr["workflowInstanceID"]);
        }
        con.Close();
        return data;
    }
    public DtoDotThi getDataByWorkflowInstance(string strInstanceID)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTTheoWorkflowInstance ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@workflowInstanceID", strInstanceID);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        if (lst != null && lst.Count != 0)
            return lst[0];
        return null;
    }
    public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHI ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
    public List<DtoDotThi> getDataList()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHI ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    /// <summary>
    /// Lấy danh sách đợt thi bị trễ hạn. (Ngày phát chứng chỉ muộn hơn so với quy định)
    /// </summary>
    /// <returns>danh sách đợt thi</returns>
    public List<DtoDotThi> getCompletedLateList()
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();

        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTTreHan ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    /// <summary>
    /// Lấy danh sách đợt thi có công việc bị trễ hạn.
    /// </summary>
    /// <returns>Danh sách đợt thi.
    /// Trường hợp lỗi trả về null</returns>
    public List<DtoDotThi> getListContainCompletedLateWorkItem()
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();

        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTCoCongViecTreHan ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getCompletedEarlyList()
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();

        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTSomHan ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getListContainCompletedEarlyWorkItem()
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();

        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTCoCongViecSomHan ", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sp = "spGetListDataDOTTHISortBy";
        SqlCommand cmd = new SqlCommand(sp, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag);
        cmd.Parameters.AddWithValue("@col", col);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getListDataBytenDotThi(string tenDotThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHIBytenDotThi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDotThi", tenDotThi);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getListDataByngayThi(DateTime ngayThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataDOTTHIByngayThi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayThi", ngayThi);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getListDataByNgayThi(DateTime ngayBatDau, DateTime ngayKetThuc)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTTheoThoiGian ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@startDay", ngayBatDau);
        cmd.Parameters.AddWithValue("@endDay", ngayKetThuc);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getListDataOnGoing()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTDangDienRa ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getListDataCompleted()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTDaHoanThanh ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public List<DtoDotThi> getListDataUpComming()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTChuaDienRa ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    /// <summary>
    /// Lấy danh sách đợt thi mà nhân viên A được phân công công việc.
    /// </summary>
    /// <param name="maNV">mã của nhân viên A.</param>
    /// <returns></returns>
    public List<DtoDotThi> getListDataByMaNV(int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSDTTheoMaNV ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoDotThi> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
    public int insertData(DtoDotThi data)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_themDotThi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        bindData(cmd.Parameters, data);
        cmd.Parameters.Add("@kq", SqlDbType.Int);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@kq"].Direction = ParameterDirection.Output;
        cmd.Parameters["@id"].Direction = ParameterDirection.Output;

        con.Open();
        cmd.ExecuteNonQuery();
        int result = int.Parse(cmd.Parameters["@kq"].Value.ToString());
        int id = int.Parse(cmd.Parameters["@id"].Value.ToString());
        con.Close();
        if (id > 0)
            return id;
        else
            return result;

    }
    public bool deleteData(DtoDotThi data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHI ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBytenDotThi(string tenDotThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIBytenDotThi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDotThi", tenDotThi);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataByngayThi(DateTime ngayThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIByngayThi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayThi", ngayThi);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataBysoLuongThiSinh(int soLuongThiSinh)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIBysoLuongThiSinh ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@soLuongThiSinh", soLuongThiSinh);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool deleteDataByworkflowInstanceID(string workflowInstanceID)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataDOTTHIByworkflowInstanceID ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@workflowInstanceID", workflowInstanceID);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }

    public bool updateData(DtoDotThi data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHI ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", data.MADT);
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }

    public bool updateDataBytenDotThi(DtoDotThi data, string tenDotThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHIBytenDotThi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.TENDOTTHI = tenDotThi;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool updateDataByngayThi(DtoDotThi data, DateTime ngayThi)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataDOTTHIByngayThi ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.NGAYTHI = ngayThi;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    #endregion

    public List<string> getListDotThi()
    {
        List<string> res = new List<string>();
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sql = "select dt.tenDotThi from DOTTHI dt, TienDo td where td.maDT = dt.maDT and td.ngayKetThucThucTe <= GetDate() and td.maCV in (select cv.maCV from CongViec cv where cv.ngayKetThuc = (select MAX(cv2.ngayKetThuc) from CongViec cv2))";
        SqlCommand cmd = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader sr = cmd.ExecuteReader();
        while (sr.Read())
            res.Add(sr.GetValue(0).ToString());

        con.Close();
        return res;
    }

    public List<string> getDotThiTheoNV(string uname)
    {
        List<string> res = new List<string>();
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sql = "  select dt.tenDotThi from DOTTHI dt, TienDo td, NhanVienThuaHanh nv, CongViec cv where dt.maDT = td.maDT and td.maNV = nv.maNV and nv.tenDangNhap =@tenDangNhap group by dt.tenDotThi, dt.ngayThi having DateAdd(d, max(cv.ngayKetThuc), dt.ngayThi) >= GetDate()";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add("@tenDangNhap", SqlDbType.NVarChar).Value = uname;
        con.Open();
        SqlDataReader sr = cmd.ExecuteReader();

        while (sr.Read())
            res.Add(sr.GetValue(0).ToString());

        con.Close();
        return res;        
    }

    public string getTenDTByMaDT(int p)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sql = "select tenDotThi from DotThi where maDT=@maDT";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = p;

        con.Open();
        string res = string.Empty;
        try
        {
            res = cmd.ExecuteScalar().ToString();
        }
        catch
        {
        }
        con.Close();
        return res;        
    }

    public List<string> getDotThiXX()
    {
        List<string> res = new List<string>();
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sql = "select dt.tenDotThi from DOTTHI dt, TienDo td where td.maDT = dt.maDT and td.maCV = 1 and td.ngayBatDauQuyDinh < GetDate()";
        SqlCommand cmd = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader sr = cmd.ExecuteReader();
        while (sr.Read())
            res.Add(sr.GetValue(0).ToString());

        con.Close();
        return res;
    }

    public int getMaDTByTenDT(string tenDT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sql = "select maDT from DotThi where tenDotThi=@tenDotThi";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add("@tenDotThi", SqlDbType.NVarChar).Value = tenDT;

        con.Open();
        int res = -1;
        try
        {
            res = int.Parse(cmd.ExecuteScalar().ToString());
        }
        catch
        {
        }
        con.Close();
        return res;
    }
}

}
