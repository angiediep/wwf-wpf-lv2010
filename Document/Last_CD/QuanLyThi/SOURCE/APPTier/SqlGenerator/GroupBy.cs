using System;
using System.Collections.Generic;

using System.Text;

namespace SqlGenerator
{
    public class GroupBy : SqlStatementComponent
    {
        private string m_GroupBy;
        private List<string> m_Tables;

        public List<string> Tables
        {
            get { return m_Tables; }
            set { m_Tables = value; }
        }

        public string GroupByStatement
        {
            get { return m_GroupBy; }
            set { m_GroupBy = value; m_GroupBy = m_GroupBy.Remove(0, 7); }
        }

        public GroupBy(List<string> columns, List<string> tables) : base(columns)
        {
            m_Tables = tables;
        }


        /// <summary>
        /// tạo tự động chuỗi sql Group By
        /// </summary>
        /// <returns></returns>
        public override string generateStatement()
        {
            if (m_Tables.Count != 0)
            {
                string res = " GROUP BY ";
                for (int i = 0; i < m_ListInput.Count; i++)
                    res += m_Tables[i] + "." + m_ListInput[i] + ", ";
                return res.Remove(res.Length - 2);
            }

            return string.Empty;
        }
    }
}
