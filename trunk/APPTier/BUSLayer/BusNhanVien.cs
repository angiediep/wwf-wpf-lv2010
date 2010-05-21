
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
public class BusNhanVien
{

	public BusNhanVien()
	{
	}
	#region "ExportFile" 
	public DtoNhanVien getDataById(int Id)
	{
		DtoNhanVien data = null;
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			data = dNhanVien.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoNhanVien> getListDataBymatKhau(string matKhau)
	{
		List<DtoNhanVien> lst = null;
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			lst = dNhanVien.getListDataBymatKhau(matKhau);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVien> getListDataBySALT(int SALT)
	{
		List<DtoNhanVien> lst = null;
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			lst = dNhanVien.getListDataBySALT(SALT);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVien> getListDataBytenNV(string tenNV)
	{
		List<DtoNhanVien> lst = null;
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			lst = dNhanVien.getListDataBytenNV(tenNV);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVien> getListDataByemail(string email)
	{
		List<DtoNhanVien> lst = null;
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			lst = dNhanVien.getListDataByemail(email);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVien> getDataList()
	{
		List<DtoNhanVien> lst = null;
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			lst = dNhanVien.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoNhanVien> getDataListSortBy(string col, bool flag)
	{
		List<DtoNhanVien> lst = null;
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			lst = dNhanVien.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoNhanVien data)
	{
		int Id = -1;
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			Id = dNhanVien.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoNhanVien data)
	{
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.deleteData(data);
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
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.deleteDataBymatKhau(matKhau);
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
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.deleteDataBySALT(SALT);
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
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.deleteDataBytenNV(tenNV);
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
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.deleteDataByemail(email);
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
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.deleteDataBydienThoai(dienThoai);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoNhanVien data)
	{
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaNV(DtoNhanVien data,int maNV)
	{
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.updateDataBymaNV(data,maNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymatKhau(DtoNhanVien data,string matKhau)
	{
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.updateDataBymatKhau(data,matKhau);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBySALT(DtoNhanVien data,int SALT)
	{
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.updateDataBySALT(data,SALT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenNV(DtoNhanVien data,string tenNV)
	{
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.updateDataBytenNV(data,tenNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByemail(DtoNhanVien data,string email)
	{
		try
		{
			DaoNhanVien dNhanVien = new DaoNhanVien();
			dNhanVien.updateDataByemail(data,email);
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

            DaoNhanVien dNhanVien = new DaoNhanVien();
            dt = dNhanVien.getDataTable();
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
