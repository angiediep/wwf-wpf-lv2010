using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BUSLayer;

namespace ModelReader
{
    public class StatusGetter
    {
        public int getStatus()
        {
            int ngaybatdau = BusTienDo.getNgayBatDau();
            int ngayketthuc = BusTienDo.getNgayKetThuc();



            return 1;
        }
    }
}
