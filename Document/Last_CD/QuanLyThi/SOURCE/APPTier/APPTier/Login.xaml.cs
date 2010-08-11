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
using DataLayer.DAO;
namespace APPTier
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {


        public static string m_userkey;
        private DataConnector m_dcSystemInfo;
        public Login()
        {
            this.InitializeComponent();
            m_dcSystemInfo = new DataConnector();
            this.cbxDatabaseType.SelectedIndex = 0;
            m_dcSystemInfo.ReadBinary("dbinfo.dat");

            reset();
            // Insert code required on object creation below this point.
        }


        /// <summary>
        /// Xử lý sự kiện đăng nhập của User tương ứng với Admin hay User
        /// </summary>
        /// <returns></returns>
        private void btnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string strMessage = "";
            string strUserName = tbxUsername.Text.Trim().Replace('\'', ' ');
            string strPassword = tbxPassword.Password.Trim().Replace('\'', ' ');
            MyHashAlg myHashAlg = new MyHashAlg();

            if ("".Equals(strUserName) || "".Equals(strPassword))
            {
                strMessage = "Vui lòng nhập chính xác tên và mật khẩu đăng nhập. ";
                goto QUIT;
            }

            BusNhanVienThuaHanh busNhanVien = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> lstNhanVienThuaHanh = busNhanVien.getListDataBytenDangNhap(strUserName);

            if (lstNhanVienThuaHanh == null || lstNhanVienThuaHanh.Count <= 0)
            {
                //tên đăng nh?p không t?n t?i trong b?ng nhân viên th?a hành.
                //Th? đăng nh?p v?i admin:
                goto LOGIN_AS_ADMIN;
            }

            int salt = lstNhanVienThuaHanh[0].SALT;
            if (myHashAlg.Hash(salt, strPassword).Equals(lstNhanVienThuaHanh[0].MATKHAU))
            {
                /**
                 * Đăng nh?p thành công v?i vai tr? nhân viên th?a hành.
                 */
                Constants.strUserName = strUserName;
                Constants.strRealName = lstNhanVienThuaHanh[0].TENNV;
                Constants.iUserType = 2;

                UserHomepage userHomePage = new UserHomepage();
                //////////////////////
                checkToAlert();
                checkDateToStartAcivityAuto();
                //////////////////////

                List<int> list = new BusTienDo().getAllTDOfNV(new BusNhanVienThuaHanh().getMaNVByTenNV(Constants.strUserName));
                int totalUnreadMsg = 0;
                for (int i = 0; i < list.Count; i++)
                    totalUnreadMsg += new BusThongBao().getNoOfUnreadMsg(list[i]);
                userHomePage.setTotalMsg(totalUnreadMsg);
                userHomePage.ucInbox.setListMsg();
                deletePC();
                
                this.Close();
                userHomePage.Show();
                return;
            }
            else
            {
                /**
                 * Tên đăng nh?p có trong b?ng nhân viên th?a hành nhưng đăng nh?p không thành công v?
                 * m?t kh?u không đúng.
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
                 * Tên đăng nh?p không t?n t?i c? trong b?ng d? li?u NV Th?a hành l?n NV Qu?n l?.
                 */
                strMessage = "Tên đăng nhập không tồn tại hoặc không kết nối được với cơ sở dữ liệu.Vui lòng kiểm tra và thử lại sau.";
                
                goto QUIT;
            }
            salt = lstQuanLy[0].SALT;
            if (myHashAlg.Hash(salt, strPassword).Equals(lstQuanLy[0].MATKHAU))
            {
                /*
                 * Đăng nh?p thành công v?i vai tr? qu?n tr?.
                 */
                AdminHomepage adminHomePage = new AdminHomepage();
                Constants.strUserName = strUserName;
                Constants.strRealName = "Admin";
                Constants.iUserType = 1;
                deletePC();
                //////////////////////
                checkToAlert();
                //////////////////////
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

        //////////////////////////////////
        private void checkDateToStartAcivityAuto()
        {
            int manv = new BusNhanVienThuaHanh().getMaNVByTenNV(Constants.strRealName);
            List<DtoDotThi> dotthi = new BusDotThi().getListDataByMaNV(manv);
            foreach (DtoDotThi dto in dotthi)
            {
                List<DtoTienDo> tiendo = new BusTienDo().getTDOfNVByMaNVAndMaDT(manv, dto.MADT);
                int idx = -1;
                for (int i = 0; i < tiendo.Count; i++)
                {
                    if (DateTime.Now < tiendo[i].NGAYKETTHUCQUYDINH)
                    {
                        if (i == tiendo.Count)
                            idx = i;
                        else
                            idx = i + 1;
                    }
                }
                new BusTienDo().startWork(tiendo[idx].MATD);
            }
        }

        private void checkToAlert()
        {
            int count = 0;
            count += activityAlert(1);
            count += activityAlert(2);
            count += activityAlert(3);
            count += activityAlert(4);
            count += activityAlert(5);
            if (count >= 1)
                MessageBox.Show("Có tin nhắn mới.");
        }
        private int activityAlert(int type)
        {
            int res = 0;
            List<string> listTD = new BusTienDo().getMsgToAlert(Constants.strUserName, type);
            for (int i = 0; i < listTD.Count; i += 2)
            {
                if (new BusThongBao().checkTBExists(int.Parse(listTD[i + 1])) == -1)
                {
                    DtoThongBao dto = new DtoThongBao();
                    dto.MATD = int.Parse(listTD[i + 1]);
                    dto.NOIDUNG = listTD[i];
                    dto.TRANGTHAI = 1;
                    new BusThongBao().insertData(dto);

                    dto.NOIDUNG += "\nNhân viên thực hiện: " + new BusNhanVienThuaHanh().getTenNVByMaNV(new BusTienDo().getDataById(dto.MATD).MANV);
                    dto.MATD = -1;
                    new BusThongBao().insertData(dto);
                    res = 1;
                }
            }
            return res;
        }
        //////////////////////////////////

        private static void deletePC()
        {
            BusPhanCong pc = new BusPhanCong();
            List<DtoPhanCong> list = pc.getDataList();
            if (list != null)
            {
                foreach (DtoPhanCong dto in list)
                {
                    if (dto.NGAYHETHAN.ToShortDateString() == DateTime.Now.ToShortDateString())
                        new BusPhanCong().deleteData(dto);
                }
            }
        }

        private void btnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình ?", "Thoát", MessageBoxButton.YesNo);
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

            MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình ?", "Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }


        /// <summary>
        /// //Added 15/6/2010
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            DataConnector dc = new DataConnector();
            dc.strServerName = this.tbxServerName.Text.Trim();
            dc.strDatabaseName = this.tbxDatabaseName.Text.Trim();
            dc.strUserID = this.tbxUserID.Text.Trim();
            dc.strPass = this.tbxPass.Text.Trim();
            dc.ServerNameToUpload = tbxPath.Text.Trim();
            string temp = null;
            if (this.cbxDatabaseType.SelectedIndex == 0)
            {
                temp = dc.WriteBinary("dbinfo.dat");
            }
            else if (this.cbxDatabaseType.SelectedIndex == 1)
            {
                temp = dc.WriteBinary("persistencyinfo.dat");
            }

            if (temp != null)
            {
                MessageBox.Show(temp, "Lỗi", MessageBoxButton.OK);
            }
            MessageBox.Show("Lưu thành công", "Lưu");
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn có chắc chắn muốn hủy thông tin trên không ?", "Hủy", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                reset();
            }

        }

        private void btnReset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.cbxDatabaseType.SelectedIndex = 0;
            m_dcSystemInfo.ReadBinary("dbinfo.dat");
            reset();
        }

        private void cbxDatabaseType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (this.cbxDatabaseType.SelectedIndex == 0)
            {
                m_dcSystemInfo.ReadBinary("dbinfo.dat");
                reset();
            }
            else if (this.cbxDatabaseType.SelectedIndex == 1)
            {
                m_dcSystemInfo.ReadBinary("persistencyinfo.dat");
                reset();
            }
          
        }

        public void reset()
        {
            this.tbxServerName.Text = m_dcSystemInfo.strServerName;
            this.tbxDatabaseName.Text = m_dcSystemInfo.strDatabaseName;
            this.tbxUserID.Text = m_dcSystemInfo.strUserID;
            this.tbxPass.Text = m_dcSystemInfo.strPass;
            this.tbxPath.Text = m_dcSystemInfo.ServerNameToUpload;
            this.tbxServerName.Focus();
        }


    }
}

