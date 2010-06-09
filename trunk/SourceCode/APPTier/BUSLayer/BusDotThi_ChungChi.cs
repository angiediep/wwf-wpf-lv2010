
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
public class BusDotThi_ChungChi
{

	public BusDotThi_ChungChi()
	{
	}
	#region "ExportFile" 
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
