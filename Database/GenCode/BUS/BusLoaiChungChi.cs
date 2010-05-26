
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using DAO;
using DTO;
namespace BUS
{
public class BusLoaiChungChi
{

	public BusLoaiChungChi()
	{
	}
	#region "ExportFile" 
	public DtoLoaiChungChi getDataById(int Id)
	{
		DtoLoaiChungChi data = null;
		try
		{
			DaoLoaiChungChi dLoaiChungChi = new DaoLoaiChungChi();
			data = dLoaiChungChi.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoLoaiChungChi> getDataList()
	{
		List<DtoLoaiChungChi> lst = null;
		try
		{
			DaoLoaiChungChi dLoaiChungChi = new DaoLoaiChungChi();
			lst = dLoaiChungChi.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoLoaiChungChi> getDataListSortBy(string col, bool flag)
	{
		List<DtoLoaiChungChi> lst = null;
		try
		{
			DaoLoaiChungChi dLoaiChungChi = new DaoLoaiChungChi();
			lst = dLoaiChungChi.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoLoaiChungChi data)
	{
		int Id = -1;
		try
		{
			DaoLoaiChungChi dLoaiChungChi = new DaoLoaiChungChi();
			Id = dLoaiChungChi.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoLoaiChungChi data)
	{
		try
		{
			DaoLoaiChungChi dLoaiChungChi = new DaoLoaiChungChi();
			dLoaiChungChi.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenLCC(string tenLCC)
	{
		try
		{
			DaoLoaiChungChi dLoaiChungChi = new DaoLoaiChungChi();
			dLoaiChungChi.deleteDataBytenLCC(tenLCC);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoLoaiChungChi data)
	{
		try
		{
			DaoLoaiChungChi dLoaiChungChi = new DaoLoaiChungChi();
			dLoaiChungChi.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaLCC(DtoLoaiChungChi data,int maLCC)
	{
		try
		{
			DaoLoaiChungChi dLoaiChungChi = new DaoLoaiChungChi();
			dLoaiChungChi.updateDataBymaLCC(data,maLCC);
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
