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
        private int m_MaNV = -1;

        public int MaNV
        {
            get { return m_MaNV; }
            set { m_MaNV = value; }
        }

        public Register()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            lblFuncName.Text = "ĐĂNG KÍ SỬ DỤNG HỆ THỐNG";
        }

        public Register(float type)
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            lblFuncName.Text = "THÊM NHÂN VIÊN";
            m_MaNV = (int)type;
            btnExit.Visibility = Visibility.Hidden;
        }

        public Register(int maNV)
        {
            this.InitializeComponent();
            m_MaNV = maNV;
            DtoNhanVienThuaHanh dto = new BusNhanVienThuaHanh().getDataById(maNV);

            tbxUsername.Text = dto.TENDANGNHAP;
            tbxRealName.Text = dto.TENNV;
            tbxPhone.Text = dto.DIENTHOAI;
            tbxEmail.Text = dto.EMAIL;

            lblFuncName.Text = "CẬP NHẬT THÔNG TIN NHÂN VIÊN";
            btnRegister.Visibility = Visibility.Hidden;
            btnExit.Visibility = Visibility.Hidden;
            btnXoa.Visibility = Visibility.Visible;
            btnUpdate.Visibility = Visibility.Visible;
        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (m_MaNV == -1)
            {
                MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
            else
            {
                m_MaNV = -2;
                Application.Current.Shutdown();
            }
        }

        private void btnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Reg();
        }


        /// <summary>
        /// Xử lý sự kiện đăng ký của User
        /// </summary>
        /// <returns></returns>
        private void Reg()
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

            try
            {
                int chekc = int.Parse(strPhoneNumber);
            }
            catch (Exception)
            {
                MessageBox.Show("Điện thoại xin nhập số.");
                return;
            }
            dtoNhanVienThuaHanh.DIENTHOAI = strPhoneNumber;
            dtoNhanVienThuaHanh.EMAIL = strEmail;
            dtoNhanVienThuaHanh.SALT = MyHashAlg.CreateRandomSalt();
            dtoNhanVienThuaHanh.MATKHAU = hash.Hash(dtoNhanVienThuaHanh.SALT, strPassword);

            if ((m_MaNV == -4) && (MessageBox.Show("Bạn có muốn thêm nhân viên không ?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
            {
                int result = busNhanVienThuaHanh.insertData(dtoNhanVienThuaHanh);

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
                    strMessage = "Thêm nhân viên không thành công, vui lòng thử lại.";
                    goto QUIT;
                }

                this.Close();
                return;
            }
            else if (m_MaNV != -4)
            {
                int result = busNhanVienThuaHanh.insertData(dtoNhanVienThuaHanh);

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
            }

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
            if (m_MaNV == -1)
            {
                if (MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    this.Close();
            }
            else
            {
                m_MaNV = -2;
                this.Close();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
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
            string strMessage = string.Empty;
            if (0 == strUserName.Length || 0 == strPassword.Length ||
                0 == strRealName.Length || 0 == strPhoneNumber.Length ||
                0 == strEmail.Length)
            //{
            //    strMessage = "Vui lòng nhập đủ các thông tin để đăng ký!";
            //    goto QUIT;
            //}
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

            DtoNhanVienThuaHanh dto = new DtoNhanVienThuaHanh();
            MyHashAlg hash = new MyHashAlg();
            dto.TENNV = strRealName;
            dto.TENDANGNHAP = strUserName;
            dto.MANV = m_MaNV;
            dto.EMAIL = strEmail;
            dto.DIENTHOAI = strPhoneNumber;
            dto.SALT = new BusNhanVienThuaHanh().getDataById(m_MaNV).SALT;
            if (strPassword != "")
                dto.MATKHAU = hash.Hash(dto.SALT, strPassword);
            else
                dto.MATKHAU = new BusNhanVienThuaHanh().getDataById(m_MaNV).MATKHAU;

            if (MessageBox.Show("Thật sự muốn chỉnh sửa ?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                busNhanVienThuaHanh.updateData(dto);
                m_MaNV = -3;
                this.Close();
                return;
            }
            else
                return;

        QUIT:
            return;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DtoNhanVienThuaHanh dto = new BusNhanVienThuaHanh().getDataById(m_MaNV);

            tbxUsername.Text = dto.TENDANGNHAP;
            tbxPassword.Password = dto.MATKHAU;
            tbxRePassword.Password = dto.MATKHAU;
            tbxRealName.Text = dto.TENNV;
            tbxPhone.Text = dto.DIENTHOAI;
            tbxEmail.Text = dto.EMAIL;

            if ((MessageBox.Show("Thật sự muốn xóa ?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes) && (new BusNhanVienThuaHanh().deleteData(dto) == true))
            {
                m_MaNV = -3;
                this.Close();
            }
        }
    }
}