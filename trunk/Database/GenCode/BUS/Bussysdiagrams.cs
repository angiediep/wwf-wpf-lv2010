
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
public class Bussysdiagrams
{

	public Bussysdiagrams()
	{
	}
	#region "ExportFile" 
	public Dtosysdiagrams getDataById(string Id)
	{
		Dtosysdiagrams data = null;
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			data = dsysdiagrams.getDataById(Id);
		}
		catch
		{
			return null;
		}
		return data;
	}
	public List<Dtosysdiagrams> getListDataByprincipal_id(int principal_id)
	{
		List<Dtosysdiagrams> lst = null;
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			lst = dsysdiagrams.getListDataByprincipal_id(principal_id);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<Dtosysdiagrams> getListDataBydiagram_id(int diagram_id)
	{
		List<Dtosysdiagrams> lst = null;
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			lst = dsysdiagrams.getListDataBydiagram_id(diagram_id);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<Dtosysdiagrams> getListDataByversion(int version)
	{
		List<Dtosysdiagrams> lst = null;
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			lst = dsysdiagrams.getListDataByversion(version);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<Dtosysdiagrams> getDataList()
	{
		List<Dtosysdiagrams> lst = null;
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			lst = dsysdiagrams.getDataList();
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public List<Dtosysdiagrams> getDataListSortBy(string col, bool flag)
	{
		List<Dtosysdiagrams> lst = null;
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			lst = dsysdiagrams.getDataListSortBy(col, flag);
		}
		catch
		{
			return null;
		}
		return lst;
	}
	public int insertData(Dtosysdiagrams data)
	{
		int Id = -1;
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			Id = dsysdiagrams.insertData(data);
		}
		catch
		{
			return -1;
		}
		return Id;
	}
	public bool deleteData(Dtosysdiagrams data)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.deleteData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByprincipal_id(int principal_id)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.deleteDataByprincipal_id(principal_id);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBydiagram_id(int diagram_id)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.deleteDataBydiagram_id(diagram_id);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataByversion(int version)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.deleteDataByversion(version);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool deleteDataBydefinition(System.Byte[] definition)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.deleteDataBydefinition(definition);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateData(Dtosysdiagrams data)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.updateData(data);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByname(Dtosysdiagrams data,string name)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.updateDataByname(data,name);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByprincipal_id(Dtosysdiagrams data,int principal_id)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.updateDataByprincipal_id(data,principal_id);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataBydiagram_id(Dtosysdiagrams data,int diagram_id)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.updateDataBydiagram_id(data,diagram_id);
		}
		catch
		{
			return false;
		}
		return true;
	}
	public bool updateDataByversion(Dtosysdiagrams data,int version)
	{
		try
		{
			Daosysdiagrams dsysdiagrams = new Daosysdiagrams();
			dsysdiagrams.updateDataByversion(data,version);
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
