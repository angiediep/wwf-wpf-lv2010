using System;
using System.Collections.Generic;

using System.Text;

namespace SqlGenerator
{
    public class From : SqlStatementComponent
    {
        public From(List<string> tablelist) : base (tablelist)
        {
        }


        /// <summary>
        /// tạo tự động chuỗi sql From
        /// </summary>
        /// <returns></returns>
        public override string generateStatement()
        {
            string res = " FROM ";

            for (int i = 0; i < m_ListInput.Count; i++)
            {
                string variableTableName = NameConverter.getTableVariableNameByDatabaseName(m_ListInput[i]);
                res += m_ListInput[i] + " " + variableTableName + ", ";
            }

            return res.Remove(res.Length - 2);
        }
    }
}