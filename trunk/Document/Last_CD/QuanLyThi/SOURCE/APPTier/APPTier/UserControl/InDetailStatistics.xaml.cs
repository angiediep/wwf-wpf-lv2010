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

namespace APPTier
{
    /// <summary>
    /// Interaction logic for InDetailStatistics.xaml
    /// </summary>
    public partial class InDetailStatistics : UserControl
    {
        StatXMLParser parser;
        int objIdx;
        int criIdx;
        int typeIdx;
        int maDT;
        List<Criteria> m_ListCri;
        List<StatHandlers.Type> m_ListType;
        List<string> m_ListMaDT;
        public InDetailStatistics()
        {
            this.InitializeComponent();
            Hidden();
            objIdx = -1;
            criIdx = -1;
            typeIdx = -1;
            maDT = -1;
            m_ListCri = new List<Criteria>();
            m_ListType = new List<StatHandlers.Type>();
            m_ListMaDT = new List<string>();

            BusDotThi xx = new BusDotThi();
            List<DtoDotThi> listx = xx.getListDataCompleted();
            foreach (DtoDotThi dotthi in listx)
            {
                string tenDT = dotthi.TENDOTTHI;
                ListBoxItem item = new ListBoxItem();
                item.Content = tenDT;
                lbxExam.Items.Add(item);

                m_ListMaDT.Add(dotthi.MADT.ToString());
            }
            loadXMLFile();
        }

        private void loadXMLFile()
        {
            parser = new StatXMLParser("Stat.xml");
            parser.Parse();

            StatHandlers.Object customObj = parser.getCustomObject();
            parser.ObjectList.Remove(customObj);

            List<string> doiTuongThongke = new List<string>();
            for (int i = 0; i < parser.ObjectList.Count; i++)
                doiTuongThongke.Add(parser.ObjectList[i].Name);
            cbxObject.ItemsSource = doiTuongThongke;
        }

        private void cbxObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objIdx = cbxObject.SelectedIndex;
            if (objIdx != -1)
            {
                List<string> tieuChi = new List<string>();
                if (m_ListCri != null)
                    m_ListCri.Clear();
                List<string> listCri = new List<string>();
                for (int i = 0; i < parser.ObjectList[objIdx].CriteriaList.Count; i++)
                {
                    if (parser.ObjectList[objIdx].CriteriaList[i].IsDetail == true)
                    {
                        Criteria cri = parser.ObjectList[objIdx].CriteriaList[i];
                        m_ListCri.Add(cri);
                        listCri.Add(cri.Name);
                    }
                }
                cbxCriteria.ItemsSource = listCri;
            }
        }

        private void cbxCriteria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            criIdx = cbxCriteria.SelectedIndex;
            if (criIdx != -1)
            {
                if (m_ListType != null)
                    m_ListType.Clear();
                List<StatHandlers.Type> listType = m_ListCri[criIdx].TypeList;
                List<string> typelist = new List<string>();
                for (int i = 0; i < listType.Count; i++)
                {
                    StatHandlers.Type type = parser.ObjectList[objIdx].CriteriaList[criIdx].TypeList[i];
                    m_ListType.Add(type);
                    typelist.Add(type.Name);
                }
                cbxType.ItemsSource = typelist;
            }
            cbxType.SelectedIndex = 0;
        }


        /// <summary>
        /// đọc xử lý tương ứng file xml quy định kiểu thống kê 
        /// </summary>
        /// <returns></returns>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if ((maDT != -1) && (objIdx != -1) && ((criIdx != -1) && ((typeIdx != -1))))
            {
                string fName = m_ListCri[criIdx].TypeList[typeIdx].Method;
                switch (fName)
                {
                    case "f1":
                        f1(maDT);
                        break;
                    //case "f2":
                    //    f2(maDT);
                    //    break;
                    //case "f2a":
                    //    f2a(maDT);
                    //    break;
                    //case "f3":
                    //    f3(maDT);
                    //    break;
                    //case "f3a":
                    //    f3a(maDT);
                    //    break;
                    case "f4":
                        f4(maDT);
                        break;
                    //case "f5":
                    //    f5(maDT);
                    //    break;
                    case "f6":
                        f6(maDT);
                        break;
                    case "f7":
                        f7(maDT);
                        break;
                    case "f8":
                        f8(maDT);
                        break;
                    case "f9":
                        f9(maDT);
                        break;
                    case "f10":
                        f10(maDT);
                        break;
                    case "f11":
                        f11(maDT);
                        break;
                    case "f12":
                        f12(maDT);
                        break;
                    case "f13":
                        f13(maDT);
                        break;
                    case "f14":
                        f14(maDT);
                        break;
                    case "f15":
                        f15(maDT);
                        break;
                    case "f16":
                        f16(maDT);
                        break;
                    case "f17":
                        f17(maDT);
                        break;
                    //case "f18":
                    //    f18(maDT);
                    //    break;
                    //case "f19":
                    //    f19(maDT);
                    //    break;
                    //case "f19a":
                    //    f19a(maDT);
                    //    break;
                    //case "f20":
                    //    f20(maDT);
                    //    break;
                    //case "f20a":
                    //    f20a(maDT);
                    //    break;
                    //case "f21a":
                    //    f21a(maDT);
                    //    break;
                    case "f22":
                        f22(maDT);
                        break;
                    //case "f23":
                    //    f23(maDT);
                    //    break;
                    //case "f24":
                    //    f24(maDT);
                    //    break;
                    //case "f25":
                    //    f25(maDT);
                    //    break;
                    //case "f25a":
                    //    f25a(maDT);
                    //    break;
                    //case "f26":
                    //    f26(maDT);
                    //    break;
                    //case "f26a":
                    //    f26a(maDT);
                    //    break;
                    //case "f27":
                    //    f27(maDT);
                    //    break;
                    //case "f28":
                    //    f28(maDT);
                    //    break;
                    //case "f29":
                    //    f29(maDT);
                    //    break;
                    //case "f29a":
                    //    f29a(maDT);
                    //    break;
                    //case "f30":
                    //    f30(maDT);
                    //    break;
                    //case "f31":
                    //    f31(maDT);
                    //    break;
                    case "f32":
                        f32(maDT);
                        break;
                    //case "f32a":
                    //    f32a(maDT);
                    //    break;
                    case "f33":
                        f33(maDT);
                        break;
                    //case "f33a":
                    //    f33a(maDT);
                    //    break;
                    case "f34":
                        f34(maDT);
                        break;
                    //case "f34a":
                    //    f34a(maDT);
                    //    break;
                    //case "f35":
                    //    f35(maDT);
                    //    break;
                    //case "f35a":
                    //    f35a(maDT);
                    //    break;
                    //case "f36":
                    //    f36(maDT);
                    //    break;
                    //case "f36a":
                    //    f36a(maDT);
                    //    break;
                    //case "f37":
                    //    f37(maDT);
                    //    break;
                    //case "f37a":
                    //    f37a(maDT);
                    //    break;
                    //case "f38":
                    //    f38(maDT);
                    //    break;
                    //case "f38a":
                    //    f38a(maDT);
                    //    break;
                }
            }
            else
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin.");
        }

        private void lbxExam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = lbxExam.SelectedIndex;
            if (idx != -1)
                maDT = int.Parse(m_ListMaDT[idx]);
        }

        private void f34(int maDT)
        {
            Hidden();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataBymaDT(maDT);
            int tongsochungchi = 0;
            foreach (DtoTienDo _dto in td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null && _dto.MACV == 20)
                {
                    tongsochungchi = _dto.TONGKHOILUONGCV; break;
                }
            }
            tRes.Text = cbxCriteria.Text + ":" + tongsochungchi + " chứng chỉ";
            tRes.Visibility = Visibility.Visible;
        }

        private void Hidden()
        {
            tRes.Visibility = Visibility.Hidden;
            gRes.Visibility = Visibility.Hidden;
            cResLine.Visibility = Visibility.Hidden;
            cResCol.Visibility = Visibility.Hidden;
        }

        private void f33(int maDT)
        {
            Hidden();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataBymaDT(maDT);
            int tongsophuckhao = 0;

            foreach (DtoTienDo _dto in td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null && _dto.MACV == 18)
                {
                    tongsophuckhao = _dto.TONGKHOILUONGCV; break;
                }
            }
            tRes.Text = cbxCriteria.Text + ":" + tongsophuckhao + " bài thi";
            tRes.Visibility = Visibility.Visible;
        }

        private void f32(int maDT)
        {
            Hidden();
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td1 = _bus.getListDataBymaDT(maDT);
            int tongsobaithi = 0;
            foreach (DtoTienDo _dto in td1)
            {
                if (_dto.NGAYKETTHUCTHUCTE != null && _dto.MACV == 7)
                {
                    tongsobaithi = _dto.TONGKHOILUONGCV; break;
                }
            }
            tRes.Text = cbxCriteria.Text + ":" + tongsobaithi + " bài thi";
            tRes.Visibility = Visibility.Visible;
        }


        private void f22(int maDT)
        {
            Hidden();
            BusDotThi bus = new BusDotThi();

            string res = string.Empty;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataDelayedByMaDT(maDT);
            foreach (DtoTienDo _dto in td)
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

            tRes.Text = cbxCriteria.Text + ":" + res;
            tRes.Visibility = Visibility.Visible;
        }

        private void f17(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime > time && _dto.MACV > 14)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Trễ hạn\r\n";
                    tongsocvhoanthanhtrehan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f16(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime > time && _dto.MACV > 7 && _dto.MACV <= 14)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Trễ hạn\r\n";
                    tongsocvhoanthanhtrehan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f15(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime > time && _dto.MACV <= 7)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Trễ hạn\r\n";
                    tongsocvhoanthanhtrehan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f14(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhdunghan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime == time && _dto.MACV > 14)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Đúng hạn\r\n";
                    tongsocvhoanthanhdunghan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f13(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhdunghan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime == time && _dto.MACV > 7 && _dto.MACV <= 14)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Đúng hạn\r\n";
                    tongsocvhoanthanhdunghan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f12(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhdunghan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime == time && _dto.MACV <= 7)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Đúng hạn\r\n";
                    tongsocvhoanthanhdunghan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f11(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhsomhan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {

                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime < time && _dto.MACV > 14)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Sớm hạn\r\n";
                    tongsocvhoanthanhsomhan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan;
            tRes.Visibility = Visibility.Visible;

        }

        private void f10(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhsomhan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {

                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime < time && _dto.MACV > 7 && _dto.MACV <= 14)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Sớm hạn\r\n";
                    tongsocvhoanthanhsomhan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f9(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhsomhan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {

                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime < time && _dto.MACV <= 7)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Sớm hạn\r\n";
                    tongsocvhoanthanhsomhan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f8(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhdunghan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime == time)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Đúng hạn\r\n";
                    tongsocvhoanthanhdunghan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhdunghan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f7(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhtrehan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime > time)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Trễ hạn\r\n";
                    tongsocvhoanthanhtrehan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhtrehan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f6(int maDT)
        {
            Hidden();
            string res = string.Empty;
            int tongsocvhoanthanhsomhan = 0;
            BusTienDo _bus = new BusTienDo();
            List<DtoTienDo> td = _bus.getListDataBymaDT(maDT);
            foreach (DtoTienDo _dto in td)
            {
                int realtime = _dto.NGAYKETTHUCTHUCTE.Subtract(_dto.NGAYBATDAUTHUCTE).Days;
                int time = _dto.NGAYKETTHUCQUYDINH.Subtract(_dto.NGAYBATDAUQUYDINH).Days;
                if (realtime < time)
                {
                    BusCongViec bus = new BusCongViec();
                    res += "Công việc: " + bus.getMotaCVByMaCV(_dto.MACV) + " - " + " Sớm hạn\r\n";
                    tongsocvhoanthanhsomhan++;
                }
            }
            tRes.Text = res + "\t\n" + cbxCriteria.Text + ": " + tongsocvhoanthanhsomhan;
            tRes.Visibility = Visibility.Visible;
        }

        private void f5(int year1, int year2, int month1, int month2)
        {
            Hidden();
            tRes.Text = cbxCriteria.Text + ": " + new BusCongViec().getDataList().Count.ToString();
            tRes.Visibility = Visibility.Visible;
        }

        private void f4(int maDT)
        {
            Hidden();
            List<DtoPhanCong> listpc = new BusPhanCong().getDataList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Nhân Viên");
            dt.Columns.Add("Công việc");
            dt.Columns.Add("Thời gian làm (Ngày)");

            for (int i = 0; i < listpc.Count; i++)
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

            gRes.ItemsSource = dt.DefaultView;
            gRes.Visibility = Visibility.Visible;
        }

        private void f1(int maDT)
        {
            Hidden();
            List<DtoNhanVienThuaHanh> list = new BusNhanVienThuaHanh().getDataList();
            tRes.Text = cbxCriteria.Text + ": " + list.Count.ToString();
            tRes.Visibility = Visibility.Visible;
        }

        private void cbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            typeIdx = cbxType.SelectedIndex;
        }
    }
}
