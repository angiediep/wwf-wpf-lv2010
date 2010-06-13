
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
public class DaoCongViec
{

	public DaoCongViec()
	{
	}
	#region "ExportFile" 
	public DtoCongViec getDataById(int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetDataCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DtoCongViec data = null;
        while (dr.Read())
        {
            data = new DtoCongViec();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.TENCV =Convert.ToString(dr["tenCV"]);
			data.NGAYBATDAU =Convert.ToInt32(dr["ngayBatDau"]);
			data.NGAYKETTHUC =Convert.ToInt32(dr["ngayKetThuc"]);
			data.MOTA =Convert.ToString(dr["moTa"]);
		}
        con.Close();
        return data;
    }
	public DataTable getDataTable()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
	public List<DtoCongViec>  getDataList()
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoCongViec> lst = new List<DtoCongViec>();
        DtoCongViec data = null;
        while (dr.Read())
        {
            data = new DtoCongViec();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.TENCV =Convert.ToString(dr["tenCV"]);
			data.NGAYBATDAU =Convert.ToInt32(dr["ngayBatDau"]);
			data.NGAYKETTHUC =Convert.ToInt32(dr["ngayKetThuc"]);
			data.MOTA =Convert.ToString(dr["moTa"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoCongViec>  getDataListSortBy(string col, bool flag)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        string sp ="spGetListDataCongViecSortBy";
        SqlCommand cmd = new SqlCommand(sp , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@flag", flag); 
        cmd.Parameters.AddWithValue("@col", col); 
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoCongViec> lst = new List<DtoCongViec>();
        DtoCongViec data = null;
        while (dr.Read())
        {
            data = new DtoCongViec();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.TENCV =Convert.ToString(dr["tenCV"]);
			data.NGAYBATDAU =Convert.ToInt32(dr["ngayBatDau"]);
			data.NGAYKETTHUC =Convert.ToInt32(dr["ngayKetThuc"]);
			data.MOTA =Convert.ToString(dr["moTa"]);
            lst.Add(data);
		}
        con.Close();
        return lst;
    }
	public List<DtoCongViec> getListDataBytenCV(string tenCV)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataCongViecBytenCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenCV", tenCV);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoCongViec> lst = new List<DtoCongViec>();
        DtoCongViec data = null;
        while (dr.Read())
        {
            data = new DtoCongViec();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.TENCV =Convert.ToString(dr["tenCV"]);
			data.NGAYBATDAU =Convert.ToInt32(dr["ngayBatDau"]);
			data.NGAYKETTHUC =Convert.ToInt32(dr["ngayKetThuc"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoCongViec> getListDataByngayBatDau(int ngayBatDau)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataCongViecByngayBatDau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDau", ngayBatDau);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoCongViec> lst = new List<DtoCongViec>();
        DtoCongViec data = null;
        while (dr.Read())
        {
            data = new DtoCongViec();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.TENCV =Convert.ToString(dr["tenCV"]);
			data.NGAYBATDAU =Convert.ToInt32(dr["ngayBatDau"]);
			data.NGAYKETTHUC =Convert.ToInt32(dr["ngayKetThuc"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public List<DtoCongViec> getListDataByngayKetThuc(int ngayKetThuc)    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spGetListDataCongViecByngayKetThuc " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        List<DtoCongViec> lst = new List<DtoCongViec>();
        DtoCongViec data = null;
        while (dr.Read())
        {
            data = new DtoCongViec();
			data.MACV =Convert.ToInt32(dr["maCV"]);
			data.TENCV =Convert.ToString(dr["tenCV"]);
			data.NGAYBATDAU =Convert.ToInt32(dr["ngayBatDau"]);
			data.NGAYKETTHUC =Convert.ToInt32(dr["ngayKetThuc"]);
            lst.Add(data);
		}
        dr.Close();
        con.Close();
        return lst;
    }
	public int insertData(DtoCongViec data)
    {
        int Id = -1;
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spInsertDataCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenCV", data.TENCV);
		cmd.Parameters.AddWithValue("@ngayBatDau", data.NGAYBATDAU);
		cmd.Parameters.AddWithValue("@ngayKetThuc", data.NGAYKETTHUC);
		cmd.Parameters.AddWithValue("@moTa", data.MOTA);
        con.Open();
        Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
	public bool deleteData(DtoCongViec data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", data.MACV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBytenCV(string tenCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataCongViecBytenCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@tenCV", tenCV);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayBatDau(int ngayBatDau)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataCongViecByngayBatDau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayBatDau", ngayBatDau);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataByngayKetThuc(int ngayKetThuc)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataCongViecByngayKetThuc " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool deleteDataBymoTa(string moTa)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spDelDataCongViecBymoTa " , con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@moTa", moTa);

        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateData(DtoCongViec data)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataCongViec " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@tenCV", data.TENCV);
		cmd.Parameters.AddWithValue("@ngayBatDau", data.NGAYBATDAU);
		cmd.Parameters.AddWithValue("@ngayKetThuc", data.NGAYKETTHUC);
		cmd.Parameters.AddWithValue("@moTa", data.MOTA);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBymaCV(DtoCongViec data,int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataCongViecBymaCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@tenCV", data.TENCV);
		cmd.Parameters.AddWithValue("@ngayBatDau", data.NGAYBATDAU);
		cmd.Parameters.AddWithValue("@ngayKetThuc", data.NGAYKETTHUC);
		cmd.Parameters.AddWithValue("@moTa", data.MOTA);
		cmd.Parameters.AddWithValue("@maCV",maCV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataBytenCV(DtoCongViec data,string tenCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataCongViecBytenCV " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@ngayBatDau", data.NGAYBATDAU);
		cmd.Parameters.AddWithValue("@ngayKetThuc", data.NGAYKETTHUC);
		cmd.Parameters.AddWithValue("@moTa", data.MOTA);
		cmd.Parameters.AddWithValue("@tenCV",tenCV);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayBatDau(DtoCongViec data,int ngayBatDau)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataCongViecByngayBatDau " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@tenCV", data.TENCV);
		cmd.Parameters.AddWithValue("@ngayKetThuc", data.NGAYKETTHUC);
		cmd.Parameters.AddWithValue("@moTa", data.MOTA);
		cmd.Parameters.AddWithValue("@ngayBatDau",ngayBatDau);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
	public bool updateDataByngayKetThuc(DtoCongViec data,int ngayKetThuc)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString(); 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("spUpdateDataCongViecByngayKetThuc " , con);
        cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@maCV", data.MACV);
		cmd.Parameters.AddWithValue("@tenCV", data.TENCV);
		cmd.Parameters.AddWithValue("@ngayBatDau", data.NGAYBATDAU);
		cmd.Parameters.AddWithValue("@moTa", data.MOTA);
		cmd.Parameters.AddWithValue("@ngayKetThuc",ngayKetThuc);
        con.Open();
        cmd.ExecuteNonQuery();
        return true;
    }

    public int getNumOfLateCompletion(int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_laySoLanCongViecTreHan ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);
        cmd.Parameters.Add("@soLanTreHan",SqlDbType.Int);
        cmd.Parameters["@soLanTreHan"].Direction = ParameterDirection.Output;

        con.Open();
        cmd.ExecuteNonQuery();
        int result = 0;
        int.TryParse(cmd.Parameters["@soLanTreHan"].Value.ToString(),out result);
        return result;
    }
    public int getNumOfEarlyCompletion(int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_laySoLanCongViecSomHan ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);
        cmd.Parameters.Add("@soLanSomHan", SqlDbType.Int);
        cmd.Parameters["@soLanSomHan"].Direction = ParameterDirection.Output;

        con.Open();
        cmd.ExecuteNonQuery();
        int result = 0;
        int.TryParse(cmd.Parameters["@soLanSomHan"].Value.ToString(),out result);
        return result;
    }
    public int getNumOfExecution(int maCV)
    {
        DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("sp_laySoLanThucHienCongViec ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@maCV", maCV);
        cmd.Parameters.Add("@soLanThucHien", SqlDbType.Int);
        cmd.Parameters["@soLanThucHien"].Direction = ParameterDirection.Output;

        con.Open();
        cmd.ExecuteNonQuery();
        int result = 0;
        int.TryParse(cmd.Parameters["@soLanThucHien"].Value.ToString(), out result);
        return result;
    }

	#endregion
}

}
