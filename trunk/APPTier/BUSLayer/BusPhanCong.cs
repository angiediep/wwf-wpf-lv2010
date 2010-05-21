
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
	public bool updateDataBymaTN(DtoPhanCong data,int maTN)
	{
		try
		{
			DaoPhanCong dPhanCong = new DaoPhanCong();
			dPhanCong.updateDataBymaTN(data,maTN);
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
