
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
    public class DaoGhiChu
    {

        public DaoGhiChu()
        {
        }
        #region "ExportFile"
        public DtoGhiChu getDataById(int maGC)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetDataGhiChu ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maGC", maGC);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DtoGhiChu data = null;
            while (dr.Read())
            {
                data = new DtoGhiChu();
                data.MAGC = Convert.ToInt32(dr["maGC"]);
                data.GHICHU = Convert.ToString(dr["GhiChu"]);
                data.MATD = Convert.ToInt32(dr["maTD"]);
            }
            con.Close();
            return data;
        }
        public DataTable getDataTable()
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataGhiChu ", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public List<DtoGhiChu> getDataList()
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataGhiChu ", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoGhiChu> lst = new List<DtoGhiChu>();
            DtoGhiChu data = null;
            while (dr.Read())
            {
                data = new DtoGhiChu();
                data.MAGC = Convert.ToInt32(dr["maGC"]);
                data.GHICHU = Convert.ToString(dr["GhiChu"]);
                data.MATD = Convert.ToInt32(dr["maTD"]);
                lst.Add(data);
            }
            con.Close();
            return lst;
        }
        public List<DtoGhiChu> getDataListSortBy(string col, bool flag)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sp = "spGetListDataGhiChuSortBy";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.Parameters.AddWithValue("@col", col);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoGhiChu> lst = new List<DtoGhiChu>();
            DtoGhiChu data = null;
            while (dr.Read())
            {
                data = new DtoGhiChu();
                data.MAGC = Convert.ToInt32(dr["maGC"]);
                data.GHICHU = Convert.ToString(dr["GhiChu"]);
                data.MATD = Convert.ToInt32(dr["maTD"]);
                lst.Add(data);
            }
            con.Close();
            return lst;
        }
        public List<DtoGhiChu> getListDataByMaTD(int maTD)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layGhiChuTheoMaTD ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", maTD);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoGhiChu> lst = new List<DtoGhiChu>();
            DtoGhiChu data = null;
            while (dr.Read())
            {
                data = new DtoGhiChu();
                data.MAGC = Convert.ToInt32(dr["maGC"]);
                data.GHICHU = Convert.ToString(dr["GhiChu"]);
                lst.Add(data);
            }
            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoGhiChu> getListDataByMaCVMaDT(int maCV, int maDT)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layGhiChuTheoMaCVMaDT ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maCV", maCV);
            cmd.Parameters.AddWithValue("@maDT", maDT);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoGhiChu> lst = new List<DtoGhiChu>();
            DtoGhiChu data = null;
            while (dr.Read())
            {
                data = new DtoGhiChu();
                data.MAGC = Convert.ToInt32(dr["maGC"]);
                data.GHICHU = Convert.ToString(dr["GhiChu"]);
                lst.Add(data);
            }
            dr.Close();
            con.Close();
            return lst;
        }
        public int insertData(DtoGhiChu data)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spInsertDataGhiChu ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GhiChu", data.GHICHU);
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            return Id;
        }
        public bool deleteData(DtoGhiChu data)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataGhiChu ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maGC", data.MAGC);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataByGhiChu(string GhiChu)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataGhiChuByGhiChu ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GhiChu", GhiChu);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataBymaTD(int maTD)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataGhiChuBymaTD ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", maTD);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateData(DtoGhiChu data)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataGhiChu ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maGC", data.MAGC);
            cmd.Parameters.AddWithValue("@GhiChu", data.GHICHU);
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataBymaGC(DtoGhiChu data, int maGC)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataGhiChuBymaGC ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GhiChu", data.GHICHU);
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@maGC", maGC);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataByGhiChu(DtoGhiChu data, string GhiChu)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataGhiChuByGhiChu ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maGC", data.MAGC);
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@GhiChu", GhiChu);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        #endregion

        public void updateGhiChuByMaTD(DtoGhiChu ghichu)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            string sql = "Update GhiChu Set GhiChu = @GhiChu, maTD = @maTD Where maTD = @maTD";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@GhiChu", SqlDbType.Text).Value = ghichu.GHICHU;
            cmd.Parameters.Add("@maTD", SqlDbType.Int).Value = ghichu.MATD;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int getIDTreHan(DtoTienDo td)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select gc.maGC from CongViec cv, TienDo td, DOTTHI dt, GhiChu gc where td.maCV = cv.maCV and td.maDT = dt.maDT and gc.maTD = td.maTD and cv.maCV = @maCV and dt.maDT = @maDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = td.MACV;
            cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = td.MADT;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int res = -1;
            while (dr.Read())
            {
                object o = dr["maGC"];
                if (o != null)
                    res = int.Parse(o.ToString());
            }
            con.Close();
            return res;
        }
    }

}
