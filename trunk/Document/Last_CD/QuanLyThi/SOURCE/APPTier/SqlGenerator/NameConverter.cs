using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SqlGenerator
{
    public static class NameConverter
    {
        #region ColumnName
        public static List<KeyValuePair<string, string>> ColumnName = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("maCV", "Mã Công Việc"),
new KeyValuePair<string, string>("tenCV", "Tên Công Việc"),
new KeyValuePair<string, string>("ngayBatDau", "Ngày Bắt Đầu"),
new KeyValuePair<string, string>("ngayKetThuc", "Ngày Kết Thúc"),
new KeyValuePair<string, string>("moTa", "Mô Tả"),
new KeyValuePair<string, string>("maCC", "Mã Chứng Chỉ"),
new KeyValuePair<string, string>("tenCC", "Tên Chứng Chỉ"),
new KeyValuePair<string, string>("maDT", "Mã Đợt Thi"),
new KeyValuePair<string, string>("tenDotThi", "Tên Đợt Thi"),
new KeyValuePair<string, string>("ngayThi", "Ngày Thi"),
new KeyValuePair<string, string>("soLuongThiSinh", "Số Lượng Thí Sinh"),
new KeyValuePair<string, string>("maDT", "Mã Đợt Thi"),
new KeyValuePair<string, string>("maCC", "Mã Chứng Chỉ"),
new KeyValuePair<string, string>("soLuongThiSinh", "Số Lượng Thí Sinh"),
new KeyValuePair<string, string>("maGC", "Mã Ghi Chú"),
new KeyValuePair<string, string>("GhiChu", "Ghi Chú"),
new KeyValuePair<string, string>("maTD", "Mã Tiến Độ"),
new KeyValuePair<string, string>("maNV", "Mã Nhân Viên"),
new KeyValuePair<string, string>("tenDangNhap", "Tên Đăng Nhập"),
new KeyValuePair<string, string>("email", "Email"),
new KeyValuePair<string, string>("tenNV", "Tên Nhân Viên"),
new KeyValuePair<string, string>("dienThoai", "Điện Thoại"),
new KeyValuePair<string, string>("maCV", "Mã Công Việc"),
new KeyValuePair<string, string>("maNV", "Mã Nhân Viên"),
new KeyValuePair<string, string>("ngayApDung", "Ngày Áp Dụng"),
new KeyValuePair<string, string>("ngayHetHan", "Ngày Hết Hạn"),
new KeyValuePair<string, string>("tenDangNhap", "Tên Đăng Nhập"),
new KeyValuePair<string, string>("email", "Email"),
new KeyValuePair<string, string>("maTD", "Mã Tiến Độ"),
new KeyValuePair<string, string>("tongKhoiLuongCV", "Tổng Khối Lượng Công Việc"),
new KeyValuePair<string, string>("khoiLuongCVHT", "Khối Lượng Công Viêc Hoàn Thành"),
new KeyValuePair<string, string>("ngayBatDauQuyDinh", "Ngày Bắt Đầu Quy Định"),
new KeyValuePair<string, string>("ngayKetThucQuyDinh", "Ngày Kết Thúc Quy Định"),
new KeyValuePair<string, string>("ngayBatDauThucTe", "Ngày Bắt Đầu Thực Tế"),
new KeyValuePair<string, string>("ngayKetThucThucTe", "Ngày Kết Thúc Thực Tế"),
new KeyValuePair<string, string>("maDT", "Mã Đợt Thi"),
new KeyValuePair<string, string>("maCV", "Mã Công Việc"),
new KeyValuePair<string, string>("maNV", "Mã Nhân Viên"),
new KeyValuePair<string, string>("maTB", "Mã Thông Báo"),
new KeyValuePair<string, string>("noiDung", "Nội Dung"),
new KeyValuePair<string, string>("maTD", "Mã Tiến Độ"),
new KeyValuePair<string, string>("trangThai", "Trạng Thái")
        };
        #endregion

        #region TableName
        public static List<KeyValuePair<string, KeyValuePair<string, string>>> TableName = new List<KeyValuePair<string,KeyValuePair<string,string>>>()
            {
                new KeyValuePair<string, KeyValuePair<string, string>>("Công Việc", new KeyValuePair<string, string>("CongViec", "cv")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Chứng Chỉ", new KeyValuePair<string, string>("ChungChi", "cc")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Đợt Thi", new KeyValuePair<string, string>("DotThi", "dt")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Đợt Thi - Chứng Chỉ", new KeyValuePair<string, string>("DotThi_ChungChi", "dtcc")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Ghi Chú", new KeyValuePair<string, string>("GhiChu", "gc")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Nhân Viên Thừa Hành", new KeyValuePair<string, string>("NhanVienThuaHanh", "nvth")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Phân Công", new KeyValuePair<string, string>("PhanCong", "pc")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Quản Lý", new KeyValuePair<string, string>("QuanLy", "ql")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Thông Báo", new KeyValuePair<string, string>("ThongBao", "tb")),
                new KeyValuePair<string, KeyValuePair<string, string>>("Tiến Độ", new KeyValuePair<string, string>("TienDo", "td"))
            };
        #endregion


        /// <summary>
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="tableName"></param>
        /// <returns>
        /// 1: số
        /// 2: chuỗi, ngày tháng, etc.
        /// </returns>
        public static int getColumnType(string colName, string tableName)
        {
            DataLayer.DAO.DataConnector dc = new DataLayer.DAO.DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "SELECT data_type FROM information_schema.columns WHERE table_schema = 'dbo' AND table_name = @tenBang AND column_name = @tenCot";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenBang", System.Data.SqlDbType.VarChar).Value = tableName;
            cmd.Parameters.Add("@tenCot", System.Data.SqlDbType.VarChar).Value = colName;

            string ret = cmd.ExecuteScalar().ToString();
            con.Close();
            if (ret == "int")
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// lấy tên cột tương ứng với các bảng
        /// </summary>
        /// <returns></returns>
        public static DataTable getColumnList(string tableName)
        {
            DataLayer.DAO.DataConnector dc = new DataLayer.DAO.DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "SELECT syscolumns.name as N'Tên Cột' FROM sysobjects JOIN syscolumns ON sysobjects.id = syscolumns.id WHERE sysobjects.xtype='U' and sysobjects.name = N'" + tableName + "'";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("Tên Bảng");
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i][1] = getCommonName(tableName);

            con.Close();
            return dt;
        }

        public static string convertColumnName(string colName)
        {
            return ColumnName.Find(
                                delegate(KeyValuePair<string, string> value)
                                {
                                    return value.Value == colName;
                                }).Key;
        }

        public static string getCommonName(string databaseTableName)
        {
            return TableName.Find(
                                   delegate(KeyValuePair<string, KeyValuePair<string, string>> value)
                                   {
                                       return value.Value.Key == databaseTableName;
                                   }).Key;
        }

        public static string getCommonNameByTableVariableName(string variableTableName)
        {
            return TableName.Find(
                                   delegate(KeyValuePair<string, KeyValuePair<string, string>> value)
                                   {
                                       return value.Value.Value == variableTableName;
                                   }).Key;
        }

        public static string getDatabaseNameByTableVariableName(string variableTableName)
        {
            return TableName.Find(
                                   delegate(KeyValuePair<string, KeyValuePair<string, string>> value)
                                   {
                                       return value.Value.Value == variableTableName;
                                   }).Value.Key;
        }

        public static KeyValuePair<string, string> convertTable(string tableName)
        {
            return TableName.Find(
                                delegate(KeyValuePair<string, KeyValuePair<string, string>> value)
                                {
                                    return value.Key == tableName;
                                }).Value;
        }

        public static string getTableVariableNameByDatabaseName(string tableName)
        {
            return TableName.Find(
                                delegate(KeyValuePair<string, KeyValuePair<string, string>> value)
                                {
                                    return value.Value.Key == tableName;
                                }).Value.Value;
        }

        public static string getTableVariableNameByCommonName(string tableName)
        {
            return TableName.Find(
                                delegate(KeyValuePair<string, KeyValuePair<string, string>> value)
                                {
                                    return value.Key == tableName;
                                }).Value.Value;
        }


        /// <summary>
        /// lấy tên bảng tương ứng với giá trị trên giao diện
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<string, string> getTableByUIControlName(string controlName)
        {
            if (controlName.Contains("CV"))
                return TableName[0].Value;
            else if (controlName.Contains("DTCC"))
                return TableName[3].Value;
            else if (controlName.Contains("CC"))
                return TableName[1].Value;
            else if (controlName.Contains("DT"))
                return TableName[2].Value;
            else if (controlName.Contains("GC"))
                return TableName[4].Value;
            else if (controlName.Contains("NVTH"))
                return TableName[5].Value;
            else if (controlName.Contains("PC"))
                return TableName[6].Value;
            else if (controlName.Contains("QL"))
                return TableName[7].Value;
            else if (controlName.Contains("TB"))
                return TableName[8].Value;
            else if (controlName.Contains("TD"))
                return TableName[9].Value;
            return new KeyValuePair<string,string>();
        }
    }
}
