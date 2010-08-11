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

namespace APPTier
{
    /// <summary>
    /// Interaction logic for ThemChungChi.xaml
    /// </summary>
    public partial class ThemChungChi : Window
    {
        int res = -1;
        int macc = -1;

        public int Res
        {
            get { return res; }
            set { res = value; }
        }
        public ThemChungChi()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void btnUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (this.tbxChungChi.Text == "")
                MessageBox.Show("Lỗi! Tên chứng chỉ không thể rỗng");
            else
            {
                List<DtoChungChi> cc = new BusChungChi().getDataList();
                int temp = 0;
                for (int i = 0; i < cc.Count; i++)
                    if (this.tbxChungChi.Text == cc[i].TENCC)
                    {
                        temp = 1;
                    }
                if (temp == 1)
                {
                    MessageBox.Show("Lỗi! Chứng chỉ " + this.tbxChungChi.Text + " đã tồn tại trong hệ thống!");
                }
                else if (temp == 0)
                {
                    DtoChungChi _cc = new DtoChungChi();
                    _cc.TENCC = this.tbxChungChi.Text;
                    new BusChungChi().insertData(_cc);
                    res = 1;
					MessageBox.Show("Thêm Chứng Chỉ Thành Công");
					this.Close();
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
    }
}