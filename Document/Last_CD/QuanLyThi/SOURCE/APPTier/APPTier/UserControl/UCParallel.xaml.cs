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


        /// <summary>
        /// vẽ workflow view
        /// </summary>
        /// <returns></returns>
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
                        string name = Constants.strRealName;
                        DtoTienDo td = new DtoTienDo();
                        DtoPhanCong pc = new DtoPhanCong();
                        UCWorkItem r = null;
                        if (name != "")
                        {
                            int flag = 0;
                            int flag1 = 1;
                            int countx = UserWfView.ListTenCVOfNV.Count;
                            for (int j = 0; j < countx; j++)
                            {
                                if (UserWfView.ListTenCVOfNV[j] == act.Name)
                                {
                                    int manv = new BusNhanVienThuaHanh().getListDataBytenNV(Constants.strRealName)[0].MANV;
                                    td = new BusTienDo().getTDOfNVByMaCVAndMaDT(manv, new BusCongViec().getMaCVByMoTaCV(act.Name), UserWfView.MaDT);

                                    flag = 1;
                                    break;
                                }
                            }
                            if (td.MADT == 0)
                            {
                                flag1 = 1;
                                td = new BusTienDo().getTDByMaCVAndMaDT(new BusCongViec().getMaCVByMoTaCV(act.Name), UserWfView.MaDT);
                            }
                            r = new UCWorkItem(act, act.Width, act.Height, act.getstatus(), td);
                            if (flag1 == 1)
                                r.setStatusAndColor(5);
                            ((TextBlock)r.FindName("personNameAssigned")).Text = "Click phải chuột để bắt đầu/kết thúc công việc.";
                            if (flag == 1)
                            {
                                r.setVisisbleStartChangeFinishButton();
                                if (td.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001" && td.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001")
                                    r.setDisableBatDauButton();
                                else
                                    r.setEnableBatDauButton();
                                if ((td.NGAYKETTHUCTHUCTE.ToShortDateString() != "1/1/0001" && td.NGAYKETTHUCTHUCTE.ToShortDateString() != "01/01/0001") || (td.NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001" || td.NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001"))
                                    r.setDisableFinishButton();
                                else
                                    r.setEnableBatDauButton();
                            }
                            else
                            {
                                //   r.setHiddenTooltip();
                                r.setHiddenPopUp();
                                //r.setHiddenStartChangeFinishButton();
                            }
                            int statusOfWorkItem = r.getStatus();
                            string tooltipForNotNVCV = "Click phải chuột để bắt đầu/kết thúc công việc.";
                            if (statusOfWorkItem == 4)
                                tooltipForNotNVCV = "Công việc đã hoàn tất.";
                            else if (statusOfWorkItem == 1)
                                tooltipForNotNVCV = "Công việc chưa xong.";
                            else if (statusOfWorkItem == 2)
                                tooltipForNotNVCV = "Công việc đang diễn ra.";
                            if (flag1 != 1)
                                tooltipForNotNVCV += "\r\nClick phải chuột để bắt đầu/kết thúc công việc.";
                            ((TextBlock)r.FindName("personNameAssigned")).Text = tooltipForNotNVCV;
                        }
                        else
                        {
                            r = new UCWorkItem(act, act.Width, act.Height, act.getstatus(), null);
                            r.setHiddenPopUp();
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
                                        if ((listNVCV[j + 2] == "1/1/9999") || ((listNVCV[j + 2] == "01/01/9999")))
                                            res += " về sau." + "\r\n\t";
                                        else
                                            res += listNVCV[j + 2] + "\r\n\t";
                                    }
                                    ((TextBlock)r.FindName("personNameAssigned")).Text = res;
                                }
                            }
                            else if (AssignUser.ASSIGNTYPE == 2)
                            {
                                string res = string.Empty;
                                BusTienDo listbusTD = new BusTienDo();

                                List<string> listNVCV = listbusTD.getListNVofCV(new BusCongViec().getMaCVByTenCV(r.XName), AssignUser.MaDT);
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
                            }
                        }

                        r.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        r.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        r.AllowDrop = true;
                        r.Drop += new DragEventHandler(r_Drop);
                        canv.Children.Add(r);
                        if (i < count - 1)
                            nextStartPoint = new PointF(nextStartPoint.X + (float)list[i].Width / 2 - (float)list[i + 1].Width / 2, nextStartPoint.Y + 10f + (float)r.Height);
                        break;
                }
                i++;
            }
        }


        /// <summary>
        /// xử lý drag-drop và lưu vào database
        /// </summary>
        /// <returns></returns>
        void r_Drop(object sender, DragEventArgs e)
        {
            if (AssignUser.MaDT != -1)
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
                            if ((listNVCV[i + 2] == "1/1/9999") || ((listNVCV[i + 2] == "01/01/9999")))

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
                        {
                            res += listNVCV[j] + "\r\n\t";
                        }
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


        /// <summary>
        /// vẽ ParallelActivity
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// vẽ lại workitem đối với user
        /// </summary>
        /// <returns></returns>
        public void setWorkItemOfUser()
        {
            for (int i = 0; i < canv.Children.Count; i++)
            {
                if (canv.Children[i].Uid == "WorkItem")
                {
                    UCWorkItem wi = canv.Children[i] as UCWorkItem;
                    ((TextBlock)wi.FindName("personNameAssigned")).Text = "Click phải chuột để bắt đầu/kết thúc công việc.";

                    UserWfView.setWorkItemOfUser(wi);
                }
                else if (canv.Children[i].Uid == "ParallelActivity")
                {
                    UCParallel wi = canv.Children[i] as UCParallel;
                    wi.setWorkItemOfUser();
                }
                else if (canv.Children[i].Uid == "SequenceActivity")
                {
                    UCSequence wi = canv.Children[i] as UCSequence;
                    wi.setWorkItemOfUser();
                }
            }
        }
    }
}