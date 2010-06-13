
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
public class BusGhiChu
{

	public BusGhiChu()
	{
	}
	#region "ExportFile" 
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
	public bool deleteDataByGhiChu(string GhiChu)
	{
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			dGhiChu.deleteDataByGhiChu(GhiChu);
		}
		catch
		{
			return false;
		}
		return true;
	}
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
	public bool updateDataByGhiChu(DtoGhiChu data,string GhiChu)
	{
		try
		{
			DaoGhiChu dGhiChu = new DaoGhiChu();
			dGhiChu.updateDataByGhiChu(data,GhiChu);
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
