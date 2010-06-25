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
            foreach (DtoNhanVienThuaHanh nv in list)
            {
                listNV.Add(nv.TENNV);
            }
            lblUser.ItemsSource = listNV;
            ////////////////////////////////

            ////////////////////////////////
            BusDotThi xx = new BusDotThi();
            List<DtoDotThi> listx= xx.getDataList();
            List<string> str = new List<string>();
            foreach (DtoDotThi dotthi in listx)
            {
                str.Add(dotthi.TENDOTTHI);
                m_ListTenDTVaMaDT.Add(dotthi.TENDOTTHI);
                m_ListTenDTVaMaDT.Add(dotthi.MADT.ToString());
            }
            lbxExam.ItemsSource = str;
            ////////////////////////////////

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

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        private void btnFinish_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

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
                        
                        List<string> listNVCV = listbusTD.getListNVofCV(new BusCongViec().getMaCVByTenCV(r.XName), int.Parse(m_ListTenDTVaMaDT[1]));
                        if (listNVCV.Count != 0)
                        {
                            res += "Phân công cho:\r\n\t";
                            for (int j = 0; j < listNVCV.Count; j ++)
                            {
                                res += listNVCV[j] + "\r\n";
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

        void r_Drop(object sender, DragEventArgs e)
        {
            UCWorkItem parent = (UCWorkItem)sender;
            object data = e.Data.GetData(typeof(string));

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
                    pc.insertData(dtoPC);

                BusCongViec listbuscv = new BusCongViec();
                List<string> listNVCV = listbuscv.getListNVofCV(tenCV);
                if (listNVCV.Count != 0)
                {
                    res += "Phân công cho:\r\n\t";
                    for (int i = 0; i < listNVCV.Count; i += 3)
                    {
                        res += listNVCV[i] + " - ";
                        res += "Từ " + listNVCV[i + 1] + " đến ";
                        if (listNVCV[i + 2] == "1/1/9999")
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
                x.insertData(td);

                List<string> listNVCV = x.getListNVofCV(new BusCongViec().getMaCVByMoTaCV(parent.XName), td.MADT);
                if (listNVCV.Count != 0)
                {
                    res += "Phân công cho:\r\n\t";
                    for (int j = 0; j < listNVCV.Count; j += 2)
                    {
                        res += listNVCV[j] + "\r\n\t";
                    }
                    if (res == string.Empty)
                        res = "Chưa được phân công";
                }
            }

            //((IList)AssignUser.dragSource.ItemsSource).Remove(data);
            //parent.Color = System.Windows.Media.Brushes.Green;
            if (res == string.Empty)
                res = "Chưa được phân công";
            ((TextBlock)parent.FindName("personNameAssigned")).Text = res;
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

            TenDT = this.lbxExam.SelectedValue.ToString();
            MaDT = new BusDotThi().getListDataBytenDotThi(TenDT)[0].MADT;

            for (int i = 0; i < canv.Children.Count; i++)
            {
                if (canv.Children[i].Uid == "WorkItem")
                {
                    UCWorkItem wi = canv.Children[i] as UCWorkItem;
                    ((TextBlock)wi.FindName("personNameAssigned")).Text = "Chưa được phân công";
                    setTooltip(wi);
                }
                else if(canv.Children[i].Uid == "ParallelActivity")
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
                for (int j = 0; j < listNVCV.Count; j+=2)
                {
                    res += listNVCV[j] + "\r\n\t";
                }
                if (res == string.Empty)
                    res = "Chưa được phân công";
                ((TextBlock)wi.FindName("personNameAssigned")).Text = res;
            }
            ((TextBlock)wi.FindName("personNameAssigned")).Text = (res == string.Empty) ? "Chưa được phân công" : res;
        }
    }
}