
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoGhiChu
{

	public DtoGhiChu()
	{
	}
	private int mmaGC ;


	public int MAGC 

	{
		get { return mmaGC ; }

		set { mmaGC = value ; }
	}

	private string mGhiChu ;


	public string GHICHU 

	{
		get { return mGhiChu ; }

		set { mGhiChu = value ; }
	}

	private int mmaTD ;


	public int MATD 

	{
		get { return mmaTD ; }

		set { mmaTD = value ; }
	}

}

}
