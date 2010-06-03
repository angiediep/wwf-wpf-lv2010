using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;

namespace ModelReader
{
    public class XOMLReader
    {
        private string m_FilePath;
        private List<Activity> m_ListActivity;

        public List<Activity> ListActivity
        {
            get { return m_ListActivity; }
            set { m_ListActivity = value; }
        }
        public string FilePath
        {
            get { return m_FilePath; }
            set { m_FilePath = value; }
        }

        public XOMLReader(string filepath)
        {
            m_FilePath = filepath;
            m_ListActivity = new List<Activity>();
        }

        public void parseXOML()
        {
            XmlTextReader tr = new XmlTextReader(m_FilePath);
            tr.Read(); tr.Read();
            int numberOfBlocks = getNumbersOfBlock();
            int i = 0;
            int flag = 0;
            while (i < numberOfBlocks)
            {
                Activity act = null;

                // READ a MAIN ACTIVITY, one by one
                while (tr.Read())
                {
                    if (tr.Name == "SequentialWorkflowActivity")
                        break;
                    string tagName = tr.Name;
                    if (tagName !="")
                    {
                        switch (tr.Name)
                        {
                            case "ParallelActivity":
                                act = new ParallelActivity(i, tr.GetAttribute("x:Name"));
                                break;
                            case "SequenceActivity":
                                act = new SequenceActivity(i, tr.GetAttribute("x:Name"));
                                break;
                            case "ns0:Work":
                                act = new WorkItem(i, tr.GetAttribute("x:Name"), new Random().Next(1, 5));
                                //Thread.Sleep(1000);
                                flag = 1;
                                break;
                        }
                        if (flag != 1)
                        {
                            tr.Read(); tr.Read();
                            act.parseXOML(tr, tagName);
                        }
                        else
                            flag = 0;

                        double defaultWidth = act.Name.Length * 10;
                        double defaultHeight = -1;
                        if (act.Type == "SequenceActivity")
                            defaultHeight = 0;
                        else
                            defaultHeight = 62;

                        act.setWidthAndHeight(defaultWidth, defaultHeight);

                        m_ListActivity.Add(act);
                        tr.Read();
                    }
                    i++;
                }
            }
            tr.Close();
        }

        private int getNumbersOfBlock()
        {
            XmlTextReader tr = new XmlTextReader(m_FilePath);
            int i = 0;
            int countFlag = 0;
            tr.Read();
            tr.Read();
            tr.Read();
            string markTagName = tr.Name;
            while (!tr.EOF)
            {
                if (markTagName == "ns0:Work")
                {
                    i++;
                    tr.Read();
                    tr.Read();
                    markTagName = tr.Name;
                }
                else
                {
                    string tagName = tr.Name;
                    if (tagName == markTagName)
                        countFlag++;
                    if (tr.IsStartElement() == true && tagName == markTagName)
                    {
                        markTagName = tagName;
                        tr.Read();
                        tr.Read();
                    }
                    else if (tr.IsStartElement() == false && tagName == markTagName && countFlag % 2 == 0)
                    {
                        i++;
                        countFlag = 0;
                        tr.Read();
                        tr.Read();
                        markTagName = tr.Name;
                    }
                    else
                    {
                        tr.Read();
                        tr.Read();
                    }
                }
            }
            tr.Close();

            return i;
        }
    }
}
