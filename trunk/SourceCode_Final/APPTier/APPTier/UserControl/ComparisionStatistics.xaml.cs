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
using System.Windows.Controls.DataVisualization.Charting;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for ComparisionStatistics.xaml
    /// </summary>
    public partial class ComparisionStatistics : UserControl
    {
        public ComparisionStatistics()
        {
            this.InitializeComponent();
            BusTienDo td = new BusTienDo();
            List<int> listYear = td.getListYearForComparisonStat();
            cbxYear2.ItemsSource = cbxYear1.ItemsSource = listYear;
        }

        private void setWidthForSuperGrid(List<int> width)
        {
            int max = 0;
            for (int i = 0; i < width.Count; i++)
                max = Math.Max(max, width[i]);
            this.SuperGrid.Width = max + 5000;
        }

        private void cbxChiTiet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cbxChiTiet.SelectedIndex == 0)
            //{
            //    MyChart1.Visibility = Visibility.Hidden;
            //    MyChart11.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    MyChart1.Visibility = Visibility.Visible;
            //    MyChart11.Visibility = Visibility.Hidden;
            //}
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cbxChiTiet.SelectedIndex == 0)
            //{
            //    MyChart2.Visibility = Visibility.Hidden;
            //    MyChart22.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    MyChart2.Visibility = Visibility.Visible;
            //    MyChart22.Visibility = Visibility.Hidden;
            //}
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //if (cbxChiTiet.SelectedIndex == 0)
            //{
            //    MyChart3.Visibility = Visibility.Hidden;
            //    MyChart33.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    MyChart3.Visibility = Visibility.Visible;
            //    MyChart33.Visibility = Visibility.Hidden;
            //}
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            int year1 = int.Parse(cbxYear1.SelectedValue.ToString());
            int year2 = int.Parse(cbxYear2.SelectedValue.ToString());
            int month1 = int.Parse(cbxMonth1.SelectedValue.ToString());
            int month2 = int.Parse(cbxMonth2.SelectedValue.ToString());

            x1(year1,month1);
            x2(year2, month2);

            List<int> width = new List<int>();
            List<KeyValuePair<string, int>> res1 = new BusTienDo().getDataForChart(year1, month1);
            List<KeyValuePair<string, int>> res2 = new BusTienDo().getDataForChart(year2, month2);
            int w = res1.Count * 100;
            this.MyChart1.Width = w;
            this.MyChart11.Width = w;
            width.Add(w);
            ((ColumnSeries)mcChart11.SeriesHost.Series[0]).ItemsSource = res1;
            ((ColumnSeries)mcChart12.SeriesHost.Series[0]).ItemsSource = res2;
            ((LineSeries)mcChart21.SeriesHost.Series[0]).ItemsSource = res1;
            ((LineSeries)mcChart22.SeriesHost.Series[0]).ItemsSource = res2;

            res1 = new BusTienDo().getDataForChart2(year1, month1);
            res2 = new BusTienDo().getDataForChart2(year2, month2);
            w = res1.Count * 100;
            this.MyChart3.Width = w;
            this.MyChart4.Width = w;
            width.Add(w);
            ((ColumnSeries)mcChart31.SeriesHost.Series[0]).ItemsSource = res1;
            ((ColumnSeries)mcChart32.SeriesHost.Series[0]).ItemsSource = res2;
            ((LineSeries)mcChart41.SeriesHost.Series[0]).ItemsSource = res1;
            ((LineSeries)mcChart42.SeriesHost.Series[0]).ItemsSource = res2;

            res1 = new BusTienDo().getDataForChart3(year1, month1);
            res2 = new BusTienDo().getDataForChart3(year2, month2);
            w = res1.Count * 100;
            this.MyChart5.Width = w;
            this.MyChart6.Width = w;
            width.Add(w);
            ((ColumnSeries)mcChart51.SeriesHost.Series[0]).ItemsSource = res1;
            ((ColumnSeries)mcChart52.SeriesHost.Series[0]).ItemsSource = res2;
            ((LineSeries)mcChart61.SeriesHost.Series[0]).ItemsSource = res1;
            ((LineSeries)mcChart62.SeriesHost.Series[0]).ItemsSource = res2;

            setWidthForSuperGrid(width);
        }

        private void x2(int y, int m)
        {
            BusTienDo bus = new BusTienDo();
            int sum = bus.getSumTS(y, m);
            this.tbxSoThiSinh2.Text = sum + " bài thi.";

            sum = bus.getSumCC(y, m);
            this.txbSLCC2.Text = sum + " chứng chỉ.";

            int x1 = new BusTienDo().getCVHoanThanhDungHanCT(y, m);
            int x2 = new BusTienDo().getCVHoanThanhTreHanCT(y, m);
            this.txbChiTietTungCongDoan2.Text = "Tổng số công việc hoàn thành đúng hạn: " + x1 + " (công việc); Tổng số công việc trễ hạn:" + x2 + " (công việc)";

            int x3 = new BusTienDo().getCVHoanThanhDungHanCDT(y, m);
            int x4 = new BusTienDo().getCVHoanThanhTreHanCDT(y, m);
            this.txbCongDoanThi2.Text = "Tổng số công việc hoàn thành đúng hạn: " + x3 + " (công việc); Tổng số công việc trễ hạn:" + x4 + " (công việc)";

            int x5 = new BusTienDo().getCVHoanThanhDungHanCHT(y, m);
            int x6 = new BusTienDo().getCVHoanThanhTreHanCHT(y, m);
            this.txbChamThi2.Text = "Tổng số công việc hoàn thành đúng hạn: " + x5 + " (công việc); Tổng số công việc trễ hạn:" + x6 + " (công việc)";

            int x7 = new BusTienDo().getCVHoanThanhDungHanCCI(y, m);
            int x8 = new BusTienDo().getCVHoanThanhTreHanCCI(y, m);
            this.txbCCVaIn2.Text = "Tổng số công việc hoàn thành đúng hạn: " + x7 + " (công việc); Tổng số công việc trễ hạn:" + x8 + " (công việc)";

            string s1 = new BusTienDo().getChiTietTungThoiKy(y, m);
            this.txbChiTietTungThoiKy2.Text = s1;

            string s2 = new BusTienDo().getNVTreHan(y, m);
            this.txbCacNVTreHan2.Text = s2;
        }

        private void x1(int y, int m)
        {
            BusTienDo bus = new BusTienDo();
            int sum = bus.getSumTS(y,m);
            this.tbxSoThiSinh1.Text = sum + " bài thi.";

            sum = bus.getSumCC(y,m);
            this.txbSLCC1.Text = sum + " chứng chỉ.";

            int x1 = new BusTienDo().getCVHoanThanhDungHanCT(y,m);
            int x2 = new BusTienDo().getCVHoanThanhTreHanCT(y,m);
            this.txbChiTietTungCongDoan1.Text = "Tổng số công việc hoàn thành đúng hạn: " + x1 + " (công việc); Tổng số công việc trễ hạn:" + x2 + " (công việc)";

            int x3 = new BusTienDo().getCVHoanThanhDungHanCDT(y,m);
            int x4 = new BusTienDo().getCVHoanThanhTreHanCDT(y,m);
            this.txbCongDoanThi1.Text = "Tổng số công việc hoàn thành đúng hạn: " + x3 + " (công việc); Tổng số công việc trễ hạn:" + x4 + " (công việc)";

            int x5 = new BusTienDo().getCVHoanThanhDungHanCHT(y,m);
            int x6 = new BusTienDo().getCVHoanThanhTreHanCHT(y,m);
            this.txbChamThi1.Text = "Tổng số công việc hoàn thành đúng hạn: " + x5 + " (công việc); Tổng số công việc trễ hạn:" + x6 + " (công việc)";

            int x7 = new BusTienDo().getCVHoanThanhDungHanCCI(y,m);
            int x8 = new BusTienDo().getCVHoanThanhTreHanCCI(y,m);
            this.txbCCVaIn1.Text = "Tổng số công việc hoàn thành đúng hạn: " + x7 + " (công việc); Tổng số công việc trễ hạn:" + x8 + " (công việc)";

            string s1 = new BusTienDo().getChiTietTungThoiKy(y,m);
            this.txbChiTietTungThoiKy1.Text = s1;

            string s2 = new BusTienDo().getNVTreHan(y,m);
            this.txbCacNVTreHan1.Text = s2;
        }

        private void cbxYear1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int year = int.Parse(cbxYear1.SelectedValue.ToString());
            List<int> list = new BusTienDo().getListMonthForComparisonStat(year);
            cbxMonth1.ItemsSource = list;
        }

        private void cbxYear2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int year = int.Parse(cbxYear2.SelectedValue.ToString());
            List<int> list = new BusTienDo().getListMonthForComparisonStat(year);
            cbxMonth2.ItemsSource = list;
        }
    }
}
