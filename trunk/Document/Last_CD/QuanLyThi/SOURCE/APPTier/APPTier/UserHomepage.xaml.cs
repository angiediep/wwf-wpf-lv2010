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
using QuanLyThi;

namespace APPTier
{
	/// <summary>
	/// Interaction logic for UserHomepage.xaml
	/// </summary>
	public partial class UserHomepage : Window
	{
		public UserHomepage()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
           
            //string uname = Constants.strUserName;
            //BusDotThi bus = new BusDotThi();
            //List<string> list = bus.getDotThiTheoNV(uname);
            // binding !!
            
		}

        public void setTotalMsg(int x)
        {
            this.btnNewMsg.Content = "Thông điệp mới (" + x + ")";
            
        }
		
		private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			this.DragMove();
		}
		
		private void btnMinimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			this.WindowState = WindowState.Minimized;
		}
		
		private void btnClose_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?","Thoát", MessageBoxButton.YesNo);
            if (msg == MessageBoxResult.Yes)
            { 
                this.Close();
            }
		}

		private void btnSearch_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void btnHome_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucHome.Visibility = Visibility.Visible;
			
		}

		private void Hidden()
		{
			ucHome.Visibility = Visibility.Hidden;
			ucInbox.Visibility = Visibility.Hidden;
			ucPersonalInfo.Visibility = Visibility.Hidden;
		}

		private void btnNewMsg_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucInbox.Visibility = Visibility.Visible;
		}

		private void btnPersonalInfo_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			Hidden();
			ucPersonalInfo.Visibility = Visibility.Visible;
		}
	}
}