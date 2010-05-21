using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelReader
{
    public class WorkItem : Activity
    {
        public WorkItem(int index, string name)
            : base(index, name)
        {
            Type = "WorkItem";
        }

        public override void parseXOML(System.Xml.XmlTextReader tr, string parentTagName)
        {
            throw new NotImplementedException();
        }

        public override double getHeight()
        {
            return m_Height;
        }

        public override double getWidth()
        {
            return m_Width;
        }
    }
}
