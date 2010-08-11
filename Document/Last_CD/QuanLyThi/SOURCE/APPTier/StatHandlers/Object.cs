using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace StatHandlers
{
    public class Object
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private List<Criteria> m_CriteriaList;

        public List<Criteria> CriteriaList
        {
            get { return m_CriteriaList; }
            set { m_CriteriaList = value; }
        }

        public Object()
        {
            m_CriteriaList = new List<Criteria>();
        }

        public Object(List<Criteria> criterialist)
        {
            m_CriteriaList = criterialist;
        }

        public void Parse(System.Xml.XmlTextReader tr)
        {
            while (tr.Read() && tr.Name == "Criteria")
            {
                if (tr.IsStartElement() == true)
                {
                    Criteria cri = new Criteria();
                    cri.Name = tr.GetAttribute("Name");
                    cri.IsDetail = bool.Parse(tr.GetAttribute("IsDetail").ToString());
                    tr.Read();
                    cri.Parse(tr);
                    m_CriteriaList.Add(cri);
                }
            }
        }

        public Criteria getCriByName(string Name)
        {
            foreach (Criteria cri in m_CriteriaList)
            {
                if (cri.Name == Name)
                    return cri;
            }
            return null;
        }

        public void Save(XmlTextWriter tw)
        {
            tw.WriteStartElement("object");
            tw.WriteStartAttribute("Name");
            tw.WriteString(m_Name);
            tw.WriteEndAttribute();

            foreach (Criteria cri in m_CriteriaList)
                cri.Save(tw);
            tw.WriteEndElement();
        }
    }
}
