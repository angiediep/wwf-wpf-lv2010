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
using DataLayer.DTO;
using BUSLayer;
using QuanLyThi;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for UserWfView.xaml
    /// </summary>
    public partial class UserWfView : UserControl
    {
        //ObservableCollection<string> listNV = new ObservableCollection<string>();
        XOMLReader reader;
        double height = 0;
        double width = 0;
        public static List<string> ListTenCVOfNV = new List<string>();
        public static int MaDT;

        public UserWfView()
        {
            this.InitializeComponent();
            reader = new XOMLReader("QuyTrinhThiWorkflow.xoml");
            reader.parseXOML();

            canv.Margin = new Thickness(0, 0, 0, 0);

            ////////////////////////////////
            BusDotThi x = new BusDotThi();
            List<string> list = x.getDotThiTheoNV(Constants.strUserName);
            foreach (string str in list)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = str;
                lbxExamList.Items.Add(item);
            }
            ////////////////////////////////

            BusTienDo td = new BusTienDo();
            if (lbxExamList.Items.Count != 0)
            {
                lbxExamList.SelectedIndex = 0;
                string tenDT = (this.lbxExamList.Items[0] as ListBoxItem).Content.ToString();
                ListTenCVOfNV = td.getListTenCVOfNVAndDotThi(Constants.strUserName, tenDT);
                MaDT = new BusDotThi().getMaDTByTenDT(tenDT);

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


        /// <summary>
        /// vẽ Workflow tương ứng với mỗi User
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
                        string name = Constants.strRealName;
                        DtoTienDo td = new DtoTienDo();
                        DtoPhanCong pc = new DtoPhanCong();
                        UCWorkItem r = null;
                        if (name != "")
                        {
                            int flag = 0;
                            int flag1 = 0;

                            int countx = UserWfView.ListTenCVOfNV.Count;
                            for (int j = 0; j < countx; j++)
                            {
                                if (UserWfView.ListTenCVOfNV[j] == act.Name)
                                {
                                    td = null;
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

                                if ((td.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001") && (td.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001"))
                                    r.setDisableBatDauButton();
                                else
                                    r.setEnableBatDauButton();
                                if ((td.NGAYKETTHUCTHUCTE.ToShortDateString() != "1/1/0001" && td.NGAYKETTHUCTHUCTE.ToShortDateString() != "01/01/0001") || (td.NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001" || td.NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001"))
                                    r.setDisableFinishButton();
                                else
                                    r.setEnableFinishButton();
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
                                        if (listNVCV[j + 2] == "1/1/9999")
                                            res += " về sau." + "\r\n\t";
                                        else
                                            res += listNVCV[j + 2] + "\r\n\t";
                                    }
                                    ((TextBlock)r.FindName("personNameAssigned")).Text = res;
                                }
                            }
                            else if (AssignUser.ASSIGNTYPE == 2)
                            {
                                r.ToolTip = "Click phải chuột để bắt đầu/kết thúc công việc.";
                                string res = string.Empty;
                                BusTienDo listbusTD = new BusTienDo();

                                List<string> listNVCV = listbusTD.getListNVofCV(new BusCongViec().getMaCVByTenCV(r.XName), AssignUser.MaDT);
                                if (listNVCV.Count != 0)
                                {
                                    res += "Phân công cho:\r\n\t";
                                    for (int j = 0; j < listNVCV.Count; j++)
                                    {
                                        res += listNVCV[j] + "\r\n";
                                    }
                                    if (res == string.Empty)
                                        res = "Chưa được phân công";
                                    ((TextBlock)r.FindName("personNameAssigned")).Text = res;
                                }
                            }
                        }

                        r.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        r.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        canv.Children.Add(r);
                        if (i < count - 1)
                            nextStartPoint = new PointF(nextStartPoint.X + (float)list[i].Width / 2 - (float)list[i + 1].Width / 2, nextStartPoint.Y + 10f + (float)r.Height);
                        break;
                }
            }
        }

        private void lbxExamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tenDT = (this.lbxExamList.Items[lbxExamList.SelectedIndex] as ListBoxItem).Content.ToString();
            MaDT = new BusDotThi().getMaDTByTenDT(tenDT);
            ListTenCVOfNV = new BusTienDo().getListTenCVOfNVAndDotThi(Constants.strUserName, tenDT);

            for (int i = 0; i < canv.Children.Count; i++)
            {
                if (canv.Children[i].Uid == "WorkItem")
                {
                    UCWorkItem wi = canv.Children[i] as UCWorkItem;
                    ((TextBlock)wi.FindName("personNameAssigned")).Text = "Click phải chuột để bắt đầu/kết thúc công việc.";

                    setWorkItemOfUser(wi);
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


        /// <summary>
        /// set màu và thuộc tính của workitem tương ứng với mỗi User
        /// </summary>
        /// <returns></returns>
        public static void setWorkItemOfUser(UCWorkItem wi)
        {
            int flag = 0;
            for (int i = 0; i < ListTenCVOfNV.Count; i++)
            {
                if (wi.XName == ListTenCVOfNV[i])
                {
                    flag = 1;
                    break;
                }
            }

            DtoTienDo td = new DtoTienDo();
            if (flag == 1)
            {
                td = new BusTienDo().getTDOfNVByMaCVAndMaDT(new BusNhanVienThuaHanh().getListDataBytenNV(Constants.strRealName)[0].MANV, new BusCongViec().getMaCVByMoTaCV(wi.XName), MaDT);
                wi.TienDo = td;
                int status = wi.getStatus();
                wi.setStatusAndColor(status);
                wi.setVisiblePopUp();
                wi.setVisisbleStartChangeFinishButton();

                if (td.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001" && td.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001")
                    wi.setDisableBatDauButton();
                else
                    wi.setEnableBatDauButton();
                if ((td.NGAYKETTHUCTHUCTE.ToShortDateString() != "1/1/0001" && td.NGAYKETTHUCTHUCTE.ToShortDateString() != "01/01/0001") || (td.NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001" || td.NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001"))
                    wi.setDisableFinishButton();
                else
                    wi.setEnableFinishButton();
                wi.setPopUpInfo(td);
            }
            else
            {
                wi.Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 244, 255, 195));
                wi.setHiddenStartChangeFinishButton();
                wi.setHiddenPopUp();
            }
            int statusOfWorkItem = wi.getStatus();
            string tooltipForNotNVCV = "Click phải chuột để bắt đầu/kết thúc công việc.";
            if (statusOfWorkItem == 4)
                tooltipForNotNVCV = "Công việc đã hoàn tất.";
            else if (statusOfWorkItem == 1)
                tooltipForNotNVCV = "Công việc chưa xong.";
            else if (statusOfWorkItem == 2)
                tooltipForNotNVCV = "Công việc đang diễn ra.";
            if (td.MANV != 0)
                tooltipForNotNVCV += "\r\nClick phải chuột để bắt đầu/kết thúc công việc.";
            ((TextBlock)wi.FindName("personNameAssigned")).Text = tooltipForNotNVCV;
        }



        /// <summary>
        /// Zoomin-out Workflow view
        /// </summary>
        /// <returns></returns>
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