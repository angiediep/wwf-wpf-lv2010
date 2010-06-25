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
using BUSLayer;
using System.Data;

namespace APPTier
{
	/// <summary>
	/// Interaction logic for ChangeWorkTimebyTime.xaml
	/// </summary>
	public partial class ChangeWorkTimebyTime : UserControl
	{
        DataTable dt = new DataTable();

		public ChangeWorkTimebyTime()
		{
			this.InitializeComponent();

            setDataForDatagrid();
            dtgvWorkItem.Loaded += new RoutedEventHandler(dtgvUser_Loaded);
		}

        private void setDataForDatagrid()
        {
            BusCongViec cv = new BusCongViec();
            dt = cv.getData();  
            this.dtgvWorkItem.ItemsSource = dt.DefaultView;
        }

        void dtgvUser_Loaded(object sender, RoutedEventArgs e)
        {
            setColumn();
        }

        private void setColumn()
        {
            dtgvWorkItem.Columns[0].Header = "Mã CV";
            dtgvWorkItem.Columns[1].Header = "Tên công việc";
            dtgvWorkItem.Columns[2].Header = "Ngày bắt đầu";
            dtgvWorkItem.Columns[3].Header = "Ngày kết thúc";

            dtgvWorkItem.Columns[0].Visibility = Visibility.Hidden;
        }

		private void btnReset_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

        private void dtgvWorkItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (dt != null)
            {
                int idx = dtgvWorkItem.SelectedIndex;
                if (idx != -1)
                {
                    int maCV = int.Parse(dt.Rows[idx]["maCV"].ToString());
                    ChangeWorkTimebyTimeDetail detail = new ChangeWorkTimebyTimeDetail(maCV);
                    detail.ShowDialog();
                    if (detail.Res == 0)
                    {
                        setDataForDatagrid();
                        setColumn();
                    }      
                }
            }
        }
	}
}