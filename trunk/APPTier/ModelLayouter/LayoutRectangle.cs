using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ModelLayouter
{
    public class LayoutRectangle : LayoutShape
    {
        private double m_Width;
        private double m_Height;
        private int m_NumberOfLines;
        private List<LayoutLine> m_LineList;
        private double m_PaddingGap;

        #region Properties
        public double PaddingGap
        {
            get { return m_PaddingGap; }
            set { m_PaddingGap = value; }
        }
        public int NumberOfLines
        {
            get { return m_NumberOfLines; }
            set { m_NumberOfLines = value; }
        }
        public List<LayoutLine> LineList
        {
            get { return m_LineList; }
            set { m_LineList = value; }
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
        #endregion

        public LayoutRectangle(PointF start, double width, double height, int numberoflines, double paddingGap)
            : base(start)
        {
            m_Height = height;
            m_NumberOfLines = numberoflines;
            m_LineList = new List<LayoutLine>();
            m_PaddingGap = paddingGap;
            m_Width = width - 2 * m_PaddingGap;
            m_StartPointF = new PointF((float)(m_StartPointF.X + paddingGap), m_StartPointF.Y);
            calculateToDraw();
        }

        private void calculateToDraw()
        {
            float subWidth = (float)(m_Width / (m_NumberOfLines + 1));
            float coorY = m_StartPointF.Y + (float)m_Height;
            PointF startingPointLine = new PointF(m_StartPointF.X + subWidth, m_StartPointF.Y);
            for (int i = 0; i < m_NumberOfLines; i++)
            {
                PointF endingPointFLine = new PointF(startingPointLine.X,coorY);
                m_LineList.Add(new LayoutLine(startingPointLine, endingPointFLine));
                startingPointLine = new PointF(startingPointLine.X + subWidth, startingPointLine.Y);
            }
        }

        public override double getHeight()
        {
            return m_Height;
        }
        public override double getWidth()
        {
            return m_Width;
        }
        public override List<LayoutLine> getLineList()
        {
            return m_LineList;
        }
    }
}
