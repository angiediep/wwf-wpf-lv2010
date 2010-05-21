using System;
using System.Collections.Generic;
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
using System.Drawing;

namespace APPTier
{
	/// <summary>
	/// Interaction logic for AssignUser.xaml
	/// </summary>
	public partial class AssignUser : UserControl
	{
        XOMLReader reader;
        double height = 0;
        double width = 0;
		public AssignUser()
		{
			this.InitializeComponent();
            reader = new XOMLReader("QuyTrinhThiWorkflow.xoml");
            reader.parseXOML();

            canv.Margin = new Thickness(0, 0, 0, 0);

            System.Drawing.PointF startingPoint = new System.Drawing.PointF(100f, 20f);
            //Ellipse e = new Ellipse();
            //e.Stroke = new SolidColorBrush(Colors.Tomato);
            //e.Width = 5;
            //e.Height = 5;
            //e.SetValue(Canvas.LeftProperty, (double)startingPoint.X + );
            //e.SetValue(Canvas.TopProperty, (double)startingPoint.Y - 10);
            //canv.Children.Add(e);
            draw(startingPoint, reader.ListActivity);
            this.sss.Height = height;
            this.sss.Width = width;
		}

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void btnFinish_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}
        
        private void draw(PointF nextStartPoint, List<Activity> list)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                Activity act = list[i];
                height += act.Height + 15;
                width += act.Width;

                switch (act.Type)
                {
                    case "ParallelActivity":
                        UCParallel p = new UCParallel(act, act.Width, act.Height);
                        p.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        p.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        canv.Children.Add(p);
                        if (i < count - 1)
                            nextStartPoint = new PointF(nextStartPoint.X + (float)list[i].Width / 2 - (float)list[i + 1].Width / 2 , nextStartPoint.Y + 10f + (float)p.Height);
                        break;
                    case "SequenceActivity":
                        UCSequence s = new UCSequence(act, act.Width, act.Height);
                        s.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        s.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        canv.Children.Add(s);
                        break;
                    case "WorkItem":
                        UCWorkItem r = new UCWorkItem(act, act.Width, act.Height);
                        r.SetValue(Canvas.LeftProperty, (double)nextStartPoint.X);
                        r.SetValue(Canvas.TopProperty, (double)nextStartPoint.Y);
                        canv.Children.Add(r);
                        if (i < count - 1)
                            nextStartPoint = new PointF(nextStartPoint.X + (float)list[i].Width / 2 - (float)list[i + 1].Width / 2, nextStartPoint.Y + 10f + (float)r.Height);
                        break;
                }
            }
        }

	}
}