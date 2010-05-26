
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DTO
{
public class DtoNhanVien
{

	public DtoNhanVien()
	{
	}
	private int mmaNV ;


	public int MANV 

	{
		get { return mmaNV ; }

		set { mmaNV = value ; }
	}

	private string mtenDangNhap ;


	public string TENDANGNHAP 

	{
		get { return mtenDangNhap ; }

		set { mtenDangNhap = value ; }
	}

	private string mmatKhau ;


	public string MATKHAU 

	{
		get { return mmatKhau ; }

		set { mmatKhau = value ; }
	}

	private int mSALT ;


	public int SALT 

	{
		get { return mSALT ; }

		set { mSALT = value ; }
	}

	private string mtenNV ;


	public string TENNV 

	{
		get { return mtenNV ; }

		set { mtenNV = value ; }
	}

	private string memail ;


	public string EMAIL 

	{
		get { return memail ; }

		set { memail = value ; }
	}

	private string mdienThoai ;


	public string DIENTHOAI 

	{
		get { return mdienThoai ; }

		set { mdienThoai = value ; }
	}

}

}
