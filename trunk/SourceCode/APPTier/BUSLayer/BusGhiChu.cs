
using System.Collections.Generic;
using DataLayer.DAO;
using DataLayer.DTO;
namespace BUSLayer
{
public class BusGhiChu
{

	public BusGhiChu()
	{
	}
	#region "ExportFile" 
    /// <summary>
    /// lấy thông tin ghi chú khi biết mã ghi chú.
    /// </summary>
    /// <param name="Id">mã ghi chú</param>
    /// <returns></returns>
	public DtoGhiChu getDataById(int Id)
	{
		DtoGhiChu data = null;
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			data = dGhiChu.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
    /// <summary>
    /// lấy thông tin ghi chú của một thể hiện tiến độ
    /// </summary>
    /// <param name="maTD">mã tiến độ</param>
    /// <returns></returns>
	public DtoGhiChu getDataByMaTD(int maTD)
	{
		List<DtoGhiChu> lst = null;
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			lst = dGhiChu.getListDataByMaTD(maTD);
            return lst[0];
		}
		catch
		{
			return null;
		}
	}
    /// <summary>
    /// lấy danh sách ghi chú trong quá trình thực thi công việc trong một đợt thi xác định.
    /// </summary>
    /// <param name="maCV">mã công việc</param>
    /// <param name="maDT">mã đợt thi</param>
    /// <returns></returns>
    public DtoGhiChu getListDataByMaCVMaDT(int maCV, int maDT)
    {
        List<DtoGhiChu> lst = null;
        try
        {
            DaoGhiChu dGhiChu = new DaoGhiChu();
            lst = dGhiChu.getListDataByMaCVMaDT(maCV, maDT);
            return lst[0];
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// lấy danh sách toàn bộ thông tin ghi chú.
    /// </summary>
    /// <returns></returns>
	public List<DtoGhiChu> getDataList()
	{
		List<DtoGhiChu> lst = null;
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			lst = dGhiChu.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy danh sách toàn bộ thông tin ghi chú có sắp xếp
    /// </summary>
    /// <param name="col">số thứ tự cột cần sắp xếp</param>
    /// <param name="flag">
    /// true: sắp tăng.
    /// false: sắp giảm.</param>
    /// <returns></returns>
	public List<DtoGhiChu> getDataListSortBy(string col, bool flag)
	{
		List<DtoGhiChu> lst = null;
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			lst = dGhiChu.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// Thêm thông tin ghi chú mới
    /// </summary>
    /// <param name="data">Đối tượng chứa thông tin ghi chú cần thêm.</param>
    /// <returns></returns>
	public int insertData(DtoGhiChu data)
	{
		int Id = -1;
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			Id = dGhiChu.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
    /// <summary>
    /// xóa nội dung ghi chú
    /// </summary>
    /// <param name="data">thông tin ghi chú cần xóa.</param>
    /// <returns></returns>
	public bool deleteData(DtoGhiChu data)
	{
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			dGhiChu.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// xóa thông tin ghi chú khi biết mã tiến độ
    /// </summary>
    /// <param name="maTD">mã tiến độ</param>
    /// <returns></returns>
    public bool deleteDataBymaTD(int maTD)
	{
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			dGhiChu.deleteDataBymaTD(maTD);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật thông tin ghi chú.
    /// </summary>
    /// <param name="data">thông tin ghi chú mới.</param>
    /// <returns></returns>
	public bool updateData(DtoGhiChu data)
	{
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			dGhiChu.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật thông tin ghi chú khi biết mã ghi chú.
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="maGC">mã ghi chú</param>
    /// <returns></returns>
	public bool updateDataBymaGC(DtoGhiChu data,int maGC)
	{
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			dGhiChu.updateDataBymaGC(data,maGC);
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
