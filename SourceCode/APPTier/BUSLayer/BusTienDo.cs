
using System;
using System.Collections.Generic;
using DataLayer.DAO;
using DataLayer.DTO;
namespace BUSLayer
{
public class BusTienDo
{

	public BusTienDo()
	{
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
		catch(Exception ex)
		{
            string str = ex.Message;
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
		catch (Exception ex)
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
		catch ( Exception ex)
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaTD(DtoTienDo data,int maTD)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBymaTD(data,maTD);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytongKhoiLuongCV(DtoTienDo data,int tongKhoiLuongCV)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBytongKhoiLuongCV(data,tongKhoiLuongCV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBykhoiLuongCVHT(DtoTienDo data,int khoiLuongCVHT)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBykhoiLuongCVHT(data,khoiLuongCVHT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayBatDauQuyDinh(DtoTienDo data,DateTime ngayBatDauQuyDinh)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataByngayBatDauQuyDinh(data,ngayBatDauQuyDinh);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayKetThucQuyDinh(DtoTienDo data,DateTime ngayKetThucQuyDinh)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataByngayKetThucQuyDinh(data,ngayKetThucQuyDinh);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayBatDauThucTe(DtoTienDo data,DateTime ngayBatDauThucTe)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataByngayBatDauThucTe(data,ngayBatDauThucTe);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayKetThucThucTe(DtoTienDo data,DateTime ngayKetThucThucTe)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataByngayKetThucThucTe(data,ngayKetThucThucTe);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaDT(DtoTienDo data,int maDT)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBymaDT(data,maDT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaCV(DtoTienDo data,int maCV)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBymaCV(data,maCV);
		}
		catch
		{
			return false;
		}
		return true;
	}

	#endregion
}

}
