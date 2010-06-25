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
	/// Interaction logic for AdminHomepage.xaml
	/// </summary>
	public partial class AdminHomepage : Window
	{
		public AdminHomepage()
		{
			this.InitializeComponent();
            tabUser.IsSelected = false;
            tabExam.IsSelected = true;
            this.Loaded += new RoutedEventHandler(AdminHomepage_Loaded);

			// Insert code required on object creation below this point.
            BusDotThi dt = new BusDotThi();
            List<DtoDotThi> listdt = dt.getDataList();
            GanttView gv = new GanttView(listdt);
            xx.Children.Add(gv);
            xx.Width = gv.Width;
            xx.Height = gv.Height;
            xx.Visibility = Visibility.Hidden;
            borGantt.Visibility = Visibility.Hidden;
		}

        void AdminHomepage_Loaded(object sender, RoutedEventArgs e)
        {
            tabExam.IsSelected = false;
            tabUser.IsSelected = true;
        }
		
		private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			//this.DragMove();
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
			xx.Visibility = Visibility.Hidden;
            borGantt.Visibility = Visibility.Hidden;
            ucInbox.Visibility = Visibility.Hidden;
            ucChangeWorkTimebyTime.Visibility = Visibility.Hidden;
            ucChangeWorkTimebyExam.Visibility = Visibility.Hidden;
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
            AssignUser.ASSIGNTYPE = 1;
			ucAssignByTime.Visibility = Visibility.Visible;
		}

		private void mitemAssignByExam_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Hidden();
            AssignUser.ASSIGNTYPE = 2;
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
			xx.Visibility = Visibility.Visible;
            borGantt.Visibility = Visibility.Visible;
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

        private void mitemChangeWorkbyTime_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Hidden();
            ucChangeWorkTimebyTime.Visibility = Visibility.Visible;
        }

        private void mitemChangeWorkbyExam_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Hidden();
            ucChangeWorkTimebyExam.Visibility = Visibility.Visible;
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Hidden();
            ucInbox.Visibility = Visibility.Visible;
        }
	}
}