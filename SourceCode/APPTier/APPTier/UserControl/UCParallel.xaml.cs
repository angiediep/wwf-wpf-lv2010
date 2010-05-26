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

            canv = new Canvas();
            //add the Canvas as sole child of Window
            this.Content = canv;
            canv.Margin = new Thickness(0, 0, 0, 0);
            canv.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0,67,67,67));

            System.Drawing.PointF startingPoint = new System.Drawing.PointF(0f, 0f);
            drawParallel(startingPoint, act);
            draw(act.ListActivity);
        }

        private void draw(List<Activity> list)
        {
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
                        UCWorkItem r = new UCWorkItem(act, act.Width, act.Height, act.getstatus());
                        r.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        r.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        r.AllowDrop = true;
                        r.Drop += new DragEventHandler(r_Drop);
                        canv.Children.Add(r);
                        break;
                }
                i++;
            }
        }

        void r_Drop(object sender, DragEventArgs e)
        {
            UCWorkItem parent = (UCWorkItem)sender;
            object data = e.Data.GetData(typeof(string));
            //((IList)AssignUser.dragSource.ItemsSource).Remove(data);
            ((TextBlock)parent.FindName("personNameAssigned")).Text = data.ToString();
        }

        private void drawParallel(PointF startingPoint, Activity act)
        {
            m_ListNextPoint.Add(new PointF(startingPoint.X - (float)act.ListActivity[0].Width/2 -1f, startingPoint.Y + 10f));

            double w = act.Width;

            LayoutShape shape = new LayoutRectangle(startingPoint, w, act.Height, act.ListActivity.Count - 2, 0);
            System.Windows.Shapes.Rectangle layoutRect = new System.Windows.Shapes.Rectangle();
            layoutRect.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            layoutRect.StrokeThickness = 2;
            layoutRect.Width = shape.getWidth();
            layoutRect.Height = shape.getHeight();
            layoutRect.SetValue(Canvas.LeftProperty, (double)shape.StartPointF.X);
            layoutRect.SetValue(Canvas.TopProperty, (double)shape.StartPointF.Y);
            List<LayoutLine> lineList = shape.getLineList();
            for (int i = 0; i < lineList.Count; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
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