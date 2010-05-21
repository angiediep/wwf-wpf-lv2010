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

namespace APPTier
{
	/// <summary>
	/// Interaction logic for AdminHomepage.xaml
	/// </summary>
	public partial class AdminHomepage : Window
	{
		public AdminHomepage()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
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
		
		public void Hidden()
		{
			ucUpdateUser.Visibility = Visibility.Hidden;
			ucAssignByTime.Visibility = Visibility.Hidden;
			ucAssignByExam.Visibility = Visibility.Hidden;
			ucUpdateExam.Visibility = Visibility.Hidden;
			ucGeneralStatistic.Visibility = Visibility.Hidden;
			ucDetailStatistic.Visibility = Visibility.Hidden;
			ucComparisionStatistic.Visibility = Visibility.Hidden;
			ucGanttStatistic.Visibility = Visibility.Hidden;
		}

		private void mitemUpdateUser_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucUpdateUser.Visibility = Visibility.Visible;
		}

		private void mitemAssignByTime_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucAssignByTime.Visibility = Visibility.Visible;
		}

		private void mitemAssignByExam_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucAssignByExam.Visibility = Visibility.Visible;
		}

		private void mitemUpdateExam_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucUpdateExam.Visibility = Visibility.Visible;
		}

		private void mitemGeneralStatistic_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucGeneralStatistic.Visibility = Visibility.Visible;
		}

		private void mitemGanttStatistic_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucGanttStatistic.Visibility = Visibility.Visible;
		}

		private void mitemCompareStatistic_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucComparisionStatistic.Visibility = Visibility.Visible;
		}

		private void mitemDetailStatistic_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
			ucDetailStatistic.Visibility = Visibility.Visible;
		}
	}
}