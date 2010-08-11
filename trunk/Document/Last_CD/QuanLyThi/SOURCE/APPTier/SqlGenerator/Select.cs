using System;
using System.Collections.Generic;

using System.Text;

namespace SqlGenerator
{
    public class Select : SqlStatementComponent
    {
        private List<string> m_ListTableVariable;
        public Select(List<string> columnlist, List<string> tableVariable) : base(columnlist)
        {
            m_ListTableVariable = tableVariable;
        }


        /// <summary>
        /// tạo tự động chuỗi sql Select
        /// </summary>
        /// <returns></returns>
        public string generateSelect()
        {
            if (m_ListInput.Count != 0)
            {
                string res = "Select ";

                for (int i = 0; i < m_ListInput.Count; i++)
                    res += m_ListTableVariable[i] + "." + m_ListInput[i] + ", ";

                return res.Remove(res.Length - 2);   
            }

            return string.Empty;
        }
    }
}
