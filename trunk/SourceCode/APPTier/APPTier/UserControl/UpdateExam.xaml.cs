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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using BUSLayer;

namespace APPTier
{
	/// <summary>
	/// Interaction logic for UpdateExam.xaml
	/// </summary>
	public partial class UpdateExam : UserControl
	{
		public UpdateExam()
		{
			this.InitializeComponent();
            BUSLayer.BusDOTTHI exams = new BUSLayer.BusDOTTHI();
            DataTable dt = new DataTable();
            dt = exams.getDataTable();
            this.dtgvExam.ItemsSource = dt.DefaultView;
		}

		private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn có chắc bạn muốn lưu thông tin đã cập nhật không?", "Cập nhật Nhân viên", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.No)
            {
                BusDOTTHI exams = new BusDOTTHI();
                DataTable dt = new DataTable();
                dt = exams.getDataTable();
                this.dtgvExam.ItemsSource = dt.DefaultView;
            }
            else
            {
                //Luu thong tin da cap nhat xuong
                //Hien thi lai thong tin
            }
		}

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            MessageBoxResult msg = MessageBox.Show("Bạn có chắc bạn muốn hủy cập nhật thông tin không?","Cập nhật Đợt thi", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            {
                BusDOTTHI exams = new BusDOTTHI();
                DataTable dt = new DataTable();
                dt = exams.getDataTable();
                this.dtgvExam.ItemsSource = dt.DefaultView;
            }
		}
	}
}