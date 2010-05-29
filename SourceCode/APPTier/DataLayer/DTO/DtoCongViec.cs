
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DTO
{
public class DtoCongViec
{

	public DtoCongViec()
	{
	}
	private int mmaCV ;


	public int MACV 

	{
		get { return mmaCV ; }

		set { mmaCV = value ; }
	}

	private string mtenCV ;


	public string TENCV 

	{
		get { return mtenCV ; }

		set { mtenCV = value ; }
	}

	private int mngayBatDau ;


	public int NGAYBATDAU 

	{
		get { return mngayBatDau ; }

		set { mngayBatDau = value ; }
	}

	private int mngayKetThuc ;


	public int NGAYKETTHUC 

	{
		get { return mngayKetThuc ; }

		set { mngayKetThuc = value ; }
	}

	private string mmoTa ;


	public string MOTA 

	{
		get { return mmoTa ; }

		set { mmoTa = value ; }
	}

}

}
