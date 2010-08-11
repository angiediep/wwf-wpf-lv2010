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
    public class DaoTienDo
    {

        public DaoTienDo()
        {
        }

        public int getNgayBatDau()
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);

            string sql = "select Min(ngayBatDau) from CongViec";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int getNgayKetThuc()
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);

            string sql = "select Max(ngayKetThuc) from CongViec";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

          #region "ExportFile
        /// <summary>
        /// L?y thông tin ti?n d? c?a các côn vi?c du?c phân công cho m?t nhân viên
        /// c? th? và chua du?c th?c hi?n.
        /// </summary>
        /// <param name="maNV">m? nhân viên</param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataUpcomingByMaNV(int maNV)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDSapDienRaCuaMotNhanVien", conn);
            cmd.Parameters.AddWithValue("@maNV", maNV);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;

        }
        /// <summary>
        /// L?y thông tin theo d?i ti?n d? c?a t?t c? các công vi?c s?p di?n ra trong m?t d?t thi c? th?.
        /// </summary>
        /// <param name="maDT"></param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataUpcomingByMaDT(int maDT)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDSapDienRaCuaMotDotThi", conn);
            cmd.Parameters.AddWithValue("@maDT", maDT);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;

        }

        /// <summary>
        /// L?y thông tin theo d?i ti?n d? c?a t?t c? các công vi?c s?p di?n ra.
        /// </summary>
        /// <returns></returns>
        public List<DtoTienDo> getListDataUpcoming()
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDSapDienRa", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;

        }
        /// <summary>
        /// L?y thông tin theo d?i ti?n d? công vi?c dang th?c hi?n, c?a m?t nhân viên
        /// b?t k?
        /// </summary>
        /// <param name="maDT">M? nhân viên</param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataOnGoingByMaNV(int maNV)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDDangDienRaCuaMotNhanVien", conn);
            cmd.Parameters.AddWithValue("@maNV", maNV);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;

        }
        /// <summary>
        /// L?y thông tin theo d?i ti?n d? c?a nh?ng công vi?c dang di?n ra trong m?t d?t thi b?t k?
        /// </summary>
        /// <param name="maDT">M? d?t thi</param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataOnGoingByMaDT(int maDT)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDDangDienRaCuaMotDotThi", conn);
            cmd.Parameters.AddWithValue("@maDT", maDT);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;

        }
        /// <summary>
        /// L?y toàn b? thông tin theo d?i ti?n d? c?a các công vi?c dang di?n ra
        /// </summary>
        /// <returns></returns>
        public List<DtoTienDo> getListDataOnGoing()
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDDangDienRa", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;
        }
        /// <summary>
        /// l?y thông tin theo d?i ti?n d? c?a các công vi?c d? hoàn thành c?a m?t nhân viên
        /// </summary>
        /// <param name="maNV">M? nhân viên</param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataCompletedByMaNV(int maNV)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDDaHoanThanhCuaMotNhanVien", conn);
            cmd.Parameters.AddWithValue("@maNV", maNV);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;
        }
        /// <summary>
        /// L?y thông tin theo d?i ti?n d? c?a các công vi?c d? hoàn thành trong m?t d?t thi b?t k?.
        /// </summary>
        /// <param name="maDT">m? d?t thi c?n l?y thông tin ti?n d?.</param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataCompletedByMaDT(int maDT)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDDaHoanThanhCuaMotDotThi", conn);
            cmd.Parameters.AddWithValue("@maDT", maDT);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;
        }

        /// <summary>
        /// L?y toàn b? n?i dung theo d?i ti?n d? c?a các công vi?c d? hoàn thành.
        /// </summary>
        /// <returns></returns>
        public List<DtoTienDo> getListDataCompleted()
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layTDDaHoanThanh", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;
        }
        /// <summary>
        /// L?y danh sách thông tin ti?n d? c?a các công vi?c k?t thúc s?m h?n trong m?t d?t thi
        /// </summary>
        /// <param name="maDT">m? d?t thi dang xét</param>
        /// <returns>Danh sách ti?n d? s?m h?n</returns>
        public List<DtoTienDo> getListDataEarlyByMaDT(int maDT)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layDSCongViecSomHan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maDT", maDT);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;
        }
        /// <summary>
        /// L?y danh sách thông tin ti?n d? c?a các công  vi?c b? tr? h?n trong m?t d?t thi.
        /// </summary>
        /// <param name="maDT">M? d?t thi dang xét</param>
        /// <returns>Danh sách thông tin ti?n d? c?a các công vi?c tr? h?n.</returns>
        public List<DtoTienDo> getListDataDelayedByMaDT(int maDT)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layDSCongViecTreHan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maDT", maDT);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;
        }
        /// <summary>
        /// l?y danh sách công vi?c du?c phân công cho m?t nhân viên b?t k?
        /// qua các k? thi.
        /// </summary>
        /// <param name="maNV">m? nhân viên c?n xem danh sách phân công.</param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataByMaNV(int maNV, DateTime startDay, DateTime endDay)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layDSTDTheoMaNVVaThoiGian ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maNV", maNV);
            cmd.Parameters.AddWithValue("@startDay", startDay);
            cmd.Parameters.AddWithValue("@endDay", endDay);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        /// <summary>
        /// l?y danh sách công vi?c du?c phân công cho m?t nhân viên b?t k?
        /// qua các k? thi.
        /// </summary>
        /// <param name="maNV">m? nhân viên c?n xem danh sách phân công.</param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataByMaNV(int maNV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layDSTDTheoMaNV ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maNV", maNV);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getListDataBymaCV(int maCV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDoBymaCV ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maCV", maCV);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getListDataBymaDT(int maDT)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDoBymaDT ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maDT", maDT);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getListDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayKetThucThucTe ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", ngayKetThucThucTe);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getListDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayBatDauThucTe ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", ngayBatDauThucTe);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getListDataByngayKetThucQuyDinh(DateTime ngayKetThucQuyDinh)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayKetThucQuyDinh ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", ngayKetThucQuyDinh);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getListDataByngayBatDauQuyDinh(DateTime ngayBatDauQuyDinh)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDoByngayBatDauQuyDinh ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", ngayBatDauQuyDinh);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getListDataBykhoiLuongCVHT(int khoiLuongCVHT)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDoBykhoiLuongCVHT ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", khoiLuongCVHT);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);
            dr.Close();
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getListDataBytongKhoiLuongCV(int tongKhoiLuongCV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDoBytongKhoiLuongCV ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", tongKhoiLuongCV);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);
            dr.Close();
            con.Close();
            return lst;
        }

        /// <summary>
        /// L?y danh sách thông tin theo d?i ti?n đ? th?c hi?n m?t công vi?c c? th? theo các tiêu chí khác nhau.
        /// </summary>
        /// <param name="maCV">M? công vi?c c?n l?y thông tin theo d?i</param>
        /// <param name="maNV">M? nhân viên th?c hi?n công vi?c.
        ///  0: Xét m?i nhân viên
        ///  >0: xét m?t nhân viên c? th?.</param>
        /// <param name="from">gi?i h?n th?i gian th?c t? công vi?c đư?c th?c thi.
        /// null: không gi?i h?n th?i gian
        /// != null:ch? xét các công vi?c di?n ra trong th?i gian này.
        /// from và to là hai tham s? ph?i đ?ng th?i null ho?c khác null.
        /// </param>
        /// <param name="to">
        /// gi?i h?n th?i gian th?c t? công vi?c đư?c th?c thi.
        /// null: không gi?i h?n th?i gian
        /// != null:ch? xét các công vi?c di?n ra trong th?i gian này.
        /// from và to là hai tham s? ph?i đ?ng th?i null ho?c khác null.
        /// </param>
        /// <returns></returns>
        public List<DtoTienDo> getListDataByWorks(int maCV, int maNV, DateTime from, DateTime to)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_layDSTDCuaMotCongViec", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maCV", maCV);
            cmd.Parameters.AddWithValue("@maNV", maNV);
            if (DateTime.Compare(from, DateTime.MinValue) == 0)
                cmd.Parameters.AddWithValue("@from", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@from", from);

            if (DateTime.Compare(to, DateTime.MinValue) == 0)
                cmd.Parameters.AddWithValue("@to", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@to", to);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            conn.Close();
            return lst;
        }

        public List<DtoTienDo> getDataList()
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDo ", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = new List<DtoTienDo>();
            DtoTienDo data = null;
            while (dr.Read())
            {
                data = new DtoTienDo();
                data.MATD = Convert.ToInt32(dr["maTD"]);
                data.TONGKHOILUONGCV = Convert.ToInt32(dr["tongKhoiLuongCV"]);
                data.KHOILUONGCVHT = Convert.ToInt32(dr["khoiLuongCVHT"]);
                data.NGAYBATDAUQUYDINH = Convert.ToDateTime(dr["ngayBatDauQuyDinh"]);
                data.NGAYKETTHUCQUYDINH = Convert.ToDateTime(dr["ngayKetThucQuyDinh"]);
                data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);
                data.NGAYKETTHUCTHUCTE = Convert.ToDateTime(dr["ngayKetThucThucTe"]);
                data.MADT = Convert.ToInt32(dr["maDT"]);
                data.MACV = Convert.ToInt32(dr["maCV"]);
                data.MANV = Convert.ToInt32(dr["maNV"]);
                lst.Add(data);
            }
            con.Close();
            return lst;
        }
        public List<DtoTienDo> getDataListSortBy(string col, bool flag)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sp = "spGetListDataTienDoSortBy";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.Parameters.AddWithValue("@col", col);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> lst = extractData(dr);

            dr.Close();
            con.Close();
            return lst;
        }
        public DataTable getDataTable()
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetListDataTienDo ", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DtoTienDo getDataById(int maTD)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spGetDataTienDo ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", maTD);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DtoTienDo data = null;
            while (dr.Read())
            {
                data = new DtoTienDo();
                data.MATD = Convert.ToInt32(dr["maTD"]);
                data.TONGKHOILUONGCV = Convert.ToInt32(dr["tongKhoiLuongCV"]);
                data.KHOILUONGCVHT = Convert.ToInt32(dr["khoiLuongCVHT"]);

                if (dr["ngayBatDauThucTe"] == DBNull.Value)
                    data.NGAYBATDAUTHUCTE = DateTime.MinValue;
                else
                    data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);

                if (dr["ngayKetThucThucTe"] == DBNull.Value)
                    data.NGAYKETTHUCTHUCTE = DateTime.MinValue;
                else
                    data.NGAYKETTHUCTHUCTE = Convert.ToDateTime(dr["ngayKetThucThucTe"]);
                data.MADT = Convert.ToInt32(dr["maDT"]);
                data.MACV = Convert.ToInt32(dr["maCV"]);
                data.MANV = Convert.ToInt32(dr["maNV"]);
            }
            con.Close();
            return data;
        }
        private List<DtoTienDo> extractData(SqlDataReader dr)
        {
            List<DtoTienDo> lst = new List<DtoTienDo>();
            DtoTienDo data = null;
            while (dr.Read())
            {
                data = new DtoTienDo();
                data.MATD = Convert.ToInt32(dr["maTD"]);
                data.TONGKHOILUONGCV = Convert.ToInt32(dr["tongKhoiLuongCV"]);
                data.KHOILUONGCVHT = Convert.ToInt32(dr["khoiLuongCVHT"]);
                data.NGAYBATDAUQUYDINH = Convert.ToDateTime(dr["ngayBatDauQuyDinh"]);
                data.NGAYKETTHUCQUYDINH = Convert.ToDateTime(dr["ngayKetThucQuyDinh"]);

                if (dr["ngayBatDauThucTe"] == DBNull.Value)
                    data.NGAYBATDAUTHUCTE = DateTime.MinValue;
                else
                    data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);

                if (dr["ngayKetThucThucTe"] == DBNull.Value)
                    data.NGAYBATDAUTHUCTE = DateTime.MinValue;
                else
                    data.NGAYKETTHUCTHUCTE = Convert.ToDateTime(dr["ngayKetThucThucTe"]);

                data.MADT = Convert.ToInt32(dr["maDT"]);
                data.MACV = Convert.ToInt32(dr["maCV"]);
                data.MANV = Convert.ToInt32(dr["maNV"]);
                lst.Add(data);
            }
            return lst;
        }

        public int insertData(DtoTienDo data)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spInsertDataTienDo ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.Add("@ngayBatDauQuyDinh", SqlDbType.DateTime).Value = data.NGAYBATDAUQUYDINH; //.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.Add("@ngayKetThucQuyDinh", SqlDbType.DateTime).Value = data.NGAYKETTHUCQUYDINH; //.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            con.Open();
            try
            {
                Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {}
            return Id;
        }
        public bool deleteData(DtoTienDo data)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDo ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataBytongKhoiLuongCV(int tongKhoiLuongCV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoBytongKhoiLuongCV ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", tongKhoiLuongCV);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataBykhoiLuongCVHT(int khoiLuongCVHT)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoBykhoiLuongCVHT ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", khoiLuongCVHT);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataByngayBatDauQuyDinh(DateTime ngayBatDauQuyDinh)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoByngayBatDauQuyDinh ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", ngayBatDauQuyDinh);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataByngayKetThucQuyDinh(DateTime ngayKetThucQuyDinh)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoByngayKetThucQuyDinh ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", ngayKetThucQuyDinh);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoByngayBatDauThucTe ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", ngayBatDauThucTe);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoByngayKetThucThucTe ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", ngayKetThucThucTe);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataBymaDT(int maDT)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoBymaDT ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maDT", maDT);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataBymaCV(int maCV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoBymaCV ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maCV", maCV);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteDataBymaNV(int maNV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spDelDataTienDoBymaNV ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maNV", maNV);

            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateData(DtoTienDo data)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDo ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataBymaTD(DtoTienDo data, int maTD)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaTD ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@maTD", maTD);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataBytongKhoiLuongCV(DtoTienDo data, int tongKhoiLuongCV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBytongKhoiLuongCV ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", tongKhoiLuongCV);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataBykhoiLuongCVHT(DtoTienDo data, int khoiLuongCVHT)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBykhoiLuongCVHT ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", khoiLuongCVHT);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataByngayBatDauQuyDinh(DtoTienDo data, DateTime ngayBatDauQuyDinh)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayBatDauQuyDinh ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", ngayBatDauQuyDinh);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataByngayKetThucQuyDinh(DtoTienDo data, DateTime ngayKetThucQuyDinh)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayKetThucQuyDinh ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", ngayKetThucQuyDinh);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataByngayBatDauThucTe(DtoTienDo data, DateTime ngayBatDauThucTe)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayBatDauThucTe ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", ngayBatDauThucTe);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataByngayKetThucThucTe(DtoTienDo data, DateTime ngayKetThucThucTe)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoByngayKetThucThucTe ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", ngayKetThucThucTe);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataBymaDT(DtoTienDo data, int maDT)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaDT ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maCV", data.MACV);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@maDT", maDT);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool updateDataBymaCV(DtoTienDo data, int maCV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spUpdateDataTienDoBymaCV ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", data.MATD);
            cmd.Parameters.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            cmd.Parameters.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            cmd.Parameters.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            cmd.Parameters.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            cmd.Parameters.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);
            cmd.Parameters.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);
            cmd.Parameters.AddWithValue("@maDT", data.MADT);
            cmd.Parameters.AddWithValue("@maNV", data.MANV);
            cmd.Parameters.AddWithValue("@maCV", maCV);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        public void startWork(int maTD)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_batDauCongViec ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", maTD);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        public void finishWork(int maTD)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_ketThucCongViec ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maTD", maTD);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        #endregion
        private void bindData(SqlParameterCollection para, DtoTienDo data)
        {
            para.AddWithValue("@tongKhoiLuongCV", data.TONGKHOILUONGCV);
            para.AddWithValue("@khoiLuongCVHT", data.KHOILUONGCVHT);
            para.AddWithValue("@ngayBatDauQuyDinh", data.NGAYBATDAUQUYDINH);
            para.AddWithValue("@ngayKetThucQuyDinh", data.NGAYKETTHUCQUYDINH);
            if (data.NGAYKETTHUCTHUCTE.Year == DateTime.MinValue.Year)
                para.AddWithValue("@ngayBatDauThucTe", DBNull.Value);
            else
                para.AddWithValue("@ngayBatDauThucTe", data.NGAYBATDAUTHUCTE);

            if (data.NGAYKETTHUCTHUCTE.Year == DateTime.MinValue.Year)
                para.AddWithValue("@ngayKetThucThucTe", DBNull.Value);
            else
                para.AddWithValue("@ngayKetThucThucTe", data.NGAYKETTHUCTHUCTE);

            para.AddWithValue("@maDT", data.MADT);
            para.AddWithValue("@maCV", data.MACV);
            para.AddWithValue("@maNV", data.MANV);
        }
        public List<int> getListNVofCV(int p)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select * from TienDo where maCV=@maCV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> lst = new List<int>();
            while (dr.Read())
            {
                lst.Add(int.Parse(dr.GetValue(9).ToString()));
            }
            con.Close();
            return lst;
        }

        public string getTenNVByMaNV(int p)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);

            string sql = "select tenNV from NhanVienThuaHanh where maNV=@maNV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maNV", SqlDbType.Int).Value = p;

            con.Open();
            string res = cmd.ExecuteScalar().ToString();
            con.Close();
            return res;
        }

        public List<int> getMonthYearForChart()
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select Month(ngayKetThucThucTe) ,Year(ngayKetThucThucTe ) from TienDo group by Month(ngayKetThucThucTe) ,Year(ngayKetThucThucTe )";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> lst = new List<int>();
            while (dr.Read())
            {
                try
                {
                    lst.Add(int.Parse(dr.GetValue(0).ToString()));
                    lst.Add(int.Parse(dr.GetValue(1).ToString()));
                }
                catch
                {
                    lst.Add(-1);
                    lst.Add(-1);
                }
            }
            con.Close();
            return lst;
        }

        public int getTongKLCVByMonthYear(int month, int year)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select sum(tongKhoiLuongCV) from TienDo where maCV= 1 and Month(ngayKetThucThucTe) =@Month and Year(ngayKetThucThucTe )= @Year";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = month;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;

            con.Open();
            int res = -1;
            try
            {
                res = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            {
            }
            con.Close();
            return res;
        }

        public int getSumTS()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select sum(tongKhoiLuongCV)from TienDo where maCV=1";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getSumTS(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select td.tongKhoiLuongCV from TienDo td, DotThi dt where td.maCV=1 and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getSumCC()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select sum(tongKhoiLuongCV) from TienDo where maCV=15";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getSumCC(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select td.tongKhoiLuongCV from TienDo td, DotThi dt where td.maCV=15 and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public List<int> getMonthYearForChart2()
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select Month(ngayKetThucThucTe) ,Year(ngayKetThucThucTe ) from TienDo group by Month(ngayKetThucThucTe) ,Year(ngayKetThucThucTe)";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> lst = new List<int>();
            while (dr.Read())
            {
                try
                {
                    lst.Add(int.Parse(dr.GetValue(0).ToString()));
                    lst.Add(int.Parse(dr.GetValue(1).ToString()));
                }
                catch
                {
                    lst.Add(-1);
                    lst.Add(-1);
                }
            }
            con.Close();
            return lst;
        }

        public int getTongKLCVByMonthYear2(int month, int year)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select sum(tongKhoiLuongCV) from TienDo where maCV= 1 and Month(ngayKetThucThucTe) =@Month and Year(ngayKetThucThucTe )= @Year";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = month;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;

            con.Open();
            int res = -1;
            try
            {
                res = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            {
            }
            con.Close();
            return res;
        }

        public int getCVHoanThanhDungHanCT()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = " select count(*) from TienDo where ngayKetThucThucTe <= ngayKetThucQuyDinh";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCT(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = " select count(*) from TienDo td,  DotThi dt where td.ngayKetThucThucTe <= td.ngayKetThucQuyDinh and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCT()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = " select count(*) from TienDo where ngayKetThucThucTe > ngayKetThucQuyDinh";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCT(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td,  DotThi dt where ngayKetThucThucTe > ngayKetThucQuyDinh and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCDT()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo where ngayKetThucThucTe <= ngayKetThucQuyDinh and maCV <=7";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCDT(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td,  DotThi dt where ngayKetThucThucTe <= ngayKetThucQuyDinh and maCV <=7 and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCDT()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = " select count(*) from TienDo where ngayKetThucThucTe > ngayKetThucQuyDinh and maCV <=7";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCDT(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td,  DotThi dt where ngayKetThucThucTe > ngayKetThucQuyDinh and maCV <=7 and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCHT()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = " select count(*) from TienDo where ngayKetThucThucTe <= ngayKetThucQuyDinh and maCV > 7 and maCV <=14";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCHT(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td,  DotThi dt where ngayKetThucThucTe <= ngayKetThucQuyDinh and maCV > 7 and maCV <=14 and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCHT()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = " select count(*) from TienDo where ngayKetThucThucTe > ngayKetThucQuyDinh and maCV > 7 and maCV <=14";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCHT(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td,  DotThi dt where ngayKetThucThucTe > ngayKetThucQuyDinh and maCV > 7 and maCV <=14 and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCCI()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo where ngayKetThucThucTe <= ngayKetThucQuyDinh and maCV >14";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCCI(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td,  DotThi dt where ngayKetThucThucTe <= ngayKetThucQuyDinh and maCV >14 and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCCI()
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = " select count(*) from TienDo where ngayKetThucThucTe > ngayKetThucQuyDinh and maCV >14";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCCI(string tenDT)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td,  DotThi dt where ngayKetThucThucTe > ngayKetThucQuyDinh and maCV >14 and td.maDT = dt.maDT and dt.tenDotThi = @tenDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenDT", SqlDbType.NVarChar).Value = tenDT;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVChuaHTQuaCacDot(int month, int year)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count from TienDo where ngayKetThucThucTe > ngayKetThucQuyDinh and Month(ngayKetThucThucTe) =@Month and Year(ngayKetThucThucTe )= @Year";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = month;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;

            con.Open();
            int res = -1;
            try
            {
                res = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            {
            }
            con.Close();
            return res;
        }

        public List<string> getDotThiByMonthYear(int year, int month)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select maDT, tenDotThi from DotThi where Month(ngayThi) =@Month and Year(ngayThi)= @Year";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = month;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> lst = new List<string>();
            while (dr.Read())
            {
                try
                {
                    lst.Add(dr.GetValue(0).ToString());
                    lst.Add(dr.GetValue(1).ToString());
                }
                catch
                {
                    lst.Add(string.Empty);
                    lst.Add(string.Empty);
                }
            }
            con.Close();
            return lst;
        }

        public List<string> getDotThiNVDetail(int month, int year, int p)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = " select cv.tenCV, td.khoiLuongCVHT,  nv.tenNV, gc.GhiChu from TienDo td, CongViec cv, NhanVienThuaHanh nv, DOTTHI dt, GhiChu gc where td.maDT = dt.maDT and cv.maCV = td.maCV and nv.maNV = td.maNV and gc.maTD = td.maTD and td.ngayKetThucThucTe > td.ngayKetThucQuyDinh and Month(td.ngayKetThucThucTe) =@Month and Year(td.ngayKetThucThucTe )= @Year and dt.maDT = @maDT ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = month;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;
            cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = p;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> lst = new List<string>();
            while (dr.Read())
            {
                lst.Add(dr.GetValue(0).ToString());
                lst.Add(dr.GetValue(1).ToString());
                lst.Add(dr.GetValue(2).ToString());
                lst.Add(dr.GetValue(3).ToString());
            }
            con.Close();
            return lst;
        }

        public List<int> getListYearForComparisonStat()
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select distinct Year(ngayBatDauQuyDinh) from TienDo order by Year(ngayBatDauQuyDinh)";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> lst = new List<int>();
            while (dr.Read())
            {
                try
                {
                    lst.Add(int.Parse(dr.GetValue(0).ToString()));
                }
                catch
                {
                    continue;
                }
            }
            con.Close();
            return lst;
        }

        public List<int> getListMonthForComparisonStat(int year)
        {   
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select distinct Month(ngayKetThucQuyDinh) from TienDo where Year(ngayKetThucQuyDinh)=@Year order by Month(ngayKetThucQuyDinh)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            List<int> lst = new List<int>();
            while (dr.Read())
            {
                try
                {
                    lst.Add(int.Parse(dr.GetValue(0).ToString()));
                }
                catch
                {
                    continue;
                }
            }
            con.Close();
            return lst;
        }

        public int getSumTS(int y, int m)
        {
            int Id = 0;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select sum(td.tongKhoiLuongCV) from TienDo td, DOTTHI dt where maCV=1 and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            try
            {
                Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
            }
            con.Close();
            return Id;
        }

        public int getSumCC(int y, int m)
        {
            int Id = 0;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select sum(tongKhoiLuongCV) from TienDo td, DOTTHI dt where maCV=15 and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            try
            {
                Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
            }
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCT(int y, int m)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe <= td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCT(int y, int m)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe > td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCDT(int y, int m)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe <= td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y and td.maCV <=7";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCDT(int y, int m)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe > td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y and td.maCV <=7";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCHT(int y, int m)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe <= td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y and td.maCV > 7 and td.maCV <=14";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCHT(int y, int m)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe > td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y and td.maCV > 7 and td.maCV <=14";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;
            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhDungHanCCI(int y, int m)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe <= td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y and td.maCV >14";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public int getCVHoanThanhTreHanCCI(int y, int m)
        {
            int Id = -1;
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe > td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y and td.maCV >14";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public List<string> getNVTreHan(int p, int y, int m)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select cv.tenCV, td.khoiLuongCVHT,  nv.tenNV, gc.GhiChu from TienDo td, CongViec cv, NhanVienThuaHanh nv, DOTTHI dt, GhiChu gc where td.maDT = dt.maDT and cv.maCV = td.maCV and nv.maNV = td.maNV and gc.maTD = td.maTD and td.ngayKetThucThucTe > td.ngayKetThucQuyDinh and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y and dt.maDT = @Ma";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;
            cmd.Parameters.Add("@Ma", SqlDbType.Int).Value = p;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> lst = new List<string>();
            while (dr.Read())
            {
                lst.Add(dr.GetValue(0).ToString());
                lst.Add(dr.GetValue(1).ToString());
                lst.Add(dr.GetValue(2).ToString());
                lst.Add(dr.GetValue(3).ToString());
            }
            con.Close();
            return lst;
        }

        public List<string> getListNVTreHan(int y, int m)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select nv.tenNV, dt.tenDotThi from NhanVienThuaHanh nv, tienDo td, DOTTHI dt where nv.maNV = td.maNV and td.ngayKetThucThucTe > td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> lst = new List<string>();
            while (dr.Read())
            {
                lst.Add(dr.GetValue(0).ToString());
                lst.Add(dr.GetValue(1).ToString());
            }
            con.Close();
            return lst;
        }

        public int getTongKLCVByMaDT(int p)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select sum(tongKhoiLuongCV) from TienDo td, DOTTHi dt	where maCV= 1 and td.maDT = dt.maDT and dt.maDT = @Ma group by td.maDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Ma", SqlDbType.Int).Value = p;

            con.Open();
            int res = -1;
            try
            {
                res = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            {
                res = -1;
            }
            con.Close();
            return res;
        }

        public int getTongKLCVByMaDT2(int p)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select sum(tongKhoiLuongCV) from TienDo td, DOTTHi dt where maCV= 15 and td.maDT = dt.maDT and dt.maDT = @Ma group by td.maDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Ma", SqlDbType.Int).Value = p;

            con.Open();
            int res = -1;
            try
            {
                res = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            {
                res = -1;
            }
            con.Close();
            return res;
        }

        public int getTongKLCVByMonYear(int y, int m)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select count(*) from TienDo td, DotThi dt where td.ngayKetThucThucTe > td.ngayKetThucQuyDinh and td.maDT = dt.maDT and Month(dt.ngayThi) = @M and Year(dt.ngayThi) = @Y group by td.maDT";
            SqlCommand cmd = new SqlCommand(sql, con); cmd.Parameters.Add("@M", SqlDbType.Int).Value = m;
            cmd.Parameters.Add("@Y", SqlDbType.Int).Value = y;

            con.Open();
            int res = -1;
            try
            {
                res = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            {
                res = -1;
            }
            con.Close();
            return res;
        }

        public List<string> getMsgToAlert(string p, int type)
        {
            DataConnector dc = new DataConnector(); 
			string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = string.Empty;
			DateTime x = DateTime.Now.Date;
			TimeSpan ts= new TimeSpan(24,0,0);
			DateTime y = x.Add(ts);
            if (type == 1)
                sql = "select * from TienDo td where td.maNV in (select nv.maNV from NhanVienThuaHanh nv where nv.tenDangNhap = @Ten) and td.NgayBatDauQuyDinh = @NgayMai and td.NgayBatDauThucTe is null";
            else if (type == 2)
                sql = "select * from TienDo td where td.maNV in (select nv.maNV from NhanVienThuaHanh nv where nv.tenDangNhap = @Ten) and td.NgayKetThucQuyDinh= @NgayMai and td.NgayKetThucThucTe is null";
            else if (type == 3)
                sql = "select * from TienDo td where td.maNV in (select nv.maNV from NhanVienThuaHanh nv where nv.tenDangNhap = @Ten) and td.NgayKetThucQuyDinh= @Ngay and td.NgayKetThucThucTe is null";
            else if (type == 4)
                sql = "select * from TienDo td where td.maNV in (select nv.maNV from NhanVienThuaHanh nv where nv.tenDangNhap = @Ten) and td.NgayBatDauQuyDinh = @Ngay and td.NgayBatDauThucTe is null";
            else if (type == 5)
                sql = "select td.* from TienDo td, GhiChu gc, NhanVienThuaHanh nv where td.NgayKetThucThucTe > td.NgayKetThucQuyDinh and gc.maTD = td.maTD and gc.GhiChu is null and td.maNV = nv.maNV and nv.tenDangNhap = @Ten";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = p;
			if(type == 1 || type == 2)
			{
				cmd.Parameters.Add("@NgayMai", SqlDbType.DateTime).Value = y;
			}
			else if(type ==3 || type == 4)
			{
				cmd.Parameters.Add("@Ngay", SqlDbType.DateTime).Value = x;
			}

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> lst = new List<string>();
            while (dr.Read())
            {
                lst.Add(dr.GetValue(7).ToString());
                lst.Add(dr.GetValue(8).ToString());
                lst.Add(DateTime.Parse(dr.GetValue(3).ToString()).ToShortDateString());
                lst.Add(dr.GetValue(0).ToString());
                if (type == 5)
                    lst.Add(DateTime.Parse(dr.GetValue(6).ToString()).ToShortDateString());
            }
            con.Close();
            return lst;
        }

        public List<int> getAllTDOfNV(int p)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select maTD from TienDo where maNV = @Ma";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Ma", SqlDbType.Int).Value = p;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> lst = new List<int>();
            while (dr.Read())
            {
                lst.Add(int.Parse(dr.GetValue(0).ToString()));
            }
            con.Close();
            return lst;
        }

        public List<string> getDataByMaDTAndMaCV(int maDT, int maCV)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select td.ngayBatDauQuyDinh, td.ngayKetThucQuyDinh from TienDo td, DOTTHI dt where td.maDT = dt.maDT and dt.maDT = @DT and td.maCV = @CV ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@DT", SqlDbType.Int).Value = maDT;
            cmd.Parameters.Add("@CV", SqlDbType.Int).Value = maCV;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> lst = new List<string>();
            while (dr.Read())
            {
                lst.Add(dr.GetValue(0).ToString());
                lst.Add(dr.GetValue(1).ToString());
            }
            con.Close();
            return lst;
        }

        public void updateDataByMaCVAndMaDT(DtoTienDo td)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "UPDATE TienDo SET ngayBatDauQuyDinh=@BD, ngayKetThucQuyDinh=@KT where maCV=@MaCV and maDT=@maDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@BD", SqlDbType.DateTime).Value = td.NGAYBATDAUQUYDINH;
            cmd.Parameters.Add("@KT", SqlDbType.DateTime).Value = td.NGAYKETTHUCQUYDINH;
            cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = td.MACV;
            cmd.Parameters.Add("@MaDT", SqlDbType.Int).Value = td.MADT;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<int> getListNVofCV(int p, int maDT)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select * from TienDo where maCV=@maCV and maDT=@MaDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p;
            cmd.Parameters.Add("@MaDT", SqlDbType.Int).Value = maDT;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<int> lst = new List<int>();
            while (dr.Read())
            {
                lst.Add(int.Parse(dr.GetValue(9).ToString()));
                lst.Add(int.Parse(dr.GetValue(7).ToString()));
            }
            con.Close();
            return lst;
        }

        public List<string> getListNVofCV(string tenCV, int maDT)
        {
            List<string> res = new List<string>();
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "Select nv.tenNV from NhanVienThuaHanh nv, TienDo td,  CongViec cv, DOTTHI dt where td.maNV=nv.maNV and td.maCV = cv.maCV and td.maDT = dt.maDT and cv.tenCV = @TenCV and  dt.maDT = @maDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@TenCV", SqlDbType.VarChar).Value = tenCV;
            cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = maDT;
            con.Open();

            SqlDataReader sr = cmd.ExecuteReader();
            while (sr.Read())
            {
                res.Add(sr.GetValue(0).ToString());
                res.Add(DateTime.Parse(sr.GetValue(1).ToString()).ToShortDateString());
                try
                {
                    res.Add(DateTime.Parse(sr.GetValue(2).ToString()).ToShortDateString());
                }
                catch
                {
                    res.Add(new DateTime(9999, 1, 1).ToShortDateString());
                }
            }

            con.Close();
            return res;
        }

        public List<int> getListTenCVOfNVAndDotThi(int p, int p_2)
        {
            List<int> res = new List<int>();
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "SELECT distinct [maCV] FROM [TienDo] where maNV=@manv and maDT = @madt";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@manv", SqlDbType.Int).Value = p;
            cmd.Parameters.Add("@madt", SqlDbType.Int).Value = p_2;
            con.Open();

            SqlDataReader sr = cmd.ExecuteReader();
            while (sr.Read())
                res.Add(int.Parse(sr.GetValue(0).ToString()));

            con.Close();
            return res;
        }

        public DtoTienDo getTDOfNVByMaCVAndMaDT(int p, int p_2, int p_3)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "SELECT * FROM [TienDo] where maNV=@manv and maDT =@madt and maCV =@macv";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@manv", SqlDbType.Int).Value = p;
            cmd.Parameters.Add("@madt", SqlDbType.Int).Value = p_3;
            cmd.Parameters.Add("@macv", SqlDbType.Int).Value = p_2;
            
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DtoTienDo data = null;
            while (dr.Read())
            {
                data = new DtoTienDo();
                data.MATD = Convert.ToInt32(dr["maTD"]);
                data.MACV = Convert.ToInt32(dr["maCV"]);
                data.MADT = Convert.ToInt32(dr["maDT"]);

                if (dr["ngayBatDauThucTe"] == DBNull.Value)
                    data.NGAYBATDAUTHUCTE = DateTime.MinValue;
                else
                    data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);

                if (dr["ngayKetThucThucTe"] == DBNull.Value)
                    data.NGAYKETTHUCTHUCTE= DateTime.MinValue;
                else
                    data.NGAYKETTHUCTHUCTE = Convert.ToDateTime(dr["ngayKetThucThucTe"]);

                if (dr["ngayBatDauQuyDinh"] == DBNull.Value)
                    data.NGAYBATDAUQUYDINH = DateTime.MinValue;
                else
                    data.NGAYBATDAUQUYDINH = Convert.ToDateTime(dr["ngayBatDauQuyDinh"]);

                if (dr["ngayKetThucQuyDinh"] == DBNull.Value)
                    data.NGAYKETTHUCQUYDINH = DateTime.MinValue;
                else
                    data.NGAYKETTHUCQUYDINH = Convert.ToDateTime(dr["ngayKetThucQuyDinh"]);
                data.MANV = Convert.ToInt32(dr["maNV"]);
            }
            con.Close();
            return data;
        }

        public DtoTienDo getTDByMaCVAndMaDT(int p_2, int p_3)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "SELECT * FROM [TienDo] where maDT =@madt and maCV =@macv";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@madt", SqlDbType.Int).Value = p_3;
            cmd.Parameters.Add("@macv", SqlDbType.Int).Value = p_2;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DtoTienDo data = null;
            while (dr.Read())
            {
                data = new DtoTienDo();
                data.MATD = Convert.ToInt32(dr["maTD"]);
                data.MACV = Convert.ToInt32(dr["maCV"]);
                data.MADT
                    = Convert.ToInt32(dr["maDT"]);

                if (dr["ngayBatDauThucTe"] == DBNull.Value)
                    data.NGAYBATDAUTHUCTE = DateTime.MinValue;
                else
                    data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);

                if (dr["ngayKetThucThucTe"] == DBNull.Value)
                    data.NGAYKETTHUCTHUCTE = DateTime.MinValue;
                else
                    data.NGAYKETTHUCTHUCTE = Convert.ToDateTime(dr["ngayKetThucThucTe"]);

                if (dr["ngayBatDauQuyDinh"] == DBNull.Value)
                    data.NGAYBATDAUQUYDINH = DateTime.MinValue;
                else
                    data.NGAYBATDAUQUYDINH = Convert.ToDateTime(dr["ngayBatDauQuyDinh"]);

                if (dr["ngayKetThucQuyDinh"] == DBNull.Value)
                    data.NGAYKETTHUCQUYDINH = DateTime.MinValue;
                else
                    data.NGAYKETTHUCQUYDINH = Convert.ToDateTime(dr["ngayKetThucQuyDinh"]);
            }
            con.Close();
            return data;
        }

        public List<DtoTienDo> getTDOfNVByMaNVAndMaDT(int maNV, int maDT)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "SELECT * FROM [TienDo] where maNV=@manv and maDT =@madt order by maTD ASC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@manv", SqlDbType.Int).Value = maNV;
            cmd.Parameters.Add("@madt", SqlDbType.Int).Value = maDT;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DtoTienDo> res = new List<DtoTienDo>();
            while (dr.Read())
            {
                DtoTienDo data = new DtoTienDo();
                data.MATD = Convert.ToInt32(dr["maTD"]);

                if (dr["ngayBatDauThucTe"] == DBNull.Value)
                    data.NGAYBATDAUTHUCTE = DateTime.MinValue;
                else
                    data.NGAYBATDAUTHUCTE = Convert.ToDateTime(dr["ngayBatDauThucTe"]);

                if (dr["ngayKetThucThucTe"] == DBNull.Value)
                    data.NGAYKETTHUCTHUCTE = DateTime.MinValue;
                else
                    data.NGAYKETTHUCTHUCTE = Convert.ToDateTime(dr["ngayKetThucThucTe"]);

                res.Add(data);
            }
            con.Close();
            return res;
        }

        public void updateDataBymaTD(DtoTienDo dto)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "UPDATE TienDo SET tongKhoiLuongCV=@tongKhoiLuongCV, khoiLuongCVHT=@khoiLuongCVHT where maTD=@maTD";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tongKhoiLuongCV", SqlDbType.Int).Value = dto.TONGKHOILUONGCV;
            cmd.Parameters.Add("@khoiLuongCVHT", SqlDbType.Int).Value = dto.KHOILUONGCVHT;
            cmd.Parameters.Add("@maTD", SqlDbType.Int).Value = dto.MATD;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<string> getTextToolTip(DtoTienDo td)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "select cv.moTa, cv.ngayKetThuc - cv.ngayBatDau as 'SoNgay', td.ngayBatDauQuyDinh, td.ngayKetThucQuyDinh, td.ngayBatDauThucTe, td.ngayKetThucThucTe, td.tongKhoiLuongCV, td.khoiLuongCVHT from CongViec cv, TienDo td, DOTTHI dt where td.maCV = cv.maCV and td.maDT = dt.maDT and cv.maCV = @maCV and dt.maDT = @maDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = td.MACV;
            cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = td.MADT;

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> res = new List<string>();
                while (dr.Read())
                {
                    res.Add(dr["moTa"].ToString());
                    res.Add(dr["SoNgay"].ToString());

                    if (dr["ngayBatDauThucTe"] == DBNull.Value)
                        res.Add(DateTime.MinValue.ToShortDateString());
                    else
                        res.Add(Convert.ToDateTime(dr["ngayBatDauThucTe"]).ToShortDateString());

                    if (dr["ngayKetThucThucTe"] == DBNull.Value)
                        res.Add(DateTime.MinValue.ToShortDateString());
                    else
                        res.Add(Convert.ToDateTime(dr["ngayKetThucThucTe"]).ToShortDateString());

                    if (dr["ngayBatDauQuyDinh"] == DBNull.Value)
                        res.Add(DateTime.MinValue.ToShortDateString());
                    else
                        res.Add(Convert.ToDateTime(dr["ngayBatDauQuyDinh"]).ToShortDateString());

                    if (dr["ngayKetThucQuyDinh"] == DBNull.Value)
                        res.Add(DateTime.MinValue.ToShortDateString());
                    else
                        res.Add(Convert.ToDateTime(dr["ngayKetThucQuyDinh"]).ToShortDateString());

                    res.Add(dr["tongKhoiLuongCV"].ToString());
                    res.Add(dr["khoiLuongCVHT"].ToString());
                }
                con.Close();
                return res;
            }
            catch
            {
                
            }
            return null;
        }

        public int getMaNVByMaDTAndMaCV(int p, int p_2)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);

            string sql = "select maNV from TienDo where maDT=@maDT and maCV=@maCV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = p;
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p_2;

            con.Open();
            int res = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return res;
        }

        public int getMaTDByMaDTAndMaCV(int p, int p_2)
        {
            DataConnector dc = new DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);

            string sql = "select maTD from TienDo where maDT=@maDT and maCV=@maCV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = p;
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p_2;

            con.Open();
            int res = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return res;
        }
                public int CheckCoChua(int p, int p_2, int p_3)
        {
            try
            {
                DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                string sql = "select maTD from TienDo where maNV=@maNV and maCV=@maCV and maDT=@maDT";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@maNV", SqlDbType.Int).Value = p_2;
                cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p_3;
                cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = p;
                con.Open();
                int res = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return res;
            }
            catch
            {
                return -1;
            }
        }

        public void deleteDataBymaNVAndMaCVAndMaDT(int p, int p_2, int p_3)
        {
            DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "delete from TienDo where maNV=@maNV and maCV=@maCV and maDT=@maDT";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@maNV", SqlDbType.Int).Value = p_2;
            cmd.Parameters.Add("@maCV", SqlDbType.Int).Value = p_3;
            cmd.Parameters.Add("@maDT", SqlDbType.Int).Value = p;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
                public int getMaDTByMaTD(int m_TD)
        {
            try
            {
                DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                string sql = "select maDT from TienDo where maTD=@maTD";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@maTD", SqlDbType.Int).Value = m_TD;
                con.Open();
                int res = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return res;
            }
            catch
            {
                return -1;
            }
        }

        public int getMaCVByMaTD(int m_TD)
        {
            try
            {
                DataConnector dc = new DataConnector(); string conStr = dc.getQuyTrinhThiConnectionString();
                SqlConnection con = new SqlConnection(conStr);
                string sql = "select maCV from TienDo where maTD=@maTD";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@maTD", SqlDbType.Int).Value = m_TD;
                con.Open();
                int res = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                return res;
            }
            catch
            {
                return -1;
            }
        }
    }

    }


