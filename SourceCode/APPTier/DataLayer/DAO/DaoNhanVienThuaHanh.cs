
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Text;

using System.Data.SqlClient;
using System.IO;
using DTO;
namespace DAO
{
public class DaoNhanVienThuaHanh
{

	public DaoNhanVienThuaHanh()
	{
	}
	#region "ExportFile" 
	public DtoNhanVienThuaHanh getDataById(int maNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.DIENTHOAI =Convert.ToString(dr["dienThoai"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoNhanVienThuaHanh>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.DIENTHOAI =Convert.ToString(dr["dienThoai"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataNhanVienThuaHanhSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.DIENTHOAI =Convert.ToString(dr["dienThoai"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataBytenDangNhap(string tenDangNhap)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataBymatKhau(string matKhau)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@matKhau", matKhau);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataBySALT(int SALT)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SALT", SALT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataByemail(string email)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataBytenNV(string tenNV)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhBytenNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenNV", tenNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoNhanVienThuaHanh data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoNhanVienThuaHanh data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", data.MANV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBytenDangNhap(string tenDangNhap)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienThuaHanhBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymatKhau(string matKhau)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienThuaHanhBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@matKhau", matKhau);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBySALT(int SALT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienThuaHanhBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SALT", SALT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByemail(string email)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienThuaHanhByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBytenNV(string tenNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienThuaHanhBytenNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenNV", tenNV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBydienThoai(string dienThoai)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienThuaHanhBydienThoai " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@dienThoai", dienThoai);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoNhanVienThuaHanh data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaNV(DtoNhanVienThuaHanh data,int maNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBymaNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@maNV",maNV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenDangNhap(DtoNhanVienThuaHanh data,string tenDangNhap)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@tenDangNhap",tenDangNhap);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymatKhau(DtoNhanVienThuaHanh data,string matKhau)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@matKhau",matKhau);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBySALT(DtoNhanVienThuaHanh data,int SALT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@SALT",SALT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByemail(DtoNhanVienThuaHanh data,string email)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@email",email);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenNV(DtoNhanVienThuaHanh data,string tenNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBytenNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@tenNV",tenNV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
