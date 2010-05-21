
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
public class BusDOTTHI
{

	public BusDOTTHI()
	{
	}
	#region "ExportFile" 
	public DtoDOTTHI getDataById(int Id)
	{
		DtoDOTTHI data = null;
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
	public List<DtoDOTTHI> getListDataBymaLoaiCC(int maLoaiCC)
	{
		List<DtoDOTTHI> lst = null;
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			lst = dDOTTHI.getListDataBymaLoaiCC(maLoaiCC);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoDOTTHI> getListDataByngayThi(DateTime ngayThi)
	{
		List<DtoDOTTHI> lst = null;
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
	public List<DtoDOTTHI> getDataList()
	{
		List<DtoDOTTHI> lst = null;
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
	public List<DtoDOTTHI> getDataListSortBy(string col, bool flag)
	{
		List<DtoDOTTHI> lst = null;
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
	public int insertData(DtoDOTTHI data)
	{
		int Id = -1;
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			Id = dDOTTHI.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoDOTTHI data)
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
	public bool deleteDataBymaLoaiCC(int maLoaiCC)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.deleteDataBymaLoaiCC(maLoaiCC);
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
	public bool updateData(DtoDOTTHI data)
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
	public bool updateDataBymaDT(DtoDOTTHI data,int maDT)
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
	public bool updateDataBymaLoaiCC(DtoDOTTHI data,int maLoaiCC)
	{
		try
		{
			DaoDOTTHI dDOTTHI = new DaoDOTTHI();
			dDOTTHI.updateDataBymaLoaiCC(data,maLoaiCC);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayThi(DtoDOTTHI data,DateTime ngayThi)
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

    public DataTable getDataTable()
    {
        DataTable dt = new DataTable();
        try
        {

            DaoDOTTHI dDotThi = new DaoDOTTHI();
            dt = dDotThi.getDataTable();
        }
        catch
        {
            return null;
        }
        return dt;
    }

	#endregion
}

}
