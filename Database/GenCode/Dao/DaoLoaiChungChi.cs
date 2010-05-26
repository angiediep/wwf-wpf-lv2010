
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
public class DaoLoaiChungChi
{

	public DaoLoaiChungChi()
	{
	}
	#region "ExportFile" 
	public DtoLoaiChungChi getDataById(int maLCC)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataLoaiChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maLCC", maLCC);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoLoaiChungChi data = null;
        while (dr.Read())
        {
            data = new DtoLoaiChungChi();
			data.MALCC =Convert.ToInt32(dr["maLCC"]);
			data.TENLCC =Convert.ToString(dr["tenLCC"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataLoaiChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoLoaiChungChi>  getDataList()
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataLoaiChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoLoaiChungChi> lst = new List<DtoLoaiChungChi>();
        DtoLoaiChungChi data = null;
        while (dr.Read())
        {
            data = new DtoLoaiChungChi();
			data.MALCC =Convert.ToInt32(dr["maLCC"]);
			data.TENLCC =Convert.ToString(dr["tenLCC"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoLoaiChungChi>  getDataListSortBy(string col, bool flag)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataLoaiChungChiSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoLoaiChungChi> lst = new List<DtoLoaiChungChi>();
        DtoLoaiChungChi data = null;
        while (dr.Read())
        {
            data = new DtoLoaiChungChi();
			data.MALCC =Convert.ToInt32(dr["maLCC"]);
			data.TENLCC =Convert.ToString(dr["tenLCC"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public int insertData(DtoLoaiChungChi data)
    {
        int Id = -1;
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataLoaiChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenLCC", data.TENLCC);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoLoaiChungChi data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataLoaiChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maLCC", data.MALCC);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBytenLCC(string tenLCC)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataLoaiChungChiBytenLCC " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenLCC", tenLCC);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoLoaiChungChi data)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataLoaiChungChi " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maLCC", data.MALCC);
		cmd.Parameters.AddWithValue("@tenLCC", data.TENLCC);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaLCC(DtoLoaiChungChi data,int maLCC)
    {
        string conStr = Config.CONSTRING;
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataLoaiChungChiBymaLCC " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenLCC", data.TENLCC);
		cmd.Parameters.AddWithValue("@maLCC",maLCC);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	#endregion
}

}
