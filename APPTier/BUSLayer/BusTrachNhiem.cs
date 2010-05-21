
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
public class BusTrachNhiem
{

	public BusTrachNhiem()
	{
	}
	#region "ExportFile" 
	public DtoTrachNhiem getDataById(int Id)
	{
		DtoTrachNhiem data = null;
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			data = dTrachNhiem.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoTrachNhiem> getListDataBytenTN(string tenTN)
	{
		List<DtoTrachNhiem> lst = null;
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			lst = dTrachNhiem.getListDataBytenTN(tenTN);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTrachNhiem> getListDataBythuTuCongViec(int thuTuCongViec)
	{
		List<DtoTrachNhiem> lst = null;
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			lst = dTrachNhiem.getListDataBythuTuCongViec(thuTuCongViec);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTrachNhiem> getListDataByngayBatDauQuyDinh(int ngayBatDauQuyDinh)
	{
		List<DtoTrachNhiem> lst = null;
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			lst = dTrachNhiem.getListDataByngayBatDauQuyDinh(ngayBatDauQuyDinh);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTrachNhiem> getDataList()
	{
		List<DtoTrachNhiem> lst = null;
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			lst = dTrachNhiem.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTrachNhiem> getDataListSortBy(string col, bool flag)
	{
		List<DtoTrachNhiem> lst = null;
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			lst = dTrachNhiem.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoTrachNhiem data)
	{
		int Id = -1;
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			Id = dTrachNhiem.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoTrachNhiem data)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytenTN(string tenTN)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.deleteDataBytenTN(tenTN);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBythuTuCongViec(int thuTuCongViec)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.deleteDataBythuTuCongViec(thuTuCongViec);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayBatDauQuyDinh(int ngayBatDauQuyDinh)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.deleteDataByngayBatDauQuyDinh(ngayBatDauQuyDinh);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayKetThucQuyDinh(int ngayKetThucQuyDinh)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.deleteDataByngayKetThucQuyDinh(ngayKetThucQuyDinh);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoTrachNhiem data)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaTN(DtoTrachNhiem data,int maTN)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.updateDataBymaTN(data,maTN);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytenTN(DtoTrachNhiem data,string tenTN)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.updateDataBytenTN(data,tenTN);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBythuTuCongViec(DtoTrachNhiem data,int thuTuCongViec)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.updateDataBythuTuCongViec(data,thuTuCongViec);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayBatDauQuyDinh(DtoTrachNhiem data,int ngayBatDauQuyDinh)
	{
		try
		{
			DaoTrachNhiem dTrachNhiem = new DaoTrachNhiem();
			dTrachNhiem.updateDataByngayBatDauQuyDinh(data,ngayBatDauQuyDinh);
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
