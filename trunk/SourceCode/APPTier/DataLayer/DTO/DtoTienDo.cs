
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DTO
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

	private int mtongKhoiLuongCV ;


	public int TONGKHOILUONGCV 

	{
		get { return mtongKhoiLuongCV ; }

		set { mtongKhoiLuongCV = value ; }
	}

	private int mkhoiLuongCVHT ;


	public int KHOILUONGCVHT 

	{
		get { return mkhoiLuongCVHT ; }

		set { mkhoiLuongCVHT = value ; }
	}

	private DateTime mngayBatDauQuyDinh ;


	public DateTime NGAYBATDAUQUYDINH 

	{
		get { return mngayBatDauQuyDinh ; }

		set { mngayBatDauQuyDinh = value ; }
	}

	private DateTime mngayKetThucQuyDinh ;


	public DateTime NGAYKETTHUCQUYDINH 

	{
		get { return mngayKetThucQuyDinh ; }

		set { mngayKetThucQuyDinh = value ; }
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

	private int mmaDT ;


	public int MADT 

	{
		get { return mmaDT ; }

		set { mmaDT = value ; }
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

}

}
