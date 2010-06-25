using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.DTO;
using BUSLayer;

namespace APPTier
{
    public class DotThiBar
    {
        int m_Startindex = -1;
        int m_EndIndex = -1;

        public int Startindex
        {
            get { return m_Startindex; }
            set { m_Startindex = value; }
        }
        public int EndIndex
        {
            get { return m_EndIndex; }
            set { m_EndIndex = value; }
        }

        public DotThiBar(DtoDotThi dto, DateTime start)
        {
            m_Startindex = dto.NGAYTHI.Subtract(new TimeSpan(BusTienDo.NGAYBATDAU, 0, 0, 0)).Subtract(start).Days;
            m_EndIndex = dto.NGAYTHI.Add(new TimeSpan(BusTienDo.NGAYKETTHUC, 0, 0, 0)).Subtract(start).Days;
        }

        public DotThiBar(DtoTienDo dto, DateTime start)
        {
            m_Startindex = dto.NGAYBATDAUTHUCTE.Subtract(start).Days;
            m_EndIndex = dto.NGAYKETTHUCTHUCTE.Subtract(start).Days;
        }
    }
}
