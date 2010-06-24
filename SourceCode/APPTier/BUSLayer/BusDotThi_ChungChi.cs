
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
    /// <summary>
    /// 
    /// </summary>
public class BusDotThi_ChungChi
{

	public BusDotThi_ChungChi()
	{
	}
	#region "ExportFile" 
    /// <summary>
    /// lấy dữ liệu khi biết mã Đợt thi chứng chỉ
    /// </summary>
    /// <param name="Id">mã đợt thi chứng chỉ.</param>
    /// <returns></returns>
	public DtoDotThi_ChungChi getDataById(int Id)
	{
		DtoDotThi_ChungChi data = null;
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			data = dDotThi_ChungChi.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
    /// <summary>
    /// lấy danh sách thông tin khi biết mã chứng chỉ
    /// </summary>
    /// <param name="maCC">mã chứng chỉ</param>
    /// <returns></returns>
	public List<DtoDotThi_ChungChi> getListDataBymaCC(int maCC)
	{
		List<DtoDotThi_ChungChi> lst = null;
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			lst = dDotThi_ChungChi.getListDataBymaCC(maCC);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy danh sách toàn bộ thông tin đợt thi _ Chứng chỉ.
    /// </summary>
    /// <returns></returns>
	public List<DtoDotThi_ChungChi> getDataList()
	{
		List<DtoDotThi_ChungChi> lst = null;
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			lst = dDotThi_ChungChi.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// lấy danh sách toàn bộ thông tin đợt thi _ chứng chỉ có sắp xếp.
    /// </summary>
    /// <param name="col">thứ tự cột cần sắp xếp.</param>
    /// <param name="flag">true: sắp tăng,
    /// false: sắp giảm.</param>
    /// <returns></returns>
	public List<DtoDotThi_ChungChi> getDataListSortBy(string col, bool flag)
	{
		List<DtoDotThi_ChungChi> lst = null;
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			lst = dDotThi_ChungChi.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// thêm thông tin đợt thi chứng chỉ.
    /// </summary>
    /// <param name="data">dữ liệu mới cần thêm.</param>
    /// <returns></returns>
	public int insertData(DtoDotThi_ChungChi data)
	{
		int Id = -1;
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			Id = dDotThi_ChungChi.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
    /// <summary>
    /// xóa thông tin đợt thi chứng chỉ
    /// </summary>
    /// <param name="data">đối tượng chứa thông tin cần xóa.</param>
    /// <returns></returns>
	public bool deleteData(DtoDotThi_ChungChi data)
	{
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			dDotThi_ChungChi.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// xóa thông tin khi biết mã chứng chỉ.
    /// </summary>
    /// <param name="maCC"></param>
    /// <returns></returns>
	public bool deleteDataBymaCC(int maCC)
	{
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			dDotThi_ChungChi.deleteDataBymaCC(maCC);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// xóa thông tin khi biết số lượng thí sinh.
    /// </summary>
    /// <param name="soLuongThiSinh"></param>
    /// <returns></returns>
	public bool deleteDataBysoLuongThiSinh(int soLuongThiSinh)
	{
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			dDotThi_ChungChi.deleteDataBysoLuongThiSinh(soLuongThiSinh);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật thông tin đợt thi chứng chỉ.
    /// </summary>
    /// <param name="data">dữ liệu mới.</param>
    /// <returns></returns>
	public bool updateData(DtoDotThi_ChungChi data)
	{
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			dDotThi_ChungChi.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật thông tin khi biết mã đợt thi
    /// </summary>
    /// <param name="data">dữ liệu mới.</param>
    /// <param name="maDT">mã đợt thi</param>
    /// <returns></returns>
	public bool updateDataBymaDT(DtoDotThi_ChungChi data,int maDT)
	{
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			dDotThi_ChungChi.updateDataBymaDT(data,maDT);
		}
		catch
		{
			return false;
		}
		return true;
	}
    /// <summary>
    /// cập nhật thông tin khi biết mã chứng chỉ
    /// </summary>
    /// <param name="data">dữ liệu mới</param>
    /// <param name="maCC">mã chứng chỉ</param>
    /// <returns></returns>
	public bool updateDataBymaCC(DtoDotThi_ChungChi data,int maCC)
	{
		try
		{
			DaoDotThi_ChungChi dDotThi_ChungChi = new DaoDotThi_ChungChi();
			dDotThi_ChungChi.updateDataBymaCC(data,maCC);
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
