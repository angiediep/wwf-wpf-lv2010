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
    public partial class UpdateWorkTime : Window
    {
        private int m_maTD;
        private int m_Res;

        public int Res
        {
            get { return m_Res; }
            set { m_Res = value; }
        }


        public UpdateWorkTime(int maTD)
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            m_Res = -1;
            m_maTD = maTD;

            DtoTienDo dto = new BusTienDo().getDataById(m_maTD);
            tbxKhoiLuongCV.Text = dto.TONGKHOILUONGCV.ToString();
            tbxKhoiLuongCVHT.Text = dto.KHOILUONGCVHT.ToString();

            DtoGhiChu gc = new BusGhiChu().getDataByMaTD(m_maTD);
            if (gc != null)
                rbNguyenNhan.Text = gc.GHICHU;
        }


        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

            this.Close();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {

            DtoTienDo dto = new DtoTienDo();
            dto.MATD = m_maTD;
            dto.TONGKHOILUONGCV = int.Parse(tbxKhoiLuongCV.Text);
            dto.KHOILUONGCVHT = int.Parse(tbxKhoiLuongCVHT.Text);

            if (dto.TONGKHOILUONGCV >= dto.KHOILUONGCVHT)
            {
                DtoTienDo td = new BusTienDo().getDataById(dto.MATD);
                if (td.NGAYKETTHUCTHUCTE == null && (int.Parse(tbxKhoiLuongCV.Text) != td.TONGKHOILUONGCV) && (int.Parse(tbxKhoiLuongCVHT.Text) != td.KHOILUONGCVHT))
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu, đợt thi đã kết thúc!");
                }
                else
                {
                    List<DtoTienDo> _td = new BusTienDo().getListDataBymaDT(td.MADT);
                    MessageBoxResult msg = MessageBox.Show("Khối lượng CVHT là khối lượng cv của riêng bạn hay của cả nhóm làm việc? \n Chọn Yes nếu đây khối lượng CVHT của riêng Bạn. \n Chọn No nếu đây là khối lượng CVHT của cả nhóm.", "Xác nhận", MessageBoxButton.YesNo);
                    if (msg == MessageBoxResult.Yes)
                    {
                        dto.KHOILUONGCVHT += td.KHOILUONGCVHT;
                        
                        foreach (DtoTienDo _dto in _td)
                        {
                            if (_dto.MACV == td.MACV)
                            {
                                _dto.TONGKHOILUONGCV = dto.TONGKHOILUONGCV;
                                if (_dto.TONGKHOILUONGCV < dto.KHOILUONGCVHT)
                                {
                                    MessageBox.Show("Tổng khối lượng công việc không được nhỏ hơn Khối lượng công việc hoàn thành");
                                }
                                else
                                {
                                    _dto.KHOILUONGCVHT = dto.KHOILUONGCVHT;                                    
                                    new BusTienDo().updateDataBymaTD(_dto);
                                }
                            }
                        }

                    }
                    else if (msg == MessageBoxResult.No)
                    {
                        foreach (DtoTienDo _dto in _td)
                        {
                            if (_dto.MACV == td.MACV)
                            {
                                _dto.TONGKHOILUONGCV = dto.TONGKHOILUONGCV;
                                _dto.KHOILUONGCVHT = dto.KHOILUONGCVHT;
                                new BusTienDo().updateDataBymaTD(_dto);
                            }
                        }
                    }

                    DtoGhiChu ghichu = new DtoGhiChu();
                    ghichu.GHICHU = rbNguyenNhan.Text;
                    ghichu.MATD = m_maTD;
                    new BusGhiChu().insertData(ghichu);
                    if (td.MACV == 1)
                    {

                        DtoDotThi dt = new BusDotThi().getDataById(td.MADT);
                        dt.SOLUONGTHISINH = int.Parse(this.tbxKhoiLuongCV.Text);
                        new BusDotThi().updateData(dt);
                        DtoDotThi_ChungChi dtcc = new BusDotThi_ChungChi().getDataById(td.MADT);
                        dtcc.SOLUONGTHISINH = int.Parse(this.tbxKhoiLuongCV.Text);
                        foreach (DtoTienDo _dto in _td) 
                        {
                            _dto.TONGKHOILUONGCV = int.Parse(this.tbxKhoiLuongCV.Text);
                            new BusTienDo().updateDataBymaTD(_dto);
                        }
                    }
                    m_Res = 1;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tổng khối lượng công việc không được nhỏ hơn Khối lượng công việc hoàn thành");
            }




        }
    }
}