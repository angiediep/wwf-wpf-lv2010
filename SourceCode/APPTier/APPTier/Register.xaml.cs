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
            // TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //try
            //{
            //    // TODO: Add event handler implementation here.
            //    int iCheckFinish = 1; //kiểm tra có nhập đủ thông tin chưa, mặc định là đủ
            //    //nếu kiểm tra có ô thông tin chưa điền, iCheckFinish = 0
            //    if (tbxPassword.Password == "")
            //    {
            //        iCheckFinish = 0;
            //    }
            //    else
            //    {
            //        foreach (TextBox temp in FindVisualChildren<TextBox>(this.Window))
            //        {
            //            if (temp.Text == "")//nếu thông tin có rỗng
            //            {
            //                iCheckFinish = 0;
            //                break;
            //            }
            //        }
            //    }
            //    //Nếu thông tin chưa hoàn tất, hỏi xem có muốn thoát khỏi đăng kí và vào đăng nhập không
            //    //Nếu có, hiện đăng nhập
            //    if (iCheckFinish == 0)
            //    {
            //        MessageBoxResult msg = MessageBox.Show("Bạn chưa hoàn tất thủ tục đăng kí, bạn có thật sự muốn đăng nhập không?", "Đăng nhập", MessageBoxButton.YesNo);
            //        if (msg == MessageBoxResult.Yes)
            //        {
            //            Login login = new Login();
            //            login.Show();
            //            this.Close();

            //        }
            //    }
            //    //Nếu thông tin đã hoàn tất, thông báo thông tin chưa được lưu, hỏi xem người dùng có muốn lưu không
            //    //Nếu có, tiến hành lưu và hiện form đăng nhập
            //    //Nếu không, bỏ qua và chỉ hiện form đăng nhập
            //    else
            //    {
            //        MessageBoxResult msg = MessageBox.Show("Bạn chưa chọn đăng kí, bạn có muốn chúng tôi đăng kí với thông tin này không?", "Đăng nhập", MessageBoxButton.YesNo);
            //        if (msg == MessageBoxResult.Yes)
            //        {
            //            //Lưu thông tin đăng kí xuống cơ sở dữ liệu
            //            DtoNhanVien user = new DtoNhanVien();
            //            MyHashAlg hash = new MyHashAlg();
            //            if (!Regex.IsMatch(this.tbxEmail.Text, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            //            {
            //                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButton.OK);

            //            }
            //            else
            //            {
            //                user.TENNV = this.tbxRealName.Text;
            //                user.DIENTHOAI = this.tbxPhone.Text;
            //                user.EMAIL = this.tbxEmail.Text;
            //                user.SALT = MyHashAlg.CreateRandomSalt();
            //                user.MATKHAU = hash.Hash(user.SALT, this.tbxPassword.Password);
            //                BusNhanVien _user = new BusNhanVien();
            //                List<DtoNhanVien> users = _user.getListDataBytenNV(user.TENNV);
            //                if (users != null)
            //                {
            //                    MessageBox.Show("Tài khoản đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButton.OK);
            //                }
            //                else
            //                {
            //                    _user.insertData(user);
            //                }
            //            }
            //            MessageBox.Show("Thủ tục đăng kí hoàn tất, bấm OK để đăng nhập!", "Đăng kí", MessageBoxButton.OK);
            //        }
            //        Login login = new Login();
            //        login.Show();
            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBoxResult msg = MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK);
            //}
        }

        private void btnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //try
            //{
            //    // TODO: Add event handler implementation here.
            //    int iCheckFinish = 1; //kiểm tra có nhập đủ thông tin chưa, mặc định là đủ
            //    //nếu kiểm tra có ô thông tin chưa điền, iCheckFinish = 0
            //    if (tbxPassword.Password == "")
            //    {
            //        iCheckFinish = 0;
            //    }
            //    else
            //    {
            //        foreach (TextBox temp in FindVisualChildren<TextBox>(this.Window))
            //        {
            //            string _temp = temp.Name;
            //            if (temp.Text == "")//nếu thông tin có rỗng
            //            {

            //                iCheckFinish = 0;
            //                break;
            //            }
            //        }
            //    }
            //    //Nếu thông tin chưa hoàn tất, hỏi xem có muốn thoát khỏi đăng kí và vào đăng nhập không
            //    //Nếu có, hiện đăng nhập
            //    if (iCheckFinish == 0)
            //    {
            //        MessageBoxResult msg = MessageBox.Show("Bạn chưa hoàn tất thủ tục đăng kí!", "Đăng kí", MessageBoxButton.OK);
            //    }
            //    //Nếu thông tin đã hoàn tất, thông báo thông tin chưa được lưu, hỏi xem người dùng có muốn lưu không
            //    //Nếu có, tiến hành lưu và hiện form đăng nhập
            //    //Nếu không, bỏ qua và chỉ hiện form đăng nhập
            //    else
            //    {
            //        //Lưu thông tin đăng kí xuống cơ sở dữ liệu
            //        DtoNhanVien user = new DtoNhanVien();
            //        MyHashAlg hash = new MyHashAlg();
            //        if (!Regex.IsMatch(this.tbxEmail.Text, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            //        {
            //            MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButton.OK);

            //        }
            //        else
            //        {
            //            user.TENNV = this.tbxRealName.Text;
            //            user.DIENTHOAI = this.tbxPhone.Text;
            //            user.EMAIL = this.tbxEmail.Text;
            //            user.SALT = MyHashAlg.CreateRandomSalt();
            //            user.MATKHAU = hash.Hash(user.SALT, this.tbxPassword.Password);
            //            BusNhanVien _user = new BusNhanVien();
            //            List<DtoNhanVien> users = _user.getListDataBytenNV(user.TENNV);
            //            if (users.Count != 0)
            //            {
            //                MessageBox.Show("Tài khoản đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButton.OK);
            //            }
            //            else
            //            {
            //                _user.insertData(user);
            //            }
            //        }
            //        MessageBox.Show("Thủ tục đăng kí hoàn tất, bấm OK để đăng nhập!", "Đăng kí", MessageBoxButton.OK);

            //        Login login = new Login();
            //        login.Show();
            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBoxResult msg = MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK);
            //}
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
            // TODO: Add event handler implementation here.
            this.DragMove();
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}