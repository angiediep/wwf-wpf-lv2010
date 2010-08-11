using System;
using System.Collections.Generic;

using System.Text;

namespace SqlGenerator
{
    public class Having : SqlStatementComponent
    {
        private List<string> m_ListValue;

        public List<string> ListValue
        {
            get { return m_ListValue; }
            set { m_ListValue = value; }
        }

        public Having(List<string> columnlist, List<string> values)
            : base(columnlist)
        {
            m_ListValue = values;
        }


        /// <summary>
        /// tạo tự động chuỗi sql Having
        /// </summary>
        /// <returns></returns>
        public override string generateStatement()
        {
            if (m_ListInput.Count != 0)
            {
                string res = " HAVING ";

                int j = 0;
                for (int i = 0; i < m_ListInput.Count; i += 2)
                {
                    res += m_ListInput[i] + "." + m_ListInput[i + 1] + " = ";

                    if (m_ListValue[i] == "1")
                        res += m_ListValue[i + 1] + ", ";
                    else
                        res += "N'" + m_ListValue[i + 1] + "', ";
                    j += 2;
                }

                return res.Remove(res.Length - 2);
            }

            return string.Empty;
        }
    }
}
