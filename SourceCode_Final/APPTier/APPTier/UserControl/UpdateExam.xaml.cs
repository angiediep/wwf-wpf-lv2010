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
        DataTable dt = new DataTable();
        public UpdateExam()
        {
            this.InitializeComponent();
            setDataForDatagrid();
        }

        private void setDataForDatagrid()
        {
            BUSLayer.BusDotThi exams = new BUSLayer.BusDotThi();
            dt = exams.getDataTable();
            this.dtgvExam.ItemsSource = dt.DefaultView;
            dtgvExam.Loaded += new RoutedEventHandler(dtgvUser_Loaded);
        }

        void dtgvUser_Loaded(object sender, RoutedEventArgs e)
        {
            dtgvExam.Columns[0].Header = "Mã DT";
            dtgvExam.Columns[1].Header = "Tên đợt thi";
            dtgvExam.Columns[2].Header = "Ngày thi";
            dtgvExam.Columns[3].Header = "Số lượng thí sinh";

            dtgvExam.Columns[0].Visibility = Visibility.Hidden;
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateExamDetail detail = new UpdateExamDetail();
            detail.ShowDialog();
            if (detail.Res == 0)
                setDataForDatagrid();
        }

        private void dtgvExam_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int maDT = int.Parse(dt.Rows[dtgvExam.SelectedIndex]["maDT"].ToString());
            UpdateExamDetail detail = new UpdateExamDetail(maDT);
            detail.ShowDialog();
            if (detail.Res == 0)
                setDataForDatagrid();
        }
    }
}