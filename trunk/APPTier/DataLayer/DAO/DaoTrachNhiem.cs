
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
public class DaoTrachNhiem
{

	public DaoTrachNhiem()
	{
	}
	#region "ExportFile" 
	public DtoTrachNhiem getDataById(int maTN)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataTrachNhiem " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTN", maTN);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoTrachNhiem data = null;
        while (dr.Read())
        {
            data = new DtoTrachNhiem();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.TENTN =Convert.ToString(dr["tenTN"]);
			data.THUTUCONGVIEC =Convert.ToInt32(dr["thuTuCongViec"]);
			data.NGAYBATDAUQUYDINH =Convert.ToInt32(dr["ngayBatDauQuyDinh"]);
			data.NGAYKETTHUCQUYDINH =Convert.ToInt32(dr["ngayKetThucQuyDinh"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTrachNhiem " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoTrachNhiem>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTrachNhiem " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTrachNhiem> lst = new List<DtoTrachNhiem>();
        DtoTrachNhiem data = null;
        while (dr.Read())
        {
            data = new DtoTrachNhiem();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.TENTN =Convert.ToString(dr["tenTN"]);
			data.THUTUCONGVIEC =Convert.ToInt32(dr["thuTuCongViec"]);
			data.NGAYBATDAUQUYDINH =Convert.ToInt32(dr["ngayBatDauQuyDinh"]);
			data.NGAYKETTHUCQUYDINH =Convert.ToInt32(dr["ngayKetThucQuyDinh"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoTrachNhiem>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataTrachNhiemSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTrachNhiem> lst = new List<DtoTrachNhiem>();
        DtoTrachNhiem data = null;
        while (dr.Read())
        {
            data = new DtoTrachNhiem();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.TENTN =Convert.ToString(dr["tenTN"]);
			data.THUTUCONGVIEC =Convert.ToInt32(dr["thuTuCongViec"]);
			data.NGAYBATDAUQUYDINH =Convert.ToInt32(dr["ngayBatDauQuyDinh"]);
			data.NGAYKETTHUCQUYDINH =Convert.ToInt32(dr["ngayKetThucQuyDinh"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoTrachNhiem> getListDataBytenTN(string tenTN)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTrachNhiemBytenTN " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenTN", tenTN);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTrachNhiem> lst = new List<DtoTrachNhiem>();
        DtoTrachNhiem data = null;
        while (dr.Read())
        {
            data = new DtoTrachNhiem();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.TENTN =Convert.ToString(dr["tenTN"]);
			data.THUTUCONGVIEC =Convert.ToInt32(dr["thuTuCongViec"]);
			data.NGAYBATDAUQUYDINH =Convert.ToInt32(dr["ngayBatDauQuyDinh"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTrachNhiem> getListDataBythuTuCongViec(int thuTuCongViec)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTrachNhiemBythuTuCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@thuTuCongViec", thuTuCongViec);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTrachNhiem> lst = new List<DtoTrachNhiem>();
        DtoTrachNhiem data = null;
        while (dr.Read())
        {
            data = new DtoTrachNhiem();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.TENTN =Convert.ToString(dr["tenTN"]);
			data.THUTUCONGVIEC =Convert.ToInt32(dr["thuTuCongViec"]);
			data.NGAYBATDAUQUYDINH =Convert.ToInt32(dr["ngayBatDauQuyDinh"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoTrachNhiem> getListDataByngayBatDauQuyDinh(int ngayBatDauQuyDinh)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataTrachNhiemByngayBatDauQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", ngayBatDauQuyDinh);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoTrachNhiem> lst = new List<DtoTrachNhiem>();
        DtoTrachNhiem data = null;
        while (dr.Read())
        {
            data = new DtoTrachNhiem();
			data.MATN =Convert.ToInt32(dr["maTN"]);
			data.TENTN =Convert.ToString(dr["tenTN"]);
			data.THUTUCONGVIEC =Convert.ToInt32(dr["thuTuCongViec"]);
			data.NGAYBATDAUQUYDINH =Convert.ToInt32(dr["ngayBatDauQuyDinh"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoTrachNhiem data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataTrachNhiem " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenTN", data.TENTN);
		cmd.Parameters.AddWithValue("@thuTuCongViec", data.THUTUCONGVIEC);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoTrachNhiem data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTrachNhiem " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maTN", data.MATN);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBytenTN(string tenTN)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTrachNhiemBytenTN " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenTN", tenTN);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBythuTuCongViec(int thuTuCongViec)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTrachNhiemBythuTuCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@thuTuCongViec", thuTuCongViec);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayBatDauQuyDinh(int ngayBatDauQuyDinh)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTrachNhiemByngayBatDauQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", ngayBatDauQuyDinh);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayKetThucQuyDinh(int ngayKetThucQuyDinh)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataTrachNhiemByngayKetThucQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", ngayKetThucQuyDinh);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoTrachNhiem data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTrachNhiem " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTN", data.MATN);
		cmd.Parameters.AddWithValue("@tenTN", data.TENTN);
		cmd.Parameters.AddWithValue("@thuTuCongViec", data.THUTUCONGVIEC);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaTN(DtoTrachNhiem data,int maTN)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTrachNhiemBymaTN " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenTN", data.TENTN);
		cmd.Parameters.AddWithValue("@thuTuCongViec", data.THUTUCONGVIEC);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@maTN",maTN);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenTN(DtoTrachNhiem data,string tenTN)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTrachNhiemBytenTN " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTN", data.MATN);
		cmd.Parameters.AddWithValue("@thuTuCongViec", data.THUTUCONGVIEC);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@tenTN",tenTN);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBythuTuCongViec(DtoTrachNhiem data,int thuTuCongViec)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTrachNhiemBythuTuCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTN", data.MATN);
		cmd.Parameters.AddWithValue("@tenTN", data.TENTN);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@thuTuCongViec",thuTuCongViec);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayBatDauQuyDinh(DtoTrachNhiem data,int ngayBatDauQuyDinh)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataTrachNhiemByngayBatDauQuyDinh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maTN", data.MATN);
		cmd.Parameters.AddWithValue("@tenTN", data.TENTN);
		cmd.Parameters.AddWithValue("@thuTuCongViec", data.THUTUCONGVIEC);
		cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
		cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh",ngayBatDauQuyDinh);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
