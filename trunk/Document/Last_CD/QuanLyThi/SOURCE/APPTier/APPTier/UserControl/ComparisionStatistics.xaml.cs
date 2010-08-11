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
using StatHandlers;
using System.Data;
using DataLayer.DTO;
using System.Data.SqlClient;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for ComparisionStatistics.xaml
    /// </summary>
    public partial class ComparisionStatistics : UserControl
    {
        StatXMLParser parser;
        int objIdx;
        int criIdx;
        int typeIdx;
        int maDT;

        public ComparisionStatistics()
        {
            this.InitializeComponent();
            Hidden();
            objIdx = -1;
            criIdx = -1;
            typeIdx = -1;
            maDT = -1;
            loadXMLFile();
        }

        private void loadXMLFile()
        {
            parser = new StatXMLParser("Stat.xml");
            parser.Parse();

            List<string> doiTuongThongke = new List<string>();
            for (int i = 0; i < parser.ObjectList.Count; i++)
                doiTuongThongke.Add(parser.ObjectList[i].Name);
            cbxObject.ItemsSource = doiTuongThongke;

            List<int> listYear = new BusTienDo().getListYearForComparisonStat();
            cbxYear1.ItemsSource = cbxYear1.ItemsSource = listYear;
            cbxYear2.ItemsSource = cbxYear2.ItemsSource = listYear;
            cbxYear1.SelectedIndex = cbxYear1.SelectedIndex = 0;
            cbxYear2.SelectedIndex = cbxYear2.SelectedIndex = 0;
        }

        private void cbxYear1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = cbxYear1.SelectedIndex;
            if (idx != -1)
            {
                int year = int.Parse(cbxYear1.SelectedValue.ToString());
                List<int> list = new BusTienDo().getListMonthForComparisonStat(year);
                cbxMonth1.ItemsSource = list;
                cbxMonth1.SelectedIndex = 0;
            }
        }

        private void cbxYear2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = cbxYear2.SelectedIndex;
            if (idx != -1)
            {
                int year = int.Parse(cbxYear2.SelectedValue.ToString());
                List<int> list = new BusTienDo().getListMonthForComparisonStat(year);
                cbxMonth2.ItemsSource = list;
                cbxMonth2.SelectedIndex = 0;
            }
        }

        private void cbxObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objIdx = cbxObject.SelectedIndex;
            if (objIdx != -1)
            {
                List<string> tieuChi = new List<string>();
                for (int i = 0; i < parser.ObjectList[objIdx].CriteriaList.Count; i++)
                    tieuChi.Add(parser.ObjectList[objIdx].CriteriaList[i].Name);
                cbxCriteria.ItemsSource = tieuChi;
            }
        }

        private void cbxCriteria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            criIdx = cbxCriteria.SelectedIndex;
            if (criIdx != -1)
            {
                List<string> type = new List<string>();
                for (int i = 0; i < parser.ObjectList[objIdx].CriteriaList[criIdx].TypeList.Count; i++)
                    type.Add(parser.ObjectList[objIdx].CriteriaList[criIdx].TypeList[i].Name);
                cbxType.ItemsSource = type;
            }
            cbxType.SelectedIndex = 0;
        }

        private void cbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            typeIdx = cbxType.SelectedIndex;
        }


        /// <summary>
        /// xử lý đọc file XML lưu kiểu thống kê
        /// </summary>
        /// <returns></returns>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            int year1 = int.Parse(cbxYear1.SelectedValue.ToString());
            int year2 = int.Parse(cbxYear2.SelectedValue.ToString());
            int month1 = int.Parse(cbxMonth1.SelectedValue.ToString());
            int month2 = int.Parse(cbxMonth2.SelectedValue.ToString());
            if ((objIdx != -1) && ((criIdx != -1) && ((typeIdx != -1))))
            {
                string fName = parser.ObjectList[objIdx].CriteriaList[criIdx].TypeList[typeIdx].Method;
                switch (fName)
                {
                    case "f1":
                        tRes.Text = f1(year1, month1);
                        tRes1.Text = f1(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;
                        break;
                    case "f2":
                        tRes.Text = f2(year1, month1);
                        tRes1.Text = f2(year2, month2);

                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;
                        break;
                    case "f2a":
                        tRes.Text = f2a(year1, month1);
                        tRes1.Text = f2a(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f3":
                        tRes.Text = f3(year1, month1);
                        tRes1.Text = f3(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f3a":
                        tRes.Text = f3a(year1, month1);
                        tRes1.Text = f3a(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f4":
                        gRes.ItemsSource = f4(year1, month1).DefaultView;
                        gRes1.ItemsSource = f4(year2, month2).DefaultView;
                        gRes.Visibility = Visibility.Visible;
                        gRes1.Visibility = Visibility.Visible;
                        break;
                    case "f5":
                        tRes.Text = f5(year1, month1);
                        tRes1.Text = f5(year2, month2);
						gRes.Visibility = Visibility.Visible;
                        gRes1.Visibility = Visibility.Visible;
                        break;
                    case "f6":
                        tRes.Text = f6(year1, month1);
                        tRes1.Text = f6(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f7":
                        tRes.Text = f7(year1, month1);
                        tRes1.Text = f7(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f8":
                        tRes.Text = f8(year1, month1);
                        tRes1.Text = f8(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f9":
                        tRes.Text = f9(year1, month1);
                        tRes1.Text = f9(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f10":
                        tRes.Text = f10(year1, month1);
                        tRes1.Text = f10(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f11":
                        tRes.Text = f11(year1, month1);
                        tRes1.Text = f11(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f12":
                        tRes.Text = f12(year1, month1);
                        tRes1.Text = f12(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f13":
                        tRes.Text = f13(year1, month1);
                        tRes1.Text = f13(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f14":
                        tRes.Text = f14(year1, month1);
                        tRes1.Text = f14(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f15":
                        tRes.Text = f15(year1, month1);
                        tRes1.Text = f15(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f16":
                        tRes.Text = f16(year1, month1);
                        tRes1.Text = f16(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f17":
                        tRes.Text = f17(year1, month1);
                        tRes1.Text = f17(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f18":
                        tRes.Text = f18(year1, month1);
                        tRes1.Text = f18(year2, month2);
                        tRes.Visibility = Visibility.Visible;
                        tRes1.Visibility = Visibility.Visible;

                        break;
                    case "f19":
                        ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = f19(year1, month1);
                        ((ColumnSeries)mcChart3.SeriesHost.Series[0]).ItemsSource = f19(year2, month2);
                        cResCol.Visibility = Visibility.Visible;
                        cResCol1.Visibility = Visibility.Visible;
                        break;
                    case "f19a":
                        f19a(year1, month1, year2, month2);
                        break;
                    case "f20":
                        f20(year1, month1, year2, month2);
                        break;
                    case "f20a":
                        f20a(year1, month1, year2, month2);
                        break;
					case "f21":
                        f21(year1, month1, year2, month2);
                        break;
                    case "f21a":
                        f21a(year1, month1, year2, month2);
                        break;
                    case "f22":
                        f22(year1, month1, year2, month2);
                        break;
                    case "f23":
                        f23(year1, month1, year2, month2);
                        break;
                    case "f24":
                        f24(year1, month1, year2, month2);
                        break;
                    case "f25":
                        f25(year1, month1, year2, month2);
                        break;
                    case "f25a":
                        f25a(year1, month1, year2, month2);
                        break;
                    case "f26":
                        f26(year1, month1, year2, month2);
                        break;
                    case "f26a":
                        f26a(year1, month1, year2, month2);
                        break;
                    case "f27":
                        f27(year1, month1, year2, month2);
                        break;
                    case "f28":
                        f28(year1, month1, year2, month2);
                        break;
						case "f29":
                        f29(year1, month1, year2, month2);
                        break;
					case "f29a":
                        f29a(year1, month1, year2, month2);
                        break;
                    case "f30":
                        f30(year1, month1, year2, month2);
                        break;
                    case "f31":
                        f31(year1, month1, year2, month2);
                        break;
                    case "f32":
                        f32(year1, month1, year2, month2);
                        break;
                    case "f32a":
                        f32a(year1, month1, year2, month2);
                        break;
                    case "f33":
                        f33(year1, month1, year2, month2);
                        break;
                    case "f33a":
                        f33a(year1, month1, year2, month2);
                        break;
                    case "f34":
                        f34(year1, month1, year2, month2);
                        break;
                    case "f34a":
                        f34a(year1, month1, year2, month2);
                        break;
						case "f35":
                        f35(year1, month1, year2, month2);
                        break;
						case "f35a":
                        f35a(year1, month1, year2, month2);
                        break;
						case "f36":
                        f36(year1, month1, year2, month2);
                        break;
						case "f36a":
                        f36a(year1, month1, year2, month2);
                        break;
						case "f37":
                        f37(year1, month1, year2, month2);
                        break;
						case "f37a":
                        f37a(year1, month1, year2, month2);
                        break;
						case "f38":
                        f38(year1, month1, year2, month2);
                        break;
						case "f38a":
                        f38a(year1, month1, year2, month2);
                        break;
                    case "custom":
                        runCustomCriteria(parser.ObjectList[objIdx].CriteriaList[criIdx].TypeList[typeIdx].SQL);
                        break;
                }
            }
            else
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin.");
        }

        private void runCustomCriteria(string sql)
        {
            Hidden();
            gRes.Visibility = Visibility.Visible;
            DataLayer.DAO.DataConnector dc = new DataLayer.DAO.DataConnector();
            string conStr = dc.getQuyTrinhThiConnectionString();
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            gRes.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void Hidden()
        {
            tRes.Visibility = Visibility.Hidden;
            gRes.Visibility = Visibility.Hidden;
            cResCol.Visibility = Visibility.Hidden;
            cResLine.Visibility = Visibility.Hidden;
            tRes1.Visibility = Visibility.Hidden;
            gRes1.Visibility = Visibility.Hidden;
            cResCol1.Visibility = Visibility.Hidden;
            cResLine1.Visibility = Visibility.Hidden;
        }

		
		private void f38a(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}
private void f38(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}
private void f37a(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}
private void f37(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}
private void f36a(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}
private void f36(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}

		
		private void f35a(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}

		
		private void f35(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}

		
        private void f34a(int year1, int month1, int year2, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(20, 0, date1, date2);
            List<DtoTienDo> td2 = _bus.getListDataByWorks(8, 0, date1, date2);
            int tongsothisinh = 0;
            int tongsobaithi = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh += _dto.TONGKHOILUONGCV;
                }
            }
            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi += _dto.TONGKHOILUONGCV;
                }
            }
            if (tongsothisinh != 0)
            {
                tRes.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsobaithi / (float)tongsothisinh * 100).ToString() + " % so với tổng số thí sinh tham gia dự thi";
            }
            else
            {
                tRes.Text = cbxCriteria.Text + " chiếm: Không có";
            }
            tRes.Visibility = Visibility.Visible;

            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            List<DtoTienDo> td3 = _bus.getListDataByWorks(20, 0, date3, date4);
            List<DtoTienDo> td4 = _bus.getListDataByWorks(8, 0, date3, date4);
            int tongsothisinh1 = 0;
            int tongsobaithi1 = 0;
            List<DtoTienDo> _td3 = XoaCongViecTrung(td3);
            List<DtoTienDo> _td4 = XoaCongViecTrung(td4);

            foreach (DtoTienDo _dto in _td3)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh1 += _dto.TONGKHOILUONGCV;
                }
            }
            foreach (DtoTienDo _dto in _td4)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi1 += _dto.TONGKHOILUONGCV;
                }
            }

            if (tongsothisinh1 != 0)
            {
                tRes1.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsobaithi1 / (float)tongsothisinh1 * 100).ToString() + " % so với tổng số thí sinh tham gia dự thi";
            }
            else
            { tRes1.Text = cbxCriteria.Text + " chiếm: Không có."; }
            tRes1.Visibility = Visibility.Visible;
        }

        private void f34(int year1, int month1, int year2, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(20, 0, date1, date2);
            int tongsothisinh = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh += _dto.TONGKHOILUONGCV;
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + tongsothisinh + " thí sinh";
            tRes.Visibility = Visibility.Visible;

            List<DtoTienDo> td2 = _bus.getListDataByWorks(20, 0, date3, date4);
            int tongsothisinh1 = 0;
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh1 += _dto.TONGKHOILUONGCV;
                }
            }
            tRes1.Text = cbxCriteria.Text + ": " + tongsothisinh1 + " thí sinh";
            tRes1.Visibility = Visibility.Visible;
        }

        private List<DtoTienDo> XoaCongViecTrung(List<DtoTienDo> dto)
        {
            for (int i = 0; i < dto.Count; i++)
            {
                int cout = dto.Count;
                for (int j = 0; j < cout; j++)
                {
                    if (j != i && dto[j].MACV == dto[i].MACV && dto[j].MADT == dto[i].MADT)
                    {
                        dto.RemoveAt(j);
                        j--;
                        cout = dto.Count;
                    }
                }
            }
            return dto;
        }

        private void f33a(int year1, int month1, int year2, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(18, 0, date1, date2);
            List<DtoTienDo> td2 = _bus.getListDataByWorks(8, 0, date1, date2);
            int tongsothisinh = 0;
            int tongsobaithi = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh += _dto.TONGKHOILUONGCV;
                }
            }
            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi += _dto.TONGKHOILUONGCV;
                }
            }

            if (tongsothisinh != 0)
            {
                tRes.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsobaithi / (float)tongsothisinh * 100).ToString() + " % so với tổng số thí sinh tham gia dự thi";
            }
            else
            { tRes.Text = cbxCriteria.Text + " chiếm: Không có."; }
            tRes.Visibility = Visibility.Visible;

            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            List<DtoTienDo> td3 = _bus.getListDataByWorks(18, 0, date3, date4);
            List<DtoTienDo> td4 = _bus.getListDataByWorks(8, 0, date3, date4);
            int tongsothisinh1 = 0;
            int tongsobaithi1 = 0;
            List<DtoTienDo> _td3 = XoaCongViecTrung(td3);
            List<DtoTienDo> _td4 = XoaCongViecTrung(td4);

            foreach (DtoTienDo _dto in _td3)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh1 += _dto.TONGKHOILUONGCV;
                }
            }
            foreach (DtoTienDo _dto in _td4)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi1 += _dto.TONGKHOILUONGCV;
                }
            }
            if (tongsothisinh1 != 0)
            {
                tRes1.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsobaithi1 / (float)tongsothisinh1 * 100).ToString() + " % so với tổng số thí sinh tham gia dự thi";
            }
            else
            {
                tRes1.Text = cbxCriteria.Text + " chiếm: Không có.";
            }

            tRes1.Visibility = Visibility.Visible;
        }

        private void f33(int year1, int month1, int year2, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(18, 0, date1, date2);
            int tongsothisinh = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh += _dto.TONGKHOILUONGCV;
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + tongsothisinh + " thí sinh";
            tRes.Visibility = Visibility.Visible;

            List<DtoTienDo> td2 = _bus.getListDataByWorks(18, 0, date3, date4);
            int tongsothisinh1 = 0;
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh1 += _dto.TONGKHOILUONGCV;
                }
            }
            tRes1.Text = cbxCriteria.Text + ": " + tongsothisinh1 + " thí sinh";
            tRes1.Visibility = Visibility.Visible;
        }

        private void f32a(int year1, int month1, int year2, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(3, 0, date1, date2);
            List<DtoTienDo> td2 = _bus.getListDataByWorks(8, 0, date1, date2);
            int tongsothisinh = 0;
            int tongsobaithi = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh += _dto.TONGKHOILUONGCV;
                }
            }
            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi += _dto.TONGKHOILUONGCV;
                }
            }
            if (tongsothisinh != 0)
            {
                tRes.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsobaithi / (float)tongsothisinh * 100).ToString() + " % so với tổng số thí sinh tham gia dự thi";
            }
            else
            {
                tRes.Text = cbxCriteria.Text + " chiếm: Không có.";
            }
            tRes.Visibility = Visibility.Visible;

            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            List<DtoTienDo> td3 = _bus.getListDataByWorks(3, 0, date3, date4);
            List<DtoTienDo> td4 = _bus.getListDataByWorks(8, 0, date3, date4);
            int tongsothisinh1 = 0;
            int tongsobaithi1 = 0;
            List<DtoTienDo> _td3 = XoaCongViecTrung(td3);
            List<DtoTienDo> _td4 = XoaCongViecTrung(td4);

            foreach (DtoTienDo _dto in _td3)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh1 += _dto.TONGKHOILUONGCV;
                }
            }
            foreach (DtoTienDo _dto in _td4)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi1 += _dto.TONGKHOILUONGCV;
                }
            }

            if (tongsothisinh1 != 0)
            {
                tRes1.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsobaithi1 / (float)tongsothisinh1 * 100).ToString() + " % so với tổng số thí sinh tham gia dự thi";
            }
            else
            {
                tRes1.Text = cbxCriteria.Text + " chiếm: Không có.";
            }
            tRes1.Visibility = Visibility.Visible;
        }

        private void f32(int year1, int month1, int year2, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(8, 0, date1, date2);
            int tongsothisinh = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh += _dto.TONGKHOILUONGCV;
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + tongsothisinh + " thí sinh";
            tRes.Visibility = Visibility.Visible;

            List<DtoTienDo> td2 = _bus.getListDataByWorks(8, 0, date3, date4);
            int tongsothisinh1 = 0;
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh1 += _dto.TONGKHOILUONGCV;
                }
            }
            tRes1.Text = cbxCriteria.Text + ": " + tongsothisinh1 + " thí sinh";
            tRes1.Visibility = Visibility.Visible;
        }

        private void f31(int year1, int month1, int year2, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(3, 0, date1, date2);
            int tongsothisinh = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh += _dto.TONGKHOILUONGCV;
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + tongsothisinh + " thí sinh";
            tRes.Visibility = Visibility.Visible;

            List<DtoTienDo> td2 = _bus.getListDataByWorks(3, 0, date3, date4);
            int tongsothisinh1 = 0;
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsothisinh1 += _dto.TONGKHOILUONGCV;
                }
            }
            tRes1.Text = cbxCriteria.Text + ": " + tongsothisinh1 + " thí sinh";
            tRes1.Visibility = Visibility.Visible;
        }

        private void f30(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusDotThi bus = new BusDotThi();
            string res = string.Empty;
            List<DtoDotThi> dt = bus.getListDataCompleted();
            foreach (DtoDotThi dto in dt)
            {
                BusChungChi cc = new BusChungChi();
                BusDotThi_ChungChi dc = new BusDotThi_ChungChi();
                DtoDotThi_ChungChi dtcc = dc.getDataById(dto.MADT);
                if (dtcc != null)
                    res += "\n\t-\t" + (cc.getDataById((dc.getDataById(dto.MADT)).MACC)).TENCC;
            }
            tRes.Text = cbxCriteria.Text + ": " + res;
            tRes.Visibility = Visibility.Visible;
			
            tRes1.Text = cbxCriteria.Text + ": " + res;
            tRes1.Visibility = Visibility.Visible;
        }
		
		private void f29a(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}
		
		private void f29(int year1,int month1, int year2,int month2)
		{
			Hidden();
			tRes.Visibility = Visibility.Visible;
			tRes1.Visibility = Visibility.Visible;
			tRes.Text = "Chức năng chưa cập nhật";
			tRes1.Text = "Chức năng chưa cập nhật";
		}

        private void f28(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> dt = bus.getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(20, 0, date1, date2);
            int tongsochungchi = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);
            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsochungchi += _dto.TONGKHOILUONGCV;
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + tongsochungchi + " chứng chỉ";
            tRes.Visibility = Visibility.Visible;

            List<DtoTienDo> td2 = _bus.getListDataByWorks(20, 0, date3, date4);
            int tongsochungchi1 = 0;
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);
            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsochungchi1 += _dto.TONGKHOILUONGCV;
                }
            }
            tRes1.Text = cbxCriteria.Text + ": " + tongsochungchi1 + " chứng chỉ";
            tRes1.Visibility = Visibility.Visible;
        }

        private void f27(int year1, int month1, int year2, int month2)
        {
            Hidden();
            List<DtoDotThi> dt = new BusDotThi().getCompletedLateList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            string res = string.Empty;
            string res1 = string.Empty;
            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    res += "\n\t-\t" + dto.TENDOTTHI + " - Ngày thi: " + dto.NGAYTHI;
                    List<DtoTienDo> td = new BusTienDo().getListDataBymaDT(dto.MADT);
                    foreach (DtoTienDo _dto in td)
                    {
                        if (_dto.MACV == 21)
                        {
                            res += " - Kết thúc trễ " + _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYKETTHUCQUYDINH).Days + " ngày so với quy định";
                        }
                    }
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    res1 += "\n\t-\t" + dto.TENDOTTHI + " - Ngày thi: " + dto.NGAYTHI;
                    List<DtoTienDo> td = new BusTienDo().getListDataBymaDT(dto.MADT);
                    foreach (DtoTienDo _dto in td)
                    {
                        if (_dto.MACV == 21)
                        {
                            res1 += " - Kết thúc trễ " + _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYKETTHUCQUYDINH).Days + " ngày so với quy định";
                        }
                    }
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + res;
            tRes.Visibility = Visibility.Visible;
            tRes1.Text = cbxCriteria.Text + ": " + res;
            tRes1.Visibility = Visibility.Visible;
        }

        private void f26a(int year1, int month1, int year2, int month2)
        {
            Hidden();
            List<DtoDotThi> dtLate = new BusDotThi().getCompletedLateList();
            List<DtoDotThi> dt = new BusDotThi().getDataList();
            List<DtoDotThi> dtCompleted = new BusDotThi().getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            int tongsodotthi = 0;
            int tongsodotthikhongkipthoihan = 0;
            int tongsodotthihoanthanh = 0;
            int tongsodotthi1 = 0;
            int tongsodotthikhongkipthoihan1 = 0;
            int tongsodotthihoanthanh1 = 0;
            foreach (DtoDotThi dto in dtLate)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthikhongkipthoihan++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    tongsodotthikhongkipthoihan1++;
                }
            }

            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthi++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    tongsodotthi1++;
                }
            }

            foreach (DtoDotThi dto in dtCompleted)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthihoanthanh++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    tongsodotthihoanthanh1++;
                }
            }


            if ((tongsodotthi != 0) && (tongsodotthihoanthanh != 0))
            {
                tRes.Text = cbxCriteria.Text + ": \n\t-\t Chiếm " + ((float)tongsodotthikhongkipthoihan / (float)tongsodotthi* 100).ToString() + "% so với tổng số đợt thi\n\t-\t Chiếm" + ((float)tongsodotthikhongkipthoihan / (float)tongsodotthihoanthanh * 100).ToString() + "% so với tổng số đợt thi hoàn thành\n";
            }
            else
            {
                tRes.Text = cbxCriteria.Text + ": \n\t-\t Không có đợt thi nào không hoàn thành kịp thời hạn.";
            }

            if ((tongsodotthi1 != 0) && (tongsodotthihoanthanh1 != 0))
            {
                tRes1.Text = cbxCriteria.Text + ": \n\t-\t Chiếm " + ((float)tongsodotthikhongkipthoihan1 / (float)tongsodotthi1 * 100).ToString() + "% so với tổng số đợt thi\n\t-\t Chiếm" + ((float)tongsodotthikhongkipthoihan1 / (float)tongsodotthihoanthanh1 * 100).ToString() + "% so với tổng số đợt thi hoàn thành\n";
            }
            else
            {
                tRes1.Text = cbxCriteria.Text + ": \n\t-\t Không có đợt thi nào không hoàn thành kịp thời hạn.";
            }

            tRes.Visibility = Visibility.Visible;
            tRes1.Visibility = Visibility.Visible;
        }

        private void f26(int year1, int month1, int year2, int month2)
        {
            Hidden();
            List<DtoDotThi> dt = new BusDotThi().getCompletedLateList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            int count = 0;
            int count1 = 0;
            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    count++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    count1++;
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + count;
            tRes1.Text = cbxCriteria.Text + ": " + count1;
            tRes.Visibility = Visibility.Visible;
            tRes1.Visibility = Visibility.Visible;
        }

        private void f25a(int year1, int month1, int year2, int month2)
        {
            Hidden();
            List<DtoDotThi> dtEarly = new BusDotThi().getCompletedEarlyList();
            List<DtoDotThi> dt = new BusDotThi().getDataList();
            List<DtoDotThi> dtCompleted = new BusDotThi().getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            int tongsodotthi = 0;
            int tongsodotthikipthoihan = 0;
            int tongsodotthihoanthanh = 0;
            int tongsodotthi1 = 0;
            int tongsodotthikipthoihan1 = 0;
            int tongsodotthihoanthanh1 = 0;
			int count = 0;
			int count1 = 0;
            foreach (DtoDotThi dto in dtEarly)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    count++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    count1++;
                }
            }

            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthi++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    tongsodotthi1++;
                }
            }

            foreach (DtoDotThi dto in dtCompleted)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthihoanthanh++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    tongsodotthihoanthanh1++;
                }
            }
			
			tongsodotthikipthoihan = tongsodotthihoanthanh - count;
			tongsodotthikipthoihan1 = tongsodotthihoanthanh1 - count1;

            if ((tongsodotthi != 0) && (tongsodotthihoanthanh != 0))
            {
                tRes.Text = cbxCriteria.Text + ": \n\t-\t Chiếm " + ((float)tongsodotthikipthoihan / (float)tongsodotthi * 100).ToString() + "% so với tổng số đợt thi\n\t-\t Chiếm" + ((float)tongsodotthikipthoihan / (float)tongsodotthihoanthanh * 100).ToString() + "% so với tổng số đợt thi hoàn thành không bị trễ\n";
            }
            else
            {
                tRes.Text = cbxCriteria.Text + ": \n\t-\t Không có đợt thi nào hoàn thành kịp thời hạn.";

            }

            if ((tongsodotthi1 != 0) && (tongsodotthihoanthanh1 != 0))
            {
                tRes1.Text = cbxCriteria.Text + ": \n\t-\t Chiếm " +((float)tongsodotthikipthoihan1/(float)tongsodotthi1 * 100).ToString() + " % so với tổng số đợt thi\n\t-\t Chiếm" + ((float)tongsodotthikipthoihan1 / (float)tongsodotthihoanthanh1 * 100).ToString() + "% so với tổng số đợt thi hoàn thành không bị trễ\n";
            }
            else
            {
                tRes1.Text = cbxCriteria.Text + ": \n\t-\t Không có đợt thi nào hoàn thành kịp thời hạn.";

            }

            tRes.Visibility = Visibility.Visible;
            tRes1.Visibility = Visibility.Visible;
        }

        private void f25(int year1, int month1, int year2, int month2)
        {
            Hidden();
            List<DtoDotThi> dt = new BusDotThi().getCompletedEarlyList();			
            List<DtoDotThi> _dt = new BusDotThi().getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            int count = 0;
            int count1 = 0;
			int _count = 0;
            int _count1 = 0;
            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    count++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    count1++;
                }
            }
			foreach (DtoDotThi dto in _dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    _count++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    _count1++;
                }
            }
			
			int res = _count - count;
			int res1 = _count1 - count1;
            tRes.Text = cbxCriteria.Text + ": " + res;
            tRes1.Text = cbxCriteria.Text + ": " + res1;
            tRes.Visibility = Visibility.Visible;
            tRes1.Visibility = Visibility.Visible;
        }

        private void f24(int year1, int month1, int year2, int month2)
        {
            Hidden();
            gRes.Visibility = Visibility.Hidden;
            List<DtoDotThi> dt = new BusDotThi().getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            int count = 0;
            int count1 = 0;
            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    count++;
                }
                if (dto.NGAYTHI >= date3 && dto.NGAYTHI <= date4)
                {
                    count1++;
                }
            }
           
            tRes.Text = cbxCriteria.Text + ": " + count;

            tRes1.Text = cbxCriteria.Text + ": " + count1;
            tRes.Visibility = Visibility.Visible;
            tRes1.Visibility = Visibility.Visible;
        }

        // nên thêm hàm tương ứng nhưng trả ra liệt kê cv sớm hạn
        private void f23(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> dt = bus.getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            string res = string.Empty;
            string res1 = string.Empty;
            foreach (DtoDotThi dto in dt)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataCompletedByMaDT(dto.MADT);
								int count = 0;
				int count1 = 0;
				foreach (DtoTienDo _dto in td)
                {
                    if ((_dto.NGAYBATDAUTHUCTE <= date1 && _dto.NGAYKETTHUCTHUCTE >= date1) || (_dto.NGAYBATDAUTHUCTE >= date1 && _dto.NGAYBATDAUTHUCTE <= date2))
                    {
						count++;
					}
					if ((_dto.NGAYBATDAUTHUCTE <= date3 && _dto.NGAYKETTHUCTHUCTE >= date3) || (_dto.NGAYBATDAUTHUCTE >= date3 && _dto.NGAYBATDAUTHUCTE <= date4))
                    {
						count1++;
					}
				}
				if(count != 0)
				{
					res += "\n-\t" + dto.TENDOTTHI + ": ";
				}
				if(count1 != 0)
				{
					res1 += "\n-\t" + dto.TENDOTTHI + ": ";
				}
                foreach (DtoTienDo _dto in td)
                {
                    if ((_dto.NGAYBATDAUTHUCTE <= date1 && _dto.NGAYKETTHUCTHUCTE >= date1) || (_dto.NGAYBATDAUTHUCTE >= date1 && _dto.NGAYBATDAUTHUCTE <= date2))
                    {
                        BusCongViec cv = new BusCongViec();
                        res += "\n\t-\tCông việc " + cv.getTenCVByMaCV(_dto.MACV) + ": ";
                        BusNhanVienThuaHanh nv = new BusNhanVienThuaHanh();
                        res += "Do " + nv.getTenNVByMaNV(_dto.MANV) + " thực hiện - Thời gian thực hiện: ";
                        int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                        res += realtime.ToString() + " (ngày)" + "\n"; // them file xác thực công việc hoàn thành
                    }
                    if ((_dto.NGAYBATDAUTHUCTE <= date3 && _dto.NGAYKETTHUCTHUCTE >= date3) || (_dto.NGAYBATDAUTHUCTE >= date3 && _dto.NGAYBATDAUTHUCTE <= date4))
                    {
                        BusCongViec cv = new BusCongViec();
                        res1 += "\n\t-\tCông việc " + cv.getTenCVByMaCV(_dto.MACV) + ": ";
                        BusNhanVienThuaHanh nv = new BusNhanVienThuaHanh();
                        res1 += "Do " + nv.getTenNVByMaNV(_dto.MANV) + " thực hiện - Thời gian thực hiện: ";
                        int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                        res1 += realtime.ToString() + " (ngày)" + "\n"; // them file xác thực công việc hoàn thành
                    }
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + res;
            tRes.Visibility = Visibility.Visible;
            tRes1.Text = cbxCriteria.Text + ": " + res1;
            tRes1.Visibility = Visibility.Visible;
        }

        private void f22(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> dt = bus.getListContainCompletedLateWorkItem();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            string res = string.Empty;
            string res1 = string.Empty;
            foreach (DtoDotThi dto in dt)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataDelayedByMaDT(dto.MADT);
				int count = 0;
				int count1 = 0;
				foreach (DtoTienDo _dto in td)
                {
                    if ((_dto.NGAYBATDAUTHUCTE <= date1 && _dto.NGAYKETTHUCTHUCTE >= date1) || (_dto.NGAYBATDAUTHUCTE >= date1 && _dto.NGAYBATDAUTHUCTE <= date2))
                    {
						count++;
					}
					if ((_dto.NGAYBATDAUTHUCTE <= date3 && _dto.NGAYKETTHUCTHUCTE >= date3) || (_dto.NGAYBATDAUTHUCTE >= date3 && _dto.NGAYBATDAUTHUCTE <= date4))
                    {
						count1++;
					}
				}
				if(count != 0)
				{
					res += "\n-\t" + dto.TENDOTTHI + ": ";
				}
				if(count1 != 0)
				{
					res1 += "\n-\t" + dto.TENDOTTHI + ": ";
				}
                foreach (DtoTienDo _dto in td)
                {
                    if ((_dto.NGAYBATDAUTHUCTE <= date1 && _dto.NGAYKETTHUCTHUCTE >= date1) || (_dto.NGAYBATDAUTHUCTE >= date1 && _dto.NGAYBATDAUTHUCTE <= date2))
                    {
                        BusCongViec cv = new BusCongViec();
                        res += "\n\t-\tCông việc " + cv.getTenCVByMaCV(_dto.MACV) + ": ";
                        BusNhanVienThuaHanh nv = new BusNhanVienThuaHanh();
                        res += "Do " + nv.getTenNVByMaNV(_dto.MANV) + " thực hiện - Thời gian thực hiện: ";
                        int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                        int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                        int minus = time - realtime;
                        res += realtime.ToString() + " (ngày)(trễ " + minus.ToString() + " ngày so với quy định) - Nguyên Nhân: ";
                        BusGhiChu gc = new BusGhiChu();
                        res += (gc.getDataByMaTD(_dto.MATD)).GHICHU + "\n"; // thêm file xác thực công việc hoàn thành
                    }
                    if ((_dto.NGAYBATDAUTHUCTE <= date3 && _dto.NGAYKETTHUCTHUCTE >= date3) || (_dto.NGAYBATDAUTHUCTE >= date3 && _dto.NGAYBATDAUTHUCTE <= date4))
                    {
                        BusCongViec cv = new BusCongViec();
                        res1 += "\n\t-\tCông việc " + cv.getTenCVByMaCV(_dto.MACV) + ": ";
                        BusNhanVienThuaHanh nv = new BusNhanVienThuaHanh();
                        res1 += "Do " + nv.getTenNVByMaNV(_dto.MANV) + " thực hiện - Thời gian thực hiện: ";
                        int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                        int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                        int minus = time - realtime;
                        res1 += realtime.ToString() + " (ngày)(trễ " + minus.ToString() + " ngày so với quy định) - Nguyên Nhân: ";
                        BusGhiChu gc = new BusGhiChu();
                        res1 += (gc.getDataByMaTD(_dto.MATD)).GHICHU + "\n"; // thêm file xác thực công việc hoàn thành
                    }
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + res;
            tRes.Visibility = Visibility.Visible;
            tRes1.Text = cbxCriteria.Text + ": " + res1;
            tRes1.Visibility = Visibility.Visible;
        }

        private void f21a(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<int> socongviectrehan = new List<int>();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> _dto = new List<DtoTienDo>();
            List<DtoCongViec> dto = bus.getDataList();
            for (int i = 0; i < dto.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto[i].MACV, 0, date1, date2);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto.Add(temp[j]);
                }
            }
            _dto = XoaDotThiTrung(_dto);
            for (int i = 0; i < _dto.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi.Add(bdt.getTenDTByMaDT(_dto[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto[i].MADT, 0, -1, date1, date2);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], socongviectrehan[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;//////////////////////////////////////////////
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;


            List<string> kithi1 = new List<string>();
            List<int> socongviectrehan1 = new List<int>();
            List<DtoTienDo> _dto1 = new List<DtoTienDo>();
            List<DtoCongViec> dto1 = bus.getDataList();
            for (int i = 0; i < dto1.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto1[i].MACV, 0, date3, date4);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto1.Add(temp[j]);
                }
            }
            _dto1 = XoaDotThiTrung(_dto1);
            for (int i = 0; i < _dto1.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi1.Add(bdt.getTenDTByMaDT(_dto1[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto1[i].MADT, 0, -1, date3, date4);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes1.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res1 = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi1.Count; i++)
                res1.Add(new KeyValuePair<string, int>(kithi1[i], socongviectrehan[i]));
            int w1 = res1.Count * 100;
            this.cResLine1.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res; ///////////////////////////////////////////
            tRes1.Visibility = Visibility.Visible;
            cResLine1.Visibility = Visibility.Visible;
        }

        private void f21(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<int> socongviectrehan = new List<int>();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> _dto = new List<DtoTienDo>();
            List<DtoCongViec> dto = bus.getDataList();
            for (int i = 0; i < dto.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto[i].MACV, 0, date1, date2);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto.Add(temp[j]);
                }
            }
            _dto = XoaDotThiTrung(_dto);
            for (int i = 0; i < _dto.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi.Add(bdt.getTenDTByMaDT(_dto[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto[i].MADT, 0, -1, date1, date2);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], socongviectrehan[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;//////////////////////////////////////////////
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;


            List<string> kithi1 = new List<string>();
            List<int> socongviectrehan1 = new List<int>();
            List<DtoTienDo> _dto1 = new List<DtoTienDo>();
            List<DtoCongViec> dto1 = bus.getDataList();
            for (int i = 0; i < dto1.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto1[i].MACV, 0, date3, date4);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto1.Add(temp[j]);
                }
            }
            _dto1 = XoaDotThiTrung(_dto1);
            for (int i = 0; i < _dto1.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi1.Add(bdt.getTenDTByMaDT(_dto1[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto1[i].MADT, 0, -1, date3, date4);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes1.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res1 = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi1.Count; i++)
                res1.Add(new KeyValuePair<string, int>(kithi1[i], socongviectrehan[i]));
            int w1 = res1.Count * 100;
            this.cResLine1.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res; ///////////////////////////////////////////
            tRes1.Visibility = Visibility.Visible;
            cResLine1.Visibility = Visibility.Visible;
        }

        private void f20a(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<int> socongviectrehan = new List<int>();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> _dto = new List<DtoTienDo>();
            List<DtoCongViec> dto = bus.getDataList();
            for (int i = 0; i < dto.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto[i].MACV, 0, date1, date2);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto.Add(temp[j]);
                }
            }
            _dto = XoaDotThiTrung(_dto);
            for (int i = 0; i < _dto.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi.Add(bdt.getTenDTByMaDT(_dto[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto[i].MADT, 0, 0, date1, date2);
                if (cv != null)
                    socongviectrehan.Add(cv.Count);    
                else
                    socongviectrehan.Add(0);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], socongviectrehan[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;//////////////////////////////////
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;


            List<string> kithi1 = new List<string>();
            List<int> socongviectrehan1 = new List<int>();
            List<DtoTienDo> _dto1 = new List<DtoTienDo>();
            List<DtoCongViec> dto1 = bus.getDataList();
            for (int i = 0; i < dto1.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto1[i].MACV, 0, date3, date4);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto1.Add(temp[j]);
                }
            }
            _dto1 = XoaDotThiTrung(_dto1);
            for (int i = 0; i < _dto1.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi1.Add(bdt.getTenDTByMaDT(_dto1[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto1[i].MADT, 0, 0, date3, date4);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes1.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res1 = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi1.Count; i++)
                res1.Add(new KeyValuePair<string, int>(kithi1[i], socongviectrehan[i]));
            int w1 = res1.Count * 100;
            this.cResLine1.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res; ///////////////////////////////////////////
            tRes1.Visibility = Visibility.Visible;
            cResLine1.Visibility = Visibility.Visible;

        }

        private void f20(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<int> socongviectrehan = new List<int>();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> _dto = new List<DtoTienDo>();
            List<DtoCongViec> dto = bus.getDataList();
            for (int i = 0; i < dto.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto[i].MACV, 0, date1, date2);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto.Add(temp[j]);
                }
            }
            _dto = XoaDotThiTrung(_dto);
            for (int i = 0; i < _dto.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi.Add(bdt.getTenDTByMaDT(_dto[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto[i].MADT, 0, 0, date1, date2);
                if (cv != null)
                socongviectrehan.Add(cv.Count);    
                else
                    socongviectrehan.Add(0);
                
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], socongviectrehan[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;////////////////////////////////////////////
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;


            List<string> kithi1 = new List<string>();
            List<DtoTienDo> _dto1 = new List<DtoTienDo>();
            List<DtoCongViec> dto1 = bus.getDataList();
            for (int i = 0; i < dto1.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto1[i].MACV, 0, date3, date4);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto1.Add(temp[j]);
                }
            }
            _dto1 = XoaDotThiTrung(_dto1);
            for (int i = 0; i < _dto1.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi1.Add(bdt.getTenDTByMaDT(_dto1[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto1[i].MADT, 0, 0, date3, date4);
                if (cv != null)
                    socongviectrehan.Add(cv.Count);
                else 
                    socongviectrehan.Add(0);
                
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes1.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res1 = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi1.Count; i++)
                res1.Add(new KeyValuePair<string, int>(kithi1[i], socongviectrehan[i]));
            int w1 = res1.Count * 100;
            this.cResLine1.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res; ///////////////////////////////////////////
            tRes1.Visibility = Visibility.Visible;
            cResLine1.Visibility = Visibility.Visible;
        }

        private void f19a(int year1, int month1, int year2, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            DateTime date3 = new DateTime(year2, month2, 1);
            DateTime date4 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<int> socongviectrehan = new List<int>();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> _dto = new List<DtoTienDo>();
            List<DtoCongViec> dto = bus.getDataList();
            for (int i = 0; i < dto.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto[i].MACV, 0, date1, date2);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto.Add(temp[j]);
                }
            }
            _dto = XoaDotThiTrung(_dto);
            for (int i = 0; i < _dto.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi.Add(bdt.getTenDTByMaDT(_dto[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto[i].MADT, 0, 1, date1, date2);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], socongviectrehan[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;//////////////////////////////////////
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;


            List<string> kithi1 = new List<string>();
            List<int> socongviectrehan1 = new List<int>();
            List<DtoTienDo> _dto1 = new List<DtoTienDo>();
            List<DtoCongViec> dto1 = bus.getDataList();
            for (int i = 0; i < dto1.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto1[i].MACV, 0, date3, date4);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto1.Add(temp[j]);
                }
            }
            _dto1 = XoaDotThiTrung(_dto1);
            for (int i = 0; i < _dto1.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi1.Add(bdt.getTenDTByMaDT(_dto1[i].MADT));

                List<DtoCongViec> cv = bus.getListDataCompleted(_dto1[i].MADT, 0, 1, date3, date4);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes1.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res1 = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi1.Count; i++)
                res1.Add(new KeyValuePair<string, int>(kithi1[i], socongviectrehan[i]));
            int w1 = res1.Count * 100;
            this.cResLine1.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res; ///////////////////////////////////////////
            tRes1.Visibility = Visibility.Visible;
            cResLine1.Visibility = Visibility.Visible;

        }

        private List<DtoTienDo> XoaDotThiTrung(List<DtoTienDo> dto)
        {
            for (int i = 0; i < dto.Count; i++)
            {
                int cout = dto.Count;
                for (int j = 0; j < cout; j++)
                {
                    if (j != i && dto[j].MADT == dto[i].MADT)
                    {
                        dto.RemoveAt(j);
                        j--;
                        cout = dto.Count;
                    }
                }
            }
            return dto;
        }

        private List<KeyValuePair<string, int>> f19(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<int> socongviectrehan = new List<int>();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> _dto = new List<DtoTienDo>();
            List<DtoCongViec> dto = bus.getDataList();
            for (int i = 0; i < dto.Count; i++)
            {
                List<DtoTienDo> temp = new List<DtoTienDo>();
                temp = _bus.getListDataByWorks(dto[i].MACV, 0, date1, date2);
                for (int j = 0; j < temp.Count; j++)
                {
                    _dto.Add(temp[j]);
                }
            }
            _dto = XoaDotThiTrung(_dto);
            for (int i = 0; i < _dto.Count; i++)
            {
                BusDotThi bdt = new BusDotThi();
                kithi.Add(bdt.getTenDTByMaDT(_dto[i].MADT));
                List<DtoCongViec> cv = bus.getListDataCompleted(_dto[i].MADT, 0, 1, date1, date2);
                if (cv == null)
                    socongviectrehan.Add(0);
                else
                    socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], socongviectrehan[i]));
            return res;
        }

        //f18 nên thêm biểu đồ đường/cột
        private string f18(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime > time)
                    {
                        count++;
                    }
                }
                tongsocvhoanthanhtrehan += count;
            }
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int tre = 0;
                int som = 0;
                int dung = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime < time)
                    {
                        som++;
                    }
                    else if (realtime == time)
                    {
                        dung++;
                    }
                    else
                    {
                        tre++;
                    }

                }
                if (tre >= 2)
                {


                    int Denominator = (tre + dung + som);
                    if (tongsocvhoanthanhtrehan != 0)
                    {

                        float Percent1 = (tre / tongsocvhoanthanhtrehan) * 100;

                        res += " lần\n\t\t - Trễ " + Percent1.ToString();
                    }
                    else
                    {
                        res += " lần\n\t\t - Trễ : Không có.";
                    }
                    if (tongsocvhoanthanhtrehan != 0)
                    {

                        float Percent2 = (tre / (tre + dung + som)) * 100;

                        res += "% so với tổng số công việc trễ hạn\n\t\t - Trễ" + Percent2.ToString();
                    }
                    else
                    {
                        res += "% so với tổng số công việc trễ hạn\n\t\t - Trễ: Không có.";
                    }

                    res += "\tCông việc: " + bus.getMotaCVByMaCV(dto.MACV) + "Thực hiện" + (tre + dung + som).ToString();
                    res += " lan\n\t\t - " + " Trễ: " + tre;
                    res += "% so với tổng số lần thực hiện của công việc\r\n";
                }
            }
            return res + "\nTổng số công việc hoàn thành trễ hạn: " + tongsocvhoanthanhtrehan + " công việc";
        }

        private string f17(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV <= 14)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime > time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Trễ: " + count + " công việc\r\n";
                tongsocvhoanthanhtrehan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan + " công việc";
        }

        private string f16(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV <= 7 || cv[i].MACV > 14)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime > time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Trễ: " + count + " công việc\r\n";
                tongsocvhoanthanhtrehan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan + " công việc";
        }

        private string f15(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV > 7)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime > time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Trễ: " + count + " công việc\r\n";
                tongsocvhoanthanhtrehan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan + " công việc";
        }

        private string f14(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV <= 14)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhdunghan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime == time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Đúng hạn: " + count + " công việc\r\n";
                tongsocvhoanthanhdunghan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan + " công việc";
        }

        private string f13(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV <= 7 || cv[i].MACV > 14)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhdunghan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime == time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Đúng hạn: " + count + " công việc\r\n";
                tongsocvhoanthanhdunghan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan + " công việc";
        }

        private string f12(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV > 7)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhdunghan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime == time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Đúng hạn: " + count + " công việc\r\n";
                tongsocvhoanthanhdunghan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan + " công việc";
        }

        private string f11(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV <= 14)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhsomhan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime < time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Sớm: " + count + " công việc\r\n";
                tongsocvhoanthanhsomhan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan + " công việc";

        }

        private string f10(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV <= 7 || cv[i].MACV > 14)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhsomhan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime < time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Sớm: " + count + " công việc\r\n";
                tongsocvhoanthanhsomhan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan + " công việc";
        }

        private string f9(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            List<int> temp = new List<int>();
            for (int i = 0; i < cv.Count; i++)
                if (cv[i].MACV > 7)
                    temp.Add(i);
            int cout = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                cv.RemoveAt(temp[i] - cout);
                cout++;
            }
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhsomhan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime < time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Sớm: " + count + " công việc\r\n";
                tongsocvhoanthanhsomhan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan + " công việc";
        }

        private string f8(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();

            List<DtoCongViec> cv = bus.getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhdunghan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime == time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Đúng hạn: " + count + " công việc\r\n";
                tongsocvhoanthanhdunghan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan + " công việc";
        }

        private string f7(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();

            List<DtoCongViec> cv = bus.getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime > time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Trễ: " + count + " công việc\r\n";
                tongsocvhoanthanhtrehan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan + " công việc";
        }

        private string f6(int year1, int month1)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            string res = string.Empty;
            int tongsocvhoanthanhsomhan = 0;
            foreach (DtoCongViec dto in cv)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(dto.MACV, 0, date1, date2);
                int count = 0;
                foreach (DtoTienDo _dto in td)
                {
                    int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                    int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                    if (realtime < time)
                    {
                        count++;
                    }
                }
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Sớm: " + count + " công việc\r\n";
                tongsocvhoanthanhsomhan += count;
            }
            return res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan + " công việc";
        }

        private string f5(int year1, int month1)
        {
            Hidden();
            return cbxCriteria.Text + ": " + new BusCongViec().getDataList().Count.ToString();
        }

        private DataTable f4(int year1, int month1)
        {
            Hidden();
            List<DtoPhanCong> listpc = new BusPhanCong().getDataList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Nhân Viên");
            dt.Columns.Add("Công việc");
            dt.Columns.Add("Thời gian làm (Ngày)");
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));

            for (int i = 0; i < listpc.Count; i++)
            {
                if ((listpc[i].NGAYAPDUNG <= date1 && listpc[i].NGAYHETHAN >= date1) || (listpc[i].NGAYAPDUNG >= date1 && listpc[i].NGAYAPDUNG <= date2))
                {
                    DataRow row = dt.NewRow();
                    row["Tên Nhân Viên"] = new BusNhanVienThuaHanh().getTenNVByMaNV(listpc[i].MANV);
                    row["Công việc"] = new BusCongViec().getMotaCVByMaCV(listpc[i].MACV);
                    if ((listpc[i].NGAYHETHAN.ToShortDateString() != "1/1/9999") && (listpc[i].NGAYHETHAN.ToShortDateString() != "01/01/9999"))
                        row["Thời gian làm (Ngày)"] = listpc[i].NGAYHETHAN.Subtract(listpc[i].NGAYAPDUNG).Days.ToString();
                    else
                        row["Thời gian làm (Ngày)"] = "Chưa xác định.";

                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        private string f3a(int year1, int month1)
        {
            Hidden();
            string temp = string.Empty;
            string tRes = string.Empty;
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = bus.getListDataCompletedWork(-1);
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            for (int i = 0; i < list.Count; i++)
            {
                int iNumOfWork1 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 1, date1, date2);
                int iNumOfWork2 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 0, date1, date2);
                int iNumOfWork3 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, -1, date1, date2);
                int Denominator = iNumOfWork1 + iNumOfWork2 + iNumOfWork3;
                if (Denominator != 0)
                {
                    float fPercent = (iNumOfWork1 / Denominator) * 100;

                    temp += "\n\t - " + list[i].TENNV + " - Phần trăm sớm hạn so với tổng công việc thực hiện: " + fPercent.ToString() + "%";
                }
                else
                {
                    temp += "\n\t - " + list[i].TENNV + " - Phần trăm sớm hạn so với tổng công việc thực hiện: Không có.";
                }

            }
            if (temp != null)
            {
                tRes = cbxCriteria.Text + ": " + temp;
            }
            else
            {
                tRes = cbxCriteria.Text + ": không có nhân viên nào";
            }
            return tRes;
        }

        private string f3(int year1, int month1)
        {
            Hidden();
            string temp = string.Empty;
            string tRes = string.Empty;
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = bus.getListDataCompletedWork(-1);
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            for (int i = 0; i < list.Count; i++)
            {
                int iNumOfWork = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, -1, date1, date2);
                temp += "\n\t - " + list[i].TENNV + " - Số lần sớm: " + iNumOfWork.ToString();
            }
            if (temp != null)
            {
                tRes = cbxCriteria.Text + ": " + temp;
            }
            else
            {
                tRes = cbxCriteria.Text + ": không có nhân viên nào";
            }
            return tRes;
        }

        private string f2a(int year1, int month1)
        {
            Hidden();
            string tRes = string.Empty;
            string temp = null;
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = bus.getListDataCompletedWork(1);
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            for (int i = 0; i < list.Count; i++)
            {
                int iNumOfWork1 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 1, date1, date2);
                int iNumOfWork2 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 0, date1, date2);
                int iNumOfWork3 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, -1, date1, date2);


                int Denominator = iNumOfWork1 + iNumOfWork2 + iNumOfWork3;
                if (Denominator != 0)
                {
                    float fPercent = (iNumOfWork1 / Denominator) * 100;

                    temp += "\n\t - " + list[i].TENNV + " - Phần trăm trễ hạn so với tổng công việc thực hiện: " + fPercent.ToString() + "%";
                }
                else
                {
                    temp += "\n\t - " + list[i].TENNV + " - Phần trăm trễ hạn so với tổng công việc thực hiện: Không có.";
                }

            }
            if (temp != "")
            {
                tRes = cbxCriteria.Text + ": " + temp;
            }
            else
            {
                tRes = cbxCriteria.Text + ": không có nhân viên nào";
            }
            return tRes;
        }

        private string f2(int year1, int month1)
        {
            Hidden();
            string result = string.Empty;
            string temp = string.Empty;
            string _temp = string.Empty;
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = bus.getListDataCompletedWork(1);
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year1, month1, DateTime.DaysInMonth(year1, month1));
            for (int i = 0; i < list.Count; i++)
            {
                int iNumOfWork = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 1, date1, date2);
                if (iNumOfWork != 0)
                {
                    temp += "\n\t - " + list[i].TENNV + " - Số lần trễ: " + iNumOfWork.ToString();
                }
            }
            if (temp != "")
            {
                result = cbxCriteria.Text + ": " + temp;
            }
            else
            {
                result = cbxCriteria.Text + ": không có nhân viên nào";
            }
            return result;
        }

        private string f1(int year1, int month1)
        {
            List<DtoNhanVienThuaHanh> list = new BusNhanVienThuaHanh().getDataList();
            return cbxCriteria.Text + ": " + list.Count.ToString();

        }

    }
}
