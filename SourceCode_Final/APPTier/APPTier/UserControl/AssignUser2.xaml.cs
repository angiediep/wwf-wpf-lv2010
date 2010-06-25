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
using System.Collections.ObjectModel;
using ModelReader;
using BUSLayer;
using DataLayer.DTO;
using System.Drawing;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for AssignUser2.xaml
    /// </summary>
    public partial class AssignUser2 : UserControl
    {
        ObservableCollection<string> listNV = new ObservableCollection<string>();
        public static DateTime From;
        public static DateTime To;
        public ListBox dragSource = null;

        XOMLReader reader;
        double height = 0;
        double width = 0;

        public AssignUser2()
        {
            this.InitializeComponent();
            AssignUser.ASSIGNTYPE = 1;
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
                        if (AssignUser.ASSIGNTYPE == 1)
                        {
                            string tenCV = new BusCongViec().getTenCVByMoTaCV(act.Name); string res = string.Empty;
                            BusCongViec listbuscv = new BusCongViec();
                            List<string> listNVCV = listbuscv.getListNVofCV(tenCV);
                            if (listNVCV.Count != 0)
                            {
                                res += "Phân công cho:\r\n\t";
                                for (int j = 0; j < listNVCV.Count; j += 3)
                                {
                                    res += listNVCV[j] + " - ";
                                    res += "Từ " + listNVCV[j + 1] + " đến ";
                                    if (listNVCV[j + 2] == "1/1/9999")
                                        res += " về sau." + "\r\n\t";
                                    else
                                        res += listNVCV[j + 2] + "\r\n\t";
                                }
                                ((TextBlock)r.FindName("personNameAssigned")).Text = res;
                            }
                        }

                        r.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        r.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);

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
                    for (int j = 0; j < listNVCV.Count; j++)
                    {
                        res += listNVCV[j] + "\r\n";
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

            if (dpkFrom.Text == "")
                MessageBox.Show("Xin nhập ngày bắt đầu!");
            else if (DateTime.Parse(dpkFrom.Text) <= DateTime.Now)
                MessageBox.Show("Ngày bắt đầu phải sau ngày hôm nay, " + DateTime.Now.ToShortDateString() + ".");
            else
            {
                From = DateTime.Parse(dpkFrom.Text);
                string textTo = dpkTo.Text;
                if (textTo != "")
                    To = DateTime.Parse(dpkTo.Text);
                else
                    To = new DateTime(9999, 1, 1);

                if (data != null)
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
    }
}