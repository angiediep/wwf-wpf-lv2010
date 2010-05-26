
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
public class DaoNguoiQuanLy
{

	public DaoNguoiQuanLy()
	{
	}
	#region "ExportFile" 
	public DtoNguoiQuanLy getDataById(string tenDangNhap)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataNguoiQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoNguoiQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoNguoiQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNguoiQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoNguoiQuanLy>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNguoiQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNguoiQuanLy> lst = new List<DtoNguoiQuanLy>();
        DtoNguoiQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoNguoiQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoNguoiQuanLy>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataNguoiQuanLySortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNguoiQuanLy> lst = new List<DtoNguoiQuanLy>();
        DtoNguoiQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoNguoiQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoNguoiQuanLy> getListDataBymatKhau(string matKhau)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNguoiQuanLyBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@matKhau", matKhau);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNguoiQuanLy> lst = new List<DtoNguoiQuanLy>();
        DtoNguoiQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoNguoiQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNguoiQuanLy> getListDataBySALT(int SALT)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNguoiQuanLyBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SALT", SALT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNguoiQuanLy> lst = new List<DtoNguoiQuanLy>();
        DtoNguoiQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoNguoiQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoNguoiQuanLy data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataNguoiQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoNguoiQuanLy data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNguoiQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymatKhau(string matKhau)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataNguoiQuanLyBymatKhau " , con);
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
        SqlCommand cmd = new SqlCommand("spDelDataNguoiQuanLyBySALT " , con);
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
        SqlCommand cmd = new SqlCommand("spDelDataNguoiQuanLyByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoNguoiQuanLy data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNguoiQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenDangNhap(DtoNguoiQuanLy data,string tenDangNhap)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNguoiQuanLyBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@tenDangNhap",tenDangNhap);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymatKhau(DtoNguoiQuanLy data,string matKhau)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNguoiQuanLyBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@matKhau",matKhau);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBySALT(DtoNguoiQuanLy data,int SALT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNguoiQuanLyBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@SALT",SALT);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
