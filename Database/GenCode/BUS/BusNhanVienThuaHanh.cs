
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
public class BusNhanVienThuaHanh
{

	public BusNhanVienThuaHanh()
	{
	}
	#region "ExportFile" 
	public DtoNhanVienThuaHanh getDataById(int Id)
	{
		DtoNhanVienThuaHanh data = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			data = dNhanVienThuaHanh.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoNhanVienThuaHanh> getListDataBytenDangNhap(string tenDangNhap)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBytenDangNhap(tenDangNhap);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataBymatKhau(string matKhau)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBymatKhau(matKhau);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataBySALT(int SALT)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBySALT(SALT);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataByemail(string email)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataByemail(email);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getListDataBytenNV(string tenNV)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getListDataBytenNV(tenNV);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getDataList()
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVienThuaHanh> getDataListSortBy(string col, bool flag)
	{
		List<DtoNhanVienThuaHanh> lst = null;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			lst = dNhanVienThuaHanh.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoNhanVienThuaHanh data)
	{
		int Id = -1;
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			Id = dNhanVienThuaHanh.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoNhanVienThuaHanh data)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenDangNhap(string tenDangNhap)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBytenDangNhap(tenDangNhap);
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
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBymatKhau(matKhau);
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
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBySALT(SALT);
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
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataByemail(email);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenNV(string tenNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBytenNV(tenNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBydienThoai(string dienThoai)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.deleteDataBydienThoai(dienThoai);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoNhanVienThuaHanh data)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaNV(DtoNhanVienThuaHanh data,int maNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBymaNV(data,maNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenDangNhap(DtoNhanVienThuaHanh data,string tenDangNhap)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBytenDangNhap(data,tenDangNhap);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymatKhau(DtoNhanVienThuaHanh data,string matKhau)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBymatKhau(data,matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBySALT(DtoNhanVienThuaHanh data,int SALT)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBySALT(data,SALT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByemail(DtoNhanVienThuaHanh data,string email)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataByemail(data,email);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenNV(DtoNhanVienThuaHanh data,string tenNV)
	{
		try
		{
			DaoNhanVienThuaHanh dNhanVienThuaHanh = new DaoNhanVienThuaHanh();
			dNhanVienThuaHanh.updateDataBytenNV(data,tenNV);
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
