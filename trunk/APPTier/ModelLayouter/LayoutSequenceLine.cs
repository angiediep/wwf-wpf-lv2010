using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ModelLayouter
{
    public class LayoutSequenceLine : LayoutShape
    {
        private List<LayoutLine> m_LineList;
        public List<LayoutLine> LineList
        {
            get { return m_LineList; }
            set { m_LineList = value; }
        }

        public LayoutSequenceLine(PointF start, PointF end)
            : base(start, end)
        {
            calculateToDraw();
        }

        private void calculateToDraw()
        {

        }
        public override List<LayoutLine> getLineList()
        {
            return m_LineList;
        }
    }
}
