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
using DataLayer.DTO;
using BUSLayer;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for GanttViewTienDo.xaml
    /// </summary>
    public partial class GanttViewTienDo : UserControl
    {
        private List<string> m_ListFirstRowLabel;
        private List<DtoTienDo> m_ListTD;
        private DateTime m_StartDate;
        private DateTime m_EndDate;

        public List<DtoTienDo> ListDotThi
        {
            get { return m_ListTD; }
            set { m_ListTD = value; }
        }

        public List<string> ListFirstRowLabel
        {
            get { return m_ListFirstRowLabel; }
            set { m_ListFirstRowLabel = value; }
        }

        int numberOfDayStartEquEnd;
        public GanttViewTienDo(List<DtoTienDo> listDT)
        {
            InitializeComponent();
            numberOfDayStartEquEnd = -1;
            m_ListFirstRowLabel = new List<string>();
            m_ListTD = listDT;

            getStartAndEndDate();
            int count = m_EndDate.Subtract(m_StartDate).Days;
            for (int i = 0; i < count + numberOfDayStartEquEnd; i++)
                m_ListFirstRowLabel.Add(m_StartDate.Add(new TimeSpan(i, 0, 0, 0)).ToShortDateString());

            draw();
        }

        /// <summary>
        /// tính ngày bắt đầu và ngày kết thúc của GanttView
        /// </summary>
        /// <returns></returns>
        private void getStartAndEndDate()
        {
            List<DateTime> list1 = new List<DateTime>();
            List<DateTime> list2 = new List<DateTime>();

            foreach (DtoTienDo td in m_ListTD)
            {
                DateTime bdtt = td.NGAYBATDAUTHUCTE;
                DateTime bdqd = td.NGAYBATDAUQUYDINH;
                DateTime kttt = td.NGAYKETTHUCTHUCTE;
                DateTime ktqd = td.NGAYKETTHUCQUYDINH;
                if ((bdtt == bdqd) || (bdtt == kttt) || (bdtt == ktqd) || (bdqd == kttt) || (bdqd == ktqd) || (kttt == ktqd) || ((bdtt == bdqd) && (bdqd == kttt)) || ((bdtt == bdqd) && (bdqd == ktqd)) || ((bdqd == kttt) && (kttt == ktqd)) || ((bdqd == bdtt) && (bdtt == kttt) && (kttt == ktqd)))
                    numberOfDayStartEquEnd++;

                list1.Add(bdqd);
                list1.Add(bdtt);
                list2.Add(ktqd);
                list2.Add(kttt);
            }
            list1.Sort();
            list2.Sort();

            if ((list1[0].ToShortDateString() == "01/01/0001") || (list1[0].ToShortDateString() == "1/1/0001"))
            {
                int idx = 0;
                for (int i = 0; i < list1.Count; i++)
                {
                    if ((list1[i].ToShortDateString() != "01/01/0001") && (list1[i].ToShortDateString() != "1/1/0001"))
                    {
                        idx = i;
                        break;
                    }
                }
                m_StartDate = list1[idx];
            }
            else
                m_StartDate = list1[0];
            m_EndDate = list2[list2.Count - 1];
        }


        /// <summary>
        /// dùng datagrid vẽ GanttView 
        /// </summary>
        /// <returns></returns>
        public void draw()
        {
            ColumnDefinition e = new ColumnDefinition();
            e.Width = new GridLength(100, GridUnitType.Pixel);
            this.MyGanttChart.ColumnDefinitions.Add(e);

            for (int i = 1; i < m_ListFirstRowLabel.Count + 1; i++)
            {
                ColumnDefinition ee = new ColumnDefinition();
                e.Width = new GridLength(10, GridUnitType.Pixel);
                this.MyGanttChart.ColumnDefinitions.Add(ee);
            }
            this.MyGanttChart.Width = 10 * (m_ListFirstRowLabel.Count + 1 - 1) + 100;

            for (int i = 0; i <= m_ListTD.Count + 1; i++)
            {
                RowDefinition w = new RowDefinition();
                w.Height = new GridLength(30, GridUnitType.Pixel);
                this.MyGanttChart.RowDefinitions.Add(w);
            }
            this.MyGanttChart.Height = 30 * (m_ListTD.Count + 1);

            Border bd1 = setCellStyle(0, 0, 1, m_ListFirstRowLabel.Count + 1);
            bd1.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 128, 0, 0));
            for (int i = 0; i < m_ListFirstRowLabel.Count; i++)
            {
                if (m_ListFirstRowLabel[i] == DateTime.Now.ToShortDateString())
                {
                    setColumnName(i + 1);
                    Border bbdx = setCellStyle(1, i + 1, m_ListTD.Count + 1, 1);
                    bbdx.Background = new SolidColorBrush(Colors.Gray);
                }
            }
            for (int i = 1; i < m_ListTD.Count + 1; i++)
            {
                DotThiBar dtbar = new DotThiBar(m_ListTD[i - 1], m_StartDate);

                int n = dtbar.Startindex;
                int h = dtbar.EndIndex;

                Border bdd = setCellStyle(i, n + 1, 1, h - n + 1);
                string s1 = (m_ListTD[i - 1].NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001" || m_ListTD[i - 1].NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001") ? "Chưa bắt đầu." : m_ListTD[i - 1].NGAYBATDAUTHUCTE.ToShortDateString();
                string s2 = (m_ListTD[i - 1].NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001" || m_ListTD[i - 1].NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001") ? "Chưa kết thúc." : m_ListTD[i - 1].NGAYKETTHUCTHUCTE.ToShortDateString();
                string tooltip = new BusCongViec().getMotaCVByMaCV(m_ListTD[i - 1].MACV) + "\r\nNgày bắt đầu: " + s1 + "\r\nNgày kết thúc: " + s2;
                bdd.ToolTip = tooltip;
                getColor(ref bdd, m_ListTD[i - 1]);

                for (int u = n + 1; u <= h + 1; u++)
                {
                    if ((u == n + 1) || (u == h + 1))
                    {
                        // LOAD ten COT
                        setColumnName(u);
                    }
                }
            }

            // LOAD TEN DOT THI
            this.MyGanttChart.ColumnDefinitions[0].Width = GridLength.Auto;
            for (int i = 0; i < m_ListTD.Count; i++)
            {
                TextBlock t = new TextBlock();
                BUSLayer.BusCongViec temp = new BUSLayer.BusCongViec();
                t.Text = temp.getMoTaByTenCV(temp.getTenCVByMaCV(m_ListTD[i].MACV));
                t.SetValue(Grid.RowProperty, (int)(i + 1));
                t.SetValue(Grid.ColumnProperty, (int)0);
                t.Uid = m_ListTD[i].MADT.ToString();
                t.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 189, 73, 73));
                t.Margin = new Thickness(10, 5, 10, 5);
                this.MyGanttChart.Children.Add(t);
            }

            for (int j = 0; j <= m_ListTD.Count; j++)
            {
                setCellStyle(j, 0, 1, 1);
                setCellStyle(j, 1, 1, m_ListFirstRowLabel.Count - 1);
            }

            Border bddd = setCellStyle(0, 0, 1, 1);
            StackPanel sp = new StackPanel();
            TextBlock tb = new TextBlock();
            tb.Text = "Công Việc";
            tb.Foreground = new SolidColorBrush(Colors.White);
            tb.TextAlignment = TextAlignment.Center;
            tb.FontWeight = FontWeights.Bold;
            tb.Margin = new Thickness(0, 5, 0, 5);
            sp.Children.Add(tb);
            this.MyGanttChart.Children.Add(sp);
            this.Width = MyGanttChart.Width;
            this.Height = MyGanttChart.Height;
        }

        /// <summary>
        /// đặt tên cột cho GanttView
        /// </summary>
        /// <returns></returns>
        private void setColumnName(int u)
        {
            Canvas s = new Canvas();
            s.SetValue(Grid.RowProperty, (int)0);
            s.SetValue(Grid.ColumnProperty, (int)u);
            s.Width = 100;
            s.Height = 15;
            this.MyGanttChart.ColumnDefinitions[u].Width = new GridLength(100, GridUnitType.Pixel);
            this.MyGanttChart.Width += 100 - 10;

            TextBlock t = new TextBlock();
            t.TextAlignment = TextAlignment.Center;
            t.Text = m_ListFirstRowLabel[u - 1];
            t.Width = s.Width;
            t.Foreground = new SolidColorBrush(Colors.White);
            t.FontWeight = FontWeights.Bold;
            s.Children.Add(t);
            this.MyGanttChart.Children.Add(s);
            Border bd = setCellStyle(0, u, 1, 1);
            bd.Width = s.Width;
        }

        /// <summary>
        /// set thuộc tính cho từng cell trong datagrid
        /// </summary>
        /// <returns></returns>
        private Border setCellStyle(int row, int col, int rowspan, int colSpan)
        {
            Border bd = new Border();
            bd.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 161, 66, 66));
            bd.BorderThickness = new Thickness(1);
            bd.SetValue(Grid.RowProperty, (int)row);
            bd.SetValue(Grid.ColumnProperty, (int)col);
            if (colSpan != 0)
                bd.SetValue(Grid.ColumnSpanProperty, (int)colSpan);
            bd.SetValue(Grid.RowSpanProperty, (int)rowspan);
            this.MyGanttChart.Children.Add(bd);

            return bd;
        }


        /// <summary>
        /// tính hiện trạng để quy định màu cho GanttView
        /// </summary>
        /// <returns></returns>
        private void getColor(ref Border bd, DtoTienDo dtoDotThi)
        {

            if (dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001" && dtoDotThi.NGAYBATDAUQUYDINH <= DateTime.Now.Date)
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                bd.ToolTip = "Công việc đã đến ngày hoặc quá ngày nhưng vẫn chưa được thực hiện\n" + bd.ToolTip;
                return;
            }
            else if (dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001" && dtoDotThi.NGAYKETTHUCQUYDINH.Date.Subtract(dtoDotThi.NGAYBATDAUTHUCTE.Date) > dtoDotThi.NGAYKETTHUCQUYDINH.Date.Subtract(dtoDotThi.NGAYBATDAUQUYDINH.Date))
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                bd.ToolTip = "Công việc đã đến ngày hoặc quá ngày nhưng vẫn chưa được kết thúc\n" + bd.ToolTip;
                return;
            }
            else if (dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001"  &&dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001" && (float)(DateTime.Now.Date.Subtract(dtoDotThi.NGAYBATDAUTHUCTE.Date)).Days / (float)(dtoDotThi.NGAYKETTHUCQUYDINH.Date.Subtract(dtoDotThi.NGAYBATDAUQUYDINH.Date)).Days > (float)(dtoDotThi.KHOILUONGCVHT) / (float)(dtoDotThi.TONGKHOILUONGCV))
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                bd.ToolTip = "Công việc đang thực hiện chậm hơn bình thường\n" + bd.ToolTip;
                return;
            }
            else if (dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() != "1/1/0001" && dtoDotThi.KHOILUONGCVHT < dtoDotThi.TONGKHOILUONGCV)
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                bd.ToolTip = "Công việc đã kết thúc nhưng vẫn chưa làm hết khối lượng công việc\n" + bd.ToolTip;
                return;
            }
            else if (dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001" && dtoDotThi.NGAYBATDAUQUYDINH <= DateTime.Now.Date)
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                bd.ToolTip = "Công việc đã đến ngày hoặc quá ngày nhưng vẫn chưa được thực hiện\n" + bd.ToolTip;
                return;
            }
            else if (dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001" && dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001" && dtoDotThi.NGAYKETTHUCQUYDINH.Date.Subtract(dtoDotThi.NGAYBATDAUTHUCTE.Date) > dtoDotThi.NGAYKETTHUCQUYDINH.Date.Subtract(dtoDotThi.NGAYBATDAUQUYDINH.Date))
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                bd.ToolTip = "Công việc đã đến ngày hoặc quá ngày nhưng vẫn chưa được kết thúc\n" + bd.ToolTip;
                return;
            }
            else if (dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001" &&dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001" && (float)(DateTime.Now.Date.Subtract(dtoDotThi.NGAYBATDAUTHUCTE.Date)).Days / (float)(dtoDotThi.NGAYKETTHUCQUYDINH.Date.Subtract(dtoDotThi.NGAYBATDAUQUYDINH.Date)).Days > (float)(dtoDotThi.KHOILUONGCVHT) / (float)(dtoDotThi.TONGKHOILUONGCV))
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                bd.ToolTip = "Công việc đang thực hiện chậm hơn bình thường\n" + bd.ToolTip;
                return;
            }
            else if (dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() != "01/01/0001" && dtoDotThi.KHOILUONGCVHT < dtoDotThi.TONGKHOILUONGCV)
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                bd.ToolTip = "Công việc đã kết thúc nhưng vẫn chưa làm hết khối lượng công việc\n" + bd.ToolTip;
                return;
            }
            else if ((dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001") || ((dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001")))
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 240, 255, 0));
                bd.ToolTip = "Công việc chưa được thực hiện\n" + bd.ToolTip;
                return;
            }
            else if (((dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001") && (dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001")) && ((dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001") || (dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001")))
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 255, 186));
                bd.ToolTip = "Công việc đang được thực hiện\n" + bd.ToolTip;
                return;
            }
            else if (((dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001") && (dtoDotThi.NGAYBATDAUTHUCTE.ToShortDateString() != "01/01/0001")) && ((dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() != "1/1/0001") && (dtoDotThi.NGAYKETTHUCTHUCTE.ToShortDateString() != "01/01/0001")))
            {
                bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 104, 233, 0));
                bd.ToolTip = "Công việc đã thực hiện xong.\n" + bd.ToolTip;
                return;
            }
            
        }
    }
}