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
    public partial class UpdateExamDetail : Window
    {
        int m_MaDT = -1;
        int res = -1;

        public int Res
        {
            get { return res; }
            set { res = value; }
        }

        public UpdateExamDetail()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            btnUpdate.Visibility = Visibility.Hidden;
            btnXoa.Visibility = Visibility.Hidden;
        }

        public UpdateExamDetail(int maDT)
        {
            this.InitializeComponent();
            btnRegister.Visibility = Visibility.Hidden;

            // Insert code required on object creation below this point.
            m_MaDT = maDT;

            DtoDotThi dt = new BusDotThi().getDataById(m_MaDT);
            tbxDotThi.Text = dt.TENDOTTHI;
            tbxPassword.Text= dt.NGAYTHI.ToShortDateString();
            tbxSoluongthisinh.Text = dt.SOLUONGTHISINH.ToString();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DtoDotThi dt = new DtoDotThi();
            dt.MADT = m_MaDT;
            dt.TENDOTTHI = tbxDotThi.Text;
            dt.NGAYTHI = DateTime.Parse(tbxPassword.Text);
            dt.SOLUONGTHISINH = int.Parse(tbxSoluongthisinh.Text);

            new BusDotThi().updateData(dt);
            res = 0;
            this.Close();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DtoDotThi dt = new DtoDotThi();
            dt.MADT = m_MaDT;
            dt.TENDOTTHI = tbxDotThi.Text;
            dt.NGAYTHI = DateTime.Parse(tbxPassword.Text);
            dt.SOLUONGTHISINH = int.Parse(tbxSoluongthisinh.Text);

            new BusDotThi().deleteData(dt);
            res = 0;
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            DtoDotThi dt = new DtoDotThi();
            dt.TENDOTTHI = tbxDotThi.Text;
            dt.NGAYTHI = DateTime.Parse(tbxPassword.Text);
            dt.SOLUONGTHISINH = int.Parse(tbxSoluongthisinh.Text);

            new BusDotThi().insertData(dt);
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