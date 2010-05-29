
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
	public DtoTienDo getDataById(int maTD)
    {
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataTienDoSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
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
	public List<DtoTienDo> getListDataBytongKhoiLuongCV(int tongKhoiLuongCV)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoBytongKhoiLuongCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tongKhoiLuongCV", tongKhoiLuongCV);
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
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataBykhoiLuongCVHT(int khoiLuongCVHT)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoBykhoiLuongCVHT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@khoiLuongCVHT", khoiLuongCVHT);
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
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataByngayBatDauQuyDinh(DateTime ngayBatDauQuyDinh)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayBatDauQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", ngayBatDauQuyDinh);
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
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataByngayKetThucQuyDinh(DateTime ngayKetThucQuyDinh)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayKetThucQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", ngayKetThucQuyDinh);
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
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayBatDauThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDauThucTe", ngayBatDauThucTe);
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
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayKetThucThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThucThucTe", ngayKetThucThucTe);
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
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataBymaDT(int maDT)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoBymaDT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maDT", maDT);
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
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTienDo> getListDataBymaCV(int maCV)    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTienDoBymaCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);
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
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoTienDo data)
    {
        int Id = -1;
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataTienDo " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoTienDo data)
    {
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
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
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDo " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaTD(DtoTienDo data,int maTD)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaTD " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@maTD",maTD);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytongKhoiLuongCV(DtoTienDo data,int tongKhoiLuongCV)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBytongKhoiLuongCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV",tongKhoiLuongCV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBykhoiLuongCVHT(DtoTienDo data,int khoiLuongCVHT)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBykhoiLuongCVHT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT",khoiLuongCVHT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayBatDauQuyDinh(DtoTienDo data,DateTime ngayBatDauQuyDinh)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayBatDauQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh",ngayBatDauQuyDinh);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayKetThucQuyDinh(DtoTienDo data,DateTime ngayKetThucQuyDinh)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayKetThucQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh",ngayKetThucQuyDinh);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayBatDauThucTe(DtoTienDo data,DateTime ngayBatDauThucTe)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayBatDauThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe",ngayBatDauThucTe);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayKetThucThucTe(DtoTienDo data,DateTime ngayKetThucThucTe)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayKetThucThucTe " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe",ngayKetThucThucTe);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaDT(DtoTienDo data,int maDT)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaDT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@maDT",maDT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaCV(DtoTienDo data,int maCV)
    {
        string conStr = DataConnector.getConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTD", data.MATD);
		cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
		cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
		cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
		cmd.Parameters.AddWithValue("@maDT", data.MADT);
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@maCV",maCV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
