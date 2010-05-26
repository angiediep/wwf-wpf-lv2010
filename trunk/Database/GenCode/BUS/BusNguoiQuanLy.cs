
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
public class BusNguoiQuanLy
{

	public BusNguoiQuanLy()
	{
	}
	#region "ExportFile" 
	public DtoNguoiQuanLy getDataById(string Id)
	{
		DtoNguoiQuanLy data = null;
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			data = dNguoiQuanLy.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoNguoiQuanLy> getListDataBymatKhau(string matKhau)
	{
		List<DtoNguoiQuanLy> lst = null;
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			lst = dNguoiQuanLy.getListDataBymatKhau(matKhau);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNguoiQuanLy> getListDataBySALT(int SALT)
	{
		List<DtoNguoiQuanLy> lst = null;
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			lst = dNguoiQuanLy.getListDataBySALT(SALT);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNguoiQuanLy> getDataList()
	{
		List<DtoNguoiQuanLy> lst = null;
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			lst = dNguoiQuanLy.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNguoiQuanLy> getDataListSortBy(string col, bool flag)
	{
		List<DtoNguoiQuanLy> lst = null;
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			lst = dNguoiQuanLy.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoNguoiQuanLy data)
	{
		int Id = -1;
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			Id = dNguoiQuanLy.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoNguoiQuanLy data)
	{
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			dNguoiQuanLy.deleteData(data);
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
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			dNguoiQuanLy.deleteDataBymatKhau(matKhau);
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
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			dNguoiQuanLy.deleteDataBySALT(SALT);
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
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			dNguoiQuanLy.deleteDataByemail(email);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoNguoiQuanLy data)
	{
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			dNguoiQuanLy.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenDangNhap(DtoNguoiQuanLy data,string tenDangNhap)
	{
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			dNguoiQuanLy.updateDataBytenDangNhap(data,tenDangNhap);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymatKhau(DtoNguoiQuanLy data,string matKhau)
	{
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			dNguoiQuanLy.updateDataBymatKhau(data,matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBySALT(DtoNguoiQuanLy data,int SALT)
	{
		try
		{
			DaoNguoiQuanLy dNguoiQuanLy = new DaoNguoiQuanLy();
			dNguoiQuanLy.updateDataBySALT(data,SALT);
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
