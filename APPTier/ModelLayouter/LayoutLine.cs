using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ModelLayouter
{
    public class LayoutLine : LayoutShape
    {
        public LayoutLine(PointF start, PointF end)
            : base(start, end)
        {
        }
    }
}