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
using System.Windows.Shapes;
using BUSLayer;
using DataLayer.DTO;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public static string m_userkey;

        public Login()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void btnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminHomepage adminHomepage = new AdminHomepage();
                                   adminHomepage.Show();
            this.Close();
            //string strUserName = tbxUsername.Text.Trim();
            //string strPassword = tbxPassword.Password.Trim();
            //MyHashAlg myHashAlg = new MyHashAlg();
            //BusNhanVienThuaHanh busNhanVien = new BusNhanVienThuaHanh();
            //m_userkey = strPassword;
            //try
            //{
            //    if (strUserName == "")
            //    {
            //        MessageBoxResult msg = MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Lỗi", MessageBoxButton.OK);
            //    }
            //    else if (strPassword == "")
            //    {
            //        MessageBoxResult msg = MessageBox.Show("Bạn chưa nhập mật khẩu!", "Lỗi", MessageBoxButton.OK);
            //    }
            //    else
            //    {
            //        //Hash password
            //       // Kiểm tra Database giá trị hash và tên tài khoản
            //        //Nếu không hợp lệ sẽ báo lỗi
            //        //Nếu hợp lệ, kiểm tra loại user
            //        List<DtoNhanVienThuaHanh> userList = busNhanVien.getListDataBytenNV(strUserName);
            //        if (userList.Count > 0)
            //        {
            //            int Salt = userList[0].SALT;
            //            if (Salt == -1)
            //            {
            //                MessageBoxResult msg = MessageBox.Show("Tài khoản không hợp lệ!", "Lỗi", MessageBoxButton.OK);
            //            }
            //            else
            //            {
            //                string passphrase = myHashAlg.Hash(Salt, strPassword); //cai dc luu trong csdl
            //                if (userList[0].MATKHAU != passphrase)
            //                {
            //                    MessageBoxResult msg = MessageBox.Show("Tài khoản không hợp lệ!", "Lỗi", MessageBoxButton.OK);
            //                }
            //                else
            //                {
            //                    if (userList[0].MANV == 1)
            //                    {
            //                        AdminHomepage adminHomepage = new AdminHomepage();
            //                        adminHomepage.Show();
            //                        this.Close();
            //                    }
            //                    else
            //                    {
            //                        UserHomepage userHomepage = new UserHomepage();
            //                        userHomepage.Show();
            //                        this.Close();
            //                    }
            //                }

            //            }
            //            //Nếu là nhân viên, mở cửa sổ Nhân viên với các chức năng tương ứng
            //            MessageBox.Show("đăng nhập thành công. nhưng chưa có code trang nhân viên");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBoxResult msg = MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK);
            //}
        }

        private void btnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}