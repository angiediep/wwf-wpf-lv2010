using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;
using BUSLayer;

namespace ModelReader
{
    public class ParallelActivity : Activity
    {
        private int m_CountStartTagFlag;
        private int m_CountEndTagFlag;

        public ParallelActivity(int index, string name)
            : base(index, name)
        {
            m_ListActivity = new List<Activity>();
            m_CountStartTagFlag = 1;
            m_CountEndTagFlag = 0;
            Type = "ParallelActivity";
            m_Width = 0;
            m_Height = 0;
        }

        public override void parseXOML(XmlTextReader tr, string parentTagName)
        {
            while (!(tr.Name == parentTagName && tr.IsStartElement() == false))
            {
                Activity act = null;
                int flag = 0;
                if ((tr.IsStartElement() == true) && (tr.Name == parentTagName))
                    m_CountStartTagFlag++;
                else if (tr.IsStartElement() == false && (tr.Name == parentTagName))
                    m_CountEndTagFlag++;

                if (tr.IsStartElement() == true)
                {
                    switch (tr.Name)
                    {
                        case "ParallelActivity":
                            act = new ParallelActivity(new Random().Next(), tr.GetAttribute("x:Name"));
                            break;
                        case "SequenceActivity":
                            act = new SequenceActivity(new Random().Next(), tr.GetAttribute("x:Name"));
                            break;
                        case "ns0:Work":
                            act = new WorkItem(new Random().Next(), new BusCongViec().getMoTaByTenCV(tr.GetAttribute("x:Name")), -1);
                            flag = 1;
                            break;
                    }
                    tr.Read(); tr.Read();
                    if (flag != 1)
                        act.parseXOML(tr, act.Type);
                    else if (m_CountEndTagFlag != m_CountStartTagFlag)
                        this.parseXOML(tr, this.Type);

                    double defaultWidth = act.Name.Length * 10;
                    double defaultHeight = -1;
                    if (act.Type == "SequenceActivity")
                        defaultHeight = 0;
                    else
                        defaultHeight = 62;

                    act.setWidthAndHeight(defaultWidth, defaultHeight);

                    m_ListActivity.Add(act);
                    tr.Read(); tr.Read();
                }
            }
        }
        public override double getHeight()
        {
            List<double> listHeight = new List<double>();
            foreach (Activity act in m_ListActivity)
                listHeight.Add(act.Height);

            m_Height = getMaxInList(listHeight) + m_GapH;

            return m_Height;
        }
    }
}