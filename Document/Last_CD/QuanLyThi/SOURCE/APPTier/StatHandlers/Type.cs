using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatHandlers
{
    public class Type
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private string m_Method;

        public string Method
        {
            get { return m_Method; }
            set { m_Method = value; }
        }
        private string m_SQL;

        public string SQL
        {
            get { return m_SQL; }
            set { m_SQL = value; }
        }

        public void Parse(System.Xml.XmlTextReader tr)
        {
            m_Name = tr.GetAttribute("Name");
            m_Method = tr.GetAttribute("Method");
            m_SQL = tr.GetAttribute("SQL");
        }

        public void Save(System.Xml.XmlTextWriter tw)
        {
            tw.WriteStartElement("Type");
            
            tw.WriteStartAttribute("Name");
            tw.WriteString(m_Name);
            tw.WriteEndAttribute();

            tw.WriteStartAttribute("Method");
            tw.WriteString(m_Method);
            tw.WriteEndAttribute();

            tw.WriteStartAttribute("SQL");
            tw.WriteString(m_SQL);
            tw.WriteEndAttribute();

            tw.WriteEndElement();
        }
    }
}
