using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ModelLayouter
{
    public abstract class LayoutShape
    {
        #region Attributes
        protected PointF m_StartPointF;
        protected PointF m_EndPointF;
        #endregion

        #region Properties
        public PointF StartPointF
        {
            get { return m_StartPointF; }
            set { m_StartPointF = value; }
        }
        public PointF EndPointF
        {
            get { return m_EndPointF; }
            set { m_EndPointF = value; }
        }
        #endregion

        public LayoutShape(PointF start)
        {
            m_StartPointF = start;
        }
        public LayoutShape(PointF start, PointF end)
        {
            m_StartPointF = start;
            m_EndPointF = end;
        }

        public virtual double getWidth() { return -1; }
        public virtual double getHeight() { return -1; }
        public virtual List<LayoutLine> getLineList() { return null; }
    }
}
