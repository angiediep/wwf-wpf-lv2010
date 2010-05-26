
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
public class BusCongViec
{

	public BusCongViec()
	{
	}
	#region "ExportFile" 
	public DtoCongViec getDataById(int Id)
	{
		DtoCongViec data = null;
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			data = dCongViec.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoCongViec> getListDataBytenCV(string tenCV)
	{
		List<DtoCongViec> lst = null;
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			lst = dCongViec.getListDataBytenCV(tenCV);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoCongViec> getListDataByngayBatDau(int ngayBatDau)
	{
		List<DtoCongViec> lst = null;
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			lst = dCongViec.getListDataByngayBatDau(ngayBatDau);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoCongViec> getListDataByngayKetThuc(int ngayKetThuc)
	{
		List<DtoCongViec> lst = null;
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			lst = dCongViec.getListDataByngayKetThuc(ngayKetThuc);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoCongViec> getDataList()
	{
		List<DtoCongViec> lst = null;
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			lst = dCongViec.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoCongViec> getDataListSortBy(string col, bool flag)
	{
		List<DtoCongViec> lst = null;
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			lst = dCongViec.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoCongViec data)
	{
		int Id = -1;
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			Id = dCongViec.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoCongViec data)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenCV(string tenCV)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.deleteDataBytenCV(tenCV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayBatDau(int ngayBatDau)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.deleteDataByngayBatDau(ngayBatDau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayKetThuc(int ngayKetThuc)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.deleteDataByngayKetThuc(ngayKetThuc);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBymoTa(string moTa)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.deleteDataBymoTa(moTa);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoCongViec data)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaCV(DtoCongViec data,int maCV)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.updateDataBymaCV(data,maCV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenCV(DtoCongViec data,string tenCV)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.updateDataBytenCV(data,tenCV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayBatDau(DtoCongViec data,int ngayBatDau)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.updateDataByngayBatDau(data,ngayBatDau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayKetThuc(DtoCongViec data,int ngayKetThuc)
	{
		try
		{
			DaoCongViec dCongViec = new DaoCongViec();
			dCongViec.updateDataByngayKetThuc(data,ngayKetThuc);
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
