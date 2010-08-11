using System;
using System.Collections.Generic;

using System.Text;

namespace SqlGenerator
{
    abstract public class SqlStatementComponent
    {
        protected List<string> m_ListInput;

        public List<string> ListInput
        {
            get { return m_ListInput; }
            set { m_ListInput = value; }
        }

        public SqlStatementComponent(List<string> input)
        {
            m_ListInput = input;
        }
        public SqlStatementComponent()
        {
            m_ListInput = new List<string>();
        }

        virtual public string generateStatement() { return string.Empty; }
    }
}