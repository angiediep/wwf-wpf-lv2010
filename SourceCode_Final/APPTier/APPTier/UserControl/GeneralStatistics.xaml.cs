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
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.DataVisualization.Charting;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for GeneralStatistics.xaml
    /// </summary>
    public partial class GeneralStatistics : UserControl
    {
        public GeneralStatistics()
        {
            this.InitializeComponent();
            List<int> width = new List<int>();

            BusTienDo bus = new BusTienDo();
            int sum = bus.getSumTS();
            this.tbxSoThiSinh.Text = sum + " bài thi.";

            List<KeyValuePair<string, int>> res = new BusTienDo().getDataForChart();
            int w = res.Count * 100;
            this.MyChart1.Width = w;
            this.MyChart11.Width = w;
            width.Add(w);
            ((LineSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;
            ((ColumnSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;
           
            sum = bus.getSumCC();
            this.txbSLCC.Text = sum + " chứng chỉ.";

            res = new BusTienDo().getDataForChart2();
            w = res.Count * 100;
            this.MyChart2.Width = w;
            this.MyChart22.Width =w;
            width.Add(w);
            ((LineSeries)mcChart3.SeriesHost.Series[0]).ItemsSource = res;
            ((ColumnSeries)mcChart4.SeriesHost.Series[0]).ItemsSource = res;

            int x1 = new BusTienDo().getCVHoanThanhDungHanCT();
            int x2 = new BusTienDo().getCVHoanThanhTreHanCT();
            this.txbChiTietTungCongDoan.Text = "Tổng số công việc hoàn thành đúng hạn: " + x1 + " (công việc); Tổng số công việc trễ hạn:" + x2 + " (công việc)";

            int x3 = new BusTienDo().getCVHoanThanhDungHanCDT();
            int x4 = new BusTienDo().getCVHoanThanhTreHanCDT();
            this.txbCongDoanThi.Text = "Tổng số công việc hoàn thành đúng hạn: " + x3 + " (công việc); Tổng số công việc trễ hạn:" + x4 + " (công việc)";

            int x5 = new BusTienDo().getCVHoanThanhDungHanCHT();
            int x6 = new BusTienDo().getCVHoanThanhTreHanCHT();
            this.txbChamThi.Text = "Tổng số công việc hoàn thành đúng hạn: " + x5 + " (công việc); Tổng số công việc trễ hạn:" + x6 + " (công việc)";

            int x7 = new BusTienDo().getCVHoanThanhDungHanCCI();
            int x8 = new BusTienDo().getCVHoanThanhTreHanCCI();
            this.txbCCVaIn.Text = "Tổng số công việc hoàn thành đúng hạn: " + x7 + " (công việc); Tổng số công việc trễ hạn:" + x8 + " (công việc)";

            res = new BusTienDo().getDataForChart3();
            w = res.Count * 100;
            this.MyChart3.Width = w;
            this.MyChart33.Width = w;
            width.Add(w);
            ((LineSeries)mcChart5.SeriesHost.Series[0]).ItemsSource = res;
            ((ColumnSeries)mcChart6.SeriesHost.Series[0]).ItemsSource = res;

            string s1 = new BusTienDo().getChiTietTungThoiKy();
            txbChiTietTungThoiKy.Text = s1;

            string s2 = new BusTienDo().getNVTreHan();
            txbCacNVTreHan.Text = s2;

            setWidthForSuperGrid(width);
        }

        private void setWidthForSuperGrid(List<int> width)
        {
            int max = 0;
            for (int i = 0; i < width.Count; i++)
                max = Math.Max(max,width[i]);
            this.SuperGrid.Width = max;
        }

        private void cbxChiTiet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxChiTiet.SelectedIndex == 0)
            {
                MyChart1.Visibility = Visibility.Hidden;
                MyChart11.Visibility = Visibility.Visible;
            }
            else
            {
                MyChart1.Visibility = Visibility.Visible;
                MyChart11.Visibility = Visibility.Hidden;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxChiTiet.SelectedIndex == 0)
            {
                MyChart2.Visibility = Visibility.Hidden;
                MyChart22.Visibility = Visibility.Visible;
            }
            else
            {
                MyChart2.Visibility = Visibility.Visible;
                MyChart22.Visibility = Visibility.Hidden;
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cbxChiTiet.SelectedIndex == 0)
            {
                MyChart3.Visibility = Visibility.Hidden;
                MyChart33.Visibility = Visibility.Visible;
            }
            else
            {
                MyChart3.Visibility = Visibility.Visible;
                MyChart33.Visibility = Visibility.Hidden;
            }
        }
    }
}