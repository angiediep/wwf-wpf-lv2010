
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
public class BusTienDo
{

	public BusTienDo()
	{
	}
	#region "ExportFile" 
	public DtoTienDo getDataById(int Id)
	{
		DtoTienDo data = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			data = dTienDo.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<DtoTienDo> getListDataBymaDT(int maDT)
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getListDataBymaDT(maDT);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTienDo> getListDataByngayPC(DateTime ngayPC)
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getListDataByngayPC(ngayPC);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTienDo> getListDataBykhoiLuongCVHT(int khoiLuongCVHT)
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getListDataBykhoiLuongCVHT(khoiLuongCVHT);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTienDo> getListDataBytongKhoiLuongCV(int tongKhoiLuongCV)
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getListDataBytongKhoiLuongCV(tongKhoiLuongCV);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTienDo> getListDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getListDataByngayBatDauThucTe(ngayBatDauThucTe);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTienDo> getListDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getListDataByngayKetThucThucTe(ngayKetThucThucTe);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTienDo> getListDataBymaTN(int maTN)
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getListDataBymaTN(maTN);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTienDo> getDataList()
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<DtoTienDo> getDataListSortBy(string col, bool flag)
	{
		List<DtoTienDo> lst = null;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			lst = dTienDo.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(DtoTienDo data)
	{
		int Id = -1;
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			Id = dTienDo.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(DtoTienDo data)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBymaDT(int maDT)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteDataBymaDT(maDT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayPC(DateTime ngayPC)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteDataByngayPC(ngayPC);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBykhoiLuongCVHT(int khoiLuongCVHT)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteDataBykhoiLuongCVHT(khoiLuongCVHT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBytongKhoiLuongCV(int tongKhoiLuongCV)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteDataBytongKhoiLuongCV(tongKhoiLuongCV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayBatDauThucTe(DateTime ngayBatDauThucTe)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteDataByngayBatDauThucTe(ngayBatDauThucTe);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByngayKetThucThucTe(DateTime ngayKetThucThucTe)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteDataByngayKetThucThucTe(ngayKetThucThucTe);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBymaTN(int maTN)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteDataBymaTN(maTN);
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
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.deleteDataBymaNV(maNV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(DtoTienDo data)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaTD(DtoTienDo data,int maTD)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBymaTD(data,maTD);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaDT(DtoTienDo data,int maDT)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBymaDT(data,maDT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayPC(DtoTienDo data,DateTime ngayPC)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataByngayPC(data,ngayPC);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBykhoiLuongCVHT(DtoTienDo data,int khoiLuongCVHT)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBykhoiLuongCVHT(data,khoiLuongCVHT);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBytongKhoiLuongCV(DtoTienDo data,int tongKhoiLuongCV)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBytongKhoiLuongCV(data,tongKhoiLuongCV);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayBatDauThucTe(DtoTienDo data,DateTime ngayBatDauThucTe)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataByngayBatDauThucTe(data,ngayBatDauThucTe);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByngayKetThucThucTe(DtoTienDo data,DateTime ngayKetThucThucTe)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataByngayKetThucThucTe(data,ngayKetThucThucTe);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBymaTN(DtoTienDo data,int maTN)
	{
		try
		{
			DaoTienDo dTienDo = new DaoTienDo();
			dTienDo.updateDataBymaTN(data,maTN);
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
