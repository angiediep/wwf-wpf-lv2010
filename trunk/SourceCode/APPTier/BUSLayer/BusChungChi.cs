
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
public class BusChungChi
{

	public BusChungChi()
	{
	}
	#region "ExportFile" 
	public DtoChungChi getDataById(int Id)
	{
		DtoChungChi data = null;
		try
		{
			DaoChungChi dChungChi = new DaoChungChi();
			data = dChungChi.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoChungChi> getDataList()
	{
		List<DtoChungChi> lst = null;
		try
		{
			DaoChungChi dChungChi = new DaoChungChi();
			lst = dChungChi.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoChungChi> getDataListSortBy(string col, bool flag)
	{
		List<DtoChungChi> lst = null;
		try
		{
			DaoChungChi dChungChi = new DaoChungChi();
			lst = dChungChi.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoChungChi data)
	{
		int Id = -1;
		try
		{
			DaoChungChi dChungChi = new DaoChungChi();
			Id = dChungChi.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoChungChi data)
	{
		try
		{
			DaoChungChi dChungChi = new DaoChungChi();
			dChungChi.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenCC(string tenCC)
	{
		try
		{
			DaoChungChi dChungChi = new DaoChungChi();
			dChungChi.deleteDataBytenCC(tenCC);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoChungChi data)
	{
		try
		{
			DaoChungChi dChungChi = new DaoChungChi();
			dChungChi.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaCC(DtoChungChi data,int maCC)
	{
		try
		{
			DaoChungChi dChungChi = new DaoChungChi();
			dChungChi.updateDataBymaCC(data,maCC);
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
