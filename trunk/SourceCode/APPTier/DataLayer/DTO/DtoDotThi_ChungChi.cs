
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoDotThi_ChungChi
{

	public DtoDotThi_ChungChi()
	{
	}
	private int mmaDT ;


	public int MADT 

	{
		get { return mmaDT ; }

		set { mmaDT = value ; }
	}

	private int mmaCC ;


	public int MACC 

	{
		get { return mmaCC ; }

		set { mmaCC = value ; }
	}

	private int msoLuongThiSinh ;


	public int SOLUONGTHISINH 

	{
		get { return msoLuongThiSinh ; }

		set { msoLuongThiSinh = value ; }
	}

}

}
