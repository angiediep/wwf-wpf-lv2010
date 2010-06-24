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
using DataLayer.DTO;

namespace APPTier
{
	/// <summary>
	/// Interaction logic for ChangeWorkTimeByExam.xaml
	/// </summary>
	public partial class ChangeWorkTimeByExam : UserControl
	{
        List<string> lstTenDT;
        DataTable dt;

		public ChangeWorkTimeByExam()
		{
			this.InitializeComponent();

            lstTenDT = new BusDotThi().getDotThiXX();
            lbxExam.ItemsSource = lstTenDT;
		}

        private void lbxExam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = lbxExam.SelectedIndex;
            string tenDT = lstTenDT[idx];
            int maDT = new BusDotThi().getMaDTByTenDT(tenDT);

            setDataForDatagrid(maDT);
        }

        private void setDataForDatagrid(int maDT)
        {
            dt = new DataTable();
            dt.Columns.Add("Mã CV");
            dt.Columns.Add("Mã DT");
            dt.Columns.Add("Tên CV");
            dt.Columns.Add("Ngày bắt đầu quy định");
            dt.Columns.Add("Ngày kết thúc quy định");

            List<DtoTienDo> listdto = new BusTienDo().getListDataBymaDT(maDT);
            if (listdto != null)
            {
                foreach (DtoTienDo dto in listdto)
                {
                    DataRow row = dt.NewRow();
                    row["Mã CV"] = dto.MACV;
                    row["Mã DT"] = dto.MADT;
                    row["Tên CV"] = new BusCongViec().getTenCVByMaCV(dto.MACV);
                    row["Ngày bắt đầu quy định"] = dto.NGAYBATDAUQUYDINH.ToShortDateString();
                    row["Ngày kết thúc quy định"] = dto.NGAYKETTHUCQUYDINH.ToShortDateString();
                    dt.Rows.Add(row);
                }
                this.dtgvWorkItem.ItemsSource = dt.DefaultView;
                dtgvWorkItem.Columns[1].Visibility = Visibility.Hidden;
            }
            else
                MessageBox.Show("Chưa có dữ liệu !!!");
        }

        private void dtgvWorkItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (dt != null)
            {
                int idx = dtgvWorkItem.SelectedIndex;
                if (idx != -1)
                {
                    int maDT = int.Parse(dt.Rows[idx]["Mã DT"].ToString());
                    int maCV = int.Parse(dt.Rows[idx]["Mã CV"].ToString());

                    ChangeWorkTimeByExamDetail detail = new ChangeWorkTimeByExamDetail(maDT, maCV);
                    detail.ShowDialog();
                    if (detail.Res == 0)
                        setDataForDatagrid(maDT);   
                }
            }
        }
	}
}