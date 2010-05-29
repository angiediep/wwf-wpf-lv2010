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

        private void btnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                int iCheckFinish = 1; //kiểm tra có nhập đủ thông tin chưa, mặc định là đủ
                //nếu kiểm tra có ô thông tin chưa điền, iCheckFinish = 0
                if (tbxPassword.Password == "")
                {
                    iCheckFinish = 0;
                }
                else
                {
                    foreach (TextBox temp in FindVisualChildren<TextBox>(this.Window))
                    {
                        if (temp.Text == "")//nếu thông tin có rỗng
                        {
                            iCheckFinish = 0;
                            break;
                        }
                    }
                }
                //Nếu thông tin chưa hoàn tất, hỏi xem có muốn thoát khỏi đăng kí và vào đăng nhập không
                //Nếu có, hiện đăng nhập
                if (iCheckFinish == 0)
                {
                    MessageBoxResult msg = MessageBox.Show("Bạn chưa hoàn tất thủ tục đăng kí, bạn có thật sự muốn đăng nhập không?", "Đăng nhập", MessageBoxButton.YesNo);
                    if (msg == MessageBoxResult.Yes)
                    {
                        Login login = new Login();
                        login.Show();
                        this.Close();

                    }
                }
                //Nếu thông tin đã hoàn tất, thông báo thông tin chưa được lưu, hỏi xem người dùng có muốn lưu không
                //Nếu có, tiến hành lưu và hiện form đăng nhập
                //Nếu không, bỏ qua và chỉ hiện form đăng nhập
                else
                {
                    MessageBoxResult msg = MessageBox.Show("Bạn chưa chọn đăng kí, bạn có muốn chúng tôi đăng kí với thông tin này không?", "Đăng nhập", MessageBoxButton.YesNo);
                    if (msg == MessageBoxResult.Yes)
                    {
                        //Lưu thông tin đăng kí xuống cơ sở dữ liệu
                        DtoNhanVienThuaHanh user = new DtoNhanVienThuaHanh();
                        MyHashAlg hash = new MyHashAlg();
                        if (!Regex.IsMatch(this.tbxEmail.Text, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                        {
                            MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButton.OK);

                        }
                        else
                        {
                            user.TENNV = this.tbxRealName.Text;
                            user.DIENTHOAI = this.tbxPhone.Text;
                            user.EMAIL = this.tbxEmail.Text;
                            user.SALT = MyHashAlg.CreateRandomSalt();
                            user.MATKHAU = hash.Hash(user.SALT, this.tbxPassword.Password);
                            BusNhanVienThuaHanh _user = new BusNhanVienThuaHanh();
                            List<DtoNhanVienThuaHanh> users = _user.getListDataBytenNV(user.TENNV);
                            if (users != null)
                            {
                                MessageBox.Show("Tài khoản đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButton.OK);
                            }
                            else
                            {
                                _user.insertData(user);
                            }
                        }
                        MessageBox.Show("Thủ tục đăng kí hoàn tất, bấm OK để đăng nhập!", "Đăng kí", MessageBoxButton.OK);
                    }
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult msg = MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK);
            }
        }

        private void btnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string strMessage = "";
            BusNhanVienThuaHanh busNhanVienThuaHanh = new BusNhanVienThuaHanh();
            //Lấy thông tin từ form:
            string strUserName = tbxUsername.Text.Trim().Replace('\'', ' ');
            string strPassword = tbxPassword.Password.Trim().Replace('\'', ' ');
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
    }
}