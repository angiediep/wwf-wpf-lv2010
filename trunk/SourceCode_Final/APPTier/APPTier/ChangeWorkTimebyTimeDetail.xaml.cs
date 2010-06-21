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
    public partial class ChangeWorkTimebyTimeDetail : Window
    {
        int m_MaCV = -1;
        int res = -1;

        public int Res
        {
            get { return res; }
            set { res = value; }
        }

        public ChangeWorkTimebyTimeDetail()
        {
            this.InitializeComponent();
        }

        public ChangeWorkTimebyTimeDetail(int maCV)
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
            m_MaCV = maCV;

            DtoCongViec cv = new BusCongViec().getDataById(m_MaCV);
            tbxNgayBatDau.Text = cv.NGAYBATDAU.ToString();
            tbxNgayKetThuc.Text = cv.NGAYKETTHUC.ToString();
            tbxTenCV.Text = cv.TENCV;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int nbd = int.Parse(tbxNgayBatDau.Text);
            int nkt = int.Parse(tbxNgayKetThuc.Text);

            new BusCongViec().updateNBDvaNKTByMaCV(nbd, nkt, m_MaCV);
            //new BusTienDo().updateNBDQDAndNKTQD(m_MaCV, nbd, nkt); ??????
            res = 0;
            this.Close();
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}