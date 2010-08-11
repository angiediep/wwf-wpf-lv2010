
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
public class BusQuanLy
{

	public BusQuanLy()
	{
	}
	#region "ExportFile" 
	public DtoQuanLy getDataById(string Id)
	{
		DtoQuanLy data = null;
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			data = dQuanLy.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoQuanLy> getListDataBymatKhau(string matKhau)
	{
		List<DtoQuanLy> lst = null;
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			lst = dQuanLy.getListDataBymatKhau(matKhau);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoQuanLy> getListDataBySALT(int SALT)
	{
		List<DtoQuanLy> lst = null;
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			lst = dQuanLy.getListDataBySALT(SALT);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoQuanLy> getDataList()
	{
		List<DtoQuanLy> lst = null;
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			lst = dQuanLy.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoQuanLy> getDataListSortBy(string col, bool flag)
	{
		List<DtoQuanLy> lst = null;
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			lst = dQuanLy.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoQuanLy data)
	{
		int Id = -1;
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			Id = dQuanLy.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoQuanLy data)
	{
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			dQuanLy.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBymatKhau(string matKhau)
	{
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			dQuanLy.deleteDataBymatKhau(matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBySALT(int SALT)
	{
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			dQuanLy.deleteDataBySALT(SALT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByemail(string email)
	{
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			dQuanLy.deleteDataByemail(email);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoQuanLy data, string tendangNhapCu)
	{
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
            dQuanLy.updateData(data, tendangNhapCu);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenDangNhap(DtoQuanLy data,string tenDangNhap)
	{
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			dQuanLy.updateDataBytenDangNhap(data,tenDangNhap);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymatKhau(DtoQuanLy data,string matKhau)
	{
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			dQuanLy.updateDataBymatKhau(data,matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBySALT(DtoQuanLy data,int SALT)
	{
		try
		{
			DaoQuanLy dQuanLy = new DaoQuanLy();
			dQuanLy.updateDataBySALT(data,SALT);
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
