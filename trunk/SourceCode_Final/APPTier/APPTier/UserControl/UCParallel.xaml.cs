using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Drawing;
using ModelLayouter;
using ModelReader;
using System.Collections;
using BUSLayer;
using DataLayer.DTO;
using QuanLyThi;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for UCParallel.xaml
    /// </summary>
    public partial class UCParallel : UserControl
    {
        Canvas canv;
        List<PointF> m_ListNextPoint = new List<PointF>();
        public UCParallel(Activity act, double width, double height)
        {
            InitializeComponent();
            this.Height = height;
            this.Width = width;
            this.Uid = "ParallelActivity";

            canv = new Canvas();
            //add the Canvas as sole child of Window
            this.Content = canv;
            canv.Margin = new Thickness(0, 0, 0, 0);
            canv.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 67, 67, 67));

            System.Drawing.PointF startingPoint = new System.Drawing.PointF(0f, 0f);
            drawParallel(startingPoint, act);
            draw(act.ListActivity);
        }

        private void draw(List<Activity> list)
        {
            int count = list.Count;
            int i = 0;
            foreach (Activity act in list)
            {
                PointF nextStartPoint = m_ListNextPoint[i];
                switch (act.Type)
                {
                    case "ParallelActivity":
                        UCParallel p = new UCParallel(act, act.Width, act.Height);
                        p.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        p.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        canv.Children.Add(p);
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
                    //case "WorkItem":
                    //    string name = Constants.strRealName;
                    //    DtoPhanCong pc = null;
                    //    if (name != "")
                    //        pc = new BusPhanCong().getDataByIdAndTenNV(new BusCongViec().getListDataBytenCV(act.Name)[0].MACV, new BusNhanVienThuaHanh().getListDataBytenNV(Constants.strRealName)[0].MANV);

                    //    UCWorkItem r = new UCWorkItem(act, act.Width, act.Height, act.getstatus(), pc);
                    //    string res = string.Empty;
                    //    if (name == "")
                    //    {
                    //        r.setHiddenPopUp();
                    //        try
                    //        {
                    //            AssignUser a1 = this.Parent as AssignUser;

                    //            BusCongViec listbuscv = new BusCongViec();
                    //            List<string> listNVCV = listbuscv.getListNVofCV(r.XName);
                    //            if (listNVCV.Count != 0)
                    //            {
                    //                res += "Phân công cho:\r\n\t";
                    //                for (int j = 0; j < listNVCV.Count; j += 3)
                    //                {
                    //                    res += listNVCV[j] + " - ";
                    //                    res += "Từ " + listNVCV[j + 1] + " đến ";
                    //                    if (listNVCV[j + 2] == "1/1/9999")
                    //                        res += " về sau." + "\r\n\t";
                    //                    else
                    //                        res += listNVCV[j + 2] + "\r\n\t";
                    //                }
                    //            }
                    //        }
                    //        catch
                    //        {
                    //            BusTienDo listbusTD = new BusTienDo();
                    //            List<string> listNVCV = listbusTD.getListNVofCV(new BusCongViec().getMaCVByTenCV(r.XName));   // truyen dot thi vo nua moi dung !!!
                    //            if (listNVCV.Count != 0)
                    //            {
                    //                res += "Phân công cho:\r\n\t";
                    //                for (int j = 0; j < listNVCV.Count; j++)
                    //                {
                    //                    res += listNVCV[j] + "\r\n";
                    //                }
                    //                if (res == string.Empty)
                    //                    res = "Chưa được phân công";
                    //            }
                    //        }
                    //    }

                    //    r.AllowDrop = true;
                    //    r.Drop += new DragEventHandler(r_Drop);
                    //    if (res == string.Empty)
                    //        res = "Chưa được phân công";
                    //    ((TextBlock)r.FindName("personNameAssigned")).Text = res;

                    //    r.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                    //    r.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                    //    canv.Children.Add(r);
                    //    break;
                }
                i++;
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
                parent.Color = System.Windows.Media.Brushes.Green;
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

        private void drawParallel(PointF startingPoint, Activity act)
        {
            m_ListNextPoint.Add(new PointF(startingPoint.X - (float)act.ListActivity[0].Width / 2 - 1f, startingPoint.Y + 10f));

            double w = act.Width;

            LayoutShape shape = new LayoutRectangle(startingPoint, w, act.Height, act.ListActivity.Count - 2, 0);
            System.Windows.Shapes.Rectangle layoutRect = new System.Windows.Shapes.Rectangle();
            layoutRect.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 15, 29, 4));
            layoutRect.StrokeThickness = 2;
            layoutRect.Width = shape.getWidth();
            layoutRect.Height = shape.getHeight();
            layoutRect.SetValue(Canvas.LeftProperty, (double)shape.StartPointF.X);
            layoutRect.SetValue(Canvas.TopProperty, (double)shape.StartPointF.Y);
            List<LayoutLine> lineList = shape.getLineList();
            for (int i = 0; i < lineList.Count; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 15, 29, 4));
                myLine.X1 = lineList[i].StartPointF.X;
                myLine.Y1 = lineList[i].StartPointF.Y;
                myLine.X2 = lineList[i].EndPointF.X;
                myLine.Y2 = lineList[i].EndPointF.Y;
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;
                myLine.StrokeThickness = 2;
                canv.Children.Add(myLine);
                m_ListNextPoint.Add(new PointF(lineList[i].StartPointF.X - (float)act.ListActivity[i + 1].Width / 2 - 2f, lineList[i].StartPointF.Y + 10f));
            }
            canv.Children.Add(layoutRect);
            m_ListNextPoint.Add(new PointF(startingPoint.X + (float)this.Width - (float)act.ListActivity[act.ListActivity.Count - 1].Width / 2 - 3f, startingPoint.Y + 10f));

            double halfWidth = shape.getWidth() / 2;
            PointF nextPoint = new System.Drawing.PointF((float)(shape.StartPointF.X + halfWidth), (float)(shape.StartPointF.Y + shape.getHeight()));
            drawLine(nextPoint);
        }

        private void drawLine(PointF startingPoint)
        {
            Line myLine = new Line();
            myLine.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 15, 29, 4));
            myLine.X1 = startingPoint.X;
            myLine.Y1 = startingPoint.Y;
            myLine.X2 = startingPoint.X;
            myLine.Y2 = startingPoint.Y + 10;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            canv.Children.Add(myLine);
        }

        public void resetTooltip()
        {
            for (int i = 0; i < canv.Children.Count; i++)
            {
                if (canv.Children[i].Uid == "WorkItem")
                {
                    UCWorkItem wi = canv.Children[i] as UCWorkItem;
                    ((TextBlock)wi.FindName("personNameAssigned")).Text = "Chưa được phân công";
                    AssignUser.setTooltip(wi);
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
    }
}