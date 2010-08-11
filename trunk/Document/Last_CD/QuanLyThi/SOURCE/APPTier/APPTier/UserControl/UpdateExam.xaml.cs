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
using DataLayer;
using DataLayer.DTO;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for UpdateExam.xaml
    /// </summary>
    public partial class UpdateExam : UserControl
    {
        List<DtoDotThi> dotthi;
        public UpdateExam()
        {
            this.InitializeComponent();
            setDataForDatagrid();
            dtgvExam.Loaded += new RoutedEventHandler(dtgvUser_Loaded);
        }

        private void setDataForDatagrid()
        {
            BUSLayer.BusDotThi exams = new BUSLayer.BusDotThi();
            dotthi = exams.getListDataUpComming();
            this.dtgvExam.ItemsSource = dotthi;
        }

        void dtgvUser_Loaded(object sender, RoutedEventArgs e)
        {
            setColumn();
        }

        private void setColumn()
        {
            if (dotthi.Count != 0)
            {
                dtgvExam.Columns[0].Header = "Mã DT";
                dtgvExam.Columns[1].Header = "Tên đợt thi";
                dtgvExam.Columns[2].Header = "Ngày thi";
                dtgvExam.Columns[3].Header = "Số lượng thí sinh";

                dtgvExam.Columns[0].Visibility = Visibility.Hidden;
                dtgvExam.Columns[4].Visibility = Visibility.Hidden;
            }
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateExamDetail detail = new UpdateExamDetail();
            detail.ShowDialog();
            if (detail.Res == 0)
            {
                setDataForDatagrid();
                setColumn();
            }
        }

        private void dtgvExam_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (dtgvExam.SelectedIndex != -1)
            {
                int maDT = int.Parse(dotthi[dtgvExam.SelectedIndex].MADT.ToString());
                UpdateExamDetail detail = new UpdateExamDetail(maDT);
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