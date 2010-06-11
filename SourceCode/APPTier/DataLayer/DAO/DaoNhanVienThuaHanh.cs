
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
public class DaoNhanVienThuaHanh
{

	public DaoNhanVienThuaHanh()
	{
	}
	#region "ExportFile" 
    private List<DtoNhanVienThuaHanh> extractData(SqlDataReader dr)
    {
        List<DtoNhanVienThuaHanh> lst = new List<DtoNhanVienThuaHanh>();
        DtoNhanVienThuaHanh data = null;
        while (dr.Read())
        {
            data = new DtoNhanVienThuaHanh();
            data.MANV = Convert.ToInt32(dr["maNV"]);
            data.TENDANGNHAP = Convert.ToString(dr["tenDangNhap"]);
            data.MATKHAU = Convert.ToString(dr["matKhau"]);
            data.SALT = Convert.ToInt32(dr["SALT"]);
            data.EMAIL = Convert.ToString(dr["email"]);
            data.TENNV = Convert.ToString(dr["tenNV"]);
            data.DIENTHOAI = Convert.ToString(dr["dienThoai"]);
            lst.Add(data);
        }
        return lst;
    }
    private void bindData(SqlParameterCollection para, DtoNhanVienThuaHanh data)
    {

        para.AddWithValue("@maNV", data.MANV);
        para.AddWithValue("@tenDangNhap", data.TENDANGNHAP);
        para.AddWithValue("@matKhau", data.MATKHAU);
        para.AddWithValue("@SALT", data.SALT);
        para.AddWithValue("@email", data.EMAIL);
        para.AddWithValue("@tenNV", data.TENNV);
        para.AddWithValue("@dienThoai", data.DIENTHOAI);

    }
    /// <summary>
    /// this method drill to database to check that the username and password is vailid. Then, it returns the result.
    /// </summary>
    /// <param name="strUsername">the login name.</param>
    /// <param name="strPassword">the password</param>
    /// <returns>true:  login success.
    ///         false: login fail.</returns>
    public bool login(String strUsername, String strPassword)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection conn = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spLoginForNhanVienThuaHanh", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDangNhap", strUsername);
        cmd.Parameters.AddWithValue("@matKhau", strPassword);
        cmd.Parameters.Add("@result", SqlDbType.Int);
        cmd.Parameters["@result"].Direction = ParameterDirection.Output;

        conn.Open();
        cmd.ExecuteNonQuery();
        int result = int.Parse(cmd.Parameters["@result"].Value.ToString());
        return result == 1;
    }
	public DtoNhanVienThuaHanh getDataById(int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maNV", maNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = extractData(dr);
        con.Close();
        if (lst == null || lst.Count == 0)
            return null;
        return lst[0];

    }
	public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh>  getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataNhanVienThuaHanhSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataBytenDangNhap(string tenDangNhap)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataBymatKhau(string matKhau)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@matKhau", matKhau);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataBySALT(int SALT)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SALT", SALT);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataByemail(string email)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoNhanVienThuaHanh> getListDataBytenNV(string tenNV)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataNhanVienThuaHanhBytenNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenNV", tenNV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoNhanVienThuaHanh> lst = extractData(dr);
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoNhanVienThuaHanh data)
    {
        int Id = -1;
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        bindData(cmd.Parameters, data);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoNhanVienThuaHanh data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
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
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanh " , con);
        cmd.CommandType = CommandType.StoredProcedure;

        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaNV(DtoNhanVienThuaHanh data,int maNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBymaNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.MANV = maNV;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenDangNhap(DtoNhanVienThuaHanh data,string tenDangNhap)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBytenDangNhap " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.TENDANGNHAP = tenDangNhap;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymatKhau(DtoNhanVienThuaHanh data,string matKhau)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBymatKhau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.MATKHAU = matKhau;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBySALT(DtoNhanVienThuaHanh data,int SALT)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBySALT " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.SALT = SALT;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByemail(DtoNhanVienThuaHanh data,string email)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhByemail " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.EMAIL = email;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenNV(DtoNhanVienThuaHanh data,string tenNV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataNhanVienThuaHanhBytenNV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        data.TENNV = tenNV;
        bindData(cmd.Parameters, data);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
