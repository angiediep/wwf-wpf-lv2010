
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

public class BusPhanCong
{

	public BusPhanCong()
	{
	}
	#region "ExportFile" 
    /// <summary>
    /// lấy thông tin phân công khi biết mã phân công
    /// </summary>
    /// <param name="Id">mã phân công</param>
    /// <returns></returns>
	public DtoPhanCong getDataById(int Id)
	{
		DtoPhanCong data = null;
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			data = dPhanCong.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
    /// <summary>
    /// lấy thông tin phân công của một nhân viên
    /// </summary>
    /// <param name="maNV">mã nhân viên</param>
    /// <returns></returns>
	public List<DtoPhanCong> getListDataBymaNV(int maNV)
	{
		List<DtoPhanCong> lst = null;
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			lst = dPhanCong.getListDataBymaNV(maNV);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy thông tin phân công có cùng ngày áp dụng. ngày áp dụng là ngày đầu tiên có hiệu lực của  sự phân công.
    /// </summary>
    /// <param name="ngayApDung">ngày áp dụng</param>
    /// <returns></returns>
	public List<DtoPhanCong> getListDataByngayApDung(DateTime ngayApDung)
	{
		List<DtoPhanCong> lst = null;
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			lst = dPhanCong.getListDataByngayApDung(ngayApDung);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy danh sách toàn bộ thông tin phân công.
    /// </summary>
    /// <returns></returns>
	public List<DtoPhanCong> getDataList()
	{
		List<DtoPhanCong> lst = null;
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			lst = dPhanCong.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy danh sách toàn bộ thông tin phân công có sắp xếp
    /// </summary>
    /// </summary>
    /// <param name="col">thứ tự cột cần sắp xếp</param>
    /// <param name="flag">
    /// true: sắp tăng,
    /// false: sắp giảm</param>
    /// <returns></returns>
	public List<DtoPhanCong> getDataListSortBy(string col, bool flag)
	{
		List<DtoPhanCong> lst = null;
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			lst = dPhanCong.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// thêm một phân công mới.
    /// </summary>
    /// <param name="data">đối tượng chứa thông tin phân công.</param>
    /// <returns></returns>
	public int insertData(DtoPhanCong data)
	{
		int Id = -1;
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			Id = dPhanCong.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
    /// <summary>
    /// xóa một phân công
    /// </summary>
    /// <param name="data">đối tượng chứa thông tin phân công cần xóa</param>
    /// <returns></returns>
	public bool deleteData(DtoPhanCong data)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// xóa  các thông tin phân công của một nhân viên
    /// </summary>
    /// <param name="maNV">mã nhân viên</param>
    /// <returns></returns>
	public bool deleteDataBymaNV(int maNV)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.deleteDataBymaNV(maNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// xóa  các thông tin phân công có cùng ngày áp dụng.
    /// </summary>
    /// <param name="ngayApDung">ngày áp dụng</param>
    /// <returns></returns>
	public bool deleteDataByngayApDung(DateTime ngayApDung)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.deleteDataByngayApDung(ngayApDung);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// xóa  các thông tin phân công có cùng ngày hết hạn.
    /// </summary>
    /// <param name="ngayHetHan">ngày hết hạn</param>
    /// <returns></returns>
	public bool deleteDataByngayHetHan(DateTime ngayHetHan)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.deleteDataByngayHetHan(ngayHetHan);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật một phân công
    /// </summary>
    /// <param name="data">đối tượng chứa thông tin phân công cần cập nhật</param>
    /// <returns></returns>
	public bool updateData(DtoPhanCong data)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật các  thông tin phân công của một công việc.
    /// </summary>
    /// <param name="data">đối tượng chứa dữ liệu mới</param>
    /// <param name="maCV">mã công việc</param>
    /// <returns></returns>
	public bool updateDataBymaCV(DtoPhanCong data,int maCV)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.updateDataBymaCV(data,maCV);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật các thông tin phân công của một nhân viên
    /// </summary>
    /// <param name="data"></param>
    /// <param name="maNV"></param>
    /// <returns></returns>
	public bool updateDataBymaNV(DtoPhanCong data,int maNV)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.updateDataBymaNV(data,maNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật các thông tin phân công có cùng ngày áp dụng
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="ngayApDung">ngày áp dụng</param>
    /// <returns></returns>
	public bool updateDataByngayApDung(DtoPhanCong data,DateTime ngayApDung)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.updateDataByngayApDung(data,ngayApDung);
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
