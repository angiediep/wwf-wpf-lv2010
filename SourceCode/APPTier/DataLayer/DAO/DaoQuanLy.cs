
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
public class DaoQuanLy
{

	public DaoQuanLy()
	{
	}
	#region "ExportFile" 
	public DtoQuanLy getDataById(string tenDangNhap)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoQuanLy();
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
        SqlCommand cmd = new SqlCommand("spGetListDataQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoQuanLy>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoQuanLy> lst = new List<DtoQuanLy>();
        DtoQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoQuanLy>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataQuanLySortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoQuanLy> lst = new List<DtoQuanLy>();
        DtoQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
			data.EMAIL =Convert.ToString(dr["email"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoQuanLy> getListDataBymatKhau(string matKhau)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataQuanLyBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@matKhau", matKhau);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoQuanLy> lst = new List<DtoQuanLy>();
        DtoQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoQuanLy> getListDataBySALT(int SALT)    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataQuanLyBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SALT", SALT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoQuanLy> lst = new List<DtoQuanLy>();
        DtoQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoQuanLy();
			data.TENDANGNHAP =Convert.ToString(dr["tenDangNhap"]);
			data.MATKHAU =Convert.ToString(dr["matKhau"]);
			data.SALT =Convert.ToInt32(dr["SALT"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoQuanLy data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoQuanLy data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataQuanLy " , con);
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
        SqlCommand cmd = new SqlCommand("spDelDataQuanLyBymatKhau " , con);
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
        SqlCommand cmd = new SqlCommand("spDelDataQuanLyBySALT " , con);
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
        SqlCommand cmd = new SqlCommand("spDelDataQuanLyByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoQuanLy data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenDangNhap(DtoQuanLy data,string tenDangNhap)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataQuanLyBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@matKhau", data.MATKHAU);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@tenDangNhap",tenDangNhap);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymatKhau(DtoQuanLy data,string matKhau)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataQuanLyBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
		cmd.Parameters.AddWithValue("@SALT", data.SALT);
		cmd.Parameters.AddWithValue("@email", data.EMAIL);
		cmd.Parameters.AddWithValue("@matKhau",matKhau);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBySALT(DtoQuanLy data,int SALT)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataQuanLyBySALT " , con);
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
