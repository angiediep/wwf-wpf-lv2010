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
        private int scale;

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

        public GanttViewTienDo(List<DtoTienDo> listDT)
        {
            InitializeComponent();
            m_ListFirstRowLabel = new List<string>();
            m_ListTD = listDT;

            getStartAndEndDate();
            int count = m_EndDate.Subtract(m_StartDate).Days;
            for (int i = 0; i < count; i++)
            {
                m_ListFirstRowLabel.Add(m_StartDate.Add(new TimeSpan(i,0,0,0)).ToShortDateString());
            }

            draw();
        }

        private void getStartAndEndDate()
        {
            List<DateTime> list1 = new List<DateTime>();
            List<DateTime> list2 = new List<DateTime>();

            foreach (DtoTienDo td in m_ListTD)
            {
                list1.Add(td.NGAYBATDAUTHUCTE);
                list2.Add(td.NGAYKETTHUCTHUCTE);
            }
            list1.Sort();
            list2.Sort();

            // DEBUG
            m_StartDate = list1[0];
            m_EndDate = list2[list2.Count - 1];
        }

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
                w.Height = new GridLength(20, GridUnitType.Pixel);
                this.MyGanttChart.RowDefinitions.Add(w);
            }
            this.MyGanttChart.Height = 20 * (m_ListTD.Count + 1);

            for (int i = 1; i < m_ListTD.Count + 1; i++)
            {
                DotThiBar dtbar = new DotThiBar(m_ListTD[i - 1], m_StartDate);

                int n = dtbar.Startindex;
                int h = dtbar.EndIndex;
                for (int u = n + 1; u <= h; u++)
                {
                    Canvas c = new Canvas();
                    c.Background = Brushes.Blue;
                    c.SetValue(Grid.RowProperty, (int)i);
                    c.SetValue(Grid.ColumnProperty, (int)u);

                    if ((u == n + 1) || (u == h))
                    {
                        // LOAD ten COT
                        Canvas s = new Canvas();
                        s.SetValue(Grid.RowProperty, (int)0);
                        s.SetValue(Grid.ColumnProperty, (int)u);
                        s.Width = 100;
                        this.MyGanttChart.ColumnDefinitions[u].Width = new GridLength(100, GridUnitType.Pixel);
                        this.MyGanttChart.Width += 100 - 10;

                        TextBlock t = new TextBlock();
                        t.Text = m_ListFirstRowLabel[u - 1];
                        s.Children.Add(t);
                        this.MyGanttChart.Children.Add(s);
                    }
                    this.MyGanttChart.Children.Add(c);
                }
            }

            this.MyGanttChart.ColumnDefinitions[0].Width = new GridLength(100, GridUnitType.Pixel);
            for (int i = 0; i < m_ListTD.Count; i++)
            {
                TextBlock t = new TextBlock();
                t.Text = new BUSLayer.BusCongViec().getTenCVByMaCV(m_ListTD[i].MACV);
                t.SetValue(Grid.RowProperty, (int)(i + 1));
                t.SetValue(Grid.ColumnProperty, (int)0);
                this.MyGanttChart.Children.Add(t);
            }
            this.Width = MyGanttChart.Width;
            this.Height = MyGanttChart.Height;
        }
    }
}