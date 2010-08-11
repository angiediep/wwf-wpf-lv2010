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
using ModelReader;
using System.Drawing;
using System.Collections;
using System.Collections.ObjectModel;
using BUSLayer;
using DataLayer.DTO;
using System.ComponentModel;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for AssignUser.xaml
    /// </summary>
    public partial class AssignUser : UserControl
    {
        public static int ASSIGNTYPE;
        public static int MaDT;
        public static string TenDT;

        ObservableCollection<string> listNV = new ObservableCollection<string>();
        public ListBox dragSource = null;

        public static List<string> m_ListTenDTVaMaDT;
        public static int SelectedDotThi = -1;

        XOMLReader reader;
        double height = 0;
        double width = 0;

        public AssignUser()
        {
            this.InitializeComponent();
            AssignUser.ASSIGNTYPE = 2;
            m_ListTenDTVaMaDT = new List<string>();
            reader = new XOMLReader("QuyTrinhThiWorkflow.xoml");
            reader.parseXOML();

            canv.Margin = new Thickness(0, 0, 0, 0);

            ////////////////////////////////
            BusNhanVienThuaHanh x = new BusNhanVienThuaHanh();
            List<DtoNhanVienThuaHanh> list = x.getDataList();
            if (list.Count != 0)
            {
                foreach (DtoNhanVienThuaHanh nv in list)
                {
                    string tennv = nv.TENNV;
                    string username = nv.TENDANGNHAP;
                    listNV.Add(tennv + " - " + username);
                }
                lblUser.ItemsSource = listNV;
                lblUser.SelectedIndex = 0;
            }
            ////////////////////////////////

            ////////////////////////////////
            BusDotThi xx = new BusDotThi();
            List<DtoDotThi> listx = xx.getListDataUpComming();
            if (listx.Count != 0)
            {
                foreach (DtoDotThi dotthi in listx)
                {
                    string tenDT = dotthi.TENDOTTHI;
                    ListBoxItem item = new ListBoxItem();
                    item.Content = tenDT;
                    lbxExam.Items.Add(item);

                    m_ListTenDTVaMaDT.Add(dotthi.TENDOTTHI);
                    m_ListTenDTVaMaDT.Add(dotthi.MADT.ToString());
                }
            }

            if (m_ListTenDTVaMaDT.Count != 0)
                MaDT = int.Parse(m_ListTenDTVaMaDT[1]);
            else
                MaDT = -1;

            ////////////////////////////////
            if (MaDT != -1)
            {
                System.Drawing.PointF startingPoint = new System.Drawing.PointF(150f, 20f);
                //Ellipse e = new Ellipse();
                //e.Stroke = new SolidColorBrush(Colors.Tomato);
                //e.Width = 5;
                //e.Height = 5;
                //e.SetValue(Canvas.LeftProperty, (double)startingPoint.X + );
                //e.SetValue(Canvas.TopProperty, (double)startingPoint.Y - 10);
                //canv.Children.Add(e);
                draw(startingPoint, reader.ListActivity);
                //   this.sss.Height = height;
                //  this.sss.Width = width + 500;
            }
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        private void btnFinish_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        /// <summary>
        /// quy định và vẽ Workflow view
        /// </summary>
        /// <returns></returns>
        private void draw(PointF nextStartPoint, List<Activity> list)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                Activity act = list[i];
                height += act.Height + 15;
                width += act.Width;

                switch (act.Type)
                {
                    case "ParallelActivity":
                        UCParallel p = new UCParallel(act, act.Width, act.Height);
                        p.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        p.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        canv.Children.Add(p);
                        if (i < count - 1)
                            nextStartPoint = new PointF(nextStartPoint.X + (float)list[i].Width / 2 - (float)list[i + 1].Width / 2, nextStartPoint.Y + 10f + (float)p.Height);
                        break;
                    case "SequenceActivity":
                        UCSequence s = new UCSequence(act, act.Width, act.Height);
                        s.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        s.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        canv.Children.Add(s);
                        break;
                    case "WorkItem":
                        UCWorkItem r = new UCWorkItem(act, act.Width, act.Height, act.getstatus(), null);
                        r.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        r.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);

                        string res = string.Empty;
                        BusTienDo listbusTD = new BusTienDo();

                        List<string> listNVCV = listbusTD.getListNVofCV(new BusCongViec().getMaCVByMoTaCV(r.XName), int.Parse(m_ListTenDTVaMaDT[1]));
                        if (listNVCV.Count != 0)
                        {
                            res += "Phân công cho:\r\n\t";
                            for (int j = 0; j < listNVCV.Count; j += 2)
                            {
                                res += listNVCV[j] + "\r\n\t";
                            }
                            if (res == string.Empty)
                                res = "Chưa được phân công";
                            ((TextBlock)r.FindName("personNameAssigned")).Text = res;
                        }

                        r.AllowDrop = true;
                        r.Drop += new DragEventHandler(r_Drop);
                        r.setHiddenPopUp();
                        canv.Children.Add(r);
                        if (i < count - 1)
                            nextStartPoint = new PointF(nextStartPoint.X + (float)list[i].Width / 2 - (float)list[i + 1].Width / 2, nextStartPoint.Y + 10f + (float)r.Height);
                        break;
                }
            }
        }


        /// <summary>
        /// xử lý kéo thả và update WorkItem vào cơ sỡ dữ liệu
        /// </summary>
        /// <returns></returns>
        void r_Drop(object sender, DragEventArgs e)
        {
            if (MaDT != -1)
            {
                UCWorkItem parent = (UCWorkItem)sender;
                string data1 = e.Data.GetData(typeof(string)).ToString();
                string data = data1.Remove(data1.IndexOf("-") - 1);

                string tenCV = new BusCongViec().getTenCVByMoTaCV(parent.XName);

                BusCongViec buscv = new BusCongViec();
                List<DtoCongViec> listcv = buscv.getListDataBytenCV(tenCV);

                BusNhanVienThuaHanh busnv = new BusNhanVienThuaHanh();
                List<DtoNhanVienThuaHanh> listnv = busnv.getListDataBytenNV(data.ToString());

                string res = string.Empty;
                if (AssignUser.ASSIGNTYPE == 1)
                {
                    DtoPhanCong dtoPC = new DtoPhanCong();
                    dtoPC.MACV = listcv[0].MACV;
                    dtoPC.MANV = listnv[0].MANV;
                    dtoPC.NGAYAPDUNG = AssignUser2.From;
                    dtoPC.NGAYHETHAN = AssignUser2.To;
                    BusPhanCong pc = new BusPhanCong();

                    if (pc.CheckCoChua(dtoPC.MACV, dtoPC.MANV) != -1)
                    {
                        if (MessageBox.Show("Nhân viên này đã được giao công việc này. Bạn muốn xóa công việc này của nhân viên này không ?\r\nNếu sau khi bấm Yes, muốn cập nhật công việc cho nhân viên này thì nắm kéo nhân viên này vào công việc tương ứng một lần nữa.", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                            pc.deleteDataBymaNVAndMaCV(dtoPC.MACV, dtoPC.MANV);
                    }
                    else
                    {
                        pc.insertData(dtoPC);
                        parent.Color = System.Windows.Media.Brushes.Green;
                    }

                    BusCongViec listbuscv = new BusCongViec();
                    List<string> listNVCV = listbuscv.getListNVofCV(tenCV);
                    if (listNVCV.Count != 0)
                    {
                        res += "Phân công cho:\r\n\t";
                        for (int i = 0; i < listNVCV.Count; i += 3)
                        {
                            res += listNVCV[i] + " - ";
                            res += "Từ " + listNVCV[i + 1] + " đến ";
                            if ((listNVCV[i + 2] == "1/1/9999") || (listNVCV[i + 2] == "01/01/9999"))
                                res += " về sau." + "\r\n\t";
                            else
                                res += listNVCV[i + 2] + "\r\n\t";
                        }
                    }
                }
                else if (AssignUser.ASSIGNTYPE == 2)
                {
                    BusDotThi dt = new BusDotThi();
                    DtoDotThi dtodt = dt.getListDataBytenDotThi(AssignUser.TenDT)[0];

                    DtoTienDo td = new DtoTienDo();
                    td.MADT = int.Parse(AssignUser.m_ListTenDTVaMaDT[AssignUser.SelectedDotThi * 2 + 1]);
                    td.MACV = listcv[0].MACV;
                    td.MANV = listnv[0].MANV;

                    td.NGAYBATDAUQUYDINH = dtodt.NGAYTHI.Add(new TimeSpan(listcv[0].NGAYBATDAU, 0, 0, 0));
                    td.NGAYKETTHUCQUYDINH = dtodt.NGAYTHI.Add(new TimeSpan(listcv[0].NGAYKETTHUC, 0, 0, 0));
                    td.MADT = AssignUser.MaDT;
                    td.NGAYKETTHUCTHUCTE = new DateTime(9999, 1, 1);
                    td.NGAYBATDAUTHUCTE = new DateTime(9999, 1, 1);

                    BusTienDo x = new BusTienDo();
                    if (x.CheckCoChua(td.MADT, td.MANV, td.MACV) != -1)
                    {
                        if (MessageBox.Show("Nhân viên này đã được giao công việc này. Bạn muốn xóa công việc này của nhân viên này không ?\r\nNếu sau khi bấm Yes, muốn cập nhật công việc cho nhân viên này thì nắm kéo nhân viên này vào công việc tương ứng một lần nữa.", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                            x.deleteDataBymaNVAndMaCVAndMaDT(td.MADT, td.MANV, td.MACV);
                    }
                    else
                        x.insertData(td);

                    List<string> listNVCV = x.getListNVofCV(new BusCongViec().getMaCVByMoTaCV(parent.XName), td.MADT);
                    if (listNVCV.Count != 0)
                    {
                        res += "Phân công cho:\r\n\t";
                        for (int j = 0; j < listNVCV.Count; j += 2)
                            res += listNVCV[j] + "\r\n\t";
                        if (res == string.Empty)
                            res = "Chưa được phân công";
                    }
                }

                if (res == string.Empty)
                    res = "Chưa được phân công";
                ((TextBlock)parent.FindName("personNameAssigned")).Text = res;
            }
            else
                MessageBox.Show("Hãy chọn một đợt thi.");
        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        #region GetDataFromListBox(ListBox,Point)
        private static object GetDataFromListBox(ListBox source, System.Windows.Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }

            return null;
        }
        #endregion

        private void lbxExam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDotThi = lbxExam.SelectedIndex;

            TenDT = (this.lbxExam.Items[SelectedDotThi] as ListBoxItem).Content.ToString();
            MaDT = new BusDotThi().getListDataBytenDotThi(TenDT)[0].MADT;

            for (int i = 0; i < canv.Children.Count; i++)
            {
                if (canv.Children[i].Uid == "WorkItem")
                {
                    UCWorkItem wi = canv.Children[i] as UCWorkItem;
                    ((TextBlock)wi.FindName("personNameAssigned")).Text = "Chưa được phân công";
                    setTooltip(wi);
                }
                else if (canv.Children[i].Uid == "ParallelActivity")
                {
                    UCParallel wi = canv.Children[i] as UCParallel;
                    wi.resetTooltip();
                }
                else if (canv.Children[i].Uid == "SequenceActivity")
                {
                    UCSequence wi = canv.Children[i] as UCSequence;
                    wi.resetTooltip();
                }
            }
        }

        public static void setTooltip(UCWorkItem wi)
        {
            string res = string.Empty;
            BusTienDo listbuscv = new BusTienDo();
            List<string> listNVCV = listbuscv.getListNVofCV(new BusCongViec().getMaCVByMoTaCV(wi.XName), int.Parse(m_ListTenDTVaMaDT[SelectedDotThi * 2 + 1]));
            if (listNVCV.Count != 0)
            {
                res += "Phân công cho:\r\n\t";
                for (int j = 0; j < listNVCV.Count; j += 2)
                {
                    res += listNVCV[j] + "\r\n\t";
                }
                if (res == string.Empty)
                    res = "Chưa được phân công";
                ((TextBlock)wi.FindName("personNameAssigned")).Text = res;
            }
            ((TextBlock)wi.FindName("personNameAssigned")).Text = (res == string.Empty) ? "Chưa được phân công" : res;
        }

        private void zoomSlider_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine(e.Delta);
            if (e.Delta < 0)
            {
                if (this.zoomSlider.Value < 5)
                {
                    this.zoomSlider.Value += .03;
                    this.zoomSlider.Value += .03;
                }
                return;
            }

            if (e.Delta > 0)
            {
                if (this.zoomSlider.Value > 0)
                {
                    this.zoomSlider.Value -= .03;
                    this.zoomSlider.Value -= .03;
                }

                return;
            }

        }

        private void zoomSlider_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
			this.zoomSlider.Focus();
        }
    }
}