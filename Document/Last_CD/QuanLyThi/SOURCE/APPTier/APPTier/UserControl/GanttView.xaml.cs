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
    /// Interaction logic for GanttChart.xaml
    /// </summary>
    public partial class GanttView : UserControl
    {
        private List<string> m_ListFirstRowLabel;
        private List<DtoDotThi> m_ListDotThi;
        private DateTime m_StartDate;
        private DateTime m_EndDate;

        public List<DtoDotThi> ListDotThi
        {
            get { return m_ListDotThi; }
            set { m_ListDotThi = value; }
        }

        public List<string> ListFirstRowLabel
        {
            get { return m_ListFirstRowLabel; }
            set { m_ListFirstRowLabel = value; }
        }

        public GanttView(List<DtoDotThi> listdotthi)
        {
            InitializeComponent();
            m_ListFirstRowLabel = new List<string>();
            m_ListDotThi = listdotthi;
            if (m_ListDotThi.Count != 0)
            {
                getStartAndEndDate();
                int count = m_EndDate.Subtract(m_StartDate).Days;
                for (int i = 0; i < count + 1; i++)
                    m_ListFirstRowLabel.Add(m_StartDate.Add(new TimeSpan(i, 0, 0, 0)).ToShortDateString());

                draw();
            }
        }


        /// <summary>
        /// tính ngày bắt đầu và kết thúc đễ vẽ GanttWiew
        /// </summary>
        /// <returns></returns>
        private void getStartAndEndDate()
        {
            List<DateTime> list1 = new List<DateTime>();
            List<DateTime> list2 = new List<DateTime>();
            int ngaybatdau = BusTienDo.getNgayBatDau();
            int ngayketthuc = BusTienDo.getNgayKetThuc();

            foreach (DtoDotThi dto in m_ListDotThi)
            {
                list1.Add(dto.NGAYTHI.Add(new TimeSpan(ngaybatdau, 0, 0, 0)));
                list2.Add(dto.NGAYTHI.Add(new TimeSpan(ngayketthuc, 0, 0, 0)));
            }
            list1.Sort();
            list2.Sort();

            // DEBUG
            m_StartDate = list1[0];
            m_EndDate = list2[list2.Count - 1];
        }

        /// <summary>
        /// dùng datagrid đễ vẽ GanttView
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
            this.Width = 10 * (m_ListFirstRowLabel.Count + 1 - 1) + 100;

            for (int i = 0; i <= m_ListDotThi.Count + 1; i++)
            {
                RowDefinition w = new RowDefinition();
                w.Height = new GridLength(30, GridUnitType.Pixel);
                this.MyGanttChart.RowDefinitions.Add(w);
            }
            this.Height = 30 * (m_ListDotThi.Count + 1);

            Border bd1 = setCellStyle(0, 0, 1, m_ListFirstRowLabel.Count + 1);
            bd1.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 128, 0, 0));
            for (int i = 0; i < m_ListFirstRowLabel.Count; i++)
            {
                if (m_ListFirstRowLabel[i] == DateTime.Now.ToShortDateString())
                {
                    setColumnName(i + 1);
                    Border bbdx = setCellStyle(1, i + 1, m_ListDotThi.Count + 1, 1);
                    bbdx.Background = new SolidColorBrush(Colors.Gray);
                }
            }
            for (int i = 1; i < m_ListDotThi.Count + 1; i++)
            {
                DotThiBar dtbar = new DotThiBar(m_ListDotThi[i - 1], m_StartDate);

                int n = dtbar.Startindex;
                int h = dtbar.EndIndex;

                Border bdd = setCellStyle(i, n, 1, h - n + 2);

                string tooltip = m_ListDotThi[i - 1].TENDOTTHI + " - Ngày thi: " + m_ListDotThi[i-1].NGAYTHI.ToShortDateString() + "\r\nNgày bắt đầu: " + m_ListDotThi[i - 1].NGAYTHI.Add(new TimeSpan(BusTienDo.NGAYBATDAU, 0, 0, 0)).ToShortDateString() + "\r\nNgày kết thúc: " + m_ListDotThi[i - 1].NGAYTHI.Add(new TimeSpan(BusTienDo.NGAYKETTHUC, 0, 0, 0)).ToShortDateString();
                bdd.ToolTip = tooltip;
                getColor(ref bdd, m_ListDotThi[i - 1]);

                for (int u = n; u <= h + 1; u++)
                {
                    if ((u == n) || (u == h + 1))
                    {
                        // LOAD ten COT
                        setColumnName(u);
                    }
                }
            }

            // LOAD TEN DOT THI
            this.MyGanttChart.ColumnDefinitions[0].Width = GridLength.Auto;
            for (int i = 0; i < m_ListDotThi.Count; i++)
            {
                TextBlock t = new TextBlock();
                t.Text = m_ListDotThi[i].TENDOTTHI;
                t.SetValue(Grid.RowProperty, (int)(i + 1));
                t.SetValue(Grid.ColumnProperty, (int)0);
                t.Uid = m_ListDotThi[i].MADT.ToString();
                t.Cursor = Cursors.Hand;
                t.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 189, 73, 73));
                t.Margin = new Thickness(10, 5, 10, 5);
                t.MouseDown += new MouseButtonEventHandler(t_MouseDown);
                this.MyGanttChart.Children.Add(t);
            }

            for (int j = 0; j <= m_ListDotThi.Count; j++)
            {
                setCellStyle(j, 0, 1, 1);
                setCellStyle(j, 1, 1, m_ListFirstRowLabel.Count);
            }

            Border bddd = setCellStyle(0, 0, 1, 1);
            StackPanel sp = new StackPanel();
            TextBlock tb = new TextBlock();
            tb.Text = "Đợt Thi";
            tb.Foreground = new SolidColorBrush(Colors.White);
            tb.TextAlignment = TextAlignment.Center;
            tb.FontWeight = FontWeights.Bold;
            tb.Margin = new Thickness(0, 5, 0, 5);
            sp.Children.Add(tb);
            this.MyGanttChart.Children.Add(sp);
        }

        /// <summary>
        /// tính toán hiện trạng và lấy màu của GanttView
        /// </summary>
        /// <returns></returns>
        private void getColor(ref Border bd, DtoDotThi dtoDotThi)
        {
            List<DtoTienDo> listdt = new BusTienDo().getListDataBymaDT(dtoDotThi.MADT);
            foreach (DtoTienDo td in listdt)
            {
                if (td.NGAYBATDAUTHUCTE.ToShortDateString() == "1/1/0001" && td.NGAYBATDAUQUYDINH <= DateTime.Now.Date)
                {
                    bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    bd.ToolTip = "Đợt thi đã đến ngày hoặc quá ngày nhưng vẫn chưa được thực hiện\n" + bd.ToolTip;
                    return;
                }
                else if (td.NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001" && td.NGAYKETTHUCQUYDINH.Date.Subtract(td.NGAYBATDAUTHUCTE.Date) > td.NGAYKETTHUCQUYDINH.Date.Subtract(td.NGAYBATDAUQUYDINH.Date))
                {
                    bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    bd.ToolTip = "Đợt thi đã đến ngày hoặc quá ngày nhưng vẫn chưa được kết thúc\n" + bd.ToolTip;
                    return;
                }
                else if (td.NGAYBATDAUTHUCTE.ToShortDateString() != "1/1/0001" && td.NGAYKETTHUCTHUCTE.ToShortDateString() == "1/1/0001" && (float)(DateTime.Now.Date.Subtract(td.NGAYBATDAUTHUCTE.Date)).Days / (float)(td.NGAYKETTHUCQUYDINH.Date.Subtract(td.NGAYBATDAUQUYDINH.Date)).Days > (float)(td.KHOILUONGCVHT) / (float)(td.TONGKHOILUONGCV))
                {
                    bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    bd.ToolTip = "Đợt thi đang thực hiện chậm hơn bình thường\n" + bd.ToolTip;
                    return;
                }
                else if (td.NGAYKETTHUCTHUCTE.ToShortDateString() != "1/1/0001" && td.KHOILUONGCVHT < td.TONGKHOILUONGCV)
                {
                    bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    bd.ToolTip = "Đợt thi đã kết thúc nhưng vẫn chưa làm hết khối lượng công việc\n" + bd.ToolTip;
                    return;
                }
                else if (td.NGAYBATDAUTHUCTE.ToShortDateString() == "01/01/0001" && td.NGAYBATDAUQUYDINH <= DateTime.Now.Date)
                {
                    bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    bd.ToolTip = "Đợt thi đã đến ngày hoặc quá ngày nhưng vẫn chưa được thực hiện\n" + bd.ToolTip;
                    return;
                }
                else if (td.NGAYBATDAUTHUCTE.ToShortDateString()  != "01/01/0001" && td.NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001" && td.NGAYKETTHUCQUYDINH.Date.Subtract(td.NGAYBATDAUTHUCTE.Date) >= td.NGAYKETTHUCQUYDINH.Date.Subtract(td.NGAYBATDAUQUYDINH.Date))
                {
                    bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    bd.ToolTip = "Đợt thi đã đến ngày hoặc quá ngày nhưng vẫn chưa được kết thúc\n" + bd.ToolTip;
                    return;
                }
                else if (td.NGAYBATDAUTHUCTE.ToShortDateString()  != "01/01/0001"  &&td.NGAYKETTHUCTHUCTE.ToShortDateString() == "01/01/0001" && (float)(DateTime.Now.Date.Subtract(td.NGAYBATDAUTHUCTE.Date)).Days / (float)(td.NGAYKETTHUCQUYDINH.Date.Subtract(td.NGAYBATDAUQUYDINH.Date)).Days > (float)(td.KHOILUONGCVHT) / (float)(td.TONGKHOILUONGCV))
                {
                    bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    bd.ToolTip = "Đợt thi đang thực hiện chậm hơn bình thường\n" + bd.ToolTip;
                    return;
                }
                else if (td.NGAYKETTHUCTHUCTE.ToShortDateString() != "01/01/0001" && td.KHOILUONGCVHT < td.TONGKHOILUONGCV)
                {
                    bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 156, 0));
                    bd.ToolTip = "Đợt thi đã kết thúc nhưng vẫn chưa làm hết khối lượng công việc\n" + bd.ToolTip;
                    return;
                }
            }
            bd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 255, 186));
            bd.ToolTip = "Đợt thi đang được thực hiện.\n" + bd.ToolTip;
        }


        /// <summary>
        /// đặt tên cột trong GanttView
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
        /// quy định màu sắc và set kích thước từng cell
        /// </summary>
        /// <returns></returns>
        private Border setCellStyle(int row, int col, int rowspan, int colSpan)
        {
            Border bd = new Border();
            bd.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 161, 66, 66));
            bd.BorderThickness = new Thickness(1);
            bd.SetValue(Grid.RowProperty, (int)row);
            bd.SetValue(Grid.ColumnProperty, (int)col);
            bd.SetValue(Grid.ColumnSpanProperty, (int)colSpan);
            bd.SetValue(Grid.RowSpanProperty, (int)rowspan);
            this.MyGanttChart.Children.Add(bd);

            return bd;
        }


        /// <summary>
        /// gọi GanttView chi tiết dợt thi
        /// </summary>
        /// <returns></returns>
        void t_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock t = sender as TextBlock;
            DotThiDetailGanttView detail = new DotThiDetailGanttView(int.Parse(t.Uid));
            if (detail.Return == 1)
            {
                detail.Show();
                detail.Topmost = true;
		
            }
        }
    }
}