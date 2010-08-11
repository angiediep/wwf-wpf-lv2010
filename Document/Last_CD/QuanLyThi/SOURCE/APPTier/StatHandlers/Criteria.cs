using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatHandlers
{
    public class Criteria
    {
        private string m_Name;
        private bool m_IsDetail;

        public bool IsDetail
        {
            get { return m_IsDetail; }
            set { m_IsDetail = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        List<Type> m_TypeList;

        public List<Type> TypeList
        {
            get { return m_TypeList; }
            set { m_TypeList = value; }
        }

        public Criteria()
        {
            m_TypeList = new List<Type>();
            m_IsDetail = true;
        }

        public Criteria(List<Type> typelist)
        {
            m_TypeList = typelist;
        }

        public void Parse(System.Xml.XmlTextReader tr)
        {
            int cont = 1;
            while ((cont == 1) || (tr.Read() && tr.Name == "Type"))
            {
                if (tr.IsStartElement()==true)
                {
                    Type t = new Type();
                    t.Parse(tr);
                    m_TypeList.Add(t);
                    tr.Read(); tr.Read();
                    if (tr.Name == "Type")
                        cont = 1;
                    else
                        cont = 0;
                }
            }
        }

        public void Save(System.Xml.XmlTextWriter tw)
        {
            tw.WriteStartElement("Criteria");
            
            tw.WriteStartAttribute("Name");
            tw.WriteString(m_Name);
            tw.WriteEndAttribute();

            tw.WriteStartAttribute("IsDetail");
            tw.WriteString(m_IsDetail.ToString());
            tw.WriteEndAttribute();

            foreach (Type type in m_TypeList)
                type.Save(tw);

            tw.WriteEndElement();
        }
    }
}
