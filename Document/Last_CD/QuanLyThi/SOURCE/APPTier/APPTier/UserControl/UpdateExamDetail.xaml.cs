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
        DtoChungChi cc = new DtoChungChi();

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
            int SoluongThiSinh = 0;
            tbxSoluongthisinh.Text = SoluongThiSinh.ToString();
            List<string> Tencc = new List<string>();
            List<DtoChungChi> _cc = new BusChungChi().getDataList();
            for (int i = 0; i < _cc.Count; i++)
            {
                Tencc.Add(_cc[i].TENCC);
            }
            cbxChungChi.ItemsSource = Tencc;
            cbxChungChi.SelectedIndex = 0;
		}
		
		public void setComboItem()
		{
            List<string> Tencc = new List<string>();
            List<DtoChungChi> _cc = new BusChungChi().getDataList();
            for (int i = 0; i < _cc.Count; i++)
            {
                Tencc.Add(_cc[i].TENCC);
            }
            this.cbxChungChi.ItemsSource = null;
            this.cbxChungChi.Items.Clear();
            this.cbxChungChi.ItemsSource = Tencc;
            cbxChungChi.SelectedIndex = 0;
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
            List<DtoDotThi_ChungChi> dtcc = new BusDotThi_ChungChi().getDataList();       
            for (int i = 0; i < dtcc.Count; i++)
            {
                if (dtcc[i].MADT == maDT)
                    cc = new BusChungChi().getDataById( dtcc[i].MACC);
            }
            List<DtoChungChi> _cc = new BusChungChi().getDataList();
            for (int i = 0; i < _cc.Count; i++)
            {
                cbxChungChi.Items.Add(_cc[i].TENCC);
            }
            cbxChungChi.SelectedIndex = cc.MACC - 1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DtoDotThi dt = new DtoDotThi();
            dt.MADT = m_MaDT;
            dt.TENDOTTHI = tbxDotThi.Text;
            dt.NGAYTHI = DateTime.Parse(tbxPassword.Text);
            dt.SOLUONGTHISINH = int.Parse(tbxSoluongthisinh.Text);
            DtoDotThi_ChungChi dtcc = new DtoDotThi_ChungChi();
            dtcc.MACC = cbxChungChi.SelectedIndex + 1;
            dtcc.MADT = m_MaDT;
            dtcc.SOLUONGTHISINH = int.Parse(tbxSoluongthisinh.Text);


            if (MessageBox.Show("Thật sự muốn sửa ?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                new BusDotThi().updateData(dt);
                new BusDotThi_ChungChi().updateData(dtcc);

                this.Close();
            }
            res = 0;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DtoDotThi dt = new BusDotThi().getDataById(m_MaDT);
            DtoDotThi_ChungChi _dtcc = new DtoDotThi_ChungChi();
            List<DtoDotThi_ChungChi> dtcc = new BusDotThi_ChungChi().getDataList();
            for (int i = 0; i < dtcc.Count; i++)
            {
                if (dtcc[i].MADT == m_MaDT)
                    cc = new BusChungChi().getDataById(dtcc[i].MACC);
            }
            _dtcc.MADT = m_MaDT;
            _dtcc.MACC = cc.MACC;
            _dtcc.SOLUONGTHISINH = dt.SOLUONGTHISINH;

            if (MessageBox.Show("Thật sự muốn xóa ?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                new BusDotThi().deleteData(dt);
                new BusDotThi_ChungChi().deleteData(_dtcc);
                this.Close();
            }
            res = 0;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
            
            if ((tbxPassword.Text == "") || (tbxDotThi.Text == "") || (tbxSoluongthisinh.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }
            else
            {
                try
                {
                    DtoDotThi dt = new DtoDotThi();
                    dt.TENDOTTHI = tbxDotThi.Text;
                    dt.NGAYTHI = DateTime.Parse(tbxPassword.Text);
                    
                    if (dt.NGAYTHI > DateTime.Now.AddDays(BusTienDo.getNgayKetThuc()))
                    {
                        dt.SOLUONGTHISINH = int.Parse(tbxSoluongthisinh.Text);

                        if (MessageBox.Show("Thật sự muốn thêm đợt thi?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            new BusDotThi().insertData(dt);
                            DtoDotThi_ChungChi dtcc = new DtoDotThi_ChungChi();
                            dtcc.MADT = new BusDotThi().getMaDTByTenDT(tbxDotThi.Text);
                            dtcc.MACC = cbxChungChi.SelectedIndex + 1;
                            dtcc.SOLUONGTHISINH = int.Parse(tbxSoluongthisinh.Text);
                            new BusDotThi_ChungChi().insertData(dtcc);
                            this.Close();
                        }
                        res = 0;   
                    }
                    else if (dt.NGAYTHI <= DateTime.Now.AddDays(BusTienDo.getNgayKetThuc()))
                    {
                        MessageBox.Show("Ngày thi phải sau ngày hôm nay " + BusTienDo.getNgayKetThuc() + " ngày! Nghĩa là phải sau ngày " + DateTime.Now.AddDays(BusTienDo.getNgayKetThuc()).ToShortDateString().ToString() + ".");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu không đúng định dạng. Vui lòng nhập lại.");
                    return;
                }
            }
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

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			ThemChungChi detail= new ThemChungChi();
            detail.ShowDialog();
            if (detail.Res == 1)
            {
                setComboItem();
            }
        }
    }
}