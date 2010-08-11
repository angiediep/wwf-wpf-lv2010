using System;
using System.Collections.Generic;

using System.Text;

namespace SqlGenerator
{
    public class Where : SqlStatementComponent
    {
        private List<string> m_ListValue;

        public List<string> ListValue
        {
            get { return m_ListValue; }
            set { m_ListValue = value; }
        }

        public Where(List<string> columnlist, List<string> values)
            : base(columnlist)
        {
            m_ListValue = values;
        }


        /// <summary>
        /// tạo tự động chuỗi sql Where
        /// </summary>
        /// <returns></returns>
        public override string generateStatement()
        {
            if (m_ListInput.Count != 0)
            {
                string res = " WHERE ";

                int j = 0;
                for (int i = 0; i < m_ListInput.Count; i++)
                {
                    res += m_ListValue[j + 2] + ".";
                    res += m_ListInput[i] + " = ";

                    if (m_ListValue[j] == "1")
                        res += m_ListValue[j + 1] + " and ";
                    else
                        res += "N'" + m_ListValue[j + 1] + "'and ";

                    j += 3;
                }

                return res.Remove(res.Length - 4);
            }

            return string.Empty;
        }
    }
}
