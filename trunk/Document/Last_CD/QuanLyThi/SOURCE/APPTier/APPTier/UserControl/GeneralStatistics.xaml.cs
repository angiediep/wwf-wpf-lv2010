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
using StatHandlers;
using DataLayer.DTO;
using System.Data;
using System.Collections;
using System.Data.SqlClient;


namespace APPTier
{
    /// <summary>
    /// Interaction logic for GeneralStatistics.xaml
    /// </summary>
    public partial class GeneralStatistics : UserControl
    {
        StatXMLParser parser;
        int objIdx;
        int criIdx;
        int typeIdx;
        public GeneralStatistics()
        {
            this.InitializeComponent();
            Hidden();
            objIdx = -1;
            criIdx = -1;
            typeIdx = -1;
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
            cbxFromYear.ItemsSource = cbxToYear.ItemsSource = listYear;
            cbxFromYear.SelectedIndex = cbxToYear.SelectedIndex = 0;
            cbxFromMonth.SelectedIndex = cbxToMonth.SelectedIndex = 0;
        }

        private void Hidden()
        {
            tRes.Visibility = Visibility.Hidden;
            gRes.Visibility = Visibility.Hidden;
            cResCol.Visibility = Visibility.Hidden;
            cResLine.Visibility = Visibility.Hidden;
        }


        /// <summary>
        /// đọc xử lý file xml lưu kiểu thống kê
        /// </summary>
        /// <returns></returns>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            int year1 = int.Parse(cbxFromYear.SelectedValue.ToString());
            int year2 = int.Parse(cbxToYear.SelectedValue.ToString());
            int month1 = int.Parse(cbxFromMonth.SelectedValue.ToString());
            int month2 = int.Parse(cbxToMonth.SelectedValue.ToString());

            if ((year2 >= year1) && (objIdx != -1) && ((criIdx != -1) && ((typeIdx != -1))))
            {
                string fName = parser.ObjectList[objIdx].CriteriaList[criIdx].TypeList[typeIdx].Method;
                switch (fName)
                {
                    case "f1":
                        f1(year1, year2, month1, month2);
                        break;
                    case "f2":
                        f2(year1, year2, month1, month2);
                        break;
                    case "f2a":
                        f2a(year1, year2, month1, month2);
                        break;
                    case "f3":
                        f3(year1, year2, month1, month2);
                        break;
                    case "f3a":
                        f3a(year1, year2, month1, month2);
                        break;
                    case "f4":
                        f4(year1, year2, month1, month2);
                        break;
                    case "f5":
                        f5(year1, year2, month1, month2);
                        break;
                    case "f6":
                        f6(year1, year2, month1, month2);
                        break;
                    case "f7":
                        f7(year1, year2, month1, month2);
                        break;
                    case "f8":
                        f8(year1, year2, month1, month2);
                        break;
                    case "f9":
                        f9(year1, year2, month1, month2);
                        break;
                    case "f10":
                        f10(year1, year2, month1, month2);
                        break;
                    case "f11":
                        f11(year1, year2, month1, month2);
                        break;
                    case "f12":
                        f12(year1, year2, month1, month2);
                        break;
                    case "f13":
                        f13(year1, year2, month1, month2);
                        break;
                    case "f14":
                        f14(year1, year2, month1, month2);
                        break;
                    case "f15":
                        f15(year1, year2, month1, month2);
                        break;
                    case "f16":
                        f16(year1, year2, month1, month2);
                        break;
                    case "f17":
                        f17(year1, year2, month1, month2);
                        break;
                    case "f18":
                        f18(year1, year2, month1, month2);
                        break;
                    case "f19":
                        f19(year1, year2, month1, month2);
                        break;
                    case "f19a":
                        f19a(year1, year2, month1, month2);
                        break;
                    case "f20":
                        f20(year1, year2, month1, month2);
                        break;
                    case "f20a":
                        f20a(year1, year2, month1, month2);
                        break;
					case "f21":
                        f21(year1, year2, month1, month2);
                        break;
                    case "f21a":
                        f21a(year1, year2, month1, month2);
                        break;
                    case "f22":
                        f22(year1, year2, month1, month2);
                        break;
                    case "f23":
                        f23(year1, year2, month1, month2);
                        break;
                    case "f24":
                        f24(year1, year2, month1, month2);
                        break;
                    case "f25":
                        f25(year1, year2, month1, month2);
                        break;
                    case "f25a":
                        f25a(year1, year2, month1, month2);
                        break;
                    case "f26":
                        f26(year1, year2, month1, month2);
                        break;
                    case "f26a":
                        f26a(year1, year2, month1, month2);
                        break;
                    case "f27":
                        f27(year1, year2, month1, month2);
                        break;
                    case "f28":
                        f28(year1, year2, month1, month2);
                        break;
                    case "f29":
                        f29(year1, year2, month1, month2);
                        break;
                    case "f29a":
                        f29a(year1, year2, month1, month2);
                        break;
                    case "f30":
                        f30(year1, year2, month1, month2);
                        break;
                    case "f31":
                        f31(year1, year2, month1, month2);
                        break;
                    case "f32":
                        f32(year1, year2, month1, month2);
                        break;
                    case "f32a":
                        f32a(year1, year2, month1, month2);
                        break;
                    case "f33":
                        f33(year1, year2, month1, month2);
                        break;
                    case "f33a":
                        f33a(year1, year2, month1, month2);
                        break;
                    case "f34":
                        f34(year1, year2, month1, month2);
                        break;
                    case "f34a":
                        f34a(year1, year2, month1, month2);
                        break;
                    case "f35":
                        f35(year1, year2, month1, month2);
                        break;
                    case "f35a":
                        f35a(year1, year2, month1, month2);
                        break;
                    case "f36":
                        f36(year1, year2, month1, month2);
                        break;
                    case "f36a":
                        f36a(year1, year2, month1, month2);
                        break;
                    case "f37":
                        f37(year1, year2, month1, month2);
                        break;
                    case "f37a":
                        f37a(year1, year2, month1, month2);
                        break;
                    case "f38":
                        f38(year1, year2, month1, month2);
                        break;
                    case "f38a":
                        f38a(year1, year2, month1, month2);
                        break;
                    case "custom":
                        runCustomCriteria(parser.ObjectList[objIdx].CriteriaList[criIdx].TypeList[typeIdx].SQL);
                        break;
                }
            }
            else
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin.");
        }


        /// <summary>
        /// xử lý kiểu thống kê do người dùng quy định
        /// </summary>
        /// <returns></returns>
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

        private void f38a(int year1, int year2, int month1, int month2)
        {
            Hidden();

            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(20, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;
        }

        private void f38(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(20, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResCol.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResCol.Visibility = Visibility.Visible;

        }

        private void f37a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(14, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;
        }

        private void f37(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(14, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResCol.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResCol.Visibility = Visibility.Visible;
        }



        private void f36a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(7, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;
        }

        private void f36(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(7, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResCol.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResCol.Visibility = Visibility.Visible;
        }



        private void f35a(int year1, int year2, int month1, int month2)
        {

            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(3, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;
        }

        private void f35(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(3, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResCol.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;

            tRes.Visibility = Visibility.Visible;
            cResCol.Visibility = Visibility.Visible;
        }




        private void f34a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(20, 0, date1, date2);
            List<DtoTienDo> td2 = _bus.getListDataByWorks(7, 0, date1, date2);
            int tongsochungchi = 0;
            int tongsobaithi = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsochungchi += _dto.TONGKHOILUONGCV;
                }
            }
            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi += _dto.TONGKHOILUONGCV;
                }
            }
			if(tongsobaithi!=0)
			{
            tRes.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsochungchi / (float)tongsobaithi * 100).ToString() + " % so với tổng số bài thi";
			}
			else
			{
				  tRes.Text = cbxCriteria.Text + " chiếm: Không có." ;
			}
            tRes.Visibility = Visibility.Visible;
        }

        private void f34(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
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

        private void f33a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(18, 0, date1, date2);
            List<DtoTienDo> td2 = _bus.getListDataByWorks(7, 0, date1, date2);
            int tongsophuckhao = 0;
            int tongsobaithi = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);
            List<DtoTienDo> _td2 = XoaCongViecTrung(td2);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsophuckhao += _dto.TONGKHOILUONGCV;
                }
            }
            foreach (DtoTienDo _dto in _td2)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi += _dto.TONGKHOILUONGCV;
                }
            }
			if(tongsobaithi!=0)
			{
            tRes.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsophuckhao / (float)tongsobaithi * 100).ToString() + " % so với tổng số bài thi";
			}
			else{
				  tRes.Text = cbxCriteria.Text + " chiếm: Không có." ;
			}
            tRes.Visibility = Visibility.Visible;
        }

        private void f33(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(18, 0, date1, date2);
            int tongsophuckhao = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);

            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsophuckhao += _dto.TONGKHOILUONGCV;
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + tongsophuckhao + " bài thi";
            tRes.Visibility = Visibility.Visible;
        }

        private void f32a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(3, 0, date1, date2);
            List<DtoTienDo> td2 = _bus.getListDataByWorks(7, 0, date1, date2);
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
			if (tongsothisinh!=0){
            tRes.Text = cbxCriteria.Text + " chiếm: " + ((float)tongsobaithi / (float)tongsothisinh * 100).ToString() + " % so với tổng số thí sinh tham gia dự thi";
            }
			else
			{
				 tRes.Text = cbxCriteria.Text + " chiếm: Không có."  ;
			}
			
			tRes.Visibility = Visibility.Visible;
        }

        private void f32(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataByWorks(7, 0, date1, date2);
            int tongsobaithi = 0;
            List<DtoTienDo> _td1 = XoaCongViecTrung(td1);
            foreach (DtoTienDo _dto in _td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null)
                {
                    tongsobaithi += _dto.TONGKHOILUONGCV;
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + tongsobaithi + " bài thi";
            tRes.Visibility = Visibility.Visible;
        }

        private void f31(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
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
        }

        private void f30(int year1, int year2, int month1, int month2)
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
        }

        private void f29a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(20, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;

        }

        private void f29(int year1, int year2, int month1, int month2)
        {
            Hidden();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> sothisinh = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataByWorks(20, 0, from, to);
                int thisinh = 0;
                foreach (DtoTienDo _dto in td)
                {
                    thisinh += _dto.KHOILUONGCVHT;
                }
                sothisinh.Add(thisinh);
            }

            //Ve bieu do dua tren 2 list kithi va list sochungchiduoccap
            tRes.Text = cbxCriteria.Text + ": \n";

            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], sothisinh[i]));
            int w = res.Count * 100;
            this.cResCol.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResCol.Visibility = Visibility.Visible;
        }

        private void f28(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> dt = bus.getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
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
        }

        private void f27(int year1, int year2, int month1, int month2)
        {
            Hidden();
            List<DtoDotThi> dt = new BusDotThi().getCompletedLateList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            string res = string.Empty;
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
            }
            tRes.Text = cbxCriteria.Text + ": " + res;
            tRes.Visibility = Visibility.Visible;
        }

        private void f26a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            List<DtoDotThi> dtLate = new BusDotThi().getCompletedLateList();
            List<DtoDotThi> dt = new BusDotThi().getDataList();
            List<DtoDotThi> dtCompleted = new BusDotThi().getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            int tongsodotthi = 0;
            int tongsodotthikhongkipthoihan = 0;
            int tongsodotthihoanthanh = 0;
            foreach (DtoDotThi dto in dtLate)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthikhongkipthoihan++;
                }
            }

            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthi++;
                }
            }

            foreach (DtoDotThi dto in dtCompleted)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthihoanthanh++;
                }
            }
			if((tongsodotthi!=0)&&(tongsodotthihoanthanh!=0))
			{
            tRes.Text = cbxCriteria.Text + ": \n\t-\t Chiếm " + (((float)tongsodotthikhongkipthoihan / (float)tongsodotthi) * 100).ToString() + "% so với tổng số đợt thi\n\t-\t Chiếm" + ((float)tongsodotthikhongkipthoihan / (float)tongsodotthihoanthanh * 100).ToString() + "% so với tổng số đợt thi hoàn thành\n";
			}
			else
			{
				 tRes.Text = cbxCriteria.Text + ": \n\t-\t Chiếm: Không có.";
			}
			tRes.Visibility = Visibility.Visible;
        }

        private void f26(int year1, int year2, int month1, int month2)
        {
            Hidden();
            List<DtoDotThi> dt = new BusDotThi().getCompletedLateList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            int count = 0;
            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    count++;
                }
            }
            tRes.Visibility = Visibility.Visible;
            tRes.Text = cbxCriteria.Text + ": " + count;
        }

        private void f25a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            List<DtoDotThi> dtEarly = new BusDotThi().getCompletedLateList();
            List<DtoDotThi> dt = new BusDotThi().getDataList();
            List<DtoDotThi> dtCompleted = new BusDotThi().getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            int tongsodotthi = 0;
            int tongsodotthikipthoihan = 0;
            int tongsodotthihoanthanh = 0;
			int count = 0;
            foreach (DtoDotThi dto in dtEarly)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    count++;
                }
            }

            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthi++;
                }
            }

            foreach (DtoDotThi dto in dtCompleted)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    tongsodotthihoanthanh++;
                }
            }
			
			tongsodotthikipthoihan = tongsodotthihoanthanh - count;
			
			if((tongsodotthi!=0)&&(tongsodotthihoanthanh!=0))
			{ 
				tRes.Text = cbxCriteria.Text + ": \n\t-\t Chiếm " + ((float)tongsodotthikipthoihan/(float)tongsodotthi*100).ToString() + "% so với tổng số đợt thi\n\t-\t Chiếm " + ((float)tongsodotthikipthoihan /(float) tongsodotthihoanthanh * 100).ToString() + "% so với tổng số đợt thi hoàn thành không bị trễ\n";
         }
			else{
			tRes.Text = cbxCriteria.Text + ": \n\t-\t Không có đợt thi nào hoàn thành kịp thời hạn. " ;
       
			}
            tRes.Visibility = Visibility.Visible;
        }

        private void f25(int year1, int year2, int month1, int month2)
        {
            Hidden();
            List<DtoDotThi> _dt = new BusDotThi().getListDataCompleted();
			List<DtoDotThi> dt = new BusDotThi().getCompletedLateList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            int count = 0;
			int _count = 0;
            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    count++;
                }
            }
			foreach (DtoDotThi dto in _dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    _count++;
                }
            }
			int res = _count - count;
			
            tRes.Text = cbxCriteria.Text + ": " + res;
			tRes.Visibility = Visibility.Visible;
        }

        private void f24(int year1, int year2, int month1, int month2)
        {
            Hidden();
            List<DtoDotThi> dt = new BusDotThi().getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            int count = 0;
            foreach (DtoDotThi dto in dt)
            {
                if (dto.NGAYTHI >= date1 && dto.NGAYTHI <= date2)
                {
                    count++;
                }
            }
            tRes.Visibility = Visibility.Visible;
            tRes.Text = cbxCriteria.Text + ": " + count;
        }

        // nên thêm hàm tương ứng nhưng trả ra liệt kê cv sớm hạn
        private void f23(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> dt = bus.getListDataCompleted();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            string res = string.Empty;
            foreach (DtoDotThi dto in dt)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataCompletedByMaDT(dto.MADT);
				int count = 0;
				foreach (DtoTienDo _dto in td)
                {
                    if ((_dto.NGAYBATDAUTHUCTE <= date1 && _dto.NGAYKETTHUCTHUCTE >= date1) || (_dto.NGAYBATDAUTHUCTE >= date1 && _dto.NGAYBATDAUTHUCTE <= date2))
                    {
						count++;
					}
				}
				if(count != 0)
				{
					res += "\n-\t" + dto.TENDOTTHI + ": ";
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
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + res;
            tRes.Visibility = Visibility.Visible;
        }

        private void f22(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusDotThi bus = new BusDotThi();
            List<DtoDotThi> dt = bus.getListContainCompletedLateWorkItem();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            string res = string.Empty;
            foreach (DtoDotThi dto in dt)
            {
                BusTienDo _bus = new BusTienDo();
                List<DtoTienDo> td = _bus.getListDataDelayedByMaDT(dto.MADT);
				int count = 0;
				foreach (DtoTienDo _dto in td)
                {
                    if ((_dto.NGAYBATDAUTHUCTE <= date1 && _dto.NGAYKETTHUCTHUCTE >= date1) || (_dto.NGAYBATDAUTHUCTE >= date1 && _dto.NGAYBATDAUTHUCTE <= date2))
                    {
						count++;
					}
				}
				if(count != 0)
				{
					res += "\n-\t" + dto.TENDOTTHI + ": ";
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
                }
            }
            tRes.Text = cbxCriteria.Text + ": " + res;
            tRes.Visibility = Visibility.Visible;
        }

        private void f21a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> socongviectrehan = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));

                List<DtoCongViec> cv = bus.getListDataCompleted(0, 0, -1, from, to);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], socongviectrehan[i]));
            int w = res.Count * 100;
            this.cResLine.Width = w;
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;

            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;
        }

        private void f21(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> socongviectrehan = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));

                List<DtoCongViec> cv = bus.getListDataCompleted(0, 0, -1, from, to);
                socongviectrehan.Add(cv.Count);
            }

            //Ve bieu do dua tren 2 list kithi va list socongviectrehan
            tRes.Text = cbxCriteria.Text + ": \n";
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < kithi.Count; i++)
                res.Add(new KeyValuePair<string, int>(kithi[i], socongviectrehan[i]));
            int w = res.Count * 100;
            this.cResCol.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResCol.Visibility = Visibility.Visible;
        }

        private void f20a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> socongviectrehan = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));

                List<DtoCongViec> cv = bus.getListDataCompleted(0, 0, 0, from, to);
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
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;

        }

        private void f20(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> socongviectrehan = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));

                List<DtoCongViec> cv = bus.getListDataCompleted(0, 0, 0, from, to);
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
            this.cResCol.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;

            tRes.Visibility = Visibility.Visible;
            cResCol.Visibility = Visibility.Visible;
        }

        private void f19a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> socongviectrehan = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime _from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));

                List<DtoCongViec> cv = bus.getListDataCompleted(0, 0, 1, _from, to);
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
            ((LineSeries)mcChart2.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResLine.Visibility = Visibility.Visible;


        }

        private void f19(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

            //Lay ra cac thang + nam tu date1 --> date2
            List<string> kithi = new List<string>();
            List<List<int>> _kithi = new List<List<int>>();
            List<int> socongviectrehan = new List<int>();
            if (Math.Abs(year1 - year2) > 0)
            {
                int y1 = year1 > year2 ? year1 : year2;
                int y2 = year1 > year2 ? year2 : year1;
                int m1 = year1 > year2 ? month1 : month2;
                int m2 = year1 > year2 ? month2 : month1;
                for (int i = m2; i <= 12; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y2);
                    kithi.Add(i + "/" + y2);
                    _kithi.Add(lst);
                }
                for (int i = y2 + 1; i < y1; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        List<int> lst = new List<int>();
                        lst.Add(j);
                        lst.Add(i);
                        kithi.Add(j + "/" + i);
                        _kithi.Add(lst);
                    }
                }
                for (int i = 1; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(y1);
                    kithi.Add(i + "/" + y1);
                    _kithi.Add(lst);
                }
            }
            else
            {
                int m1 = month1 >= month2 ? month1 : month2;
                int m2 = month1 >= month2 ? month2 : month1;
                for (int i = 2; i <= m1; i++)
                {
                    List<int> lst = new List<int>();
                    lst.Add(i);
                    lst.Add(year1);
                    kithi.Add(i + "/" + year1);
                    _kithi.Add(lst);

                }
            }

            for (int i = 0; i < kithi.Count; i++)
            {
                DateTime from = new DateTime(_kithi[i][1], _kithi[i][0], 1);
                DateTime to = new DateTime(_kithi[i][1], _kithi[i][0], DateTime.DaysInMonth(_kithi[i][1], _kithi[i][0]));

                List<DtoCongViec> cv = bus.getListDataCompleted(0, 0, 1, from, to);
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
            int w = res.Count * 100;
            this.cResCol.Width = w;
            ((ColumnSeries)mcChart1.SeriesHost.Series[0]).ItemsSource = res;
            tRes.Visibility = Visibility.Visible;
            cResCol.Visibility = Visibility.Visible;
        }

        //f18 nên thêm biểu đồ đường/cột
        private void f18(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
				if(tongsocvhoanthanhtrehan!=0)
				{
					
                    float Percent1 = (tre / tongsocvhoanthanhtrehan) * 100;
                
               res += " lần\n\t\t - Trễ " + Percent1.ToString();
				}
				else
					
				{
				res += " lần\n\t\t - Trễ : Không có.";
				}
					if(tongsocvhoanthanhtrehan!=0)
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
            tRes.Text = res + "\nTổng số công việc hoàn thành trễ hạn: " + tongsocvhoanthanhtrehan  + " công việc";
            tRes.Visibility = Visibility.Visible;

        }

        private void f17(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan + " công việc";
            tRes.Visibility = Visibility.Visible;
        }

        private void f16(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan + " công việc";

            tRes.Visibility = Visibility.Visible;
        }

        private void f15(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan + " công việc";
            tRes.Visibility = Visibility.Visible;
        }

        private void f14(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan + " công việc";

            tRes.Visibility = Visibility.Visible;
        }

        private void f13(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan + " công việc";
            tRes.Visibility = Visibility.Visible;
        }

        private void f12(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan + " công việc";
            tRes.Visibility = Visibility.Visible;
        }

        private void f11(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan + " công việc";
            tRes.Visibility = Visibility.Visible;

        }

        private void f10(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan + " công việc";
            tRes.Visibility = Visibility.Visible;
        }

        private void f9(int year1, int year2, int month1, int month2)
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
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan + " công việc";
            tRes.Visibility = Visibility.Visible;
        }

        private void f8(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();

            List<DtoCongViec> cv = bus.getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan + " công việc";
            tRes.Visibility = Visibility.Visible;
        }

        private void f7(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();

            List<DtoCongViec> cv = bus.getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
                res += "Công việc: " + bus.getMotaCVByMaCV(dto.MACV) + " - " + " Trễ: " + count + " công  việc\r\n";
                tongsocvhoanthanhtrehan += count;
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan + " công việc";
            tRes.Visibility = Visibility.Visible;



        }

        private void f6(int year1, int year2, int month1, int month2)
        {
            Hidden();
            BusCongViec bus = new BusCongViec();
            List<DtoCongViec> cv = bus.getDataList();
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan + " công việc";

            tRes.Visibility = Visibility.Visible;
        }

        private void f5(int year1, int year2, int month1, int month2)
        {
            Hidden();
            tRes.Text = cbxCriteria.Text + ": " + new BusCongViec().getDataList().Count.ToString();
            tRes.Visibility = Visibility.Visible;
        }

        private void f4(int year1, int year2, int month1, int month2)
        {
            Hidden();
            List<DtoPhanCong> listpc = new BusPhanCong().getDataList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Nhân Viên");
            dt.Columns.Add("Công việc");
            dt.Columns.Add("Thời gian làm (Ngày)");
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));

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

            gRes.ItemsSource = dt.DefaultView;
            gRes.Visibility = Visibility.Visible;
        }

        private void f3a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            string temp = null;
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = bus.getListDataCompletedWork(-1);
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            for (int i = 0; i < list.Count; i++)
            {
                int iNumOfWork1 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 1, date1, date2);
                int iNumOfWork2 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 0, date1, date2);
                int iNumOfWork3 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, -1, date1, date2);
              int Denominator = iNumOfWork1 + iNumOfWork2 + iNumOfWork3;
				if(Denominator!=0)
				{
					float fPercent = (iNumOfWork1 / Denominator	) * 100;
                
                temp += "\n\t - " + list[i].TENNV + " -Phần trăm sớm hạn so với tổng công việc thực hiện: " + fPercent.ToString() + "%";
				}
				else
					
				{
				temp += "\n\t - " + list[i].TENNV + " - Phần trăm sớm hạn so với tổng công việc thực hiện: Không có.";
				}
     
            }
            if (temp != null)
            {
                tRes.Text = cbxCriteria.Text + ": " + temp;
            }
            else
            {
                tRes.Text = cbxCriteria.Text + ": không có nhân viên nào";
            }
            tRes.Visibility = Visibility.Visible;
        }

        private void f3(int year1, int year2, int month1, int month2)
        {
            Hidden();
            string temp = null;
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = bus.getListDataCompletedWork(-1);
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            for (int i = 0; i < list.Count; i++)
            {
                int iNumOfWork = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, -1, date1, date2);
                temp += "\n\t - " + list[i].TENNV + " - Số lần sớm: " + iNumOfWork.ToString();
            }
            if (temp != null)
            {
                tRes.Text = cbxCriteria.Text + ": " + temp;
            }
            else
            {
                tRes.Text = cbxCriteria.Text + ": không có nhân viên nào";
            }
            tRes.Visibility = Visibility.Visible;
        }

        private void f2a(int year1, int year2, int month1, int month2)
        {
            Hidden();
            string temp = null;
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = bus.getListDataCompletedWork(1);
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            for (int i = 0; i < list.Count; i++)
            {
                int iNumOfWork1 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 1, date1, date2);
                int iNumOfWork2 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 0, date1, date2);
                int iNumOfWork3 = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, -1, date1, date2);
				int Denominator = iNumOfWork1 + iNumOfWork2 + iNumOfWork3;
				if(Denominator!=0)
				{
					float fPercent = (iNumOfWork1 / Denominator	) * 100;
                
                temp += "\n\t - " + list[i].TENNV + " - Phần trăm trễ hạn so với tổng công việc thực hiện: " + fPercent.ToString() + "%";
				}
				else
					
				{
				temp += "\n\t - " + list[i].TENNV + " - Phần trăm trễ hạn so với tổng công việc thực hiện: Không có.";
				}
				
            }
            if (temp != null)
            {
                tRes.Text = cbxCriteria.Text + ": " + temp;
            }
            else
            {
                tRes.Text = cbxCriteria.Text + ": không có nhân viên nào";
            }
            tRes.Visibility = Visibility.Visible;
        }

        private void f2(int year1, int year2, int month1, int month2)
        {
            Hidden();
            string temp = null;
            BusNhanVienThuaHanh bus = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = bus.getListDataCompletedWork(1);
            DateTime date1 = new DateTime(year1, month1, 1);
            DateTime date2 = new DateTime(year2, month2, DateTime.DaysInMonth(year2, month2));
            for (int i = 0; i < list.Count; i++)
            {
                int iNumOfWork = bus.getNumOfWorkCompletion(list[i].MANV, 0, 0, 1, date1, date2);
				if(iNumOfWork != 0)
				{
                	temp += "\n\t - " + list[i].TENNV + " - Số lần trễ: " + iNumOfWork.ToString();
				}
            }
            if (temp != null)
            {
                tRes.Text = cbxCriteria.Text + ": " + temp;
            }
            else
            {
                tRes.Text = cbxCriteria.Text + ": không có nhân viên nào";
            }
            tRes.Visibility = Visibility.Visible;
        }

        private void f1(int year1, int year2, int month1, int month2)
        {
            Hidden();
            List<DtoNhanVienThuaHanh> list = new BusNhanVienThuaHanh().getDataList();
            tRes.Text = cbxCriteria.Text + ": " + list.Count.ToString();
            tRes.Visibility = Visibility.Visible;
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

        private void cbxFromYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int year = int.Parse(cbxFromYear.SelectedValue.ToString());
            List<int> list = new BusTienDo().getListMonthForComparisonStat(year);
            cbxFromMonth.ItemsSource = list;
            cbxFromMonth.SelectedIndex = 0;
        }

        private void cbxToYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int year = int.Parse(cbxToYear.SelectedValue.ToString());
            List<int> list = new BusTienDo().getListMonthForComparisonStat(year);
            cbxToMonth.ItemsSource = list;
            cbxToMonth.SelectedIndex = 0;
        }

        private void cbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            typeIdx = cbxType.SelectedIndex;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStatisticItem dlg = new AddStatisticItem();
            dlg.ShowDialog();
            loadXMLFile();
        }
    }
}
