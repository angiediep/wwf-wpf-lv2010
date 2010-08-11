using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace StatHandlers
{
    public class StatXMLParser
    {
        private string m_Path;

        public string Path
        {
            get { return m_Path; }
            set { m_Path = value; }
        }
        private List<Object> m_ObjectList;

        public List<Object> ObjectList
        {
            get { return m_ObjectList; }
            set { m_ObjectList = value; }
        }

        public StatXMLParser(string path)
        {
            m_Path = path;
            m_ObjectList = new List<Object>();
        }

        public void Parse()
        {
            XmlTextReader tr = new XmlTextReader(m_Path);

            tr.Read(); tr.Read();
            while (tr.Read())
            {
                if (tr.Name == "object")
                {
                    Object obj = new Object();
                    obj.Name = tr.GetAttribute("Name");
                    tr.Read();
                    obj.Parse(tr);
                    m_ObjectList.Add(obj);
                }
            }

            tr.Close();
        }

        public void Save(string path)
        {
            XmlTextWriter tw = new XmlTextWriter(path, Encoding.UTF8);

            tw.Formatting = Formatting.Indented;
            tw.WriteStartElement("root");

            foreach (Object obj in m_ObjectList)
                obj.Save(tw);

            tw.WriteEndElement();
            tw.Close();
        }

        public Object getCustomObject()
        {
            foreach (Object o in m_ObjectList)
            {
                if (o.Name == "Custom")
                    return o;
            }
            return null;
        }
    }
}
