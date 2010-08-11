using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using BUSLayer;
using DataLayer.DTO;
using Microsoft.Windows.Controls;


using System.Text.RegularExpressions;
using QuanLyThi.UserControl;
using Microsoft.Windows.Controls.Primitives;
using System.Windows.Media;
namespace APPTier
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : UserControl
    {
        List<DtoNhanVienThuaHanh> lst;
        List<NVInfoTemp> datasource;

        public UpdateUser()
        {
            this.InitializeComponent();

            datasource = new List<NVInfoTemp>();
            setDataForGrid();
            dtgvUser.Loaded += new RoutedEventHandler(dtgvUser_Loaded);
        }

        void dtgvUser_Loaded(object sender, RoutedEventArgs e)
        {
            setColumn();
        }

        private void setColumn()
        {
            if (datasource.Count != 0)
            {
                dtgvUser.Columns[0].Header = "Tên đăng nhập";
                dtgvUser.Columns[1].Header = "Email";
                dtgvUser.Columns[2].Header = "Họ và tên ";
                dtgvUser.Columns[3].Header = "Điện thoại";
            }
        }

        private void dtgvUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dtgvUser.SelectedIndex > -1)
            {
                int maNV = lst[dtgvUser.SelectedIndex].MANV;
                Register regForm = new Register(maNV);
                regForm.ShowDialog();
                if (regForm.MaNV == -2)
                    regForm.Close();
                else if (regForm.MaNV == -3)
                {
                    setDataForGrid();
                    setColumn();
                }   
            }
        }

        private void setDataForGrid()
        {
            BusNhanVienThuaHanh users = new BusNhanVienThuaHanh();
            lst = users.getDataList();
            datasource.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                NVInfoTemp te = new NVInfoTemp();
                te.DIENTHOAI = lst[i].DIENTHOAI;
                te.EMAIL = lst[i].EMAIL;
                te.TENNV = lst[i].TENNV;
                te.TENDANGNHAP = lst[i].TENDANGNHAP;
                datasource.Add(te);
            }
            dtgvUser.ItemsSource = null;
            dtgvUser.ItemsSource = datasource;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Register regForm = new Register(-4f);
            regForm.ShowDialog();
            setDataForGrid();
            setColumn();
        }
    }

    public class NVInfoTemp
    {
        private string mtenDangNhap;

        public string TENDANGNHAP
        {
            get { return mtenDangNhap; }

            set { mtenDangNhap = value; }
        }
        private string memail;


        public string EMAIL
        {
            get { return memail; }

            set { memail = value; }
        }

        private string mtenNV;


        public string TENNV
        {
            get { return mtenNV; }

            set { mtenNV = value; }
        }

        private string mdienThoai;


        public string DIENTHOAI
        {
            get { return mdienThoai; }

            set { mdienThoai = value; }
        }

    }
}