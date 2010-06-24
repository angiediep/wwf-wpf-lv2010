
using System;
using System.Collections.Generic;
using DataLayer.DAO;
using DataLayer.DTO;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using QuanLyThiWorkflow;
namespace BUSLayer
{
/// <summary>
/// Lớp đối tượng chịu trách nhiệm xử lý các vấn đề nghiệp vụ, cung cấp phương thức
/// phục vụ cho các chức năng bên trên tầng giao diện
/// </summary>
public class BusTienDo
{

	public BusTienDo()
	{
	}
	#region "ExportFile" 
    /// <summary>
    /// Lấy thực thể TienDo khi biết mã tiến độ.
    /// </summary>
    /// <param name="Id">mã tiến độ</param>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc có cùng khối lượng công việc.
    /// </summary>
    /// <param name="tongKhoiLuongCV">Khối lượng công việc</param>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc có cùng khối lượng công việc đã hoàn thành
    /// </summary>
    /// <param name="khoiLuongCVHT">Khối lượng công việc hoàn thành</param>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc có cùng ngày bắt đầu quy định
    /// </summary>
    /// <param name="ngayBatDauQuyDinh">Ngày bắt đầu quy định</param>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc có cùng Ngày kết thúc quy định.
    /// </summary>
    /// <param name="ngayKetThucQuyDinh">Ngày kết thúc quy định</param>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc có cùng ngày bắt đầu thực tế.
    /// </summary>
    /// <param name="ngayBatDauThucTe">Ngày bắt đầu thực tế</param>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc có cùng ngày kết thúc thực tế.
    /// </summary>
    /// <param name="ngayKetThucThucTe">ngày kết thúc thực tế</param>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc trong cùng một đợt thi.
    /// </summary>
    /// <param name="maDT">mã đợt thi</param>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy danh sách thông tin theo dõi tiến độ của một công việc trong các đợt thi khác nhau.
    /// </summary>
    /// <param name="maCV">mã công việc</param>
    /// <returns></returns>
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
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc được phân công cho một nhân viên bất kỳ
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
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc được phân công cho một nhân viên bất kỳ
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
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc  kết thúc trễ hạn.
    /// </summary>
    /// <param name="maDT">mã đợt thi</param>
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
    /// Lấy danh sách thông tin theo dõi tiến độ của các công việc kết thúc sớm hạn.
    /// </summary>
    /// <param name="maDT">mã đợt thi</param>
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
    /// lấy thông tin theo dõi tiến độ của các công việc đã được một nhân viên cụ thể hoàn thành.
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
    /// Lấy thông tin theo dõi tiến độ công việc đang thực hiện và được phân công cho
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
    /// Lấy thông tin theo dõi tiến độ của tất cả các công việc chưa được thực hiện
    /// trong một đợt thi cụ thể.
    /// </summary>
    /// <param name="maDT">mã đợt thi</param>
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
    /// <summary>
    /// Lấy toàn bộ thông tin theo dõi tiến độ của tất cả công việc trong tất cả các kỳ thi.
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Lấy toàn bộ thông tin theo dõi tiến độ của tất cả công việc trong tất cả các kỳ thi. Dữ liệu
    /// trả về được sắp xếp theo yêu cầu.
    /// </summary>
    /// <param name="col">Cột cần sắp xếp.</param>
    /// <param name="flag">
    /// true: sắp tăng
    /// false: sắp giảm</param>
    /// <returns></returns>
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
    /// <summary>
    /// Thêm một thông tin theo dõi tiến độ mới.
    /// </summary>
    /// <param name="data">Thực thể chứa dữ liệu cần thêm.</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ.
    /// </summary>
    /// <param name="data">Thực thể chứa thông tin cần xóa</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của các công việc có cùng tổng khối lượng công việc.
    /// </summary>
    /// <param name="tongKhoiLuongCV">Tổng khối lượng công việc.</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của các công việc có cùng khối lượng công việc hoàn thành.
    /// </summary>
    /// <param name="khoiLuongCVHT">Khối lượng công việc hoàn thành</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của các công việc có cùng ngày bắt đầu quy định
    /// </summary>
    /// <param name="ngayBatDauQuyDinh">ngày bắt đầu quy định</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của các công việc có cùng ngày kết thúc quy định
    /// </summary>
    /// <param name="ngayKetThucQuyDinh">ngày kết thúc quy định</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của các công việc có cùng ngày bắt đầu thực tế
    /// </summary>
    /// <param name="ngayBatDauThucTe">ngày bắt đầu thực tế</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của các công việc có cùng ngày kết thúc thực tế
    /// </summary>
    /// <param name="ngayKetThucThucTe">ngày kết thúc thực tế</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của các công việc thuộc cùng một đợt thi
    /// </summary>
    /// <param name="maDT">mã đợt thi</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của cùng một công việc trong các kỳ thi khác nhau.
    /// </summary>
    /// <param name="maCV">mã công việc.</param>
    /// <returns></returns>
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
    /// <summary>
    /// xóa thông tin theo dõi tiến độ thực hiện của các công việc cùng được phân công cho một nhân viên
    /// </summary>
    /// <param name="maNV">mã nhân viên</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật dữ liệu tiến độ mới
    /// </summary>
    /// <param name="data">Đối tượng chứa dữ liệu mới.</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của công việc khi biết mã tiến độ
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="maTD">mã tiến độ</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của các công việc có cùng tổng khối lượng công việc
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="tongKhoiLuongCV">tổng khối lượng công việc</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của các công việc có cùng khối lượng công việc hoàn thành.
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="khoiLuongCVHT">khối lượng công việc hoàn thành.</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của các công việc có cùng ngày bắt đầu quy định
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="ngayBatDauQuyDinh">ngày bắt đầu quy định</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của các công việc có cùng ngày kết thúc quy định
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="ngayKetThucQuyDinh">ngày kết thúc quy định</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của các công việc có cùng ngày bắt đầu thực tế.
    /// </summary>
    /// <param name="data">dữ liệu mới.</param>
    /// <param name="ngayBatDauThucTe">ngày bắt đầu thực tế</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của các công việc có cùng ngày kết thúc thực tế
    /// </summary>
    /// <param name="data">dữ liệu mới.</param>
    /// <param name="ngayKetThucThucTe">ngày kết thúc thực tế.</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của các công việc thuộc cùng một đợt thi.
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="maDT">mã đợt thi</param>
    /// <returns></returns>
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
    /// <summary>
    /// cập nhật thông tin theo dõi tiến độ thực hiện của cùng một công việc qua các đợt thi khác nhau.
    /// </summary>
    /// <param name="data">dữ liệu mới.</param>
    /// <param name="maCV">mã công việc</param>
    /// <returns></returns>
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

    /// <summary>
    /// bắt đầu thực hiện công việc được theo dõi bởi thể hiện tiến độ cho trước.
    /// </summary>
    /// <param name="maTD">mã tiến độ</param>
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
    /// <summary>
    /// kết thúc thực hiện công việc được theo dõi bởi thể hiện tiến độ cho trước.
    /// </summary>
    /// <param name="maTD">mã tiến độ</param>
    /// <returns>
    /// 0: Lỗi khôn xác định
    /// -1: Sự kiện không không chuyển tới workflow được.
    /// 1: không có lỗi.
    /// </returns>
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
}

}
