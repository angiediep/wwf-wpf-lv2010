using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ModelReader;
using BUSLayer;
using DataLayer.DTO;
using System.Drawing;
using QuanLyThi;
using System.Text.RegularExpressions;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for AssignUser2.xaml
    /// </summary>
    public partial class PersonalInfo : UserControl
    {
        int maNV = -1;
        public PersonalInfo()
        {
            this.InitializeComponent();

            maNV = new BusNhanVienThuaHanh().getMaNVByTenNV(Constants.strUserName);

            DtoNhanVienThuaHanh dto = new BusNhanVienThuaHanh().getDataById(maNV);
            tbxUsername.Text = dto.TENDANGNHAP;
            tbxPassword.Password = "";
            tbxRePassword.Password = "";
            tbxRealName.Text = dto.TENNV;
            tbxPhone.Text = dto.DIENTHOAI;
            tbxEmail.Text = dto.EMAIL;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            BusNhanVienThuaHanh busNhanVienThuaHanh = new BusNhanVienThuaHanh();
            //Lấy thông tin từ form:
            string strUserName = tbxUsername.Text.Trim().Replace('\'', ' ');
            string strPassword = tbxPassword.Password.Trim().Replace('\'', ' ');
            string strRePassword = tbxRePassword.Password.Trim().Replace('\'', ' ');
            string strRealName = tbxRealName.Text.Trim().Replace('\'', ' ');
            string strPhoneNumber = tbxPhone.Text.Trim().Replace('\'', ' ');
            string strEmail = tbxEmail.Text.Trim().Replace('\'', ' ');

            string strMessage = string.Empty;
            if (0 == strUserName.Length || 0 == strPassword.Length ||
                0 == strRealName.Length || 0 == strPhoneNumber.Length ||
                0 == strEmail.Length)
            {
                strMessage = "Vui lòng nhập đủ các thông tin để đăng ký!";
                goto QUIT;
            }
            if (!strPassword.Equals(strRePassword))
            {
                strMessage = "Mật khẩu nhập lại không khớp. Vui lòng kiểm tra và thử lại sau.";
                MessageBox.Show("Mật khẩu nhập lại không khớp. Vui lòng kiểm tra.");
                goto QUIT;
            }
            if (!Regex.IsMatch(strEmail, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                strMessage = "Email không hợp lệ!";
                MessageBox.Show("Email không hợp lệ!");
                goto QUIT;
            }

            DtoNhanVienThuaHanh dto = new DtoNhanVienThuaHanh();
            MyHashAlg hash = new MyHashAlg();
            dto.TENNV = strRealName;
            dto.TENDANGNHAP = strUserName;
            dto.MANV = maNV;
            dto.EMAIL = strEmail;
            dto.DIENTHOAI = strPhoneNumber;
            dto.SALT = new BusNhanVienThuaHanh().getDataById(maNV).SALT;
            if (strPassword != "")
                dto.MATKHAU = hash.Hash(dto.SALT, strPassword);
            else
                dto.MATKHAU = new BusNhanVienThuaHanh().getDataById(maNV).MATKHAU;

            busNhanVienThuaHanh.updateData(dto);
            MessageBox.Show("Chỉnh sửa thành công.");
            return;

        QUIT:
            return;
        }
    }
}