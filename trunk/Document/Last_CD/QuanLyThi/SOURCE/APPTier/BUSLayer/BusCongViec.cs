
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using DataLayer.DAO;
using DataLayer.DTO;
namespace BUSLayer
{
    public class BusCongViec
    {
        public BusCongViec()
        {
        }
          #region "ExportFile"
        public DtoCongViec getDataById(int Id)
        {
            DtoCongViec data = null;
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                data = dCongViec.getDataById(Id);
            }
            catch
            {
                return null;
            }
            return data;
        }
        public List<DtoCongViec> getListDataBytenCV(string tenCV)
        {
            List<DtoCongViec> lst = null;
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                lst = dCongViec.getListDataBytenCV(tenCV);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoCongViec> getListDataByngayBatDau(int ngayBatDau)
        {
            List<DtoCongViec> lst = null;
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                lst = dCongViec.getListDataByngayBatDau(ngayBatDau);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoCongViec> getListDataByngayKetThuc(int ngayKetThuc)
        {
            List<DtoCongViec> lst = null;
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                lst = dCongViec.getListDataByngayKetThuc(ngayKetThuc);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        /// <summary>
        /// Lấy danh sách công việc mà một nhân viên đã từng được phân công
        /// </summary>
        /// <param name="maNV">mã nhân viên</param>
        /// <returns></returns>
        public List<DtoCongViec> getListDataByMaNV(int maNV)
        {
            try
            {
                DaoCongViec dao = new DaoCongViec();
                return dao.getListDataByMaNV(maNV);
            }
            catch
            {
                return null;
            }
        }
        public List<DtoCongViec> getDataList()
        {
            List<DtoCongViec> lst = null;
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                lst = dCongViec.getDataList();
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoCongViec> getDataListSortBy(string col, bool flag)
        {
            List<DtoCongViec> lst = null;
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                lst = dCongViec.getDataListSortBy(col, flag);
            }
            catch
            {
                return null;
            }
            return lst;
        }

        public int insertData(DtoCongViec data)
        {
            int Id = -1;
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                Id = dCongViec.insertData(data);
            }
            catch
            {
                return -1;
            }
            return Id;
        }
        public bool deleteData(DtoCongViec data)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.deleteData(data);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataBytenCV(string tenCV)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.deleteDataBytenCV(tenCV);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataByngayBatDau(int ngayBatDau)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.deleteDataByngayBatDau(ngayBatDau);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataByngayKetThuc(int ngayKetThuc)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.deleteDataByngayKetThuc(ngayKetThuc);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataBymoTa(string moTa)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.deleteDataBymoTa(moTa);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateData(DtoCongViec data)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.updateData(data);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataBymaCV(DtoCongViec data, int maCV)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.updateDataBymaCV(data, maCV);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataBytenCV(DtoCongViec data, string tenCV)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.updateDataBytenCV(data, tenCV);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataByngayBatDau(DtoCongViec data, int ngayBatDau)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.updateDataByngayBatDau(data, ngayBatDau);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataByngayKetThuc(DtoCongViec data, int ngayKetThuc)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                dCongViec.updateDataByngayKetThuc(data, ngayKetThuc);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int getNumOfLateCompletion(int maCV)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                return dCongViec.getNumOfLateCompletion(maCV);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int getNumOfEarlyCompletion(int maCV)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                return dCongViec.getNumOfEarlyCompletion(maCV);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int getNumOfExecution(int maCV)
        {
            try
            {
                DaoCongViec dCongViec = new DaoCongViec();
                return dCongViec.getNumOfExecution(maCV);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// lấy danh sách công việc hoàn thành theo các tiêu chí khác nhau
        /// </summary>
        /// <param name="maDT"> mã đợt thi
        /// 0: xét tất cả các đợt thi
        /// > 0: xét một đợt thi cụ thể
        /// </param>
        /// <param name="maNV"> mã nhân viên
        /// 0: xét công việc được phân công cho bất kỳ nhân viên nào
        /// >0: xét công việc được phân công cho một nhân viên cụ thể
        /// </param>
        /// <param name="completingStatus"> tình trạng hoàn thành.
        ///1: trễ hạn
        ///0: đúng hạn
        ///-1: sớm hạn
        /// </param>
        /// <param name="from">giới hạn thời gian thực tế công việc được thực thi.
        /// null: không giới hạn thời gian
        /// != null:chỉ xét các công việc diễn ra trong thời gian này.
        /// from và to là hai tham số phải đồng thời null hoặc khác null.
        /// </param>
        /// <param name="to">
        /// giới hạn thời gian thực tế công việc được thực thi.
        /// null: không giới hạn thời gian
        /// != null:chỉ xét các công việc diễn ra trong thời gian này.
        /// from và to là hai tham số phải đồng thời null hoặc khác null.
        /// </param>
        /// <returns></returns>
        public List<DtoCongViec> getListDataCompleted(int maDT, int maNV, int completingStatus, DateTime from, DateTime to)
        {
            if (maDT < 0 || maNV < 0 || completingStatus > 1 || completingStatus < -1)
                throw new Exception("tham số không hợp lệ");
            if (from == null && to != null)
                throw new Exception("Tham số không hợp lệ");
            if (from != null && to == null)
                throw new Exception("Tham số không hợp lệ");
            try
            {
                DaoCongViec dao = new DaoCongViec();
                List<DtoCongViec> lst = dao.getListDataCompleted(maDT, maNV, completingStatus, from, to);
                return lst;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// lấy danh sách công việc bắt đầu theo các tiêu chí khác nhau
        /// </summary>
        /// <param name="maDT"> mã đợt thi
        /// 0: xét tất cả các đợt thi
        /// > 0: xét một đợt thi cụ thể
        /// </param>
        /// <param name="maNV"> mã nhân viên
        /// 0: xét công việc được phân công cho bất kỳ nhân viên nào
        /// >0: xét công việc được phân công cho một nhân viên cụ thể
        /// </param>
        /// <param name="completingStatus"> tình trạng bắt đầu.
        ///1: trễ hạn
        ///0: đúng hạn
        ///-1: sớm hạn
        /// </param>
        /// <param name="from">giới hạn thời gian thực tế công việc được thực thi.
        /// null: không giới hạn thời gian
        /// != null:chỉ xét các công việc diễn ra trong thời gian này.
        /// from và to là hai tham số phải đồng thời null hoặc khác null.
        /// </param>
        /// <param name="to">
        /// giới hạn thời gian thực tế công việc được thực thi.
        /// null: không giới hạn thời gian
        /// != null:chỉ xét các công việc diễn ra trong thời gian này.
        /// from và to là hai tham số phải đồng thời null hoặc khác null.
        /// </param>
        /// <returns></returns>
        public List<DtoCongViec> getListDataSatrted(int maDT, int maNV, int startingStatus, DateTime from, DateTime to)
        {
            if (maDT < 0 || maNV < 0 || startingStatus > 1 || startingStatus < -1)
                throw new Exception("tham số không hợp lệ");
            if (from == null && to != null)
                throw new Exception("Tham số không hợp lệ");
            if (from != null && to == null)
                throw new Exception("Tham số không hợp lệ");
            try
            {
                DaoCongViec dao = new DaoCongViec();
                List<DtoCongViec> lst = dao.getListDataSatrted(maDT, maNV, startingStatus, from, to);
                return lst;
            }
            catch
            {
                return null;

            }
        }

        #endregion

        public string getTenCVByMaCV(int maCV)
        {
            return new DaoCongViec().getTenCVByMaCV(maCV);
        }

        public List<string> getListNVofCV(string tenCV)
        {
            return new DaoCongViec().getListNVofCV(tenCV);
        }

        public int getMaCVByTenCV(string p)
        {
            return new DaoCongViec().getMaCVByTenCV(p);
        }

        public void updateNBDvaNKTByMaCV(int nbd, int nkt, int m_MaCV)
        {
            new DaoCongViec().updateNBDvaNKTByMaCV(nbd, nkt, m_MaCV);
        }

        public DataTable getData()
        {
            return new DaoCongViec().getData();
        }

        public string getMoTaByTenCV(string p)
        {
            return new DaoCongViec().getMoTaByTenCV(p);
        }

        public string getTenCVByMoTaCV(string p)
        {
            return new DaoCongViec().getTenCVByMoTaCV(p);
        }

        public int getMaCVByMoTaCV(string p)
        {
            return new DaoCongViec().getMaCVByMoTaCV(p);
        }

        public string getMotaCVByMaCV(int p)
        {
            return new DaoCongViec().getMotaCVByMaCV(p);
        }
    }

}
