
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
public class BusThongBao
{

    public BusThongBao()
    {
    }
    #region "ExportFile"
    public DtoThongBao getDataById(int Id)
    {
        DtoThongBao data = null;
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            data = dThongBao.getDataById(Id);
        }
        catch
        {
            return null;
        }
        return data;
    }
    public List<DtoThongBao> getListDataBynoiDung(string noiDung)
    {
        List<DtoThongBao> lst = null;
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            lst = dThongBao.getListDataBynoiDung(noiDung);
        }
        catch
        {
            return null;
        }
        return lst;
    }
    public List<DtoThongBao> getListDataBymaTD(int maTD)
    {
        List<DtoThongBao> lst = null;
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            lst = dThongBao.getListDataBymaTD(maTD);
        }
        catch
        {
            return null;
        }
        return lst;
    }
    public List<DtoThongBao> getDataList()
    {
        List<DtoThongBao> lst = null;
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            lst = dThongBao.getDataList();
        }
        catch
        {
            return null;
        }
        return lst;
    }
    public List<DtoThongBao> getDataListSortBy(string col, bool flag)
    {
        List<DtoThongBao> lst = null;
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            lst = dThongBao.getDataListSortBy(col, flag);
        }
        catch
        {
            return null;
        }
        return lst;
    }
    /// <summary>
    /// Lấy toàn bộ nội dung thông báo của một nhân viên.
    /// </summary>
    /// <param name="maNV"></param>
    /// <returns></returns>
    public List<DtoThongBao> getDataByMaNV(int maNV)
    {
        try
        {
            BusThongBao bus = new BusThongBao();
            List<DtoThongBao> lst = bus.getDataByMaNV(maNV);
            return lst;
        }
        catch
        {
            return null;
        }
    }
    public int insertData(DtoThongBao data)
    {
        int Id = -1;
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            Id = dThongBao.insertData(data);
        }
        catch
        {
            return -1;
        }
        return Id;
    }
    public bool deleteData(DtoThongBao data)
    {
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            dThongBao.deleteData(data);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool deleteDataBynoiDung(string noiDung)
    {
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            dThongBao.deleteDataBynoiDung(noiDung);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool deleteDataBymaTD(int maTD)
    {
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            dThongBao.deleteDataBymaTD(maTD);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool deleteDataBytrangThai(int trangThai)
    {
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            dThongBao.deleteDataBytrangThai(trangThai);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool updateData(DtoThongBao data)
    {
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            dThongBao.updateData(data);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool updateDataBymaTB(DtoThongBao data, int maTB)
    {
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            dThongBao.updateDataBymaTB(data, maTB);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool updateDataBynoiDung(DtoThongBao data, string noiDung)
    {
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            dThongBao.updateDataBynoiDung(data, noiDung);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool updateDataBymaTD(DtoThongBao data, int maTD)
    {
        try
        {
            DaoThongBao dThongBao = new DaoThongBao();
            dThongBao.updateDataBymaTD(data, maTD);
        }
        catch
        {
            return false;
        }
        return true;
    }


    /// <summary>
    /// tạo thông báo nhắc nhở nhân viên bắt đầu các công việc sắp tới và có nguy cơ trễ cao.
    /// </summary>
    /// <param name="strMess">Nội dung thông báo.</param>
    /// <param name="NumOfUpcomingDay">Ngưỡng trễ. Những công việc dự kiến bắt đầu trước NumOfComingDay sẽ 
    /// được thông báo. Nếu muốn thông báo cho các công việc đã trễ hạn bắt đầu, thông số này âm.</param>
    /// <returns></returns>
    public int createMessageForUpcomingTaskStarting(string strMess,  int NumOfUpcomingDay)
    {
        try
        {
            DaoThongBao dao = new DaoThongBao();
            int num = dao.createMessageForUpcomingTaskStarting(strMess, NumOfUpcomingDay);
            return num;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// tạo thông báo nhắc nhở nhân viên hoàn thành các công việc đang thực thi và có nguy cơ trễ cao.
    /// </summary>
    /// <param name="strMess">Nội dung thông báo.</param>
    /// <param name="NumOfUpcomingDay">Ngưỡng trễ. Những công việc dự kiến kết thúc trước NumOfComingDay sẽ 
    /// được thông báo. Nếu muốn thông báo cho các công việc đã trễ hạn kết thúc, thông số này âm.</param>
    /// <returns></returns>
    public int createMessageForUpcomingTaskCompletion(string strMess, int NumOfUpcomingDay)
    {
        try
        {
            DaoThongBao dao = new DaoThongBao();
            return dao.createMessageForUpcomingTaskCompletion(strMess, NumOfUpcomingDay);
        }
        catch
        {
            return 0;
        }
    }


    /// <summary>
    /// tạo thông báo nhắc nhở nhân viên bắt đầu một công việc sắp tới có tính
    /// chất quan trọng hoặc có nguy cơ trễ cao.
    /// </summary>
    /// <param name="strMess">Nội dung thông báo.</param>
    /// <param name="maCV">mã công việc cần thông báo.</param>
    /// <param name="NumOfUpcomingDay">Ngưỡng trễ. Những công việc dự kiến bắt đầu trước NumOfComingDay sẽ 
    /// được thông báo. Nếu muốn thông báo cho các công việc bắt đầu trễ hạn, thông số này âm.</param>
    /// <returns></returns>
    public int createMessageForUpcomingTaskStarting(string strMess,int maCV, int NumOfUpcomingDay)
    {
        try
        {
            DaoThongBao dao = new DaoThongBao();
            int num = dao.createMessageForUpcomingTaskCompletion(strMess,maCV, NumOfUpcomingDay);
            return num;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// tạo thông báo nhắc nhở nhân viên hoàn thành một công việc đang thực thi và có tinh
    /// chất quan trọng hoặc có nguy cơ trễ cao.
    /// </summary>
    /// <param name="strMess">Nội dung thông báo.</param>
    /// <param name="maCV">mã công việc cần tạo thông báo</param>
    /// <param name="NumOfUpcomingDay">Ngưỡng trễ. Những công việc dự kiến kết thúc trước NumOfComingDay sẽ 
    /// được thông báo. Nếu muốn thông báo cho các công việc kết thúc trễ hạn, thông số này âm.</param>
    /// <returns></returns>
    public int createMessageForUpcomingTaskCompletion(string strMess,int maCV, int NumOfUpcomingDay)
    {
        try
        {
            DaoThongBao dao = new DaoThongBao();
            return dao.createMessageForUpcomingTaskCompletion(strMess,maCV, NumOfUpcomingDay);
        }
        catch
        {
            return 0;
        }
    }
    #endregion
}
}
