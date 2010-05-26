
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
public class DaoNhanVien
{

	public DaoNhanVien()
	{
	}
	#region "ExportFile" 
	public DtoNhanVien getDataById(int maNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataNhanVien " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoNhanVien data = null;
        while (dr.Read())
        {
            data = new DtoNhanVien();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.DIENTHOAI =Convert.ToString(dr["dienThoai"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVien " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoNhanVien>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVien " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVien> lst = new List<DtoNhanVien>();
        DtoNhanVien data = null;
        while (dr.Read())
        {
            data = new DtoNhanVien();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.DIENTHOAI =Convert.ToString(dr["dienThoai"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoNhanVien>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataNhanVienSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVien> lst = new List<DtoNhanVien>();
        DtoNhanVien data = null;
        while (dr.Read())
        {
            data = new DtoNhanVien();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.EMAIL =Convert.ToString(dr["email"]);
			data.DIENTHOAI =Convert.ToString(dr["dienThoai"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoNhanVien> getListDataBytenDangNhap(string tenDangNhap)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVien> lst = new List<DtoNhanVien>();
        DtoNhanVien data = null;
        while (dr.Read())
        {
            data = new DtoNhanVien();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVien> getListDataBymatKhau(string matKhau)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@matKhau", matKhau);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVien> lst = new List<DtoNhanVien>();
        DtoNhanVien data = null;
        while (dr.Read())
        {
            data = new DtoNhanVien();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVien> getListDataBySALT(int SALT)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SALT", SALT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVien> lst = new List<DtoNhanVien>();
        DtoNhanVien data = null;
        while (dr.Read())
        {
            data = new DtoNhanVien();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVien> getListDataBytenNV(string tenNV)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienBytenNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenNV", tenNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVien> lst = new List<DtoNhanVien>();
        DtoNhanVien data = null;
        while (dr.Read())
        {
            data = new DtoNhanVien();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVien> getListDataByemail(string email)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVien> lst = new List<DtoNhanVien>();
        DtoNhanVien data = null;
        while (dr.Read())
        {
            data = new DtoNhanVien();
			data.MANV =Convert.ToInt32(dr["maNV"]);
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.TENNV =Convert.ToString(dr["tenNV"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoNhanVien data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataNhanVien " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoNhanVien data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVien " , con);
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
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienBytenDangNhap " , con);
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
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienBymatKhau " , con);
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
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SALT", SALT);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBytenNV(string tenNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienBytenNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenNV", tenNV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByemail(string email)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBydienThoai(string dienThoai)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNhanVienBydienThoai " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@dienThoai", dienThoai);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoNhanVien data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVien " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaNV(DtoNhanVien data,int maNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienBymaNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@maNV",maNV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenDangNhap(DtoNhanVien data,string tenDangNhap)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@tenDangNhap",tenDangNhap);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymatKhau(DtoNhanVien data,string matKhau)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@matKhau",matKhau);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBySALT(DtoNhanVien data,int SALT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maNV", data.MANV);
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@tenNV", data.TENNV);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@dienThoai", data.DIENTHOAI);
		cmd.Parameters.AddWithValue("@SALT",SALT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenNV(DtoNhanVien data,string tenNV)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienBytenNV " , con);
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
	public bool updateDataByemail(DtoNhanVien data,string email)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienByemail " , con);
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
	#endregion
}

}
