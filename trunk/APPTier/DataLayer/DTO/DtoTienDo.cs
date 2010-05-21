
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DataLayer.DTO
{
public class DtoTienDo
{

	public DtoTienDo()
	{
	}
	private int mmaTD ;


	public int MATD 

	{
		get { return mmaTD ; }

		set { mmaTD = value ; }
	}

	private int mmaDT ;


	public int MADT 

	{
		get { return mmaDT ; }

		set { mmaDT = value ; }
	}

	private DateTime mngayPC ;


	public DateTime NGAYPC 

	{
		get { return mngayPC ; }

		set { mngayPC = value ; }
	}

	private int mkhoiLuongCVHT ;


	public int KHOILUONGCVHT 

	{
		get { return mkhoiLuongCVHT ; }

		set { mkhoiLuongCVHT = value ; }
	}

	private int mtongKhoiLuongCV ;


	public int TONGKHOILUONGCV 

	{
		get { return mtongKhoiLuongCV ; }

		set { mtongKhoiLuongCV = value ; }
	}

	private DateTime mngayBatDauThucTe ;


	public DateTime NGAYBATDAUTHUCTE 

	{
		get { return mngayBatDauThucTe ; }

		set { mngayBatDauThucTe = value ; }
	}

	private DateTime mngayKetThucThucTe ;


	public DateTime NGAYKETTHUCTHUCTE 

	{
		get { return mngayKetThucThucTe ; }

		set { mngayKetThucThucTe = value ; }
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
