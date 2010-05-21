
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoPhanCong
{

	public DtoPhanCong()
	{
	}
	private int mmaTN ;


	public int MATN 

	{
		get { return mmaTN ; }

		set { mmaTN = value ; }
	}

	private int mmaNV ;


	public int MANV 

	{
		get { return mmaNV ; }

		set { mmaNV = value ; }
	}

}

}
