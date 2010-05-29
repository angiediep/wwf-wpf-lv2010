
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
	private int mmaCV ;


	public int MACV 

	{
		get { return mmaCV ; }

		set { mmaCV = value ; }
	}

	private int mmaNV ;


	public int MANV 

	{
		get { return mmaNV ; }

		set { mmaNV = value ; }
	}

	private DateTime mngayApDung ;


	public DateTime NGAYAPDUNG 

	{
		get { return mngayApDung ; }

		set { mngayApDung = value ; }
	}

	private DateTime mngayHetHan ;


	public DateTime NGAYHETHAN 

	{
		get { return mngayHetHan ; }

		set { mngayHetHan = value ; }
	}

}

}
