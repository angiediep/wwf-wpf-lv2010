
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
    public class BusTienDo
    {
        public static int NGAYBATDAU;
        public static int NGAYKETTHUC;

        public BusTienDo()
        {
        }

        public static int getNgayBatDau()
        {
            NGAYBATDAU = new DaoTienDo().getNgayBatDau();
            return NGAYBATDAU;
        }

        public static int getNgayKetThuc()
        {
            NGAYKETTHUC = new DaoTienDo().getNgayKetThuc();
            return NGAYKETTHUC;
        }

        #region "ExportFile"
        public DtoTienDo getDataById(int Id)
        {
            DtoTienDo data = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                data = dTienDo.getDataById(Id);
            }
            catch
            {
                return null;
            }
            return data;
        }
        public List<DtoTienDo> getListDataBytongKhoiLuongCV(int tongKhoiLuongCV)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getListDataBytongKhoiLuongCV(tongKhoiLuongCV);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoTienDo> getListDataBykhoiLuongCVHT(int khoiLuongCVHT)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getListDataBykhoiLuongCVHT(khoiLuongCVHT);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoTienDo> getListDataByngayBatDauQuyDinh(DateTime ngayBatDauQuyDinh)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getListDataByngayBatDauQuyDinh(ngayBatDauQuyDinh);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoTienDo> getListDataByngayKetThucQuyDinh(DateTime ngayKetThucQuyDinh)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getListDataByngayKetThucQuyDinh(ngayKetThucQuyDinh);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoTienDo> getListDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getListDataByngayBatDauThucTe(ngayBatDauThucTe);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoTienDo> getListDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getListDataByngayKetThucThucTe(ngayKetThucThucTe);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoTienDo> getListDataBymaDT(int maDT)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getListDataBymaDT(maDT);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoTienDo> getListDataBymaCV(int maCV)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getListDataBymaCV(maCV);
            }
            catch
            {
                return null;
            }
            return lst;
        }
		 /// <summary>
    /// lấy danh sách công việc được phân công cho một nhân viên bất kỳ
    /// qua các kỳ thi.
    /// </summary>
    /// <param name="maNV">mã nhân viên cần xem danh sách phân công.</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataByMaNV(int maNV)
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataByMaNV(maNV);
        }
        catch
        {
            return null;
        }
    }
	/// <summary>
    /// lấy danh sách công việc được phân công cho một nhân viên bất kỳ
    /// qua các kỳ thi trong một khoảng thơi gian xác định.
    /// </summary>
    /// <param name="endDay">Ngày bắt đầu</param>
    /// <param name="startDay">Ngày kết thúc</param>
    /// <param name="maNV">mã nhân viên cần xem danh sách phân công.</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataByMaNV(int maNV,DateTime startDay, DateTime endDay)
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataByMaNV(maNV, startDay, endDay);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    /// <summary>
    /// Lấy danh sách công việc bị trễ hạn
    /// </summary>
    /// <param name="maDT"></param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataDelayedByMaDT(int maDT)
    {
        List<DtoTienDo> lst = null;
        try
        {
            DaoTienDo dao = new DaoTienDo();
            lst = dao.getListDataDelayedByMaDT(maDT);
        }
        catch
        {
            return null;
        }
        return lst;
    }
    /// <summary>
    /// Lấy danh sách công việc sớm hạn
    /// </summary>
    /// <param name="maDT"></param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataEarlyByMaDT(int maDT)
    {
        List<DtoTienDo> lst = null;
        try
        {
            DaoTienDo dao = new DaoTienDo();
            lst = dao.getListDataEarlyByMaDT(maDT);
        }
        catch
        {
            return null;
        }
        return lst;
    }
    /// <summary>
    /// Lấy toàn bộ nội dung theo dõi tiến độ của các công việc đã hoàn thành.
    /// </summary>
    /// <returns></returns>
    public List<DtoTienDo> getListDataCompleted()
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataCompleted();
        }
        catch
        {
            return null;
        }

    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ của các công việc đã hoàn thành trong một đợt thi bất kỳ.
    /// </summary>
    /// <param name="maDT">mã đợt thi cần lấy thông tin tiến độ.</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataCompletedByMaDT(int maDT)
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataCompletedByMaDT(maDT);
        }
        catch
        {
            return null;
        }

    }

    /// <summary>
    /// lấy thông tin theo dõi tiến độ của các công việc đã hoàn thành của một nhân viên
    /// </summary>
    /// <param name="maNV">Mã nhân viên</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataCompletedByMaNV(int maNV)
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataByMaNV(maNV);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy toàn bộ thông tin theo dõi tiến độ của các công việc đang diễn ra
    /// </summary>
    /// <returns></returns>
    public List<DtoTienDo> getListDataOnGoing()
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            List<DtoTienDo> lst = dao.getListDataOnGoing();
            return lst;
        }
        catch(Exception ex)
        {
            return null; 
        }
    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ của những công việc đang diễn ra trong một đợt thi bất kỳ
    /// </summary>
    /// <param name="maDT">Mã đợt thi</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataOnGoingByMaDT(int maDT)
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataOnGoingByMaDT(maDT);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ công việc đang thực hiện được phân công cho
    /// một nhân viên.
    /// </summary>
    /// <param name="maDT">Mã nhân viên</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataOnGoingByMaNV(int maNV)
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataOnGoingByMaNV(maNV);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ của tất cả các công việc sắp diễn ra.
    /// </summary>
    /// <returns></returns>
    public List<DtoTienDo> getListDataUpcoming()
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataUpcoming();
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy thông tin theo dõi tiến độ của tất cả các công việc sắp diễn ra trong một đợt thi cụ thể.
    /// </summary>
    /// <param name="maDT"></param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataUpcomingByMaDT(int maDT)
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataUpcomingByMaDT(maDT);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    /// <summary>
    /// Lấy thông tin tiến độ của các công việc chưa được thực hiện và được
    /// phân công cho một nhân viên cụ thể.
    /// </summary>
    ///<param name="maNV">Mã nhân viên</param>
    /// <returns></returns>
    public List<DtoTienDo> getListDataUpcomingByMaNV(int maNV)
    {
        try
        {
            DaoTienDo dao = new DaoTienDo();
            return dao.getListDataUpcomingByMaNV(maNV);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
        public List<DtoTienDo> getDataList()
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getDataList();
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public List<DtoTienDo> getDataListSortBy(string col, bool flag)
        {
            List<DtoTienDo> lst = null;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                lst = dTienDo.getDataListSortBy(col, flag);
            }
            catch
            {
                return null;
            }
            return lst;
        }
        public int insertData(DtoTienDo data)
        {
            int Id = -1;
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                Id = dTienDo.insertData(data);
            }
            catch
            {
                return -1;
            }
            return Id;
        }
        public bool deleteData(DtoTienDo data)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteData(data);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataBytongKhoiLuongCV(int tongKhoiLuongCV)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataBytongKhoiLuongCV(tongKhoiLuongCV);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataBykhoiLuongCVHT(int khoiLuongCVHT)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataBykhoiLuongCVHT(khoiLuongCVHT);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataByngayBatDauQuyDinh(DateTime ngayBatDauQuyDinh)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataByngayBatDauQuyDinh(ngayBatDauQuyDinh);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataByngayKetThucQuyDinh(DateTime ngayKetThucQuyDinh)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataByngayKetThucQuyDinh(ngayKetThucQuyDinh);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataByngayBatDauThucTe(ngayBatDauThucTe);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataByngayKetThucThucTe(ngayKetThucThucTe);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataBymaDT(int maDT)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataBymaDT(maDT);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataBymaCV(int maCV)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataBymaCV(maCV);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteDataBymaNV(int maNV)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.deleteDataBymaNV(maNV);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateData(DtoTienDo data)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateData(data);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataBymaTD(DtoTienDo data, int maTD)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataBymaTD(data, maTD);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataBytongKhoiLuongCV(DtoTienDo data, int tongKhoiLuongCV)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataBytongKhoiLuongCV(data, tongKhoiLuongCV);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataBykhoiLuongCVHT(DtoTienDo data, int khoiLuongCVHT)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataBykhoiLuongCVHT(data, khoiLuongCVHT);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataByngayBatDauQuyDinh(DtoTienDo data, DateTime ngayBatDauQuyDinh)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataByngayBatDauQuyDinh(data, ngayBatDauQuyDinh);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataByngayKetThucQuyDinh(DtoTienDo data, DateTime ngayKetThucQuyDinh)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataByngayKetThucQuyDinh(data, ngayKetThucQuyDinh);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataByngayBatDauThucTe(DtoTienDo data, DateTime ngayBatDauThucTe)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataByngayBatDauThucTe(data, ngayBatDauThucTe);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataByngayKetThucThucTe(DtoTienDo data, DateTime ngayKetThucThucTe)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataByngayKetThucThucTe(data, ngayKetThucThucTe);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataBymaDT(DtoTienDo data, int maDT)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataBymaDT(data, maDT);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateDataBymaCV(DtoTienDo data, int maCV)
        {
            try
            {
                DaoTienDo dTienDo = new DaoTienDo();
                dTienDo.updateDataBymaCV(data, maCV);
            }
            catch
            {
                return false;
            }
            return true;
        }
		
    /// <summary>
    /// 
    /// </summary>
    /// <param name="maTD"></param>
    /// <returns>
    /// 0: Lỗi khôn xác định
    /// -1: Sự kiện không không chuyển tới workflow được.
    /// 1: không có lỗi.
    /// </returns>
    public int startWork(int maTD)
    {
        try
        {
            DaoTienDo daoTienDo = new DaoTienDo();
            DtoTienDo dtoTienDo = daoTienDo.getDataById(maTD);
            BusDotThi busDotThi = new BusDotThi();
            DtoDotThi dtoDotThi = busDotThi.getDataById(dtoTienDo.MADT);
            BusCongViec busCongViec = new BusCongViec();
            DtoCongViec dtoCongViec = busCongViec.getDataById(dtoTienDo.MACV);

            DataConnector dataConnector = new DataConnector();

            Guid id = new Guid(dtoDotThi.WORKFLOWINSTANCEID);
            WorkflowRuntime runtime = new WorkflowRuntime();

            ExternalDataExchangeService exchangeService = new ExternalDataExchangeService();
            runtime.AddService(exchangeService);
            DataExchangeServiceWithinCorrelation localService = new DataExchangeServiceWithinCorrelation();
            exchangeService.AddService(localService);

            SqlWorkflowPersistenceService persistenceService = new SqlWorkflowPersistenceService(dataConnector.getPersistenceServiceConnectionString());
            runtime.AddService(persistenceService);

            runtime.StartRuntime();
            WorkflowInstance instance = runtime.GetWorkflow(id);
            instance.Load();
            DataEventArgs args = new DataEventArgs(instance.InstanceId, dtoCongViec.TENCV);
            localService.OnStart(args);

            instance.Unload();
            daoTienDo.startWork(maTD);

        }
        catch (EventDeliveryFailedException ex)
        {
            return -1;
        }
        catch (Exception ex)
        {

            return 0;
        }
        return 1;
    }
    public int finishWork(int maTD)
    {   try
        {
            DaoTienDo daoTienDo = new DaoTienDo();
            DtoTienDo dtoTienDo = daoTienDo.getDataById(maTD);
            BusDotThi busDotThi = new BusDotThi();
            DtoDotThi dtoDotThi = busDotThi.getDataById(dtoTienDo.MADT);
            BusCongViec busCongViec = new BusCongViec();
            DtoCongViec dtoCongViec = busCongViec.getDataById(dtoTienDo.MACV);

            DataConnector dataConnector = new DataConnector();

     
            Guid id = new Guid(dtoDotThi.WORKFLOWINSTANCEID);
            WorkflowRuntime runtime = new WorkflowRuntime();

            ExternalDataExchangeService exchangeService = new ExternalDataExchangeService();
            runtime.AddService(exchangeService);
            DataExchangeServiceWithinCorrelation localService = new DataExchangeServiceWithinCorrelation();
            exchangeService.AddService(localService);

            SqlWorkflowPersistenceService persistenceService = new SqlWorkflowPersistenceService(dataConnector.getPersistenceServiceConnectionString());
            runtime.AddService(persistenceService);

            runtime.StartRuntime();
            WorkflowInstance instance = runtime.GetWorkflow(id);
            instance.Load();
            DataEventArgs args = new DataEventArgs(instance.InstanceId, dtoCongViec.TENCV);
            localService.OnFinish(args);

            instance.Unload();
            daoTienDo.finishWork(maTD);

        }
        catch
        {
            return 0;
        }
        return 1;

    }
        #endregion

        public List<string> getListNVofCV(int p)
        {
            List<int> lstMaNV = new DaoTienDo().getListNVofCV(p);
            List<string> res = new List<string>();
            for (int i = 0; i < lstMaNV.Count; i++)
            {
                res.Add(new BusNhanVienThuaHanh().getTenNVByMaNV(lstMaNV[i]));
            }
            return res;
        }

        public List<KeyValuePair<string, int>> getDataForChart()
        {
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();

            List<int> MonthYear = getMonthYearForChart();
            for (int i = 0; i < MonthYear.Count; i += 2)
            {
                int month = MonthYear[i];
                int year = MonthYear[i + 1];
                if (month > 0 && year > 0)
                {
                    int sum = new BusTienDo().getTongKLCVByMonthYear(month, year);
                    if (sum > 0)
                        res.Add(new KeyValuePair<string, int>(month + "/" + year, sum));
                }
            }

            return res;
        }

        public List<KeyValuePair<string, int>> getDataForChart(int y, int m)
        {
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();

            List<string> lTenDT = getDotThiByMonthYear(y, m);
            for (int i = 0; i < lTenDT.Count; i += 2)
            {
                string tenDT = lTenDT[i + 1];
                int tongKLCV = getTongKLCVByMaDT(int.Parse(lTenDT[i]));
                res.Add(new KeyValuePair<string, int>(tenDT, tongKLCV));
            }

            return res;
        }

        private int getTongKLCVByMaDT(int p)
        {
            return new DaoTienDo().getTongKLCVByMaDT(p);
        }

        private int getTongKLCVByMonthYear(int month, int year)
        {
            return new DaoTienDo().getTongKLCVByMonthYear(month, year);
        }

        private List<int> getMonthYearForChart()
        {
            return new DaoTienDo().getMonthYearForChart();
        }

        public int getSumTS()
        {
            return new DaoTienDo().getSumTS();
        }

        public int getSumTS(string tenDT)
        {
            return new DaoTienDo().getSumTS(tenDT);
        }

        public int getSumCC()
        {
            return new DaoTienDo().getSumCC();
        }

        public int getSumCC(string tenDT)
        {
            return new DaoTienDo().getSumCC(tenDT);
        }

        public List<KeyValuePair<string, int>> getDataForChart2()
        {
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();

            List<int> MonthYear = getMonthYearForChart2();
            for (int i = 0; i < MonthYear.Count; i += 2)
            {
                int month = MonthYear[i];
                int year = MonthYear[i + 1];
                if (month > 0 && year > 0)
                {
                    int sum = new BusTienDo().getTongKLCVByMonthYear2(month, year);
                    if (sum > 0)
                        res.Add(new KeyValuePair<string, int>(month + "/" + year, sum));
                }
            }

            return res;
        }

        private int getTongKLCVByMonthYear2(int month, int year)
        {
            return new DaoTienDo().getTongKLCVByMonthYear2(month, year);
        }

        private List<int> getMonthYearForChart2()
        {
            return new DaoTienDo().getMonthYearForChart2();
        }

        public int getCVHoanThanhDungHanCT()
        {
            return new DaoTienDo().getCVHoanThanhDungHanCT();
        }

        public int getCVHoanThanhDungHanCT(string tenDT)
        {
            return new DaoTienDo().getCVHoanThanhDungHanCT(tenDT);
        }

        public int getCVHoanThanhTreHanCT()
        {
            return new DaoTienDo().getCVHoanThanhTreHanCT();
        }

        public int getCVHoanThanhTreHanCT(string tenDT)
        {
            return new DaoTienDo().getCVHoanThanhTreHanCT(tenDT);
        }

        public int getCVHoanThanhDungHanCDT(string tenDT)
        {
            return new DaoTienDo().getCVHoanThanhDungHanCDT(tenDT);
        }

        public int getCVHoanThanhDungHanCDT()
        {
            return new DaoTienDo().getCVHoanThanhDungHanCDT();
        }

        public int getCVHoanThanhTreHanCDT()
        {
            return new DaoTienDo().getCVHoanThanhTreHanCDT();
        }

        public int getCVHoanThanhTreHanCDT(string tenDT)
        {
            return new DaoTienDo().getCVHoanThanhTreHanCDT(tenDT);
        }

        public int getCVHoanThanhDungHanCHT()
        {
            return new DaoTienDo().getCVHoanThanhDungHanCHT();
        }

        public int getCVHoanThanhDungHanCHT(string tenDT)
        {
            return new DaoTienDo().getCVHoanThanhDungHanCHT(tenDT);
        }

        public int getCVHoanThanhTreHanCHT()
        {
            return new DaoTienDo().getCVHoanThanhTreHanCHT();
        }

        public int getCVHoanThanhTreHanCHT(string tenDT)
        {
            return new DaoTienDo().getCVHoanThanhTreHanCHT(tenDT);
        }

        public int getCVHoanThanhDungHanCCI()
        {
            return new DaoTienDo().getCVHoanThanhDungHanCCI();
        }

        public int getCVHoanThanhDungHanCCI(string tenDT)
        {
            return new DaoTienDo().getCVHoanThanhDungHanCCI(tenDT);
        }

        public int getCVHoanThanhTreHanCCI()
        {
            return new DaoTienDo().getCVHoanThanhTreHanCCI();
        }

        public int getCVHoanThanhTreHanCCI(string tenDT)
        {
            return new DaoTienDo().getCVHoanThanhTreHanCCI(tenDT);
        }

        public List<KeyValuePair<string, int>> getDataForChart3()
        {
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();

            List<int> MonthYear = getMonthYearForChart();
            for (int i = 0; i < MonthYear.Count; i += 2)
            {
                int month = MonthYear[i];
                int year = MonthYear[i + 1];
                if (month > 0 && year > 0)
                {
                    int sum = new BusTienDo().getCVChuaHTQuaCacDot(month, year);
                    if (sum > 0)
                        res.Add(new KeyValuePair<string, int>(month + "/" + year, sum));
                }
            }

            return res;
        }

        private int getCVChuaHTQuaCacDot(int month, int year)
        {
            return new DaoTienDo().getCVChuaHTQuaCacDot(month, year);
        }

        public string getChiTietTungThoiKy()
        {
            string res = string.Empty;

            List<int> MonthYear = getMonthYearForChart();
            int count = 1;
            for (int i = 0; i < MonthYear.Count; i += 2)
            {
                int month = MonthYear[i];
                int year = MonthYear[i + 1];
                if (month > 0 && year > 0)
                {
                    res += count + ". Tháng " + month + "/" + year + " :\r\n\t";
                    List<string> dt = getDotThiByMonthYear(month, year);
                    if (dt.Count > 0 && dt[0] != string.Empty && dt[1] != string.Empty)
                    {
                        res += "Tên đợt Thi : " + dt[1] + "\r\n\t";
                        List<string> l = getDotThiNVDetail(month, year, int.Parse(dt[0]));
                        for (int j = 0; j < l.Count; j += 4)
                            res += "\tCông việc " + l[j] + " : " + int.Parse(l[j + 1]) + " hoàn thành - Nhân viên phụ trách: " + l[j + 2] + " - Nguyên nhân: " + l[j + 3] + "\r\n\t";
                    }
                    res += "\r\n";
                    count++;
                }
            }

            return res;
        }

        private List<string> getDotThiNVDetail(int month, int year, int p)
        {
            return new DaoTienDo().getDotThiNVDetail(month, year, p);
        }

        private List<string> getDotThiByMonthYear(int month, int year)
        {
            return new DaoTienDo().getDotThiByMonthYear(month, year);
        }

        public string getNVTreHan()
        {
            string res = string.Empty;

            List<string> data = new BusNhanVienThuaHanh().getNVTreHan();
            int count = 1;
            for (int i = 0; i < data.Count; i += 3)
            {
                res += count + ". " + data[i] + " : Tháng " + int.Parse(data[i + 1]) + "/" + int.Parse(data[i + 2]) + ".\r\n";
                count++;
            }

            return res;            
        }

        public string getNVTreHan(string tenDT)
        {
            string res = string.Empty;

            List<string> data = new BusNhanVienThuaHanh().getNVTreHan(tenDT);
            int count = 1;
            for (int i = 0; i < data.Count; i += 4)
            {
                res += count + ". Công việc " + data[i] + " : " + int.Parse(data[i + 1]) + "% - Do " + data[i + 2] + " phụ trách. Nguyên nhân: " + data[i + 3] + ".\r\n";
                count++;
            }

            return res;
        }

        public List<int> getListYearForComparisonStat()
        {
            return new DaoTienDo().getListYearForComparisonStat();
        }

        public List<int> getListMonthForComparisonStat(int year)
        {
            return new DaoTienDo().getListMonthForComparisonStat(year);
        }

        public int getSumTS(int y, int m)
        {
            return new DaoTienDo().getSumTS(y, m);
        }

        public int getSumCC(int y, int m)
        {
            return new DaoTienDo().getSumCC(y, m);
        }

        public int getCVHoanThanhDungHanCT(int y, int m)
        {
            return new DaoTienDo().getCVHoanThanhDungHanCT(y, m);
        }

        public int getCVHoanThanhTreHanCT(int y, int m)
        {
            return new DaoTienDo().getCVHoanThanhTreHanCT(y, m);
        }

        public int getCVHoanThanhDungHanCDT(int y, int m)
        {
            return new DaoTienDo().getCVHoanThanhDungHanCDT(y, m);
        }

        public int getCVHoanThanhTreHanCDT(int y, int m)
        {
            return new DaoTienDo().getCVHoanThanhTreHanCDT(y, m);
        }

        public int getCVHoanThanhDungHanCHT(int y, int m)
        {
            return new DaoTienDo().getCVHoanThanhDungHanCHT(y, m);
        }

        public int getCVHoanThanhTreHanCHT(int y, int m)
        {
            return new DaoTienDo().getCVHoanThanhTreHanCHT(y, m);
        }

        public int getCVHoanThanhDungHanCCI(int y, int m)
        {
            return new DaoTienDo().getCVHoanThanhDungHanCCI(y, m);
        }

        public int getCVHoanThanhTreHanCCI(int y, int m)
        {
            return new DaoTienDo().getCVHoanThanhTreHanCCI(y, m);
        }

        public string getChiTietTungThoiKy(int y, int m)
        {
            string res = string.Empty;
            List<string> lTenDT = getDotThiByMonthYear(y,m);
            int count = 1;
            for (int i = 0; i < lTenDT.Count; i += 2)
            {
                List<string> str = getNVTreHan(int.Parse(lTenDT[i]),y,m);
                if (str.Count != 0)
                {
                    res += count + ". Đợt thi " + lTenDT[i + 1] + " : Công việc " + str[0] + " : " + int.Parse(str[1]) + "% - Do " + str[2] + " phụ trách. Nguyên nhân: " + str[3] + ".\r\n";
                    count++;
                }
            }

            return res;
        }

        private List<string> getNVTreHan(int p, int y, int m)
        {
            return new DaoTienDo().getNVTreHan(p, y, m);
        }

        public string getNVTreHan(int y, int m)
        {
            string res = string.Empty;
            List<string> listNV = getNVTreHanXXX(y, m);
            int count = 1;
            for (int i = 0; i < listNV.Count; i += 2)
            {
                res += count + ". Nhân viên " + listNV[i] + " : Đợt thi: " + listNV[i + 1] + ".\r\n";
                count++;
            }

            return res;
        }

        private List<string> getNVTreHanXXX(int y, int m)
        {
            return new DaoTienDo().getNVTreHanXXX(y,m);
        }

        public List<KeyValuePair<string, int>> getDataForChart2(int y, int m)
        {
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();

            List<string> lTenDT = getDotThiByMonthYear(y, m);
            for (int i = 0; i < lTenDT.Count; i += 2)
            {
                string tenDT = lTenDT[i + 1];
                int tongKLCV = getTongKLCVByMaDT2(int.Parse(lTenDT[i]));
                res.Add(new KeyValuePair<string, int>(tenDT, tongKLCV));
            }

            return res;
        }

        private int getTongKLCVByMaDT2(int p)
        {
            return new DaoTienDo().getTongKLCVByMaDT2(p);
        }

        public List<KeyValuePair<string, int>> getDataForChart3(int y, int m)
        {
            List<KeyValuePair<string, int>> res = new List<KeyValuePair<string, int>>();

            List<string> lTenDT = getDotThiByMonthYear(y, m);
            for (int i = 0; i < lTenDT.Count; i += 2)
            {
                string tenDT = lTenDT[i + 1];
                int tongKLCV = getTongKLCVByMonYear(y,m);
                res.Add(new KeyValuePair<string, int>(tenDT, tongKLCV));
            }

            return res;
        }

        private int getTongKLCVByMonYear(int y, int m)
        {
            return new DaoTienDo().getTongKLCVByMonYear(y,m);
        }

        public List<string> getMsgToAlert(string p, int type)
        {
            List<string> info = new DaoTienDo().getMsgToAlert(p, type);
            List<string> res = new List<string>();
            int jump = (type == 5) ? 5 : 4;
            for (int i = 0; i < info.Count; i+=jump)
            {
                string str = string.Empty;

                switch (type)
                {
                    case 1:
                        str += "Công việc bạn được phân công cần được thực hiện vào hôm sau. Vui lòng thực hiện công việc đúng thời hạn.\r\n";
                        break;
                    case 2:
                        str += "Công việc bạn được phân công cần được kết thúc vào hôm sau. Vui lòng kết thúc công việc đúng thời hạn.\r\n";
                        break;
                    case 3:
                        str += "Công việc bạn được phân công cần được thực hiện vào hôm nay. Vui lòng thực hiện công việc ngay khi có thể.\r\n";
                        break;
                    case 4:
                        str += "Công việc bạn được phân công cần được kết thúc trong hôm nay. Vui lòng hoàn thành công việc thời hạn. Nếu không bạn sẽ bị trễ hạn.\r\n";
                        break;
                    case 5:
                        str += "Công việc bạn được phân công đã kết thúc và bị trễ hạn. Vui lòng cập nhân nguyên nhân gây trễ hạn ngay khi có thể.\r\n";
                        break;
                }
                str += "Công Việc: " + new BusCongViec().getTenCVByMaCV(int.Parse(info[i + 1])) + "\r\n";
                str += "Đợt thi: " + new BusDotThi().getTenDTByMaDT(int.Parse(info[i])) + "\r\n";
                str += "Ngày thực hiện theo quy định: " + info[i + 2] + "\r\n";
                if (type == 5)
                    str += "Ngày kết thúc thực tế: " + info[i + 4] + "\r\n";
                res.Add(str);
                res.Add(info[i + 3]);
            }
            return res;
        }

        public List<int> getAllTDOfNV(int p)
        {
            return new DaoTienDo().getAllTDOfNV(p);   
        }

        public List<string> getDataByMaDTAndMaCV(int maDT, int maCV)
        {
            List<string> res = new List<string>();
            res.Add(new BusCongViec().getTenCVByMaCV(maCV));
            List<string> temp = new DaoTienDo().getDataByMaDTAndMaCV(maDT, maCV);
            res.Add(temp[0]);
            res.Add(temp[1]);
            return res;
        }

        public void updateDataByMaCVAndMaDT(DtoTienDo td)
        {
            new DaoTienDo().updateDataByMaCVAndMaDT(td);
        }

        public void updateNBDQDAndNKTQD(int m_MaCV, int nbd, int nkt)
        {
            List<DtoTienDo> listdto = new BusTienDo().getListDataBymaCV(m_MaCV);
            foreach (DtoTienDo dto in listdto)
            {
                //new BusTienDo().upda;
            }
        }
    }
}
