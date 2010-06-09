
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
public class BusDotThi
{

	public BusDotThi()
	{
	}
	#region "ExportFile" 
	public DtoDotThi getDataById(int Id)
	{
		DtoDotThi data = null;
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			data = dDOTTHI.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoDotThi> getListDataBytenDotThi(string tenDotThi)
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			lst = dDOTTHI.getListDataBytenDotThi(tenDotThi);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoDotThi> getListDataByngayThi(DateTime ngayThi)
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			lst = dDOTTHI.getListDataByngayThi(ngayThi);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoDotThi> getDataList()
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			lst = dDOTTHI.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoDotThi> getDataListSortBy(string col, bool flag)
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			lst = dDOTTHI.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
    /// <summary>
    /// Thêm một đợt thi mới.
    /// </summary>
    /// <param name="data">Thông tin đợt thi cần tạo</param>
    /// <returns>
    /// 2: Thêm thành công nhưng có một số phân công đã hết hiệu lực. nhắc người quản lý phân công lại.
    /// 1: Thêm thành công. Không phát sinh lỗi.
    /// 0: Thêm không thành công. Lỗi không xác định.
    /// -1:THêm không thành công. Lỗi Ngày thi < ngày hiện hành.
    /// </returns>
	public int insertData(DtoDotThi data)
	{

        DaoDOTTHI dao = new DaoDOTTHI();
        try
        {
            return dao.insertData(data);
        }
        catch
        {
            return 0;
        }

	}
	public bool deleteData(DtoDotThi data)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenDotThi(string tenDotThi)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.deleteDataBytenDotThi(tenDotThi);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayThi(DateTime ngayThi)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.deleteDataByngayThi(ngayThi);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBysoLuongThiSinh(int soLuongThiSinh)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.deleteDataBysoLuongThiSinh(soLuongThiSinh);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoDotThi data)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaDT(DtoDotThi data,int maDT)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.updateDataBymaDT(data,maDT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenDotThi(DtoDotThi data,string tenDotThi)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.updateDataBytenDotThi(data,tenDotThi);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayThi(DtoDotThi data,DateTime ngayThi)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.updateDataByngayThi(data,ngayThi);
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
