
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoDOTTHI
{

	public DtoDOTTHI()
	{
	}
	private int mmaDT ;


	public int MADT 

	{
		get { return mmaDT ; }

		set { mmaDT = value ; }
	}

	private int mmaLoaiCC ;


	public int MALOAICC 

	{
		get { return mmaLoaiCC ; }

		set { mmaLoaiCC = value ; }
	}

	private DateTime mngayThi ;


	public DateTime NGAYTHI 

	{
		get { return mngayThi ; }

		set { mngayThi = value ; }
	}

	private int msoLuongThiSinh ;


	public int SOLUONGTHISINH 

	{
		get { return msoLuongThiSinh ; }

		set { msoLuongThiSinh = value ; }
	}

}

}
