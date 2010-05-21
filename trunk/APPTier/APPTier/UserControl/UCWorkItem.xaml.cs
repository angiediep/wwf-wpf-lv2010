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

namespace APPTier
{
    /// <summary>
    /// Interaction logic for UCWorkItem.xaml
    /// </summary>
    public partial class UCWorkItem : UserControl
    {
        Canvas canv;

        public UCWorkItem(Activity act, double width, double height)
        {
            InitializeComponent();
            this.Height = height;
            this.Width = width;

            canv = new Canvas();
            //add the Canvas as sole child of Window
            this.Content = canv;
            canv.Margin = new Thickness(0, 0, 0, 0);
            canv.Background = new SolidColorBrush(Colors.White);

            TextBlock text = new TextBlock();
            text.Text = act.Name;
            canv.Children.Add(text);

            System.Drawing.PointF startingPoint = new System.Drawing.PointF(0f, 0f);
            drawWorkItem(startingPoint);
        }

        private System.Drawing.PointF drawWorkItem(PointF startingPoint)
        {
            startingPoint = new PointF(startingPoint.X + (float)this.Width/2, startingPoint.Y + (float)this.Height -2f);
            drawLine(startingPoint);

            return new PointF(startingPoint.X, startingPoint.Y + 10);
        }

        private void drawLine(PointF startingPoint)
        {
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = startingPoint.X;
            myLine.Y1 = startingPoint.Y;
            myLine.X2 = startingPoint.X;
            myLine.Y2 = startingPoint.Y + 10;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            canv.Children.Add(myLine);
        }
    }
}