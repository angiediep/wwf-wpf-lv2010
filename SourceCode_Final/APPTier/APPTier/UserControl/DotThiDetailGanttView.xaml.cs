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
using System.Windows.Shapes;
using BUSLayer;
using DataLayer.DTO;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for DotThiDetailGanttView.xaml
    /// </summary>
    public partial class DotThiDetailGanttView : Window
    {
        private int m_Return;

        public int Return
        {
            get { return m_Return; }
            set { m_Return = value; }
        }

        public DotThiDetailGanttView(int maDT)
        {
            InitializeComponent();
            tblTittle.Text = new BusDotThi().getTenDTByMaDT(maDT);
            BusTienDo td = new BusTienDo();
            List<DtoTienDo> listdt = td.getListDataBymaDT(maDT);
            if (listdt.Count != 0)
            {
                GanttViewTienDo gv = new GanttViewTienDo(listdt);
                mainGrid.Children.Add(gv);
                mainGrid.Width = gv.Width;
                mainGrid.Height = gv.Height;
                m_Return = 1;
            }
            else
            {
                MessageBox.Show("No tasks !!");
                m_Return = 0;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            this.DragMove();
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMinimize_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
