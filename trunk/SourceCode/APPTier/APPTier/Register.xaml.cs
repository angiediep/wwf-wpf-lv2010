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
using System.Text.RegularExpressions;
using BUSLayer;
using DataLayer.DTO;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void btnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string strMessage = "";
            BusNhanVienThuaHanh busNhanVienThuaHanh = new BusNhanVienThuaHanh();
            //Lấy thông tin từ form:
            string strUserName = tbxUsername.Text.Trim().Replace('\'', ' ');
            string strPassword = tbxPassword.Password.Trim().Replace('\'', ' ');
            string strRePassword = tbxRePassword.Password.Trim().Replace('\'', ' ');
            string strRealName = tbxRealName.Text.Trim().Replace('\'', ' ');
            string strPhoneNumber = tbxPhone.Text.Trim().Replace('\'', ' ');
            string strEmail = tbxEmail.Text.Trim().Replace('\'', ' '); 


            /*
             * Kiểm tra thông tin hợp lệ hay không. Nếu không hợp lệ thì không cho đăng ký.
             */
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
                goto QUIT;
            }
            if (!Regex.IsMatch(strEmail, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                strMessage = "Email không hợp lệ!";
                goto QUIT;
            }
                        

            /*
             * Lưu thông tin đăng kí xuống cơ sở dữ liệu
             */
            DtoNhanVienThuaHanh dtoNhanVienThuaHanh = new DtoNhanVienThuaHanh();
            MyHashAlg hash = new MyHashAlg();

            dtoNhanVienThuaHanh.TENDANGNHAP = strUserName;
            dtoNhanVienThuaHanh.TENNV = strRealName;
            dtoNhanVienThuaHanh.DIENTHOAI = strPhoneNumber;
            dtoNhanVienThuaHanh.EMAIL = strEmail;
            dtoNhanVienThuaHanh.SALT = MyHashAlg.CreateRandomSalt();
            dtoNhanVienThuaHanh.MATKHAU = hash.Hash(dtoNhanVienThuaHanh.SALT, strPassword);

            int result =  busNhanVienThuaHanh.insertData(dtoNhanVienThuaHanh);

            /*
             * Kiểm tra kết quả trả về.
             */
            if (result == -1)
            {
                strMessage = "Tên đăng nhập đã tồn tại trong hệ thống. Vui lòng chọn tên khác";
                goto QUIT;
            }
            if (result == -2)
            {
                strMessage = "Địa chỉ email đã tồn tại trong hệ thống. Vui lòng chọn email khác";
                goto QUIT;
            }
            if (result == 0)
            {
                strMessage = "Đăng ký không thành công. Vui lòng liên hệ với quản lý để được giúp đỡ.";
                goto QUIT;
            }
            MessageBoxResult msgResult = MessageBox.Show("Đăng ký thành công. Bạn có muốn đăng nhập hay không?", "Đăng ký", MessageBoxButton.YesNo);
            if (msgResult == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();
            }
            this.Close();
            return;
        QUIT:
            MessageBox.Show(strMessage, "Lỗi", MessageBoxButton.OK);
            
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            UserHomepage userHomePage = new UserHomepage();
            userHomePage.Show();
            this.Close();
        }
    }
}