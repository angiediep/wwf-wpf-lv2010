
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
            data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);
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
        para.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
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
			data.NGAYBATDAUQUYDINH =Convert.ToDateTime(dr["ngayBatDauQuyDinh"]);
			data.NGAYKETTHUCQUYDINH =Convert.ToDateTime(dr["ngayKetThucQuyDinh"]);
			data.NGAYBATDAUTHUCTE =Convert.ToDateTime(dr["ngayBatDauThucTe"]);
			data.NGAYKETTHUCTHUCTE =Convert.ToDateTime(dr["ngayKetThucThucTe"]);
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
	#endregion
}

}
