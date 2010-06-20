
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
public class DaoTienDo
{

	public DaoTienDo()
	{
	}
	#region "ExportFile" 
    private List<DtoTienDo> extractData(SqlDataReader dr)
    {
        List<DtoTienDo> lst = new List<DtoTienDo>();
        DtoTienDo data = null;
        while (dr.Read())
        {
            data = new DtoTienDo();
            data.MATD = Convert.ToInt32(dr["maTD"]);
            data.TONGKHOILUONGCV = Convert.ToInt32(dr["tongKhoiLuongCV"]);
            data.KHOILUONGCVHT = Convert.ToInt32(dr["khoiLuongCVHT"]);
            data.NGAYBATDAUQUYDINH = Convert.ToDateTime(dr["ngayBatDauQuyDinh"]);
            data.NGAYKETTHUCQUYDINH = Convert.ToDateTime(dr["ngayKetThucQuyDinh"]);
            
            if (dr["ngayBatDauThucTe"] == DBNull.Value)
                data.NGAYBATDAUTHUCTE = DateTime.MinValue;
            else
                data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);

            if (dr["ngayKetThucThucTe"] == DBNull.Value)
                data.NGAYBATDAUTHUCTE = DateTime.MinValue;
            else
                data.NGAYKETTHUCTHUCTE = Convert.ToDateTime(dr["ngayKetThucThucTe"]);
            
            data.MADT = Convert.ToInt32(dr["maDT"]);
            data.MACV = Convert.ToInt32(dr["maCV"]);
            data.MANV = Convert.ToInt32(dr["maNV"]);
            lst.Add(data);
        }
        return lst;
    }
    private void bindData(SqlParameterCollection para, DtoTienDo data)
    {
        para.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
        para.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
        para.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
        para.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
        if(data.NGAYKETTHUCTHUCTE.Year == DateTime.MinValue.Year)
            para.AddWithValue("@ngayBatDauThucTe", DBNull.Value);
        else
            para.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
        
        if (data.NGAYKETTHUCTHUCTE.Year == DateTime.MinValue.Year)
            para.AddWithValue("@ngayKetThucThucTe", DBNull.Value);
        else
            para.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);

        para.AddWithValue("@maDT", data.MADT);
        para.AddWithValue("@maCV", data.MACV);
        para.AddWithValue("@maNV", data.MANV);
    }
	public DtoTienDo getDataById(int maTD)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataTienDo " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", maTD);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoTienDo data = null;
        while (dr.Read())
        {
            data = new DtoTienDo();
			data.MATD =Convert.ToInt32(dr["maTD"]);
			data.TONGKHOILUONGCV =Convert.ToInt32(dr["tongKhoiLuongCV"]);
			data.KHOILUONGCVHT =Convert.ToInt32(dr["khoiLuongCVHT"]);

            if (dr["ngayBatDauThucTe"] == DBNull.Value)
                data.NGAYBATDAUTHUCTE = DateTime.MinValue;
            else
                data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);

            if (dr["ngayKetThucThucTe"] == DBNull.Value)
                data.NGAYBATDAUTHUCTE = DateTime.MinValue;
            else
                data.NGAYKETTHUCTHUCTE = Convert.ToDateTime(dr["ngayKetThucThucTe"]);
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDo " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoTienDo>  getDataList()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDo " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = new List<DtoTienDo>();
        DtoTienDo data = null;
        while (dr.Read())
        {
            data = new DtoTienDo();
			data.MATD =Convert.ToInt32(dr["maTD"]);
			data.TONGKHOILUONGCV =Convert.ToInt32(dr["tongKhoiLuongCV"]);
			data.KHOILUONGCVHT =Convert.ToInt32(dr["khoiLuongCVHT"]);
			data.NGAYBATDAUQUYDINH =Convert.ToDateTime(dr["ngayBatDauQuyDinh"]);
			data.NGAYKETTHUCQUYDINH =Convert.ToDateTime(dr["ngayKetThucQuyDinh"]);
			data.NGAYBATDAUTHUCTE =Convert.ToDateTime(dr["ngayBatDauThucTe"]);
			data.NGAYKETTHUCTHUCTE =Convert.ToDateTime(dr["ngayKetThucThucTe"]);
			data.MADT =Convert.ToInt32(dr["maDT"]);
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.MANV =Convert.ToInt32(dr["maNV"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoTienDo>  getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataTienDoSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataBytongKhoiLuongCV(int tongKhoiLuongCV)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoBytongKhoiLuongCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tongKhoiLuongCV", tongKhoiLuongCV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataBykhoiLuongCVHT(int khoiLuongCVHT)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoBykhoiLuongCVHT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@khoiLuongCVHT", khoiLuongCVHT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataByngayBatDauQuyDinh(DateTime ngayBatDauQuyDinh)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayBatDauQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", ngayBatDauQuyDinh);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataByngayKetThucQuyDinh(DateTime ngayKetThucQuyDinh)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayKetThucQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", ngayKetThucQuyDinh);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayBatDauThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDauThucTe", ngayBatDauThucTe);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayKetThucThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThucThucTe", ngayKetThucThucTe);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataBymaDT(int maDT)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoBymaDT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataBymaCV(int maCV)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoBymaCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
    /// <summary>
    /// lấy danh sách công việc được phân công cho một nhân viên bất kỳ
    /// qua các kỳ thi.
    /// </summary>
    /// <param name="maNV">mã nhân viên cần xem danh sách phân công.</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataByMaNV(int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSTDTheoMaNV ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
    /// <summary>
    /// lấy danh sách công việc được phân công cho một nhân viên bất kỳ
    /// qua các kỳ thi.
    /// </summary>
    /// <param name="maNV">mã nhân viên cần xem danh sách phân công.</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataByMaNV(int maNV,DateTime startDay, DateTime endDay)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSTDTheoMaNVVaThoiGian ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        cmd.Parameters.AddWithValue("@startDay", startDay);
        cmd.Parameters.AddWithValue("@endDay", endDay);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        con.Close();
        return lst;
    }
    /// <summary>
    /// Lấy danh sách thông tin tiến độ của các công  việc bị trễ hạn trong một đợt thi.
    /// </summary>
    /// <param name="maDT">Mã đợt thi đang xét</param>
    /// <returns>Danh sách thông tin tiến độ của các công việc trễ hạn.</returns>
    public List<DtoTienDo> getListDataDelayedByMaDT(int maDT)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSCongViecTreHan", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;
    }
    /// <summary>
    /// Lấy danh sách thông tin tiến độ của các công việc kết thúc sớm hạn trong một đợt thi
    /// </summary>
    /// <param name="maDT">mã đợt thi đang xét</param>
    /// <returns>Danh sách tiến độ sớm hạn</returns>
    public List<DtoTienDo> getListDataEarlyByMaDT(int maDT)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layDSCongViecSomHan", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;
    }
    /// <summary>
    /// Lấy toàn bộ nội dung theo dõi tiến độ của các công việc đã hoàn thành.
    /// </summary>
    /// <returns></returns>
    public List<DtoTienDo> getListDataCompleted()
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDDaHoanThanh", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;
    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ của các công việc đã hoàn thành trong một đợt thi bất kỳ.
    /// </summary>
    /// <param name="maDT">mã đợt thi cần lấy thông tin tiến độ.</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataCompletedByMaDT(int maDT)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDDaHoanThanhCuaMotDotThi", conn);
        cmd.Parameters.AddWithValue("@maDT", maDT);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;
    }
    /// <summary>
    /// lấy thông tin theo dõi tiến độ của các công việc đã hoàn thành của một nhân viên
    /// </summary>
    /// <param name="maNV">Mã nhân viên</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataCompletedByMaNV(int maNV)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDDaHoanThanhCuaMotNhanVien", conn);
        cmd.Parameters.AddWithValue("@maNV", maNV);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;
    }
    /// <summary>
    /// Lấy toàn bộ thông tin theo dõi tiến độ của các công việc đang diễn ra
    /// </summary>
    /// <returns></returns>
    public List<DtoTienDo> getListDataOnGoing()
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDDangDienRa", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;
    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ của những công việc đang diễn ra trong một đợt thi bất kỳ
    /// </summary>
    /// <param name="maDT">Mã đợt thi</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataOnGoingByMaDT(int maDT)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDDangDienRaCuaMotDotThi", conn);
        cmd.Parameters.AddWithValue("@maDT", maDT);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;

    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ công việc đang thực hiện, của một nhân viên
    /// bất kỳ
    /// </summary>
    /// <param name="maDT">Mã nhân viên</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataOnGoingByMaNV(int maNV)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDDangDienRaCuaMotNhanVien", conn);
        cmd.Parameters.AddWithValue("@maNV", maNV);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;

    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ của tất cả các công việc sắp diễn ra.
    /// </summary>
    /// <returns></returns>
    public List<DtoTienDo> getListDataUpcoming()
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDSapDienRa", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;

    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ của tất cả các công việc sắp diễn ra trong một đợt thi cụ thể.
    /// </summary>
    /// <param name="maDT"></param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataUpcomingByMaDT(int maDT)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDSapDienRaCuaMotDotThi", conn);
        cmd.Parameters.AddWithValue("@maDT", maDT);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;

    }
    /// <summary>
    /// Lấy thông tin tiến độ của các côn việc được phân công cho một nhân viên
    /// cụ thể và chưa được thực hiện.
    /// </summary>
    /// <param name="maNV">mã nhân viên</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataUpcomingByMaNV(int maNV)
    {
        DataConnector dc = new DataConnector();
        string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_layTDSapDienRaCuaMotNhanVien", conn);
        cmd.Parameters.AddWithValue("@maNV", maNV);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTienDo> lst = extractData(dr);

        dr.Close();
        conn.Close();
        return lst;

    }
	public int insertData(DtoTienDo data)
    {
        int Id = -1;
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataTienDo " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        bindData(cmd.Parameters, data);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoTienDo data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDo " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", data.MATD);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBytongKhoiLuongCV(int tongKhoiLuongCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoBytongKhoiLuongCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tongKhoiLuongCV", tongKhoiLuongCV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBykhoiLuongCVHT(int khoiLuongCVHT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoBykhoiLuongCVHT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@khoiLuongCVHT", khoiLuongCVHT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayBatDauQuyDinh(DateTime ngayBatDauQuyDinh)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoByngayBatDauQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", ngayBatDauQuyDinh);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayKetThucQuyDinh(DateTime ngayKetThucQuyDinh)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoByngayKetThucQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", ngayKetThucQuyDinh);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoByngayBatDauThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDauThucTe", ngayBatDauThucTe);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoByngayKetThucThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThucThucTe", ngayKetThucThucTe);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymaDT(int maDT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoBymaDT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymaCV(int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoBymaCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymaNV(int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTienDoBymaNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoTienDo data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDo " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", data.MATD);
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaTD(DtoTienDo data,int maTD)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaTD " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.MATD = maTD;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytongKhoiLuongCV(DtoTienDo data,int tongKhoiLuongCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBytongKhoiLuongCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.TONGKHOILUONGCV = tongKhoiLuongCV;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBykhoiLuongCVHT(DtoTienDo data,int khoiLuongCVHT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBykhoiLuongCVHT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.KHOILUONGCVHT = khoiLuongCVHT;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayBatDauQuyDinh(DtoTienDo data,DateTime ngayBatDauQuyDinh)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayBatDauQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.NGAYBATDAUQUYDINH = ngayBatDauQuyDinh;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayKetThucQuyDinh(DtoTienDo data,DateTime ngayKetThucQuyDinh)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayKetThucQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.NGAYKETTHUCQUYDINH = ngayKetThucQuyDinh;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayBatDauThucTe(DtoTienDo data,DateTime ngayBatDauThucTe)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayBatDauThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.NGAYBATDAUTHUCTE = ngayBatDauThucTe;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayKetThucThucTe(DtoTienDo data,DateTime ngayKetThucThucTe)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayKetThucThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.NGAYKETTHUCTHUCTE = ngayKetThucThucTe;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaDT(DtoTienDo data,int maDT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaDT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.MADT = maDT;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaCV(DtoTienDo data,int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.MACV = maCV;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
    public void startWork(int maTD)
    { 
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_batDauCongViec ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", maTD);
        con.Open();
        cmd.ExecuteNonQuery();
    }
    public void finishWork(int maTD)
    { 
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_ketThucCongViec ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTD", maTD);
        con.Open();
        cmd.ExecuteNonQuery();
    }
	#endregion
}

}
