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
using ModelReader;
using DataLayer.DTO;
using BUSLayer;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for UCWorkItem.xaml
    /// </summary>
    public partial class UCWorkItem : UserControl
    {
        //Canvas canv;
        private string m_Name;
        private SolidColorBrush m_Color;

        public SolidColorBrush Color
        {
            get { return m_Color; }
            set { m_Color = value; setColor(m_Color); }
        }

        private DtoTienDo m_TienDo;

        public DtoTienDo TienDo
        {
            get { return m_TienDo; }
            set { m_TienDo = value; }
        }

        public string XName
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public UCWorkItem(Activity act, double width, double height, int status, DtoTienDo td)
        {
            InitializeComponent();
            this.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 15, 29, 4));
            this.Height = height;
            this.Width = stackShowData.Width = width;
            stackShowData.SetValue(Canvas.TopProperty, (double)height / 3);
            m_Name = act.Name;
            this.Uid = "WorkItem";

            if (td != null)
            {
                m_TienDo = td;
                if ((m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001") && (m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001"))
                    status = getStatus();
            }

            //canv = new Canvas();
            //add the Canvas as sole child of Window
            //this.Content = canv;
            //canv.Margin = new Thickness(0, 0, 0, 0);
            //canv.Background = new SolidColorBrush(Colors.White);

            m_Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 244, 255, 195));
            setStatusAndColor(status);
            workItemName.Text = act.Name;
            System.Drawing.PointF startingPoint = new System.Drawing.PointF(0f, 0f);
            drawWorkItem(startingPoint);

            setPopUpInfo(td);
        }

        /// <summary>
        /// load lại thông tin của popup tương ứng với mỗi user
        /// </summary>
        /// <returns></returns>
        public void setPopUpInfo(DtoTienDo td)
        {
            if (td != null)
            {
                List<string> text = new BusTienDo().getTextToolTip(td);

                if (text.Count != 0)
                {
                    string left = string.Empty;
                    left = "Tên công việc: " + text[0] + "\r\n";
                    left += "Ngày bắt đầu quy định: " + (((text[4] == "1/1/0001") || (text[4] == "01/01/0001")) ? "Chưa có" : text[4]) + "\r\n";
                    left += "Ngày kết thúc quy định: " + (((text[5] == "1/1/0001") || (text[5] == "01/01/0001")) ? "Chưa có" : text[5]) + "\r\n";
                    left += "Khối lượng công việc: " + text[6] + "\r\n";

                    BusGhiChu gc = new BusGhiChu();
                    int magc = gc.getIDTreHan(td);
                    string gctext = "Không có";
                    if (magc != -1)
                        gctext = gc.getDataById(magc).GHICHU;
                    left += "Nguyên nhân sớm/trễ hạn: " + gctext;
                    tbxContentLeft.Text = left;

                    string right = string.Empty;
                    right = "Thời gian thực hiện: " + text[1] + "\r\n";
                    right += "Ngày bắt đầu thực tế: " + (((text[2] == "1/1/0001") || (text[2] == "01/01/0001")) ? "Chưa có" : text[2]) + "\r\n"; ;
                    right += "Ngày kết thúc thực tế: " + (((text[3] == "1/1/0001") || (text[3] == "01/01/0001")) ? "Chưa có" : text[3]) + "\r\n";
                    right += "Khối lượng công việc hoàn thành: " + text[7];
                    tbxContentRight.Text = right;
                }
            }
        }

        /// <summary>
        /// quy định hiện trạng và màu sắc
        /// </summary>
        /// <returns></returns>
        public void setStatusAndColor(int status)
        {
            switch (status)
            {
                case 1: // user chua lam: vang
                    m_Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 240, 255, 0));
                    break;
                case 2: // dang lam: xanh duong
                    m_Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 255, 186));
                    break;
                case 3: // canh bao: cam
                    m_Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    break;
                case 4: // lam roi: xanh la
                    m_Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 104, 233, 0));
                    break;
                case 5: // mau mac dinh
                    m_Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 244, 255, 195));
                    break;
            }
            setColor(m_Color);
        }

        public void setHiddenPopUp()
        {
            canv.MouseRightButtonUp -= canv_MouseLeftButtonDown;
        }

        public void setVisiblePopUp()
        {
            canv.MouseRightButtonUp += canv_MouseLeftButtonDown;
        }

        public int getStatus()
        {
            if ((m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001") || (m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001"))
                return 1; // chua thuc hien
            else if (((m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001") && (m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001")) && ((m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001") || (m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001")))
                return 2; //dang thuc hien
            #region RETURN 3
            else if (m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001" && m_TienDo.NGAYBATDAUQUYDINH >= DateTime.Now.Date)
                return 3;
            else if (m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001" && m_TienDo.NGAYKETTHUCQUYDINH.Date.Subtract(m_TienDo.NGAYBATDAUTHUCTE.Date) >= m_TienDo.NGAYKETTHUCQUYDINH.Date.Subtract(m_TienDo.NGAYBATDAUQUYDINH.Date))
                return 3;
            else if (m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001" && (float)(DateTime.Now.Date.Subtract(m_TienDo.NGAYBATDAUTHUCTE.Date)).Days / (float)(m_TienDo.NGAYKETTHUCQUYDINH.Date.Subtract(m_TienDo.NGAYBATDAUQUYDINH.Date)).Days > (float)(m_TienDo.KHOILUONGCVHT) / (float)(m_TienDo.TONGKHOILUONGCV))
                return 3;
            else if (m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() != "1/1/0001" && m_TienDo.KHOILUONGCVHT < m_TienDo.TONGKHOILUONGCV)
                return 3;
            else if (m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001" && m_TienDo.NGAYBATDAUQUYDINH >= DateTime.Now.Date)
                return 3;
            else if (m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001" && m_TienDo.NGAYKETTHUCQUYDINH.Date.Subtract(m_TienDo.NGAYBATDAUTHUCTE.Date) >= m_TienDo.NGAYKETTHUCQUYDINH.Date.Subtract(m_TienDo.NGAYBATDAUQUYDINH.Date))
                return 3;
            else if (m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001" && (float)(DateTime.Now.Date.Subtract(m_TienDo.NGAYBATDAUTHUCTE.Date)).Days / (float)(m_TienDo.NGAYKETTHUCQUYDINH.Date.Subtract(m_TienDo.NGAYBATDAUQUYDINH.Date)).Days > (float)(m_TienDo.KHOILUONGCVHT) / (float)(m_TienDo.TONGKHOILUONGCV))
                return 3;
            else if (m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() != "01/01/0001" && m_TienDo.KHOILUONGCVHT < m_TienDo.TONGKHOILUONGCV)
                return 3;


            #endregion
            else if ((m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001" && m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() != "1/1/0001") || (m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001" && m_TienDo.NGAYKETTHUCTHUCTE.ToShortDateString() != "01/01/0001"))
                return 4; //thuc hien xong
            return 1;
        }

        public void setColor(SolidColorBrush color)
        {
            canv.Background = color;
        }

        private System.Drawing.PointF drawWorkItem(PointF startingPoint)
        {
            startingPoint = new PointF(startingPoint.X + (float)this.Width / 2, startingPoint.Y + (float)this.Height - 2f);
            drawLine(startingPoint);

            return new PointF(startingPoint.X, startingPoint.Y + 10);
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

        private void canv_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            xx.IsOpen = true;
        }

        private void xx_MouseLeave(object sender, MouseEventArgs e)
        {
            xx.IsOpen = false;
        }

        public void setHiddenStartChangeFinishButton()
        {
            btnStart.Visibility = Visibility.Hidden;
            btnChange.Visibility = Visibility.Hidden;
            btnFinish.Visibility = Visibility.Hidden;
        }

        public void setVisisbleStartChangeFinishButton()
        {
            btnStart.Visibility = Visibility.Visible;
            btnChange.Visibility = Visibility.Visible;
            btnFinish.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Start Workflow
        /// </summary>
        /// <returns></returns>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int res = new BusTienDo().startWork(m_TienDo.MATD);
            while (res != 1)
            {
                res = new BusTienDo().startWork(m_TienDo.MATD);
            }
            if (res != -1)
            {
                m_TienDo = new BusTienDo().getDataById(m_TienDo.MATD);
                xx.IsOpen = false;
                this.btnStart.IsEnabled = false;
                this.btnFinish.IsEnabled = true;
                setPopUpInfo(m_TienDo);
                int status = -1;
                if ((m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001") && (m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001"))
                    status = getStatus();
                setStatusAndColor(status);
            }
            else
                MessageBox.Show("Có lỗi xảy ra trong quá trình bắt đầu.");
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            UpdateWorkTime UpdateWI = new UpdateWorkTime(m_TienDo.MATD);
            UpdateWI.ShowDialog();
            xx.IsOpen = false;
            if (UpdateWI.Res != -1)
            {
                m_TienDo = new BusTienDo().getDataById(m_TienDo.MATD);
                setPopUpInfo(m_TienDo);
            }

        }


        /// <summary>
        /// kết thúc Workflow
        /// </summary>
        /// <returns></returns>
        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            UploadPdf up = new UploadPdf(m_TienDo.MATD);
            up.ShowDialog();
            //Hang nay se del khi mo lai chuc nang upload///
            //new BusTienDo().finishWork(m_TienDo.MATD);
            //////////////////////////////////
            xx.IsOpen = false;

            if ((up.Res == 1))
            {
                int userid = 0;
                BusTienDo bus = new BusTienDo();
                userid = bus.getMaNVByMaDTAndMaCV(m_TienDo.MADT, m_TienDo.MACV);// luc dau m_Tiendo.MACV + 1 --> why
                int maTD = 0;
                maTD = bus.getMaTDByMaDTAndMaCV(m_TienDo.MADT, m_TienDo.MACV);
                DtoThongBao tb = new DtoThongBao();
                tb.MATD = maTD;
                tb.NOIDUNG = "";
                tb.TRANGTHAI = 1;
                new BusThongBao().insertData(tb);
                this.btnFinish.IsEnabled = false;
                m_TienDo = new BusTienDo().getDataById(m_TienDo.MATD);
                int status = -1;
                setPopUpInfo(m_TienDo);

                if ((m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001") && (m_TienDo.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001"))
                    status = getStatus();
                setStatusAndColor(status);
            }
        }

        public void setHiddenTooltip()
        {
            yy.Visibility = Visibility.Hidden;
        }

        public void setDisableBatDauButton()
        {
            btnStart.IsEnabled = false;
        }

        public void setEnableBatDauButton()
        {
            btnStart.IsEnabled = true;
        }

        public void setDisableFinishButton()
        {
            btnFinish.IsEnabled = false;
        }

        public void setEnableFinishButton()
        {
            btnFinish.IsEnabled = true;
        }
    }
}