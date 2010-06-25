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
            set { m_Color = value; setColor(); }
        }

        private DtoPhanCong m_PhanCong;

        public DtoPhanCong ListPhanCong
        {
            get { return m_PhanCong; }
            set { m_PhanCong = value; }
        }

        public string XName
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public UCWorkItem(Activity act, double width, double height, int status, DtoPhanCong listPC)
        {
            InitializeComponent();
            this.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 15, 29, 4));
            this.Height = height;
            this.Width = stackShowData.Width = width;
            stackShowData.SetValue(Canvas.TopProperty, (double)height/3);
            m_Name = act.Name;
            this.Uid = "WorkItem";

            if (listPC != null)
            {
                m_PhanCong = listPC;
                if (listPC.NGAYHETHAN.ToShortDateString() != "1/1/0001")
                    status = getStatus();
            }

            //canv = new Canvas();
            //add the Canvas as sole child of Window
            //this.Content = canv;
            //canv.Margin = new Thickness(0, 0, 0, 0);
            //canv.Background = new SolidColorBrush(Colors.White);

            m_Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 244, 255, 195));
            switch (status)
            {
                case 1:
                    m_Color = new SolidColorBrush(Colors.Black);
                    break;
                case 2:
                    m_Color = new SolidColorBrush(Colors.SkyBlue);
                    break;
                case 3:
                    m_Color = new SolidColorBrush(Colors.Orange);
                    break;
                case 4:
                    m_Color = new SolidColorBrush(Colors.DarkBlue);
                    break;
            }
            setColor();

            workItemName.Text = act.Name;
      

            System.Drawing.PointF startingPoint = new System.Drawing.PointF(0f, 0f);
            drawWorkItem(startingPoint);
        }

        public void setHiddenPopUp()
        {
            canv.MouseRightButtonUp -= canv_MouseLeftButtonDown;
        }

        private int getStatus()
        {
            if (DateTime.Now < m_PhanCong.NGAYAPDUNG)   
                return 1;
            else if (m_PhanCong.NGAYAPDUNG <= DateTime.Now && DateTime.Now <= m_PhanCong.NGAYHETHAN)
                return 2;
            //else if // DANH CHO RISK !!
            //    return 3;
            else if (m_PhanCong.NGAYHETHAN < DateTime.Now)
                return 4;

            return 1;
        }

        private void setColor()
        {
            canv.Background = m_Color;
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
    }
}