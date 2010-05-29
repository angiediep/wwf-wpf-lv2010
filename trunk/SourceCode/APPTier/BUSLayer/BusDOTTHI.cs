
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
			DaoDotThi dDOTTHI = new DaoDotThi();
			data = dDOTTHI.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoDotThi> getListDataBytenDT(string tenDT)
	{
		List<DtoDotThi> lst = null;
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			lst = dDOTTHI.getListDataBytenDT(tenDT);
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
			DaoDotThi dDOTTHI = new DaoDotThi();
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
			DaoDotThi dDOTTHI = new DaoDotThi();
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
			DaoDotThi dDOTTHI = new DaoDotThi();
			lst = dDOTTHI.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoDotThi data)
	{
		int Id = -1;
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			Id = dDOTTHI.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoDotThi data)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenDT(string tenDT)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.deleteDataBytenDT(tenDT);
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
			DaoDotThi dDOTTHI = new DaoDotThi();
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
			DaoDotThi dDOTTHI = new DaoDotThi();
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
			DaoDotThi dDOTTHI = new DaoDotThi();
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
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.updateDataBymaDT(data,maDT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenDT(DtoDotThi data,string tenDT)
	{
		try
		{
			DaoDotThi dDOTTHI = new DaoDotThi();
			dDOTTHI.updateDataBytenDT(data,tenDT);
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
			DaoDotThi dDOTTHI = new DaoDotThi();
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
