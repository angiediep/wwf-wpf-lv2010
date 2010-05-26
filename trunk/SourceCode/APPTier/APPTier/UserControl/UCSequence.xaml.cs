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
using ModelReader;
using ModelLayouter;
using System.Drawing;
using System.Collections;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for UCSequence.xaml
    /// </summary>
    public partial class UCSequence : UserControl
    {
        Canvas canv;
        List<PointF> m_ListNextPoint = new List<PointF>();

        public UCSequence(Activity act, double width, double height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height - 10;

            canv = new Canvas();
            //add the Canvas as sole child of Window
            this.Content = canv;
            canv.Margin = new Thickness(0, 0, 0, 0);
            canv.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255,67,67,67));

            System.Drawing.PointF startingPoint = new System.Drawing.PointF((float)width / 2, 0f);
            drawSequence(startingPoint, act);
            draw(act.ListActivity);
        }

        private void draw(List<Activity> list)
        {
            int j = 0;
            int count = list.Count;
            PointF nextStartPoint = m_ListNextPoint[0];
            for (int i = 0; i < count; i++)
            {
                Activity act = list[i];

                //PointF nextStartPoint = m_ListNextPoint[j];
                switch (act.Type)
                {
                    case "ParallelActivity":
                        UCParallel p = new UCParallel(act, act.Width, act.Height);
                        p.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        p.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        canv.Children.Add(p);
                        if (i < count - 1)
                        {
                            nextStartPoint = new PointF(nextStartPoint.X + (float)list[i].Width / 2 - (float)list[i + 1].Width / 2, nextStartPoint.Y + 10f + (float)p.Height);
                        }
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
                        if (i < count - 1)
                        {
                            nextStartPoint = new PointF(nextStartPoint.X + (float)list[i].Width / 2 - (float)list[i + 1].Width / 2, nextStartPoint.Y + 10f + (float)r.Height);
                        }
                        break;
                }
                //j++;
            }
        }

        // Ham nay ko can nhung ma cu de day, tam thoi la de add diem startingPoint vo m_ListNextPoint
        private void drawSequence(PointF startingPoint, Activity act)
        {
            if (act.ListActivity[0].Type != "WorkItem")
                startingPoint = new PointF(startingPoint.X - (float)this.Width / 2, startingPoint.Y); 
            else
                startingPoint = new PointF(startingPoint.X - (float)act.ListActivity[0].Width / 2, startingPoint.Y); 

            m_ListNextPoint.Add(startingPoint);
            for (int i = 0; i < act.ListActivity.Count; i++)
            {
                startingPoint = new PointF(startingPoint.X, startingPoint.Y + (float)(act.ListActivity[i].Height) + 10f);
                //m_ListNextPoint.Add(startingPoint);
            }
        }

        void r_Drop(object sender, DragEventArgs e)
        {
            UCWorkItem parent = (UCWorkItem)sender;
            object data = e.Data.GetData(typeof(string));
            //((IList)AssignUser.dragSource.ItemsSource).Remove(data);
            ((TextBlock)parent.FindName("personNameAssigned")).Text = data.ToString();
        }
    }
}