using System;
using System.Collections.Generic;

using System.Text;

namespace SqlGenerator
{
    public class OrderBy : SqlStatementComponent
    {
        private string m_ColumnName;
        private List<string> m_Value;

        public List<string> Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        public OrderBy(List<string> values)
        {
            m_Value = values;
        }


        /// <summary>
        /// tạo tự động chuỗi sql Order By
        /// </summary>
        /// <returns></returns>
        public override string generateStatement()
        {
            if (m_Value.Count != 0)
            {
                string res = " ORDER BY ";

                res += m_Value[0] + "." + m_Value[1] + " " + m_Value[2];

                return res;   
            }
            return string.Empty;
        }
    }
}
