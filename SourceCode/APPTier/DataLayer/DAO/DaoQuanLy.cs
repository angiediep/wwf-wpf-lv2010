
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
    private List<DtoQuanLy> extractData(SqlDataReader dr)
    {
        List<DtoQuanLy> lst = new List<DtoQuanLy>();
        DtoQuanLy data = null;
        while (dr.Read())
        {
            data = new DtoQuanLy();
            data.TENDANGNHAP = Convert.ToString(dr["tenDangNhap"]);
            data.MATKHAU = Convert.ToString(dr["matKhau"]);
            data.SALT = Convert.ToInt32(dr["SALT"]);
            data.EMAIL = Convert.ToString(dr["email"]);
            lst.Add(data);
        }
        return lst;
    }
    private void bindData(SqlParameterCollection para, DtoQuanLy data)
    {
        para.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
        para.AddWithValue("@matKhau", data.MATKHAU);
        para.AddWithValue("@SALT", data.SALT);
        para.AddWithValue("@email", data.EMAIL);
    }
	public DtoQuanLy getDataById(string tenDangNhap)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoQuanLy> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoQuanLy>  getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataQuanLySortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoQuanLy> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoQuanLy> getListDataBymatKhau(string matKhau)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataQuanLyBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@matKhau", matKhau);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoQuanLy> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoQuanLy> getListDataBySALT(int SALT)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataQuanLyBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SALT", SALT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoQuanLy> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoQuanLy data)
    {
        int Id = -1;
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataQuanLy " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenDangNhap(DtoQuanLy data,string tenDangNhap)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataQuanLyBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.TENDANGNHAP = tenDangNhap;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymatKhau(DtoQuanLy data,string matKhau)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataQuanLyBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.MATKHAU = matKhau;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBySALT(DtoQuanLy data,int SALT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataQuanLyBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.SALT = SALT;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
