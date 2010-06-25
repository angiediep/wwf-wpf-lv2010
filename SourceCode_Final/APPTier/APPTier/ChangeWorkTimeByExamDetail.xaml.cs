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
    public partial class ChangeWorkTimeByExamDetail : Window
    {
        int m_MaDT = -1;
        int m_MaCV = -1;
        int res = -1;

        public int Res
        {
            get { return res; }
            set { res = value; }
        }

        public ChangeWorkTimeByExamDetail()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            btnUpdate.Visibility = Visibility.Hidden;
        }

        public ChangeWorkTimeByExamDetail(int maDT, int maCV)
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            m_MaDT = maDT;
            m_MaCV = maCV;

            List<string> res = new BusTienDo().getDataByMaDTAndMaCV(maDT, maCV);
            tbxDotThi.Text = res[0];
            tbxPassword.Text = res[1];
            tbxSoluongthisinh.Text = res[2];
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DtoTienDo td = new DtoTienDo();
            td.MACV = m_MaCV;
            td.MADT = m_MaDT;
            td.NGAYBATDAUQUYDINH = DateTime.Parse(tbxPassword.Text);
            td.NGAYKETTHUCQUYDINH = DateTime.Parse(tbxSoluongthisinh.Text);

            new BusTienDo().updateDataByMaCVAndMaDT(td);
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