﻿using System;
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
                DateTime bd = td.NGAYBATDAUTHUCTE;
                DateTime kt = td.NGAYKETTHUCTHUCTE;
                if (bd == kt)
                    numberOfDayStartEquEnd++;

                list1.Add(bd);
                list2.Add(kt);
            }
            list1.Sort();
            list2.Sort();

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
                w.Height = new GridLength(30, GridUnitType.Pixel);
                this.MyGanttChart.RowDefinitions.Add(w);
            }
            this.MyGanttChart.Height = 30 * (m_ListTD.Count + 1);

            Border bd1 = setCellStyle(0, 0, 1, m_ListFirstRowLabel.Count + 1);
            bd1.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 128, 0, 0));
            for (int i = 1; i < m_ListTD.Count + 1; i++)
            {
                DotThiBar dtbar = new DotThiBar(m_ListTD[i - 1], m_StartDate);

                int n = dtbar.Startindex;
                int h = dtbar.EndIndex;

                Border bdd =  setCellStyle(i, n+1, 1, h - n + 1);
                bdd.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 102, 0));
                for (int u = n + 1; u <= h + 1; u++)
                {
                    if ((u == n + 1) || (u == h+1))
                    {
                        // LOAD ten COT
                        Canvas s = new Canvas();
                        s.SetValue(Grid.RowProperty, (int)0);
                        s.SetValue(Grid.ColumnProperty, (int)u);
                        s.Width = 100;
                        s.Height = 15;
                        this.MyGanttChart.ColumnDefinitions[u].Width = new GridLength(100, GridUnitType.Pixel);
                        this.MyGanttChart.Width += 100 - 10;

                        TextBlock t = new TextBlock();
                        t.TextAlignment = TextAlignment.Center;
                        t.Text = m_ListFirstRowLabel[u];
                        t.Width = s.Width;
                        t.Foreground = new SolidColorBrush(Colors.White);
                        t.FontWeight = FontWeights.Bold;
                        s.Children.Add(t);
                        this.MyGanttChart.Children.Add(s);
                        Border bd = setCellStyle(0, u, 1, 1);
                        bd.Width = s.Width;
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

            //this.MyGanttChart.ColumnDefinitions[0].Width = GridLength.Auto;
            //for (int i = 0; i < m_ListTD.Count; i++)
            //{
            //    TextBlock t = new TextBlock();
            //    t.Text = new BUSLayer.BusCongViec().getTenCVByMaCV(m_ListTD[i].MACV);
            //    t.SetValue(Grid.RowProperty, (int)(i + 1));
            //    t.SetValue(Grid.ColumnProperty, (int)0);
            //    this.MyGanttChart.Children.Add(t);
            //}
            this.Width = MyGanttChart.Width;
            this.Height = MyGanttChart.Height;
        }

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
    }
}