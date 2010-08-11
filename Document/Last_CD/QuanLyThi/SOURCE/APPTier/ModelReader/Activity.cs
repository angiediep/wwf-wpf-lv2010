using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

namespace ModelReader
{
    abstract public class Activity
    {
        protected int m_Index;
        protected string m_Name;
        protected string m_Type;
        protected double m_DefaultWidth;
        protected double m_DefaultHeight;
        protected double m_Width;
        protected double m_Height;
        protected double m_GapW;
        protected double m_GapH;
        protected List<Activity> m_ListActivity;
        protected Point m_TopLeftCoor;

        #region Properties
        public Point TopLeftCoor
        {
            get { return m_TopLeftCoor; }
            set { m_TopLeftCoor = value; }
        }
        public List<Activity> ListActivity
        {
            get { return m_ListActivity; }
            set { m_ListActivity = value; }
        }
        public double DefaultWidth
        {
            get { return m_DefaultWidth; }
            set { m_DefaultWidth = value; }
        }
        public double DefaultHeight
        {
            get { return m_DefaultHeight; }
            set { m_DefaultHeight = value; }
        }
        public double Width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }
        public double Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }
        public double GapW
        {
            get { return m_GapW; }
            set { m_GapW = value; }
        }
        public double GapH
        {
            get { return m_GapH; }
            set { m_GapH = value; }
        }

        public string Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public int Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }
        #endregion

        public Activity(int index, string name)
        {
            m_Index = index;
            m_Name = name;
            m_GapW = 20;
            m_GapH = 10;
            m_Height = m_DefaultHeight = 30;
            m_Width = m_DefaultWidth = 100;
        }

        public void setWidthAndHeight(double defaultwidth, double defaultheight)
        {
            if (this.Type == "WorkItem")
                m_Width = m_DefaultWidth = defaultwidth;
            else
                m_Width = m_DefaultWidth = 0;

            m_Height = m_DefaultHeight = defaultheight;
            this.getWidth();
            this.getHeight();
        }

        protected double getMaxInList(List<double> list)
        {
            double soldier = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (soldier < list[i])
                    soldier = list[i];
            }
            return soldier;
        }

        public abstract void parseXOML(XmlTextReader tr, string parentTagName);
        public abstract double getHeight();
        public virtual int getstatus() { return -1;}

        public virtual void swapWorkItem()
        {
            List<int> listindex = new List<int>();
            for (int i = 0; i < m_ListActivity.Count; i++)
            {
                if (m_ListActivity[i].Type == "WorkItem")
                    listindex.Add(i);
                else
                {
                    if (listindex.Count >= 2)
                        m_ListActivity.Reverse(listindex[0], listindex.Count);
                    listindex.Clear();
                    m_ListActivity[i].swapWorkItem();
                }
            }
            if (listindex.Count >= 2)
                m_ListActivity.Reverse(listindex[0], listindex.Count);
        }
        
        public virtual double getWidth()
        {
            double totalGapW = 0;
            foreach (Activity act in m_ListActivity)
            {
                m_Width += act.Width;
                totalGapW += m_GapW;
            }
            m_Width = m_Width + (totalGapW - m_GapW);

            return m_Width;
        }
    }
}