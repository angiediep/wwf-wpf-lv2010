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
using QuanLyThi;
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
            
            string strMessage = "";
            string strUserName = tbxUsername.Text.Trim().Replace('\'',' ');
            string strPassword = tbxPassword.Password.Trim().Replace('\'', ' ');
            MyHashAlg myHashAlg = new MyHashAlg();
            
            if ("".Equals(strUserName) || "".Equals(strPassword))
            {
                strMessage = "Vui lòng nhập chính xác tên và mật khẩu để đăng nhập. ";
                goto QUIT;
            }

            BusNhanVienThuaHanh busNhanVien = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> lstNhanVienThuaHanh = busNhanVien.getListDataBytenDangNhap(strUserName);
            
            if (lstNhanVienThuaHanh == null || lstNhanVienThuaHanh.Count <= 0)
            {
                //tên đăng nhập không tồn tại trong bảng nhân viên thừa hành.
                //Thử đăng nhập với admin:
                goto LOGIN_AS_ADMIN;
            }
            
            int salt = lstNhanVienThuaHanh[0].SALT;
            if (myHashAlg.Hash(salt, strPassword).Equals(lstNhanVienThuaHanh[0].MATKHAU))
            {
                /**
                 * Đăng nhập thành công với vai trò nhân viên thừa hành.
                 */
                UserHomepage userHomePage = new UserHomepage();
                Constants.strUserName = strUserName;
                Constants.strRealName = lstNhanVienThuaHanh[0].TENNV;
                Constants.iUserType = 2;
                this.Close();
                userHomePage.Show();
                return;
            }
            else
            { 
                /**
                 * Tên đăng nhập có trong bảng nhân viên thừa hành nhưng đăng nhập không thành công vì
                 * mật khẩu không đúng.
                 */
                strMessage = "Mật khẩu không đúng. Vui lòng kiểm tra và thử lại sau.";
                goto QUIT;
            }
            
        LOGIN_AS_ADMIN:
            BusQuanLy busQuanLy = new BusQuanLy();
            List<DtoQuanLy> lstQuanLy = busQuanLy.getDataList();
            if (lstQuanLy == null || lstQuanLy.Count == 0 || !lstQuanLy[0].TENDANGNHAP.Equals(strUserName))
            {
                /**
                 * Tên đăng nhập không tồn tại cả trong bảng dữ liệu NV Thừa hành lẫn NV Quản lý.
                 */
                strMessage = "Tên đăng nhập không tồn tại hoặc không kết nối được với cơ sở dữ liệu. Vui lòng kiểm tra và thử lại sau.";
                goto QUIT;
            }
            salt = lstQuanLy[0].SALT;
            if (myHashAlg.Hash(salt, strPassword).Equals(lstQuanLy[0].MATKHAU))
            {
                /*
                 * Đăng nhập thành công với vai trò quản trị.
                 */
                AdminHomepage adminHomePage = new AdminHomepage();
                Constants.strUserName = strUserName;
                Constants.strRealName = "Admin";
                Constants.iUserType = 1;
                this.Close();
                adminHomePage.Show();
            }
            else
            {
                strMessage = "Mật khẩu không đúng. Vui lòng kiểm tra và thử lại sau.";
                goto QUIT;
            }
            return;
        QUIT:
            MessageBox.Show(strMessage, "Lỗi", MessageBoxButton.OK);
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