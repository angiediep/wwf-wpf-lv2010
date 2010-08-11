using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelReader
{
    public class WorkItem : Activity
    {
        private int m_Status;

        public int Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public WorkItem(int index, string name, int status)
            : base(index, name)
        {
            Type = "WorkItem";
            m_Status = status;
        }
        public override int getstatus()
        {
            return m_Status;
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
