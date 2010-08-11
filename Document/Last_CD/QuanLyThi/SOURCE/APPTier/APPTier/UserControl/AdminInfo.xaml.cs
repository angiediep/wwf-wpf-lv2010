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
    public partial class AdminInfo : UserControl
    {
        string tendncu;
        public AdminInfo()
        {
            this.InitializeComponent();

            DtoQuanLy dto = new BusQuanLy().getDataList()[0];

            tbxUsername.Text = dto.TENDANGNHAP;
            tendncu = dto.TENDANGNHAP;
            tbxPassword.Password = "";
            tbxRePassword.Password = "";
            tbxEmail.Text = dto.EMAIL;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            BusQuanLy busNhanVienThuaHanh = new BusQuanLy();
            //Lấy thông tin từ form:
            string strUserName = tbxUsername.Text.Trim().Replace('\'', ' ');
            string strPassword = tbxPassword.Password.Trim().Replace('\'', ' ');
            string strRePassword = tbxRePassword.Password.Trim().Replace('\'', ' ');
            string strEmail = tbxEmail.Text.Trim().Replace('\'', ' ');

            string strMessage = string.Empty;
            if (0 == strUserName.Length || 0 == strPassword.Length ||
                0 == strEmail.Length)
            {
                strMessage = "Vui lòng nhập đủ các thông tin để đăng ký!";
                goto QUIT;
            }
            if (!strPassword.Equals(strRePassword))
            {
                strMessage = "Mật khẩu nhập lại không khớp. Vui lòng kiểm tra và thử lại sau.";
                MessageBox.Show("Mật khẩu nhập lại không khớp. Vui lòng kiểm tra và thử lại.");
                goto QUIT;
            }
            if (!Regex.IsMatch(strEmail, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                strMessage = "Email không hợp lệ!";
                MessageBox.Show("Email không hợp lệ!");
                goto QUIT;
            }

            DtoQuanLy dto = new DtoQuanLy();
            MyHashAlg hash = new MyHashAlg();
            dto.EMAIL = strEmail;
            dto.SALT = new BusQuanLy().getDataList()[0].SALT;
            if (strPassword != "")
                dto.MATKHAU = hash.Hash(dto.SALT, strPassword);
            else
                dto.MATKHAU = new BusQuanLy().getDataList()[0].MATKHAU;
            dto.TENDANGNHAP = strUserName;

            busNhanVienThuaHanh.updateData(dto, tendncu);
            tendncu = strUserName;
            MessageBox.Show("Chỉnh sửa thành công.");
            return;
        QUIT:
            return;
        }
    }
}